using CouponConstraints = Market.Domain.Entities.Shopping.Coupons.Constraints;

namespace Market.Application.Modules.Shopping.Coupons.Commands
{
    public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(CouponConstraints.NameMaxLength).WithMessage($"Name can be at most {CouponConstraints.NameMaxLength} characters long.");

            RuleFor(x => x.PromotionCode)
                .NotEmpty().WithMessage("Promotion code is required.")
                .MaximumLength(CouponConstraints.PromotionCodeMaxLength).WithMessage($"Promotion code can be at most {CouponConstraints.PromotionCodeMaxLength} characters long.");

            RuleFor(x => x.Description)
                .MaximumLength(CouponConstraints.DescriptionMaxLength).WithMessage($"Description can be at most {CouponConstraints.DescriptionMaxLength} characters long.")
                .When(x => x.Description != null);
        }
    }
}
