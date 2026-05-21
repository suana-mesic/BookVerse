namespace BookVerse.Application.Modules.Auth.Commands.Login;

/// <summary>
/// FluentValidation validator for <see cref="LoginCommand"/>.
/// </summary>
public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        // EmailAddress() so login behaves the same as register/2FA/reset-password validators
        // (those already enforce it). MaximumLength(200) matches the Email column in the DB,
        // so the validator never accepts a value that EF Core would reject later.
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email address is required.")
            .MaximumLength(200).WithMessage("Email can be up to 200 characters long.");

        // MinimumLength is 6 to match the user-facing message and the ResetPassword rule.
        // MaximumLength(100) stops the frontend from posting megabytes of "password" text.
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .MaximumLength(100).WithMessage("Password can be up to 100 characters long.");

        // Fingerprint is optional, but if provided, cap its length so it can't be abused
        // as a free-form data channel.
        RuleFor(x => x.Fingerprint)
            .MaximumLength(256).WithMessage("Fingerprint can be up to 256 characters long.")
            .When(x => x.Fingerprint is not null);
    }
}
