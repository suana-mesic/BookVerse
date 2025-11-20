using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Commands.Update
{
    public class UpdateStoreCommandValidator: AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreCommandValidator() { 
            RuleFor(x => x.StoreName)
                .MaximumLength(Store.Constraints.StoreNameMaxLength).WithMessage($"Naziv prodavnice ne smije biti duži od ${Store.Constraints.StoreNameMaxLength} karaktera");
            RuleFor(x => x.Phone)
                .MaximumLength(Store.Constraints.PhoneMaxLength).WithMessage($"Telefon ne smije biti duži od ${Store.Constraints.PhoneMaxLength} karaktera");
            RuleFor(x => x.Email)
                .MaximumLength(Store.Constraints.EmailMaxLength).WithMessage($"Naziv radnje ne smije biti duži od ${Store.Constraints.EmailMaxLength} karaktera");
        }
    }
}
