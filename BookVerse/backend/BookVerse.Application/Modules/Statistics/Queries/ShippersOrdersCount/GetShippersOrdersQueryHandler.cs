namespace BookVerse.Application.Modules.Statistics.Queries.ShippersOrdersCount
{
    public class GetShippersOrdersQueryHandler(IAppDbContext context) : IRequestHandler<GetShippersOrdersQuery, List<GetShippersOrdersQueryDto>>
    {
        public async Task<List<GetShippersOrdersQueryDto>> Handle(GetShippersOrdersQuery request, CancellationToken ct)
        {
            return await context.Orders
                .GroupBy(x => x.ShippingMethod.Name)
                .Select(x => new GetShippersOrdersQueryDto
                {
                    ShipperName = x.Key,
                    OrdersCount = x.Count()
                })
                .ToListAsync(ct);
        }
    }
}
