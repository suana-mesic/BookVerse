using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Queries.List
{
    public sealed class ListAuthorsQueryHandler(IAppDbContext ctx)
         : IRequestHandler<ListAuthorsQuery, PageResult<ListAuthorsQueryDto>>
    {
        public async Task<PageResult<ListAuthorsQueryDto>> Handle(
            ListAuthorsQuery request, CancellationToken ct)
        {
            var q = ctx.Authors.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                q = q.Where(x => x.FirstName.Contains(request.Search));
            }

            var projectedQuery = q.OrderBy(x => x.FirstName)
                .Select(x => new ListAuthorsQueryDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Biography = x.Biography,
                    Country = x.Country
                });

            return await PageResult<ListAuthorsQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
        }
    }

}
