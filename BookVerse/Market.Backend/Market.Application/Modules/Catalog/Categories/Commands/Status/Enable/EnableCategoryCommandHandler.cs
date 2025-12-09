using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Status.Enable
{
    public class DisableCategoryCommandHandler (IAppDbContext ctx): IRequestHandler<EnableCategoryComamnd, Unit>
    {
        public async Task<Unit> Handle(EnableCategoryComamnd request, CancellationToken ct)
        {
            var category = await ctx.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (category == null)
                throw new MarketNotFoundException($"Ne postoji kategorija sa ID {request.Id}");

            if (!category.IsEnabled)
            {
                category.IsEnabled = true;
                await ctx.SaveChangesAsync(ct);
            }
            return Unit.Value;
        }
    }
}
