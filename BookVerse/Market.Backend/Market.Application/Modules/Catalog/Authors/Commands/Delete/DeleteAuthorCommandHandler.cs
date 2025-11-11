using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Commands.Delete;
public class DeleteAuthorCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser)
  : IRequestHandler<DeleteAuthorCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Authors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (author is null)
            throw new MarketNotFoundException("Autor nije pronađen.");

        author.IsDeleted = true; // Soft delete
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

//public class DeleteProductCategoryCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser)
//      : IRequestHandler<DeleteProductCategoryCommand, Unit>
//{
//    public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
//    {
//        if (appCurrentUser.UserId is null)
//            throw new MarketBusinessRuleException("123", "Korisnik nije autentifikovan.");

//        var category = await context.ProductCategories
//            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

//        if (category is null)
//            throw new MarketNotFoundException("Kategorija nije pronađena.");

//        category.IsDeleted = true; // Soft delete
//        await context.SaveChangesAsync(cancellationToken);

//        return Unit.Value;
//    }
//}