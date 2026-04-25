using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommandValidator :AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(x => x.OldStoreId).GreaterThan(0).WithMessage("Polje StoreId je obavezno");
            RuleFor(x => x.OldBookId).GreaterThan(0).WithMessage("Polje BookId je obavezno");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("Polje StoreId je obavezno");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("Polje BookId je obavezno");
            RuleFor(x => x.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("Polje QuantityInStock je obavezno");
            RuleFor(x => x.ReorderTreshold).GreaterThan(0).WithMessage("Polje ReorderTreshold je obavezno");
        }
    }
}
