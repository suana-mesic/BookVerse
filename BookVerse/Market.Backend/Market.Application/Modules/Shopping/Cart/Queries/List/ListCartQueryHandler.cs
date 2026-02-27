namespace Market.Application.Modules.Shopping.Cart.Queries.List;

public class ListCartQueryHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<ListCartQuery, ListCartQueryDto>
{
    public async Task<ListCartQueryDto> Handle(ListCartQuery request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

        var cart = await context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted, cancellationToken);

        if (cart is null)
            return new ListCartQueryDto();

        var items = await context.CartItems
            .AsNoTracking()
            .Where(x => x.CartId == cart.Id && !x.IsDeleted)
            .Select(x => new
            {
                x.CartId,  
                x.BookId,
                x.Book.Title,
                x.Book.ImageUrl,
                x.Book.Price,
                x.Quantity,
                x.DateAdded,
                x.SavedForLater
            })
            .ToListAsync(cancellationToken);

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
                DateAdded = x.DateAdded
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
                DateAdded = x.DateAdded
            }).ToList();

        return new ListCartQueryDto
        {
            ActiveItems = activeItems,
            SavedForLaterItems = savedItems,
            TotalPrice = activeItems.Sum(x => x.Subtotal)
        };
    }
}