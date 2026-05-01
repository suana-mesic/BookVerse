using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Statistics.Queries.RevenueByMonthAndCategory
{
    public class GetRevenueByMonthAndCategoryHandler(IAppDbContext context, ITranslationService translationService) : IRequestHandler<GetRevenueByMonthAndCategoryQuery, List<GetRevenueByMonthAndCategoryQueryDto>>
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

            if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
            {
                var uniqueCategories = data.Select(d => d.CategoryName).Distinct().ToList();
                var translations = new Dictionary<string, string>();
                await Task.WhenAll(uniqueCategories.Select(async name =>
                {
                    var translated = await translationService.Translate(name, request.Language);
                    lock (translations) translations[name] = translated;
                }));
                foreach (var item in data)
                    if (translations.TryGetValue(item.CategoryName, out var t)) item.CategoryName = t;
            }

            return data;
        }
    }
}
