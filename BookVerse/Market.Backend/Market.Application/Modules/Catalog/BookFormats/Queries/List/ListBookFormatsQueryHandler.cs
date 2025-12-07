using Market.Application.Modules.Catalog.Categories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.BookFormats.Queries.List
{
    public class ListBookFormatsQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListBookFormatsQuery, PageResult<ListBookFormatsQueryDto>>
    {
        public async Task<PageResult<ListBookFormatsQueryDto>> Handle(ListBookFormatsQuery request, CancellationToken ct)
        {
            var q = ctx.BookFormats.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                q = q.Where(x => x.Format.Contains(request.Search));
            }

            var projectedQuery = q.Select(
                x =>
                new ListBookFormatsQueryDto
                {
                    Id = x.Id,
                    Format = x.Format,
                    IsDeleted = x.IsDeleted
                });

            return await PageResult<ListBookFormatsQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
        }
    }
}
