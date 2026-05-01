namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook;

public sealed class StripeWebhookCommandValidator : AbstractValidator<StripeWebhookCommand>
{
    public StripeWebhookCommandValidator()
    {
        RuleFor(x => x.Payload).NotEmpty().WithMessage("Payload is required.");
        RuleFor(x => x.StripeSignature).NotEmpty().WithMessage("Stripe signature is required.");
    }
}
