using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            // MaximumLength on every string field stops the frontend from posting megabyte-sized
            // values. Each limit lines up with the DB column or the Address.Constraints values.
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100).WithMessage("First name can be up to 100 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name can be up to 100 characters long.");

            // EmailAddress() so register behaves the same as 2FA/reset/forgot-password validators.
            // MaximumLength(200) matches the Email column in the DB.
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MaximumLength(200).WithMessage("Email can be up to 200 characters long.");

            // MinimumLength is 6 to match the message and the ResetPassword rule.
            // MaximumLength(100) keeps the request body small.
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
                .MaximumLength(100).WithMessage("Password can be up to 100 characters long.");

            RuleFor(x => x.Line1)
                .NotEmpty().WithMessage("Line1 is required.")
                .MaximumLength(Address.Constraints.LineMaxLength)
                    .WithMessage($"Line1 can be up to {Address.Constraints.LineMaxLength} characters long.");

            // Line2 is optional, but if provided we cap it the same way as Line1.
            RuleFor(x => x.Line2)
                .MaximumLength(Address.Constraints.LineMaxLength)
                    .WithMessage($"Line2 can be up to {Address.Constraints.LineMaxLength} characters long.")
                .When(x => x.Line2 is not null);

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(Address.Constraints.CityMaxLength)
                    .WithMessage($"City can be up to {Address.Constraints.CityMaxLength} characters long.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(Address.Constraints.CountryMaxLength)
                    .WithMessage($"Country can be up to {Address.Constraints.CountryMaxLength} characters long.");

            // Fingerprint is optional, but if provided, cap its length so it can't be abused
            // as a free-form data channel.
            RuleFor(x => x.Fingerprint)
                .MaximumLength(256).WithMessage("Fingerprint can be up to 256 characters long.")
                .When(x => x.Fingerprint is not null);
        }
    }
}
