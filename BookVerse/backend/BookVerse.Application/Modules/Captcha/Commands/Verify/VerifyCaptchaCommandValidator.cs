namespace BookVerse.Application.Modules.Captcha.Commands.Verify;

public sealed class VerifyCaptchaCommandValidator : AbstractValidator<VerifyCaptchaCommand>
{
    public VerifyCaptchaCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required.");

        RuleFor(x => x.Answer)
            .NotEmpty().WithMessage("Answer is required.");
    }
}
