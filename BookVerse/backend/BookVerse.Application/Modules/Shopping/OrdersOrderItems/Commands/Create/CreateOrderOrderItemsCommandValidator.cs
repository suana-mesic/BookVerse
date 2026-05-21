namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;

public sealed class CreateOrderOrderItemsCommandValidator : AbstractValidator<CreateOrderOrderItemsCommand>
{
    public CreateOrderOrderItemsCommandValidator()
    {
        // XOR rule for delivery mode: the order must use shipping OR pickup, never both and never neither.
        // The handler supports two delivery modes:
        //   - Shipping: user provides ShippingMethodId
        //   - Pickup:   user provides StoreId
        // The old rule required ShippingMethodId to always be set, which broke the pickup flow before the
        // handler even saw the request. The ^ operator (XOR) returns true only when exactly one of the two
        // values is present, so this single rule rejects both "neither" and "both" cases at the validator level.
        RuleFor(x => x)
            .Must(x => x.ShippingMethodId.HasValue ^ x.StoreId.HasValue)
            .WithMessage("Choose either shipping method or pickup store, not both.");

        // Independent value checks: if either id is provided, it must be a positive integer.
        RuleFor(x => x.ShippingMethodId)
            .GreaterThan(0).When(x => x.ShippingMethodId.HasValue);

        RuleFor(x => x.StoreId)
            .GreaterThan(0).When(x => x.StoreId.HasValue);

        // When user provides a new address, address fields are required.
        When(x => !x.UseExistingAddress, () =>
        {
            RuleFor(x => x.Line1)
                .NotEmpty().WithMessage("Address line 1 is required.")
                .MaximumLength(Address.Constraints.LineMaxLength);
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(Address.Constraints.CityMaxLength);
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(Address.Constraints.CountryMaxLength);
        });

        RuleFor(x => x.Line2).MaximumLength(Address.Constraints.LineMaxLength).When(x => x.Line2 is not null);

        RuleForEach(x => x.CouponIds).GreaterThan(0).WithMessage("Each coupon id must be greater than zero.");
    }
}
