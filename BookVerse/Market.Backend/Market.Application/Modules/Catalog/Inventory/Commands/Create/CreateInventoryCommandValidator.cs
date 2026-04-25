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
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("Polje StoreId je obavezno");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("Polje BookId je obavezno");
            RuleFor(x => x.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("Polje QuantityInStock je obavezno");
            RuleFor(x => x.ReorderTreshold).GreaterThan(0).WithMessage("Polje ReorderTreshold je obavezno");
        }
    }
}
