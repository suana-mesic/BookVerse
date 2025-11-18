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
        public Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
            //if (appCurrentUser.UserId is null)
            //    throw new MarketBusinessRuleException("123", "Korisnik nije autentifikovan.");

            var category = context.Categories
                .FirstOrDefault(x => x.Id == request.Id);

            if (category is null)
                throw new MarketNotFoundException("Kategorija nije pronađena.");

            category.IsDeleted = true; // Soft delete
            context.SaveChangesAsync(cancellationToken);

            return Task.FromResult(Unit.Value);
        }
    }
}
