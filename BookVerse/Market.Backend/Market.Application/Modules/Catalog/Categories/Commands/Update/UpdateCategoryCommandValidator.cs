using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Update
{
    public sealed class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator() {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(Category.Constraints.NameMaxLength).WithMessage($"Name can be at most {Category.Constraints.NameMaxLength} characters long.");
        }
    }
}
