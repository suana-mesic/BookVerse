using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Commands.Create
{
    public class CreateStoreCommandValidator: AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator() { 
            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Naziv prodavnice je obavezan")
                .MaximumLength(Store.Constraints.StoreNameMaxLength).WithMessage($"Naziv prodavnice ne smije biti duži od ${Store.Constraints.StoreNameMaxLength} karaktera");

            RuleFor(x => x.AddressId)
                .GreaterThan(0).WithMessage("AddressId mora biti veći od 0");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon je obavezan")
                .MaximumLength(Store.Constraints.PhoneMaxLength).WithMessage($"Telefon ne smije biti duži od ${Store.Constraints.PhoneMaxLength} karaktera");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email je obavezan")
                .MaximumLength(Store.Constraints.EmailMaxLength).WithMessage($"Naziv prodavnice ne smije biti duži od ${Store.Constraints.EmailMaxLength} karaktera");

            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Radno vrijeme je obavezno");
        }
    }
}
