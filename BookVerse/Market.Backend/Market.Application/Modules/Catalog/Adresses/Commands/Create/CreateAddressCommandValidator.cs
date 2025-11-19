using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Commands.Create
{
    public sealed class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Line1)
                .NotEmpty()
                .WithMessage("Adresa je obavezna")
                .MaximumLength(Address.Constraints.LineMaxLength)
                .WithMessage($"Adresa ne smije biti duza od ${Address.Constraints.LineMaxLength} karaktera");


            RuleFor(x => x.Line2)
                .MaximumLength(Address.Constraints.LineMaxLength)
                .WithMessage($"Adresa ne smije biti duza od ${Address.Constraints.LineMaxLength} karaktera");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Grad je obavezan")
                .MaximumLength(Address.Constraints.CityMaxLength)
                .WithMessage($"Grad ne smije biti duzi od ${Address.Constraints.CityMaxLength} karaktera");


            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("Drzava je obavezna")
                .MaximumLength(Address.Constraints.CountryMaxLength)
                .WithMessage($"Drzava ne smije biti duza od ${Address.Constraints.CountryMaxLength} karaktera");
        }
    }
}
