using Market.Application.Modules.Catalog.Authors.Queries.List;
using Market.Application.Modules.Catalog.Categories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Queries.List
{
    public class ListStoresQueryHandler(IAppDbContext context) : IRequestHandler<ListStoresQuery, PageResult<ListStoresQueryDto>>
    {
        public async Task<PageResult<ListStoresQueryDto>> Handle(ListStoresQuery request, CancellationToken cancellationToken)
        {
            var q = context.Stores.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                q = q.Where(x => x.StoreName.Contains(request.Search));
            }

            var projectedQuery = q.OrderBy(x => x.StoreName)
                .Select(x => new ListStoresQueryDto
                {
                    Id = x.Id,
                    StoreName = x.StoreName,
                    AddressId = x.AddressId,
                    Address = x.Address,
                    Phone = x.Phone,
                    Email = x.Email,
                    OpeningHours = x.OpeningHours
                });

            return await PageResult<ListStoresQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, cancellationToken);

        }
    }
}
