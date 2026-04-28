using Market.Application.Common.Interfaces;

namespace Market.Application.Modules.Shopping.Cart.Queries.List;

public class ListCartQueryHandler(IAppDbContext context, IAppCurrentUser currentUser, ITranslationService translationService)
    : IRequestHandler<ListCartQuery, ListCartQueryDto>
{
    public async Task<ListCartQueryDto> Handle(ListCartQuery request, CancellationToken ct)
    {
        var userId = currentUser.UserId
            ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

        var cart = await context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId, ct);

        if (cart is null)
            return new ListCartQueryDto();

        var items = await context.CartItems
            .AsNoTracking()
            .Where(x => x.CartId == cart.Id)
            .Select(x => new
            {
                x.CartId,  
                x.BookId,
                x.Book.Title,
                x.Book.ImageUrl,
                x.Book.Price,
                x.Quantity,
                x.DateAdded,
                x.SavedForLater,
                x.Book.QuantityInStockForOnlineOrders,
            })
            .ToListAsync(ct);

        var bookIds = items.Select(x => x.BookId).ToList();

        var storeInventories = await context.StoreInventory
            .AsNoTracking()
            .Where(x => bookIds.Contains(x.BookId) && !x.IsDeleted)
            .Select(x => new { x.BookId, x.StoreId, x.QuantityInStock })
            .ToListAsync(ct);

        var inventoryByBook = storeInventories
            .GroupBy(x => x.BookId)
            .ToDictionary(
                g => g.Key,
                g => g.ToDictionary(x => x.StoreId, x => (decimal)x.QuantityInStock)
                );

        var activeItems = items
            .Where(x => !x.SavedForLater)
            .Select(x => new CartItemDto
            {
                CartId = x.CartId,
                BookId = x.BookId,
                BookTitle = x.Title,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Quantity = x.Quantity,
                Subtotal = x.Price * x.Quantity,
                DateAdded = x.DateAdded,
                QuantityInStockForOnlineOrders = x.QuantityInStockForOnlineOrders,
                QuantityInStockInStores = inventoryByBook.TryGetValue(x.BookId, out var dict) ? dict : null
            }).ToList();


        var savedItems = items
            .Where(x => x.SavedForLater)
            .Select(x => new CartItemDto
            {
                CartId = x.CartId,
                BookId = x.BookId,
                BookTitle = x.Title,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Quantity = x.Quantity,
                Subtotal = x.Price * x.Quantity,
                DateAdded = x.DateAdded,
                QuantityInStockForOnlineOrders = x.QuantityInStockForOnlineOrders,
                QuantityInStockInStores = inventoryByBook.TryGetValue(x.BookId, out var dict) ? dict : null
            }).ToList();

        var result = new ListCartQueryDto
        {
            ActiveItems = activeItems,
            SavedForLaterItems = savedItems,
            TotalPrice = activeItems.Sum(x => x.Subtotal)
        };

        if (!string.IsNullOrWhiteSpace(request.Language) && request.Language != "bs")
        {
            await Task.WhenAll(result.ActiveItems.Concat(result.SavedForLaterItems).Select(async i =>
            {
                i.BookTitle = await translationService.Translate(i.BookTitle ?? string.Empty, request.Language);
            }));
        }

        return result;
    }
}