using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Application.Modules.Catalog.Categories.Queries.ListPaged
{
    public class ListCategoriesPagedQueryHandler(IAppDbContext ctx, ITranslationService translationService)
        : IRequestHandler<ListCategoriesPagedQuery, PageResult<ListCategoriesPagedQueryDto>>
    {
        public async Task<PageResult<ListCategoriesPagedQueryDto>> Handle(ListCategoriesPagedQuery request, CancellationToken ct)
        {
            var q = ctx.Categories.AsNoTracking().Where(x => !x.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.Search))
                q = q.Where(x => x.Name.Contains(request.Search));

            if (request.OnlyEnabled == true)
                q = q.Where(x => x.IsEnabled == true);

            var categories = q.OrderBy(x => x.Name)
                .Select(x => new ListCategoriesPagedQueryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    isEnabled = x.IsEnabled,
                });


            return await PageResult<ListCategoriesPagedQueryDto>.FromQueryableAsync(
                query: categories,
                paging: request.Paging,
                ct: ct,
                postProcess: async items =>
                {
                    if (string.IsNullOrWhiteSpace(request.Language) ||
                        request.Language == "bs")
                        return;

                    await Task.WhenAll(items.Select(async c =>
                    {
                        c.Name = await translationService.Translate(c.Name, request.Language);
                    }));
                });
        }
    }
}
