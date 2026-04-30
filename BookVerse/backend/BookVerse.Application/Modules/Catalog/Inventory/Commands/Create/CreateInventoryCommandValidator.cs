using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Create
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
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId is required.");
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId is required.");
            RuleFor(x => x.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("QuantityInStock is required.");
            RuleFor(x => x.ReorderTreshold).GreaterThan(0).WithMessage("ReorderTreshold is required.");
        }
    }
}
