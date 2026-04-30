using BookVerse.Domain.Entities.Shopping;
using Stripe;
using Stripe.Climate;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(IAppDbContext context, IAppCurrentUser currentUser) : IRequestHandler<CancelOrderCommand>
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

            var cancellableStatuses = new[]
           {
                (int)OrderStatusType.Draft,
                (int)OrderStatusType.Paid,
                (int)OrderStatusType.Packed
            };

            if (!cancellableStatuses.Contains(order.OrderStatusId))
                throw new BookVerseBusinessRuleException("123", "The order cannot be canceled in its current status.");

            // If the order is paid (Paid or Packed), a Stripe refund and inventory restore are required
            bool isPaid = order.OrderStatusId == (int)OrderStatusType.Paid ||
                          order.OrderStatusId == (int)OrderStatusType.Packed;

            if (isPaid)
            {
                await ProcessStripeRefundAsync(order, ct);
                RestoreInventory(order);
            }
            order.OrderStatusId = (int)OrderStatusType.Cancelled;
            order.CancelledAt = DateTime.UtcNow;

            await context.SaveChangesAsync(ct);
        }
        // Creates a Stripe refund for the full payment amount
        private async Task ProcessStripeRefundAsync(Orders order, CancellationToken ct)
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
        }
        private void RestoreInventory(Orders order)
        {
            //if the order was to be shipped, restore QuantityInStockForOnlineOrders
            if (order.ShippingMethodId != null)
                foreach (var item in order.OrderItems)
                    item.Book.QuantityInStockForOnlineOrders += item.Quantity;

            //if the order was to be picked up in-store, restore the inventory for that store
            if (order.PickupStoreId != null)
            {
                var inventoryDictionary = context.StoreInventory
                    .Where(x => x.StoreId == order.PickupStoreId)
                    .ToDictionary(x => x.BookId);

                foreach (var item in order.OrderItems)
                {
                    if(inventoryDictionary.TryGetValue(item.BookId, out var inventoryForBook))
                        inventoryForBook.QuantityInStock += item.Quantity;
                }
            }
        }
    }
}
