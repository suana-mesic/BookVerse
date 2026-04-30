namespace BookVerse.Application.Modules.Auth.Commands.VerifyTwoFactor;

public sealed class VerifyTwoFactorCommandValidator : AbstractValidator<VerifyTwoFactorCommand>
{
    public VerifyTwoFactorCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(256).WithMessage("Email can be up to 256 characters long.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Two-factor code is required.")
            .Length(6).WithMessage("Two-factor code must be exactly 6 characters long.")
            .Matches("^[0-9]+$").WithMessage("Two-factor code must contain digits only.");
    }
}
