using CouponsEntity = BookVerse.Domain.Entities.Shopping.Coupons;

namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

public sealed class ValidateCouponQueryValidator : AbstractValidator<ValidateCouponQuery>
{
    public ValidateCouponQueryValidator()
    {
        RuleFor(x => x.PromotionCode)
            .NotEmpty().WithMessage("Promotion code is required.")
            .MaximumLength(CouponsEntity.Constraints.PromotionCodeMaxLength)
                .WithMessage($"Promotion code can be at most {CouponsEntity.Constraints.PromotionCodeMaxLength} characters long.");
    }
}
