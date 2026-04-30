using BookVerse.Application.Modules.Catalog.Inventory.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.GetById
{
    public class GetInventoryByIdQueryValidator : AbstractValidator<GetInventoryByIdQuery>
    {
        public GetInventoryByIdQueryValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must not be zero.");
            RuleFor(x => x.StoreId).GreaterThan(0).WithMessage("StoreId must not be zero.");
        }
    }
}
