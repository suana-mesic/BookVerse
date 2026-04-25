using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser)
        : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
            var category = await context.Categories
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (category is null)
                throw new MarketNotFoundException("Kategorija nije pronađena.");

            category.IsDeleted = true;
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
