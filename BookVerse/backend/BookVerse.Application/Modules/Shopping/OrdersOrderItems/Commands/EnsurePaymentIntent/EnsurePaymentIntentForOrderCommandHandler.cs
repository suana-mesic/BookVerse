using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Stripe;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.EnsurePaymentIntent
{
    // Ensures the order has a Stripe PaymentIntent in a state that the frontend can use to render
    // the payment form. The flow:
    //   1. Load the order (only the owner can fetch it).
    //   2. Only PaymentPending orders are eligible (Draft means Stripe never got created,
    //      Paid/Cancelled/Expired/PaymentFailed are terminal).
    //   3. If the order already has a PaymentIntentId AND Stripe says that intent is still in a
    //      payable state, we reuse it - no extra API call to Stripe and no DB change.
    //   4. Otherwise we create a new PaymentIntent and persist its id on the order.
    //
    // Two safety nets exist on step 4:
    //   - We skip the Stripe GetAsync when PaymentIntentId is null or empty. Calling GetAsync("")
    //     would throw a Stripe 400 before we ever reached the fallback CreateAsync.
    //   - We pass an IdempotencyKey to CreateAsync. If the user refreshes the page, Stripe returns
    //     the SAME PaymentIntent that the previous identical request created, instead of making
    //     a duplicate one. The key changes only when the order itself changes (Id + Modified/Created
    //     timestamp), so a genuine state change still produces a fresh intent.
    public class EnsurePaymentIntentForOrderCommandHandler(
        IAppCurrentUser currentUser,
        IAppDbContext context,
        IStripeSettings stripeSettings,
        IPaymentOptions paymentOptions
        ) : IRequestHandler<EnsurePaymentIntentForOrderCommand, EnsurePaymentIntentForOrderCommandDto>
    {
        public async Task<EnsurePaymentIntentForOrderCommandDto> Handle(EnsurePaymentIntentForOrderCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new BookVerseNotFoundException("User is not logged in.");

            // userId in the predicate ensures a user can only fetch their own orders.
            var order = await context.Orders
                .FirstOrDefaultAsync(o =>
                    o.Id == request.OrderId &&
                    o.UserId == userId, ct)
                ?? throw new BookVerseNotFoundException("Order not found.");

            // PaymentPending is the only status from which a retry makes sense.
            // BusinessRuleCodes.ORDER_NOT_PAYABLE lets the frontend show a localized message.
            if (order.OrderStatusId != (int)OrderStatusType.PaymentPending)
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.ORDER_NOT_PAYABLE, "Order is not in a status that can be paid.");

            var paymentIntentService = new PaymentIntentService();
            PaymentIntent? paymentIntent = null;

            // Null/empty check: skip Stripe lookup if we don't have an existing id, otherwise
            // GetAsync("") throws a Stripe 400 and the user sees a confusing error.
            if (!string.IsNullOrEmpty(order.PaymentIntentId))
            {
                paymentIntent = await paymentIntentService.GetAsync(order.PaymentIntentId, cancellationToken: ct);
            }

            // Stripe states where the user can still complete payment with the existing PaymentIntent.
            var validStates = new[] { "requires_payment_method", "requires_confirmation", "requires_action" };

            if (paymentIntent == null || !validStates.Contains(paymentIntent.Status))
            {
                // IdempotencyKey makes Stripe return the SAME PaymentIntent for repeated identical requests
                // (e.g. the user hits F5 on the payment page) instead of creating duplicate intents.
                // We base the key on order.Id + ModifiedAtUtc (or CreatedAtUtc if never modified) so the key
                // only changes when the order itself changes, which is exactly when a fresh intent is wanted.
                var idempotencyKey = $"order-{order.Id}-{(order.ModifiedAtUtc ?? order.CreatedAtUtc).Ticks}";

                var requestOptions = new RequestOptions
                {
                    IdempotencyKey = idempotencyKey
                };

                paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
                {
                    // Same rounding as everywhere else (CreateOrder handler, webhook amount check).
                    Amount = (long)Math.Round(order.TotalPrice * 100, MidpointRounding.AwayFromZero),
                    // Currency comes from typed PaymentOptions instead of being hardcoded.
                    Currency = paymentOptions.Currency,
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions { Enabled = true },
                    Metadata = new Dictionary<string, string> { { "orderId", order.Id.ToString() } },
                    Expand = new List<string> { "latest_charge" }
                }, requestOptions, ct);

                order.PaymentIntentId = paymentIntent.Id;
                await context.SaveChangesAsync(ct);
            }

            return new EnsurePaymentIntentForOrderCommandDto
            {
                ClientSecret = paymentIntent.ClientSecret,
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
