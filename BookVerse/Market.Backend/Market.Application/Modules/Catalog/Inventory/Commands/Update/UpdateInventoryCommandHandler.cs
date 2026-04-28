namespace Market.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommandHandler(IAppDbContext context) : IRequestHandler<UpdateInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken ct)
        {
            var zapisZaUpdate = await context.StoreInventory
                .IgnoreQueryFilters()
                .Where(x => x.StoreId == request.OldStoreId && x.BookId == request.OldBookId)
                .FirstOrDefaultAsync(ct);

            if (zapisZaUpdate == null)
                throw new MarketNotFoundException("Nije pronađen zapis za ažuriranje");

            var keyChanged = request.StoreId != request.OldStoreId || request.BookId != request.OldBookId;

            if (keyChanged)
            {
                var vecPostoji = await context.StoreInventory
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(x => x.StoreId == request.StoreId && x.BookId == request.BookId, ct);

                if (vecPostoji != null && !vecPostoji.IsDeleted)
                    throw new MarketConflictException("Inventar za odabranu prodavnicu i knjigu već postoji");

                context.StoreInventory.Remove(zapisZaUpdate);

                if (vecPostoji != null && vecPostoji.IsDeleted)
                {
                    vecPostoji.IsDeleted = false;
                    vecPostoji.QuantityInStock = request.QuantityInStock;
                    vecPostoji.ReorderTreshold = request.ReorderTreshold;
                    vecPostoji.Location = request.Location;
                    vecPostoji.LastRestocked = DateTime.UtcNow;
                }
                else
                {
                    context.StoreInventory.Add(new StoreInventory
                    {
                        StoreId = request.StoreId,
                        BookId = request.BookId,
                        QuantityInStock = request.QuantityInStock,
                        ReorderTreshold = request.ReorderTreshold,
                        Location = request.Location,
                        LastRestocked = DateTime.UtcNow,
                        IsDeleted = false
                    });
                }
            }
            else
            {
                zapisZaUpdate.IsDeleted = false;
                zapisZaUpdate.QuantityInStock = request.QuantityInStock;
                zapisZaUpdate.ReorderTreshold = request.ReorderTreshold;
                zapisZaUpdate.Location = request.Location;
            }

            await context.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
