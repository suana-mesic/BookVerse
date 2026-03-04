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
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId ne smije biti jednak nuli");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId ne smije biti jednak nuli");
        }
    }
}
