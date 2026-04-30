using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Commands.Create
{
    public class CreateStoreCommandValidator: AbstractValidator<CreateStoreCommand>
    {
        public CreateStoreCommandValidator() { 
            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Store name is required.")
                .MaximumLength(Store.Constraints.StoreNameMaxLength).WithMessage($"Store name must not exceed {Store.Constraints.StoreNameMaxLength} characters.");

            RuleFor(x => x.AddressId)
                .GreaterThan(0).WithMessage("AddressId must be greater than 0.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(Store.Constraints.PhoneMaxLength).WithMessage($"Phone number must not exceed {Store.Constraints.PhoneMaxLength} characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(Store.Constraints.EmailMaxLength).WithMessage($"Email must not exceed {Store.Constraints.EmailMaxLength} characters.");

            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Opening hours are required.");
        }
    }
}
