using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Statistics.Queries.CategoriesPopularity
{
    public class GetCategoriesPopularityQueryHandler(IAppDbContext context, ITranslationService translationService) : IRequestHandler<GetCategoriesPopularityQuery, List<GetCategoriesPopularityQueryDto>>
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

            if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
            {
                await Task.WhenAll(data.Select(async d =>
                {
                    d.GenreName = await translationService.Translate(d.GenreName, request.Language);
                }));
            }

            return data;
        }
    }
}
