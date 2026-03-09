using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Statistics.Queries.CategoriesPopularity
{
    public class GetCategoriesPopularityQueryHandler(IAppDbContext context) : IRequestHandler<GetCategoriesPopularityQuery, List<GetCategoriesPopularityQueryDto>>
    {
        public async Task<List<GetCategoriesPopularityQueryDto>> Handle(GetCategoriesPopularityQuery request, CancellationToken ct)
        {
            var data = await context.OrderItems
                .Include(x => x.Book)
                .ThenInclude(x => x.Categories)
                .SelectMany(x => x.Book.Categories.Select(c => new
                {
                    CategoryName = c.Name,
                    Quantity = x.Quantity
                }))
                .GroupBy(x => x.CategoryName)
                .Select(x => new GetCategoriesPopularityQueryDto
                {
                    GenreName = x.Key,
                    TotalSold = x.Sum(x => x.Quantity)
                })
                .OrderByDescending(x=>x.TotalSold)
                .ToListAsync(ct);
            return data;
        }
    }
}
