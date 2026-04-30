namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder;

public sealed class GetPaymentIntentForOrderQueryValidator : AbstractValidator<GetPaymentIntentForOrderQuery>
{
    public GetPaymentIntentForOrderQueryValidator()
    {
        RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than zero.");
    }
}
