namespace Market.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListCategoriesQuery, List<ListCategoriesQueryDto>>
    {
        public async Task<List<ListCategoriesQueryDto>> Handle(
            ListCategoriesQuery request, CancellationToken ct)
        {

            var q = ctx.Categories.AsNoTracking();

            q = q.Where(x => x.IsEnabled == true);

            if (!string.IsNullOrWhiteSpace(request.Search))
                q = q.Where(x => x.Name.Contains(request.Search));

            var categories = await q.OrderBy(x => x.Name)
                .Select(x => new ListCategoriesQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    isEnabled = x.IsEnabled,
                }).ToListAsync(ct);

            return categories;
        }
    }
}
