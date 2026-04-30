namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.GetFormConfig;

public sealed class GetFormConfigQueryValidator : AbstractValidator<GetFormConfigQuery>
{
    private static readonly string[] AllowedCouponTypes = { "percent", "amount" };

    public GetFormConfigQueryValidator()
    {
        RuleFor(x => x.CouponType)
            .NotEmpty().WithMessage("Coupon type is required.")
            .Must(x => AllowedCouponTypes.Contains(x))
                .WithMessage("Coupon type must be either 'percent' or 'amount'.");
    }
}
