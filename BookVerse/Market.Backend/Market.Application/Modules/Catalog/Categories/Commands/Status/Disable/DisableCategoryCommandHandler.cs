using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Commands.Status.Disable
{
    public class DisableCategoryCommandHandler (IAppDbContext ctx): IRequestHandler<DisableCategoryComamnd, Unit>
    {
        public async Task<Unit> Handle(DisableCategoryComamnd request, CancellationToken ct)
        {
            var category = await ctx.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (category == null)
                throw new MarketNotFoundException($"Ne postoji kategorija sa ID {request.Id}");

            if (category.IsEnabled)
            {
                category.IsEnabled = false;
                await ctx.SaveChangesAsync(ct);
            }
            return Unit.Value;
        }
    }
}
