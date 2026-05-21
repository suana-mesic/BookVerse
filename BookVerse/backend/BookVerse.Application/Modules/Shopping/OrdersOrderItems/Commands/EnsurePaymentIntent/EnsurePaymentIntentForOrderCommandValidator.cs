namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.EnsurePaymentIntent;

public sealed class EnsurePaymentIntentForOrderCommandValidator : AbstractValidator<EnsurePaymentIntentForOrderCommand>
{
    public EnsurePaymentIntentForOrderCommandValidator()
    {
        RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than zero.");
    }
}
