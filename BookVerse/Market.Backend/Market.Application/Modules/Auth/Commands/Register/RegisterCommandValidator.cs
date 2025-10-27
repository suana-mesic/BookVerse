using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(5).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.Line1)
               .NotEmpty().WithMessage("Line1 is required.");

            RuleFor(x => x.City)
             .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.Country)
             .NotEmpty().WithMessage("Country is required.");

            // Fingerprint is optional, but if provided, you can limit its length
            RuleFor(x => x.Fingerprint)
                .MaximumLength(256).WithMessage("Fingerprint can be up to 256 characters long.")
                .When(x => x.Fingerprint is not null);
        }
    }
}
