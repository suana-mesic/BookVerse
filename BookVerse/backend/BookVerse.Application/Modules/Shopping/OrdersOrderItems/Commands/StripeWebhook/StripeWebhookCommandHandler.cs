using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Microsoft.Extensions.Logging;
using Stripe;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    // Orchestrator only. Each piece of work is delegated to a domain service:
    //   - PaymentService          : signature validation, charge fetch
    //   - InventoryService        : stock decrement
    //   - CheckoutPricingService  : Stripe amount conversion for the comparison
    //   - OrderStateMachine       : status transition Paid / PaymentFailed
    public class StripeWebhookCommandHandler(
        IAppDbContext context,
        IPaidOrderNotificationQueue paidOrderNotificationQueue,
        IPaymentService paymentService,
        IInventoryService inventoryService,
        ICheckoutPricingService pricingService,
        IOrderStateMachine stateMachine,
        TimeProvider time,
        ILogger<StripeWebhookCommandHandler> logger) : IRequestHandler<StripeWebhookCommand>
    {
        public async Task Handle(StripeWebhookCommand request, CancellationToken ct)
        {
            // Verify the Stripe signature and parse the event JSON.
            var stripeEvent = paymentService.ConstructWebhookEvent(request.Payload, request.StripeSignature);

            logger.LogInformation("Stripe webhook received: {EventType}", stripeEvent.Type);

            // Event-level idempotency guard: Stripe retries on any non-2xx response and may also redeliver
            // an event after network blips, so the same stripeEvent.Id can arrive multiple times. The
            // StripeEvents table is an append-only ledger of processed event IDs; if we've seen this one
            // before we return immediately. The actual insert lives inside the per-branch transaction so
            // it commits atomically with the work it gates.
            var alreadyProcessed = await context.StripeEvents
                .AnyAsync(e => e.StripeEventId == stripeEvent.Id, ct);

            if (alreadyProcessed)
            {
                logger.LogInformation("Stripe webhook: event {EventId} ({EventType}) already processed, skipping", stripeEvent.Id, stripeEvent.Type);
                return;
            }

            // Payment succeeded
            if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null) return;

                var order = await context.Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Book)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);

                // Fallback path: if our PaymentIntentId column is out of sync, recover the order
                // from the metadata we attached at PaymentIntent creation time.
                if (order == null && paymentIntent.Metadata != null && paymentIntent.Metadata.TryGetValue("orderId", out var orderIdStr) && int.TryParse(orderIdStr, out var orderIdFromMetadata))
                {
                    logger.LogWarning("Order not found by PaymentIntentId {PaymentIntentId}, falling back to metadata orderId {OrderId}", paymentIntent.Id, orderIdFromMetadata);
                    order = await context.Orders
                        .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Book)
                        .Include(x => x.User)
                        .FirstOrDefaultAsync(o => o.Id == orderIdFromMetadata, ct);

                    if (order != null)
                        order.PaymentIntentId = paymentIntent.Id;
                }

                if (order == null)
                {
                    logger.LogError("Stripe webhook: order not found for PaymentIntent {PaymentIntentId}", paymentIntent.Id);
                    return;
                }

                logger.LogInformation("Stripe webhook: order {OrderId} found, current status {StatusId}", order.Id, order.OrderStatusId);

                // State-machine gate: only PaymentPending orders may transition to Paid. This covers
                // repeated webhooks (Paid/Packed/Shipped), cancelled orders, failed payments and expired drafts.
                if (!stateMachine.CanTransition(order, OrderStatusType.Paid))
                {
                    logger.LogWarning("Stripe webhook: order {OrderId} is in status {StatusId}, skipping payment processing", order.Id, order.OrderStatusId);
                    return;
                }

                // Amount comparison uses the same rounding the PaymentIntent was created with.
                // Without the shared helper a fractional filler (e.g. 7.999 BAM) would round to 799
                // here but 800 on Stripe's side and the order would fail to verify.
                var expectedAmount = pricingService.ToStripeAmount(order.TotalPrice);
                if (paymentIntent.AmountReceived != expectedAmount)
                {
                    logger.LogError("Stripe webhook: amount mismatch for order {OrderId}. Expected {Expected}, received {Received}", order.Id, expectedAmount, paymentIntent.AmountReceived);
                    throw new BookVerseConflictException("Payment amount does not match the order total.");
                }

                // All preconditions validated. Wrap every mutation in an explicit transaction so a failure
                // anywhere below rolls back everything, including the Paid status.
                await using var transaction = await context.BeginTransactionAsync(ct);

                // Decrement stock through the InventoryService. The service logs and clamps at zero so
                // a race can never push stock negative.
                if (order.ShippingMethodId != null)
                    inventoryService.DecrementOrderForShipping(order);

                if (order.PickupStoreId != null)
                    await inventoryService.DecrementOrderForPickupAsync(order, ct);

                // Remove ordered items from the cart.
                var cart = await context.Carts
                    .Include(x => x.CartItems)
                    .FirstOrDefaultAsync(x => x.UserId == order.UserId, ct);

                if (cart != null)
                {
                    var itemsToDelete = cart.CartItems.Where(x => !x.SavedForLater).ToList();
                    foreach (var item in itemsToDelete)
                        context.CartItems.Remove(item);

                    if (!cart.CartItems.Any(x => x.SavedForLater))
                        context.Carts.Remove(cart);
                }

                // Build and attach the PaymentSummaries snapshot (last4, brand, expiry).
                // Stripe does not include the Charge automatically in webhook events.
                var paymentSummary = await paymentService.BuildPaymentSummaryAsync(paymentIntent.LatestChargeId, ct);
                if (paymentSummary != null)
                {
                    context.PaymentSummaries.Add(paymentSummary);
                    order.PaymentSummary = paymentSummary;
                }

                // Status transition is the very last mutation: any failure above triggers a rollback
                // and the order stays in PaymentPending for a retry.
                stateMachine.Transition(order, OrderStatusType.Paid);

                // Record the processed event inside the same transaction so the ledger and the order
                // state commit together. If a redelivered event slips past the initial check (race),
                // the unique index on StripeEventId will reject the second insert and abort the transaction.
                context.StripeEvents.Add(new StripeEvent
                {
                    StripeEventId = stripeEvent.Id,
                    EventType = stripeEvent.Type,
                    ProcessedAtUtc = time.GetUtcNow().UtcDateTime
                });

                await context.SaveChangesAsync(ct);
                await transaction.CommitAsync(ct);

                // Notification is handed off to a background service so a SignalR outage cannot
                // affect the transaction we just committed.
                var customerName = $"{order.User.FirstName} {order.User.LastName}";
                paidOrderNotificationQueue.Enqueue(new PaidOrderNotification(order.Id, order.TrackingNumber, customerName));
            }

            // Payment failed (wrong card number, insufficient funds, etc.)
            else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null) return;

                var order = await context.Orders
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);
                if (order == null) return;

                // State-machine gate: only Draft / PaymentPending orders may move to PaymentFailed.
                // Already-paid, cancelled or expired orders must not be retroactively reset.
                if (!stateMachine.CanTransition(order, OrderStatusType.PaymentFailed))
                {
                    logger.LogWarning("Stripe webhook: payment failed for order {OrderId} in status {StatusId}, skipping", order.Id, order.OrderStatusId);
                    return;
                }

                stateMachine.Transition(order, OrderStatusType.PaymentFailed);

                // Record the processed event so a redelivered payment_intent.payment_failed
                // cannot toggle this order again.
                context.StripeEvents.Add(new StripeEvent
                {
                    StripeEventId = stripeEvent.Id,
                    EventType = stripeEvent.Type,
                    ProcessedAtUtc = time.GetUtcNow().UtcDateTime
                });

                await context.SaveChangesAsync(ct);
            }
        }
    }
}
