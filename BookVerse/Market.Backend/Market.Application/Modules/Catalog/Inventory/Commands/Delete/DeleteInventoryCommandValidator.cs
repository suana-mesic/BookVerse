using Market.Application.Modules.Catalog.Book.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Delete
{
    public class DeleteInventoryCommandValidator : AbstractValidator<DeleteInventoryCommand>
    {
        public DeleteInventoryCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId ne smije biti jednak nuli");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId ne smije biti jednak nuli");
        }
    }
}
