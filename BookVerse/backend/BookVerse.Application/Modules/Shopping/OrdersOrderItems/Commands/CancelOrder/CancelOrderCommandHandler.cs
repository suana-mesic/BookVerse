using BookVerse.Domain.Entities.Shopping;
using Stripe;
using Stripe.Climate;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(
        IAppDbContext context,
        IAppCurrentUser currentUser,
        TimeProvider time) : IRequestHandler<CancelOrderCommand>
    {
        public async Task Handle(CancelOrderCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId
               ?? throw new BookVerseConflictException("User is not logged in.");

            var order = await context.Orders
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.Book)
            .FirstOrDefaultAsync(o =>
                o.Id == request.OrderId &&
                o.UserId == userId, ct)
            ?? throw new BookVerseNotFoundException("Order not found.");

            //PaymentPending is included so a user can abandon a checkout cleanly without waiting for the
            //OrderCleanupBackgroundService sweep. PaymentFailed/Expired are terminal and not cancellable.
            var cancellableStatuses = new[]
           {
                (int)OrderStatusType.Draft,
                (int)OrderStatusType.PaymentPending,
                (int)OrderStatusType.Paid,
                (int)OrderStatusType.Packed
            };

            // BusinessRuleCodes.ORDER_NOT_CANCELLABLE is the frontend-facing identifier; the English
            // message stays as a fallback so logs and Swagger callers still see a human sentence.
            if (!cancellableStatuses.Contains(order.OrderStatusId))
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.ORDER_NOT_CANCELLABLE, "The order cannot be canceled in its current status.");

            // If the order is paid (Paid or Packed), a Stripe refund and inventory restore are required
            bool isPaid = order.OrderStatusId == (int)OrderStatusType.Paid ||
                          order.OrderStatusId == (int)OrderStatusType.Packed;

            if (isPaid)
            {
                // ProcessStripeRefundAsync now returns the Stripe refund object so we can store its
                // ID, status and amount in our own Refunds table below. Without that audit row we
                // would have no way to reconcile our DB with Stripe's refund records.
                var refund = await ProcessStripeRefundAsync(order, ct);
                await RestoreInventoryAsync(order, ct);
                RecordRefund(order, refund);
            }
            order.OrderStatusId = (int)OrderStatusType.Cancelled;
            // TimeProvider so unit tests can pin the cancellation timestamp deterministically.
            order.CancelledAt = time.GetUtcNow().UtcDateTime;

            // Single SaveChangesAsync wraps the status change AND the Refunds rows we just added
            // in one EF transaction, so either everything commits or nothing does.
            await context.SaveChangesAsync(ct);
        }
        // Creates a Stripe refund for the full payment amount and returns the resulting Refund object.
        private async Task<Refund> ProcessStripeRefundAsync(Orders order, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(order.PaymentIntentId))
                throw new BookVerseNotFoundException("PaymentIntentId was not found for this order.");

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(order.PaymentIntentId, cancellationToken: ct);

            if (string.IsNullOrEmpty(paymentIntent.LatestChargeId))
                throw new BookVerseNotFoundException("Charge was not found for this PaymentIntent.");

            var refundService = new RefundService();
            var refund = await refundService.CreateAsync(new RefundCreateOptions
            {
                Charge = paymentIntent.LatestChargeId
                // Amount is not set = refund fills it automatically
            }, cancellationToken: ct);

            if (refund.Status == "failed")
                throw new BookVerseConflictException($"Stripe refund failed: {refund.FailureReason}");

            return refund;
        }

        // Stores one Refunds row per OrderItem so the per-book breakdown of the refund is auditable.
        // All rows share the same StripeRefundId, so we can later look up the entire refund from one ID.
        // RefundAmount per row equals PriceAtTime * Quantity, so the sum across the order rows
        // matches the SubTotal of the items that were refunded.
        private void RecordRefund(Orders order, Refund refund)
        {
            // Single timestamp snapshot so every refund row in this batch shares the exact same value.
            var refundedAt = time.GetUtcNow().UtcDateTime;

            foreach (var item in order.OrderItems)
            {
                context.Refunds.Add(new Refunds
                {
                    OrderId = order.Id,
                    BookId = item.BookId,
                    RefundAmount = item.PriceAtTime * item.Quantity,
                    RefundDate = refundedAt,
                    Reason = "Customer cancellation",
                    // refund.Status comes straight from Stripe ("succeeded", "pending", etc.) so our
                    // record always matches what Stripe thinks the refund's current state is.
                    Status = refund.Status ?? "unknown",
                    // refund.Id is the Stripe identifier (e.g. "re_3PxYz...") used for reconciliation.
                    StripeRefundId = refund.Id
                });
            }
        }
        private async Task RestoreInventoryAsync(Orders order, CancellationToken ct)
        {
            //if the order was to be shipped, restore QuantityInStockForOnlineOrders
            if (order.ShippingMethodId != null)
                foreach (var item in order.OrderItems)
                    item.Book.QuantityInStockForOnlineOrders += item.Quantity;

            //if the order was to be picked up in-store, restore the inventory for that store
            if (order.PickupStoreId != null)
            {
                // ToDictionaryAsync (not ToDictionary) on an IQueryable: the sync version
                // would block the thread on the DB call and throws an EF Core warning when
                // used with a scoped DbContext. The async version returns control to the
                // thread pool while SQL runs.
                var inventoryDictionary = await context.StoreInventory
                    .Where(x => x.StoreId == order.PickupStoreId)
                    .ToDictionaryAsync(x => x.BookId, ct);

                foreach (var item in order.OrderItems)
                {
                    if(inventoryDictionary.TryGetValue(item.BookId, out var inventoryForBook))
                        inventoryForBook.QuantityInStock += item.Quantity;
                }
            }
        }
    }
}
