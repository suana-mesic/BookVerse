namespace Market.Application.Modules.Statistics.Queries.RevenueByMonthAndCategory
{
    public class GetRevenueByMonthAndCategoryHandler(IAppDbContext context) : IRequestHandler<GetRevenueByMonthAndCategoryQuery, List<GetRevenueByMonthAndCategoryQueryDto>>
    {
        public async Task<List<GetRevenueByMonthAndCategoryQueryDto>> Handle(GetRevenueByMonthAndCategoryQuery request, CancellationToken ct)
        {
            var data = await context.OrderItems
                .Include(x => x.Book)
                .ThenInclude(x => x.Categories)
                .Include(x => x.Order)
                .SelectMany(x => x.Book.Categories.Select(c => new
                {
                    Month = x.Order.OrderDate.Month,
                    CategoryName = c.Name,
                    Revenue = x.Quantity * x.PriceAtTime
                }))
                .GroupBy(x => new { x.Month, x.CategoryName })
                .Select(g => new GetRevenueByMonthAndCategoryQueryDto
                {
                    Month = g.Key.Month,
                    CategoryName = g.Key.CategoryName.ToString(),
                    Revenue = g.Sum(x => x.Revenue)
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
