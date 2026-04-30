using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommandValidator :AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(x => x.OldStoreId).GreaterThan(0).WithMessage("OldStoreId is required.");
            RuleFor(x => x.OldBookId).GreaterThan(0).WithMessage("OldBookId is required.");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId is required.");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId is required.");
            RuleFor(x => x.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("QuantityInStock is required.");
            RuleFor(x => x.ReorderTreshold).GreaterThan(0).WithMessage("ReorderTreshold is required.");
        }
    }
}
