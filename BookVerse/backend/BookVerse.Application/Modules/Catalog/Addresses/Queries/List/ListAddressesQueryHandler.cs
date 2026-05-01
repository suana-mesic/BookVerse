using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Queries.List;
public class ListAddressesQueryHandler(IAppDbContext context) 
    :IRequestHandler<ListAddressesQuery, PageResult<ListAddressesQueryDto>>
{
    public async Task<PageResult<ListAddressesQueryDto>> Handle(
        ListAddressesQuery request, CancellationToken ct)
    {
        var query = context.Addresses.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(x => x.Line1.Contains(request.Search) ||
                                     (x.Line2 != null && x.Line2.Contains(request.Search)) ||
                                     x.City.Contains(request.Search) ||
                                     x.Country.Contains(request.Search));
        }

        var projectedQuery = query.OrderBy(x => x.Country)
            .ThenBy(x => x.City)
            .Select(x => new ListAddressesQueryDto
            {
                Id = x.Id,
                Line1 = x.Line1,
                Line2 = x.Line2,
                City = x.City,
                Country = x.Country
            });

        return await PageResult<ListAddressesQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
