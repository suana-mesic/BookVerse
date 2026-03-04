using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Create
{
    public class CreateInventoryCommandValidator:AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryCommandValidator()
        {
            RuleForEach(x => x.InventoryInfo).SetValidator(new CustomValidator());
        }
    }
    public class CustomValidator : AbstractValidator<InventoryInfo>
    {
        public CustomValidator()
        {
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("ID prodavnice mora biti veći od 0");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("ID knjige mora biti veći od 0");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("ID knjige mora biti veći od 0");
        }
    }
}
