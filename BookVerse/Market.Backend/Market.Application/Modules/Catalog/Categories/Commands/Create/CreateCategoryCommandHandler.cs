using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler(IAppDbContext context)
        : IRequestHandler<CreateCategoryCommand, int>
    {
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var normalized = request.Name?.Trim();

            if (string.IsNullOrWhiteSpace(normalized))
                throw new ValidationException("Name is required.");

            // Check if a category with the same name already exists.
            bool exists = await context.Categories
                .AnyAsync(x => x.Name == normalized, cancellationToken);

            if (exists)
            {
                throw new MarketConflictException("Name already exists.");
            }

            var category = new Category
            {
                Name = request.Name!.Trim()
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }

    }
}