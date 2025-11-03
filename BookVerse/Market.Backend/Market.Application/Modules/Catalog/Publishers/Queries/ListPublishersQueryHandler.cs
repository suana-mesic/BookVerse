namespace Market.Application.Modules.Catalog.Publishers.Queries;

public sealed class ListPublishersQueryHandler(IAppDbContext ctx)
        : IRequestHandler<ListPublishersQuery, PageResult<ListPublishersQueryDto>>
{
    public async Task<PageResult<ListPublishersQueryDto>> Handle(
        ListPublishersQuery request, CancellationToken ct)
    {
        var q = ctx.Publishers.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            q = q.Where(x => x.Name.Contains(request.Search));
        }

        var projectedQuery = q.OrderBy(x => x.Name)
            .Select(x => new ListPublishersQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                Country = x.Country
            });

        return await PageResult<ListPublishersQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, ct);
    }
}
