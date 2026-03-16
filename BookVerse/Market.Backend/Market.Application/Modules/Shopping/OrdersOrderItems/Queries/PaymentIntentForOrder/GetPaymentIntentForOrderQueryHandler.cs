using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder
{
    public class GetPaymentIntentForOrderQueryHandler(
        IAppCurrentUser currentUser,
        IAppDbContext context,
        IStripeSettings stripeSettings
        ) : IRequestHandler<GetPaymentIntentForOrderQuery, GetPaymentIntentForOrderQueryDto>
    {
        public async Task<GetPaymentIntentForOrderQueryDto> Handle(GetPaymentIntentForOrderQuery request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

            var order = await context.Orders
           .FirstOrDefaultAsync(o =>
               o.Id == request.OrderId &&
               o.UserId == userId, ct)  // ← userId osigurava da korisnik može dohvatiti samo svoje narudžbe
           ?? throw new MarketNotFoundException("Narudžba nije pronađena.");

            if (order.OrderStatusId != (int)OrderStatusType.Draft)
                throw new MarketBusinessRuleException("556","Narudžba nije u statusu koji se može platiti.");

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(order.PaymentIntentId, cancellationToken: ct);

            return new GetPaymentIntentForOrderQueryDto
            {
                ClientSecret = paymentIntent.ClientSecret,
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
