using Market.Domain.Entities.Catalog;
using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Create
{
    public class CreateInventoryCommandHandler(IAppDbContext context) : IRequestHandler<CreateInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(CreateInventoryCommand request, CancellationToken ct)
        {
            foreach (var item in request.InventoryInfo)
            {
                var existing = await context.StoreInventory
                    .IgnoreQueryFilters()
                    .Where(x => x.StoreId == item.StoreId && x.BookId == item.BookId)
                    .FirstOrDefaultAsync(ct);
                var book = await context.Books.Where(x => x.Id == item.BookId).FirstOrDefaultAsync(ct);
                var store = await context.Stores.Where(x => x.Id == item.StoreId).FirstOrDefaultAsync(ct);

                if (existing != null && existing.IsDeleted == false)
                    throw new MarketBusinessRuleException("123", $"Postoji inventar za  knjigu {book.Title} i prodavnicu {store.StoreName}");

                if (existing != null && existing.IsDeleted == true)
                {
                    existing.IsDeleted = false;
                    existing.QuantityInStock = item.QuantityInStock;
                    existing.ReorderTreshold = item.ReorderTreshold;
                    existing.Location = item.Location;
                    existing.LastRestocked = DateTime.Now;
                }
                if (existing == null)
                {
                   var storeInventory = new StoreInventory
                    {
                        StoreId = item.StoreId,
                        BookId = item.BookId,
                        QuantityInStock = item.QuantityInStock,
                        ReorderTreshold = item.ReorderTreshold,
                        Location = item.Location,
                        LastRestocked = DateTime.Now
                    };
                    context.StoreInventory.Add(storeInventory);
                }
            }
            await context.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
