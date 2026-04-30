using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder
{
    public class GetPaymentIntentForOrderQueryHandler(
        IAppCurrentUser currentUser,
        IAppDbContext context,
        IStripeSettings stripeSettings
        ) : IRequestHandler<GetPaymentIntentForOrderQuery, GetPaymentIntentForOrderQueryDto>
    {
        public async Task<GetPaymentIntentForOrderQueryDto> Handle(GetPaymentIntentForOrderQuery request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new BookVerseNotFoundException("User is not logged in.");

            var order = await context.Orders
           .FirstOrDefaultAsync(o =>
               o.Id == request.OrderId &&
               o.UserId == userId, ct)  // ← userId ensures the user can only fetch their own orders
           ?? throw new BookVerseNotFoundException("Order not found.");

            if (order.OrderStatusId != (int)OrderStatusType.Draft)
                throw new BookVerseBusinessRuleException("556","Order is not in a status that can be paid.");

            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(order.PaymentIntentId, cancellationToken: ct);

            var validStates = new[] { "requires_payment_method", "requires_confirmation", "requires_action" };
            if (!validStates.Contains(paymentIntent.Status))
            {
                paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
                {
                    Amount = (long)(order.TotalPrice * 100),
                    Currency = "bam",
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions { Enabled = true },
                    Metadata = new Dictionary<string, string> { { "orderId", order.Id.ToString() } },
                    Expand = new List<string> { "latest_charge" }
                }, cancellationToken: ct);

                order.PaymentIntentId = paymentIntent.Id;
                await context.SaveChangesAsync(ct);
            }

            return new GetPaymentIntentForOrderQueryDto
            {
                ClientSecret = paymentIntent.ClientSecret,
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
