using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public sealed class ListInventoryQueryHandler(IAppDbContext ctx) : IRequestHandler<ListInventoryQuery, PageResult<ListInventoryQueryDto>>
    {
        public async Task<PageResult<ListInventoryQueryDto>> Handle(ListInventoryQuery request, CancellationToken ct)
        {
            var q = ctx.StoreInventory.Include(x => x.Store).Include(x => x.Book).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchFilter = request.Search.ToLower();
                q = q.Where(x =>
                    (x.Store.StoreName.ToString() != null && x.Store.StoreName.ToString().ToLower().Contains(searchFilter)) ||
                    (x.Book.ISBN.ToString() != null && x.Book.ISBN.ToLower().Contains(searchFilter)) ||
                    (x.Book.Title.ToString() != null && x.Book.Title.ToLower().Contains(searchFilter)) ||
                    (x.Location.ToString() != null && x.Location.ToLower().Contains(searchFilter))
                );
            }

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
