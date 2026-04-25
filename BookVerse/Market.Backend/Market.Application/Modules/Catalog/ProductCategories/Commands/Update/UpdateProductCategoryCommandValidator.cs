using Market.Application.Modules.Catalog.ProductCategories.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Update
{
    public sealed class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(Category.Constraints.NameMaxLength).WithMessage($"Name can be at most {Category.Constraints.NameMaxLength} characters long.");
        }
    }
}
