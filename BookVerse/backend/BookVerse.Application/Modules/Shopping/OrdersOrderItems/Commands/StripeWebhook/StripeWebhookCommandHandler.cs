using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Microsoft.Extensions.Logging;
using Stripe;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    public class StripeWebhookCommandHandler
        (IAppDbContext context,
        IStripeSettings stripeSettings,
        IOrderNotificationService notificationService,
        ILogger<StripeWebhookCommandHandler> logger) : IRequestHandler<StripeWebhookCommand>
    {
        public async Task Handle(StripeWebhookCommand request, CancellationToken ct)
        {
            // Verify that the message is genuinely from Stripe
            var stripeEvent = EventUtility.ConstructEvent(request.Payload, request.StripeSignature, stripeSettings.WebhookSecret);

            logger.LogInformation("Stripe webhook received: {EventType}", stripeEvent.Type);

            // Payment succeeded
            if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
            {

                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null)
                    return;

                var order = await context.Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Book)
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);

                if (order == null && paymentIntent.Metadata != null && paymentIntent.Metadata.TryGetValue("orderId", out var orderIdStr) && int.TryParse(orderIdStr, out var orderIdFromMetadata))
                {
                    logger.LogWarning("Order not found by PaymentIntentId {PaymentIntentId}, falling back to metadata orderId {OrderId}", paymentIntent.Id, orderIdFromMetadata);
                    order = await context.Orders
                        .Include(x => x.OrderItems)
                        .ThenInclude(x => x.Book)
                        .Include(x => x.User)
                        .FirstOrDefaultAsync(o => o.Id == orderIdFromMetadata, ct);

                    if (order != null)
                    {
                        order.PaymentIntentId = paymentIntent.Id;
                    }
                }

                if (order == null)
                {
                    logger.LogError("Stripe webhook: order not found for PaymentIntent {PaymentIntentId}", paymentIntent.Id);
                    return;
                }

                logger.LogInformation("Stripe webhook: order {OrderId} found, current status {StatusId}", order.Id, order.OrderStatusId);
                //Stripe webhook may send the same event multiple times, so check first whether the order has already been paid
                if (order.OrderStatusId == (int)OrderStatusType.Paid)
                    return;

                order.OrderStatusId = (int)OrderStatusType.Paid;
                order.PaidAt = DateTime.UtcNow;


                //reduce stock quantity for each book
                //if ShipToAddressId != null, decrement QuantityInStockForOnlineOrders for each book
                // if PickupStoreId != null, decrement QuantityInStock in the StoreInventory table for the pickup store

                if (order.ShippingMethodId != null)
                    foreach (var item in order.OrderItems)
                        item.Book.QuantityInStockForOnlineOrders -= item.Quantity;

                if (order.PickupStoreId != null)
                {
                    var inventoryDictionary = context.StoreInventory
                        .Where(x => x.StoreId == order.PickupStoreId)
                        .ToDictionary(x => x.BookId);

                    foreach (var item in order.OrderItems)
                    {
                        if (inventoryDictionary.TryGetValue(item.BookId, out var inventoryForBook))
                            inventoryForBook.QuantityInStock -= item.Quantity;
                        else
                            throw new Exception($"Book {item.BookId} is not in StoreInventory for Store {order.PickupStoreId}");
                    }

                }

                //Remove ordered items from the cart

                var cart = await context.Carts
                    .Include(x => x.CartItems)
                    .FirstOrDefaultAsync(x => x.UserId == order.UserId, ct);

                if (cart != null)
                {
                    var itemsToDelete = cart.CartItems.Where(x => !x.SavedForLater).ToList();
                    foreach (var item in itemsToDelete)
                        context.CartItems.Remove(item);

                    // If there are no items left (including savedForLater), delete the cart as well
                    if (!cart.CartItems.Any(x => x.SavedForLater))
                        context.Carts.Remove(cart);
                }

                //Record the card details used for payment
                // Save the card details used for the payment
                // Fetch the Charge separately because Stripe does not include it automatically in the webhook event

                if (paymentIntent.LatestChargeId != null)
                {
                    var chargeService = new ChargeService();
                    var charge = await chargeService.GetAsync(paymentIntent.LatestChargeId, cancellationToken: ct);

                    if (charge?.PaymentMethodDetails?.Card is { } card)
                    {
                        var paymentSummary = new PaymentSummaries
                        {
                            Last4Digits = card.Last4,
                            Brand = card.Brand ?? "Unknown",
                            ExpMonth = (int)card.ExpMonth,
                            ExpYear = (int)card.ExpYear,
                        };
                        context.PaymentSummaries.Add(paymentSummary);
                        await context.SaveChangesAsync(ct);

                        order.PaymentSummaryId = paymentSummary.Id;
                    }
                }
                await context.SaveChangesAsync(ct);
                var customerName = $"{order.User.FirstName} {order.User.LastName}";
                await notificationService.NotifyNewPaidOrderAsync(order.Id, order.TrackingNumber, customerName, ct);
            }

            // Payment failed (wrong card number, insufficient funds, etc.)
            else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null) return;

                var order = await context.Orders
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);
                if (order == null) return;

                // Revert status back to Draft because payment did not go through
                order.OrderStatusId = (int)OrderStatusType.Draft;
                await context.SaveChangesAsync(ct);
            }
        }
    }
}
