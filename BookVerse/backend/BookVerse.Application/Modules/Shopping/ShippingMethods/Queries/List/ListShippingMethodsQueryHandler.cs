using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.ShippingMethods.Queries.List
{
    public class ListShippingMethodsQueryHandler(IAppDbContext context)
    : IRequestHandler<ListShippingMethodsQuery, List<ListShippingMethodsQueryDto>>
    {
        public async Task<List<ListShippingMethodsQueryDto>> Handle(ListShippingMethodsQuery request, CancellationToken cancellationToken)
        {
            return await context.ShippingMethods
                .AsNoTracking()
                .Where(x=>!x.IsDeleted)
                .Select(x=> new ListShippingMethodsQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToListAsync(cancellationToken);
        }
    }
}
