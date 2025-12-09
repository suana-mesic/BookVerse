using Market.Application.Modules.Catalog.Categories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Queries.GetById
{
    public class GetCategoryByIdQueryHandler(IAppDbContext ctx): IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryDto>
    {
        public async Task<GetCategoryByIdQueryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await ctx.Categories
                .Where(c => c.Id == request.Id)
                .Select(x => new GetCategoryByIdQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    isEnabled = x.IsEnabled
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                throw new MarketNotFoundException($"Product category with Id {request.Id} not found.");
            }

            return category;
        }
    }
}