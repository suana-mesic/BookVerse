namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;

public sealed class CreateOrderOrderItemsCommandValidator : AbstractValidator<CreateOrderOrderItemsCommand>
{
    public CreateOrderOrderItemsCommandValidator()
    {
        RuleFor(x => x.ShippingMethodId)
            .NotNull().WithMessage("Shipping method is required.")
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
