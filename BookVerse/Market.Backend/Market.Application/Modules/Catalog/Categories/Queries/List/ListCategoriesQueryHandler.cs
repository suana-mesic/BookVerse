using Market.Application.Common.Interfaces;

namespace Market.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQueryHandler(IAppDbContext ctx, ITranslationService translationService)
        : IRequestHandler<ListCategoriesQuery, List<ListCategoriesQueryDto>>
    {
        public async Task<List<ListCategoriesQueryDto>> Handle(
            ListCategoriesQuery request, CancellationToken ct)
        {

            var q = ctx.Categories.AsNoTracking().Where(x => !x.IsDeleted);

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

            if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
            {
                await Task.WhenAll(categories.Select(async c =>
                {
                    c.Name = await translationService.Translate(c.Name, request.Language);
                }));
            }

            return categories;
        }
    }
}
