using BookVerse.Domain.Entities.Catalog;
using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Create
{
    public class CreateInventoryCommandHandler(IAppDbContext context, TimeProvider time) : IRequestHandler<CreateInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(CreateInventoryCommand request, CancellationToken ct)
        {
            var duplicateInBatch = request.InventoryInfo
                .GroupBy(x => new { x.StoreId, x.BookId })
                .FirstOrDefault(g => g.Count() > 1);

            if (duplicateInBatch != null)
            {
                var dupBook = await context.Books
                    .Where(x => x.Id == duplicateInBatch.Key.BookId)
                    .FirstOrDefaultAsync(ct);
                var dupStore = await context.Stores
                    .Where(x => x.Id == duplicateInBatch.Key.StoreId)
                    .FirstOrDefaultAsync(ct);
                // BusinessRuleCodes.INVENTORY_DUPLICATE lets the frontend show a localized message.
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.INVENTORY_DUPLICATE,
                    $"Inventory already exists for the book {dupBook.Title} and store {dupStore.StoreName}.");
            }

            foreach (var item in request.InventoryInfo)
            {
                var existing = await context.StoreInventory
                    .IgnoreQueryFilters()
                    .Where(x => x.StoreId == item.StoreId && x.BookId == item.BookId)
                    .FirstOrDefaultAsync(ct);
                var book = await context.Books.Where(x => x.Id == item.BookId).FirstOrDefaultAsync(ct);
                var store = await context.Stores.Where(x => x.Id == item.StoreId).FirstOrDefaultAsync(ct);

                if (existing != null && existing.IsDeleted == false)
                    throw new BookVerseBusinessRuleException(BusinessRuleCodes.INVENTORY_DUPLICATE, $"Inventory already exists for the book {book.Title} and store {store.StoreName}.");

                if (existing != null && existing.IsDeleted == true)
                {
                    existing.IsDeleted = false;
                    existing.QuantityInStock = item.QuantityInStock;
                    existing.ReorderTreshold = item.ReorderTreshold;
                    existing.Location = item.Location;
                    // TimeProvider so unit tests can pin the LastRestocked stamp.
                    existing.LastRestocked = time.GetUtcNow().UtcDateTime;
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
                        // TimeProvider so unit tests can pin the LastRestocked stamp.
                        LastRestocked = time.GetUtcNow().UtcDateTime
                    };
                    context.StoreInventory.Add(storeInventory);
                }
            }
            await context.SaveChangesAsync(ct);
            return Unit.Value;
        }
    }
}
