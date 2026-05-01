using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Categories.Commands.Status.Enable
{
    public class EnableCategoryCommandHandler (IAppDbContext ctx): IRequestHandler<EnableCategoryCommand, Unit>
    {
        public async Task<Unit> Handle(EnableCategoryCommand request, CancellationToken ct)
        {
            var category = await ctx.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

            if (category == null)
                throw new BookVerseNotFoundException($"Category with ID {request.Id} does not exist.");

            if (!category.IsEnabled)
            {
                category.IsEnabled = true;
                await ctx.SaveChangesAsync(ct);
            }
            return Unit.Value;
        }
    }
}
