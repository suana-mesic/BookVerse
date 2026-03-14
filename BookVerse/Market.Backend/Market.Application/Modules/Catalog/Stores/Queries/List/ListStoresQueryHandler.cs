namespace Market.Application.Modules.Catalog.Stores.Queries.List
{
    public class ListStoresQueryHandler(IAppDbContext context) : IRequestHandler<ListStoresQuery, PageResult<ListStoresQueryDto>>
    {
        public async Task<PageResult<ListStoresQueryDto>> Handle(ListStoresQuery request, CancellationToken cancellationToken)
        {
            var q = context.Stores.Include(x=>x.Address).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                q = q.Where(x => x.StoreName.Contains(request.Search));
            }

            var projectedQuery = q.OrderBy(x => x.StoreName)
                .Select(x => new ListStoresQueryDto
                {
                    Id = x.Id,
                    StoreName = x.StoreName,
                    City = x.Address.City,
                    Line1 = x.Address.Line1,
                    Phone = x.Phone,
                    Email = x.Email,
                    OpeningHours = x.OpeningHours
                });

            return await PageResult<ListStoresQueryDto>.FromQueryableAsync(projectedQuery, request.Paging, cancellationToken);

        }
    }
}
