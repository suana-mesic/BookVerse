using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Status.Disable
{
    public class DisableCategoryCommandHandler (IAppDbContext ctx): IRequestHandler<DisableCategoryCommand, Unit>
    {
        public async Task<Unit> Handle(DisableCategoryCommand request, CancellationToken ct)
        {
            var category = await ctx.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (category == null)
                throw new BookVerseNotFoundException($"Category with ID {request.Id} does not exist.");

            if (category.IsEnabled)
            {
                category.IsEnabled = false;
                await ctx.SaveChangesAsync(ct);
            }
            return Unit.Value;
        }
    }
}
