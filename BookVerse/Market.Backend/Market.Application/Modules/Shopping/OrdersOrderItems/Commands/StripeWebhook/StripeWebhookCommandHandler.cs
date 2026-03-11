using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;
using Stripe;
using System.Threading;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    public class StripeWebhookCommandHandler
        (IAppDbContext context,
        IStripeSettings stripeSettings) : IRequestHandler<StripeWebhookCommand>
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

                var order = await context.Orders.Include(x => x.PaymentSummary).FirstOrDefaultAsync(o => o.PaymentIntentId == paymentIntent.Id, ct);

                if (order == null) return;
                order.OrderStatusId = (int)OrderStatusType.Paid;
                order.PaidAt = DateTime.UtcNow;

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
                        order.PaymentSummary.Last4Digits = int.Parse(card.Last4 ?? "0");
                        order.PaymentSummary.Brand = card.Brand ?? "Unknown";
                        order.PaymentSummary.ExpMonth = (int)card.ExpMonth;
                        order.PaymentSummary.ExpYear = (int)card.ExpYear;
                    }
                }
                await context.SaveChangesAsync(ct);
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
