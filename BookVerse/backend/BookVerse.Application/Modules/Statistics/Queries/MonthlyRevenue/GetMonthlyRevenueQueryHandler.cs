namespace BookVerse.Application.Modules.Statistics.Queries.MonthlyRevenue
{
    public class GetMonthlyRevenueQueryHandler(IAppDbContext context) : IRequestHandler<GetMonthlyRevenueQuery, List<GetMonthlyRevenueQueryDto>>
    {
        public async Task<List<GetMonthlyRevenueQueryDto>> Handle(GetMonthlyRevenueQuery request, CancellationToken ct)
        {
            var data = await context.Orders
                .GroupBy(x => x.OrderDate.Month)
                .Select(x => new GetMonthlyRevenueQueryDto
                {
                    Month = x.Key,
                    TotalRevenue = x.Sum(x => x.TotalPrice)
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
