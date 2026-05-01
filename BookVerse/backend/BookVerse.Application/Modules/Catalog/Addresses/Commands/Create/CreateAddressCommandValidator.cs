using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Commands.Create
{
    public sealed class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Line1)
                .NotEmpty()
                .WithMessage("Address is required.")
                .MaximumLength(Address.Constraints.LineMaxLength)
                .WithMessage($"Address must not exceed {Address.Constraints.LineMaxLength} characters.");


            RuleFor(x => x.Line2)
                .MaximumLength(Address.Constraints.LineMaxLength)
                .WithMessage($"Address must not exceed {Address.Constraints.LineMaxLength} characters.");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.")
                .MaximumLength(Address.Constraints.CityMaxLength)
                .WithMessage($"City must not exceed {Address.Constraints.CityMaxLength} characters.");


            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Country is required.")
                .MaximumLength(Address.Constraints.CountryMaxLength)
                .WithMessage($"Country must not exceed {Address.Constraints.CountryMaxLength} characters.");
        }
    }
}
