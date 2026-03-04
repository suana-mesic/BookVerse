namespace Market.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommandHandler(IAppDbContext context) : IRequestHandler<UpdateInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateInventoryCommand request, CancellationToken ct)
        {
            var zapisZaUpdate = await context.StoreInventory
                .Where(x => x.StoreId == request.StoreId && x.BookId == request.BookId)
                .FirstOrDefaultAsync(ct);

            if (zapisZaUpdate == null)
                throw new MarketNotFoundException("Nije pronađen zapis za ažuriranje");

            zapisZaUpdate.QuantityInStock = request.QuantityInStock;
            zapisZaUpdate.ReorderTreshold = request.ReorderTreshold;
            zapisZaUpdate.Location = request.Location;

            await context.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
