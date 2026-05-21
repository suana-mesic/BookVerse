using CouponConstraints = BookVerse.Domain.Entities.Shopping.Coupons.Constraints;

namespace BookVerse.Application.Modules.Shopping.Coupons.Commands
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

            RuleFor(x => x)
                .Must(x => x.StartDate < x.EndDate)
                .WithMessage("Start date must be before end date.");

            RuleFor(x => x.MinOrderAmount)
                .GreaterThan(0).WithMessage("Minimum order amount must be greater than zero.")
                .When(x => x.MinOrderAmount.HasValue);

            RuleFor(x => x.MaxUses)
                .GreaterThan(0).WithMessage("Maximum uses must be greater than zero.")
                .When(x => x.MaxUses.HasValue);
        }
    }
}
