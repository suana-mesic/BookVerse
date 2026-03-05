using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Queries.GetStoresAndBooksPairs
{
    public class GetStoresAndBooksPairsQueryHandler(IAppDbContext context)
        : IRequestHandler<GetStoresAndBooksPairsQuery, Dictionary<int, Dictionary<int, string>>>
    {
        public async Task<Dictionary<int, Dictionary<int, string>>> Handle(GetStoresAndBooksPairsQuery request, CancellationToken ct)
        {
            var stores = await context.Stores
                .Select(x=> x.Id)
                .ToListAsync(ct);

            var allBooks = await context.Books
                .Select(b => new { b.Id, b.Title })
                .ToListAsync(ct);

            //books that already have inventory
            var existingInventory = await context.StoreInventory
                .Select(x => new { x.StoreId, x.BookId })
                .ToListAsync(ct);

            var existingSet = existingInventory
                .Select(x=>(x.StoreId, x.BookId))
                .ToHashSet();

            var dictionary = new Dictionary<int, Dictionary<int, string>>();

            foreach(var storeId in stores)
            {
                // Books that don't have inventory in current store
                var booksWithoutInventory = allBooks
                     .Where(b => !existingSet.Contains((storeId, b.Id)))
                     .ToDictionary(b => b.Id, b => b.Title);
                dictionary.Add(storeId, booksWithoutInventory);
            }
            return dictionary;
        }
    }
}
