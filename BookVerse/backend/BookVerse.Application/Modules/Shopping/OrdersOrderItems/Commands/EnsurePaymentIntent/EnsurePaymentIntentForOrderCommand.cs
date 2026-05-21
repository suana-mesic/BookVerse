namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.EnsurePaymentIntent
{
    // This used to be a Query (GetPaymentIntentForOrderQuery) but it mutates the DB
    // (saves a new PaymentIntentId when Stripe's existing one is no longer valid),
    // so it belongs in the Commands folder per CQRS.
    public class EnsurePaymentIntentForOrderCommand : IRequest<EnsurePaymentIntentForOrderCommandDto>
    {
        public int OrderId { get; set; }
    }
}
