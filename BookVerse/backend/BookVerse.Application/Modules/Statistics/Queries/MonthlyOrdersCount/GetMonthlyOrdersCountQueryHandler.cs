using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookVerse.Application.Modules.Statistics.Queries.MonthlyOrdersCount
{
    internal class GetMonthlyOrdersCountQueryHandler(IAppDbContext context) : IRequestHandler<GetMonthlyOrdersCountQuery, List<GetMonthlyOrdersCountQueryDto>>
    {
        public async Task<List<GetMonthlyOrdersCountQueryDto>> Handle(GetMonthlyOrdersCountQuery request, CancellationToken ct)
        {
            var data = await context.Orders
                .GroupBy(x => x.OrderDate.Month)
                .Select(x => new GetMonthlyOrdersCountQueryDto
                {
                    Month = x.Key,
                    OrdersCount = x.Count()
                })
                .OrderBy(x => x.Month)
                .ToListAsync(ct);

            string[] monthNames = { "", "Januar", "Februar", "Mart", "April", "Maj",
                                 "Juni", "Juli", "August", "Septembar", "Oktobar",
                                 "Novembar", "Decembar" };

            foreach (var item in data)
                item.MonthName = monthNames[item.Month];

            return data;
        }
    }
}
