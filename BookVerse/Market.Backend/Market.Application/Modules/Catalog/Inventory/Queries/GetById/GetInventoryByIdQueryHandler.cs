namespace Market.Application.Modules.Catalog.Inventory.Queries.GetById
{
    public class GetInventoryByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetInventoryByIdQuery, GetInventoryByIdQueryDto>
    {
        public async Task<GetInventoryByIdQueryDto> Handle(GetInventoryByIdQuery request, CancellationToken ct)
        {
            var trazeniZapis = await context.StoreInventory
                .Include(x=>x.Store)
                .Include(x => x.Book)
                .Where(x => x.StoreId == request.StoreId && x.BookId == request.BookId)
                .FirstOrDefaultAsync(ct);

            if (trazeniZapis == null)
                throw new MarketNotFoundException("Ne postoji popis inventara za unesenu prodavnicu i knjigu");

            return new GetInventoryByIdQueryDto
            {
                StoreId = trazeniZapis.StoreId,
                StoreName = trazeniZapis.Store.StoreName,
                BookId = trazeniZapis.BookId,
                ISBN = trazeniZapis.Book.ISBN,
                Title = trazeniZapis.Book.Title,
                QuantityInStock = trazeniZapis.QuantityInStock,
                LastRestocked = trazeniZapis.LastRestocked,
                ReorderTreshold = trazeniZapis.ReorderTreshold,
                Location = trazeniZapis.Location
            };
        }
    }
}
