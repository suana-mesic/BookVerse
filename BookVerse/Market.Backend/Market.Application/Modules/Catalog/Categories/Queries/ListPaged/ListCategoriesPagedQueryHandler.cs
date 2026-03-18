namespace Market.Application.Modules.Catalog.Categories.Queries.ListPaged
{
    public class ListCategoriesPagedQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListCategoriesPagedQuery, PageResult<ListCategoriesPagedQueryDto>>
    {
        public async Task<PageResult<ListCategoriesPagedQueryDto>> Handle(ListCategoriesPagedQuery request, CancellationToken ct)
        {
            var q = ctx.Categories.AsNoTracking();

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


            return await PageResult<ListCategoriesPagedQueryDto>.FromQueryableAsync(categories, request.Paging, ct);
        }
    }
}
