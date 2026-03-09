namespace Market.Application.Modules.Statistics.Queries.Top5Books
{
    public class GetTopFiveBooksQueryHandler(IAppDbContext context) : IRequestHandler<GetTopFiveBooksQuery, List<GetTopFiveBooksQueryDto>>
    {
        public async Task<List<GetTopFiveBooksQueryDto>> Handle(GetTopFiveBooksQuery request, CancellationToken ct)
        {
            var data = await context.OrderItems
                .GroupBy(x => x.Book.Title)
                .Select(x => new GetTopFiveBooksQueryDto
                {
                    BookTitle = x.Key,
                    TotalSold = x.Count()
                })
                .OrderByDescending(x => x.TotalSold)
                .Take(5)
                .ToListAsync(ct);

            return data;
        }
    }
}
