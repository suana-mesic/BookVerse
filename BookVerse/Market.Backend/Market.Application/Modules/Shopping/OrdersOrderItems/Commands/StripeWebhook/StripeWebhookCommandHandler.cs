using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;
using Stripe;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    public class StripeWebhookCommandHandler
        (IAppDbContext context,
        IStripeSettings stripeSettings,
        IOrderNotificationService notificationService) : IRequestHandler<StripeWebhookCommand>
    {
        public async Task Handle(StripeWebhookCommand request, CancellationToken ct)
        {
            // Provjera da je poruka zaista od Stripe-a
            var stripeEvent = EventUtility.ConstructEvent(request.Payload, request.StripeSignature, stripeSettings.WebhookSecret);

            // Plaćanje je uspješno prošlo
            if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
            {

                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null)
                    return;

                var order = await context.Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Book)
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);


                if (order == null) return;
                //Stripe webhook može poslati isti event više puta, zbog toga provjerimo prvo da li je narudžba već plaćena
                if (order.OrderStatusId == (int)OrderStatusType.Paid)
                    return;

                order.OrderStatusId = (int)OrderStatusType.Paid;
                order.PaidAt = DateTime.UtcNow;


                //smanji količinu na skladištu za svaku knjigu 
                //ako ShipToAddressId != null, onda briši QuantityInStockForOnlineOrders za svaku knjigu
                //ako PickupStoreId != null, onda izbriši QuantityInStock u StoreInventory tabelu za prodavnicu u kojoj će biti preuzeta knjiga

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
                            throw new Exception($"Book {item.BookId} nije u StoreInventory za Store {order.PickupStoreId}");
                    }

                }

                //Brisanje poručenih stavki iz korpe

                var cart = await context.Carts
                    .Include(x => x.CartItems)
                    .FirstOrDefaultAsync(x => x.UserId == order.UserId, ct);

                if (cart == null) return;

                var itemsToDelete = cart.CartItems.Where(x => !x.SavedForLater).ToList();
                foreach (var item in itemsToDelete)
                    context.CartItems.Remove(item);

                // Ako nema više stavki (ni savedForLater), briši i korpu
                if (!cart.CartItems.Any(x => x.SavedForLater))
                    context.Carts.Remove(cart);

                //Evidentiramo podatke o kartici kojom je plaćanje izvršeno
                // Sačuvaj podatke o kartici kojom je plaćeno
                // Dohvati Charge odvojeno jer Stripe ga ne šalje automatski u webhook eventu

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
                await notificationService.NotifyNewPaidOrderAsync(order.Id, order.TrackingNumber, ct);
            }

            // Plaćanje nije bilo uspješno (pogrešan broj kartice, nema sredstava...)
            else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (paymentIntent == null) return;

                var order = await context.Orders
                    .FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);
                if (order == null) return;

                // Vrati status nazad na Draft jer plaćanje nije prošlo
                order.OrderStatusId = (int)OrderStatusType.Draft;
                await context.SaveChangesAsync(ct);
            }
        }
    }
}
