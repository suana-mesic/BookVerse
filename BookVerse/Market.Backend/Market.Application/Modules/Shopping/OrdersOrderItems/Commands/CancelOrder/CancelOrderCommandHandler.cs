using Market.Domain.Entities.Shopping;
using Stripe;
using Stripe.Climate;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder
{
    public class CancelOrderCommandHandler(IAppDbContext context, IAppCurrentUser currentUser) : IRequestHandler<CancelOrderCommand>
    {
        public async Task Handle(CancelOrderCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId
               ?? throw new MarketConflictException("Korisnik nije prijavljen.");

            var order = await context.Orders
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.Book)
            .FirstOrDefaultAsync(o =>
                o.Id == request.OrderId &&
                o.UserId == userId, ct)
            ?? throw new MarketNotFoundException("Narudžba nije pronađena.");

            var cancellableStatuses = new[]
           {
                (int)OrderStatusType.Draft,
                (int)OrderStatusType.Paid,
                (int)OrderStatusType.Packed
            };

            if (!cancellableStatuses.Contains(order.OrderStatusId))
                throw new MarketBusinessRuleException("123", "Narudžba se ne može otkazati u trenutnom statusu.");

            // Ako je narudžba plaćena (Paid ili Packed), treba Stripe refund i vraćanje zaliha
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
        // Kreira Stripe refund za puni iznos plaćanja
        private async Task ProcessStripeRefundAsync(Orders order, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(order.PaymentIntentId))
                throw new MarketNotFoundException("PaymentIntentId nije pronađen za ovu narudžbu.");

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(order.PaymentIntentId, cancellationToken: ct);

            if (string.IsNullOrEmpty(paymentIntent.LatestChargeId))
                throw new MarketNotFoundException("Charge nije pronađen za ovaj PaymentIntent.");

            var refundService = new RefundService();
            var refund = await refundService.CreateAsync(new RefundCreateOptions
            {
                Charge = paymentIntent.LatestChargeId
                // Amount se ne postavlja = automatski ga popuni refund
            }, cancellationToken: ct);

            if (refund.Status == "failed")
                throw new MarketConflictException($"Stripe refund nije uspio: {refund.FailureReason}");
        }
        private void RestoreInventory(Orders order)
        {
            //ako je narudžba trebala biti dostavljena onda se QuantityInStockForOnlineOrders restore-a
            if (order.ShippingMethodId != null)
                foreach (var item in order.OrderItems)
                    item.Book.QuantityInStockForOnlineOrders += item.Quantity;

            //a ako je narudžba trebala biti preuzeta u radnji, onda se restore-a inventar za onu 
            //prodavnicu gdje je trebala biti ipreuzeta
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
