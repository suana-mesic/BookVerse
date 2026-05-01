using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.List
{
    public sealed class ListInventoryQueryHandler(IAppDbContext ctx) : IRequestHandler<ListInventoryQuery, PageResult<ListInventoryQueryDto>>
    {
        public async Task<PageResult<ListInventoryQueryDto>> Handle(ListInventoryQuery request, CancellationToken ct)
        {
            var q = ctx.StoreInventory.Include(x => x.Store).Include(x => x.Book).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchFilter = request.Search.ToLower();
                q = q.Where(x => x.Location.ToString() != null && x.Location.ToLower().Contains(searchFilter));
            }

            if (!string.IsNullOrWhiteSpace(request.Book))
                q = q
                    .Include(x=>x.Book)
                    .Where(x => x.Book.Title.Contains(request.Book.ToLower()));

            if (!string.IsNullOrWhiteSpace(request.Store))
                q = q
                    .Include(x => x.Store)
                    .Where(x => x.Store.StoreName.Contains(request.Store.ToLower()));

            var query = q.OrderBy(x => x.StoreId).Select(x => new ListInventoryQueryDto
            {
                StoreId = x.StoreId,
                StoreName = x.Store.StoreName,
                BookId = x.Book.Id,
                ISBN = x.Book.ISBN,
                Title = x.Book.Title,
                QuantityInStock = x.QuantityInStock,
                LastRestocked = x.LastRestocked,
                ReorderTreshold = x.ReorderTreshold,
                QuantityInStockForOnlineOrders = x.Book.QuantityInStockForOnlineOrders,
                Location = x.Location
            });

            return await PageResult<ListInventoryQueryDto>.FromQueryableAsync(query, request.Paging, ct);
        }
    }
}
