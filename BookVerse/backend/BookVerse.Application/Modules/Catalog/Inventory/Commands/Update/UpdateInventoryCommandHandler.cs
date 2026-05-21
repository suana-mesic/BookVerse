namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommandHandler(IAppDbContext context, TimeProvider time) : IRequestHandler<UpdateInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken ct)
        {
            // Single "now" snapshot so every row touched in this handler shares the exact same timestamp.
            var nowUtc = time.GetUtcNow().UtcDateTime;
            var zapisZaUpdate = await context.StoreInventory
                .IgnoreQueryFilters()
                .Where(x => x.StoreId == request.OldStoreId && x.BookId == request.OldBookId)
                .FirstOrDefaultAsync(ct);

            if (zapisZaUpdate == null)
                throw new BookVerseNotFoundException("No record was found for update.");

            var keyChanged = request.StoreId != request.OldStoreId || request.BookId != request.OldBookId;

            if (keyChanged)
            {
                var vecPostoji = await context.StoreInventory
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(x => x.StoreId == request.StoreId && x.BookId == request.BookId, ct);

                if (vecPostoji != null && !vecPostoji.IsDeleted)
                    throw new BookVerseConflictException("Inventory for the selected store and book already exists.");

                context.StoreInventory.Remove(zapisZaUpdate);

                if (vecPostoji != null && vecPostoji.IsDeleted)
                {
                    vecPostoji.IsDeleted = false;
                    vecPostoji.QuantityInStock = request.QuantityInStock;
                    vecPostoji.ReorderTreshold = request.ReorderTreshold;
                    vecPostoji.Location = request.Location;
                    vecPostoji.LastRestocked = nowUtc;
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
                        LastRestocked = nowUtc,
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
