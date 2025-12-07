using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListCategoriesQuery, PageResult<ListCategoriesQueryDto>>
    {
        public async Task<PageResult<ListCategoriesQueryDto>> Handle(
            ListCategoriesQuery request, CancellationToken ct)
        {

            var q = ctx.Categories.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                q = q.Where(x => x.Name.Contains(request.Search));
            }

            var projectedQuery = q.OrderBy(x => x.Name)
                .Select(x => new ListCategoriesQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsDeleted=x.IsDeleted,
                });

            return await PageResult<ListCategoriesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
        }
    }
}
