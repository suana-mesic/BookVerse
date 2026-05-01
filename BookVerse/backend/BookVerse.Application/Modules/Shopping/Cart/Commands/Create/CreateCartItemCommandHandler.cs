using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Create;

public class CreateCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<CreateCartItemCommand, string>
{
    public async Task<string> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new BookVerseNotFoundException("User is not logged in.");

        var bookExists = await context.Books.AnyAsync(x => x.Id == request.BookId, cancellationToken);
        if (!bookExists)
            throw new BookVerseNotFoundException("Book does not exist.");

        var cart = await context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        if (cart == null)
        {
            cart = new Carts { UserId = userId};
            context.Carts.Add(cart);
            await context.SaveChangesAsync(cancellationToken);
        }

        // Include soft-deleted items to avoid duplicate key conflicts
        var existingItem = await context.CartItems
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(ci => ci.CartId == cart.Id
                                    && ci.BookId == request.BookId, cancellationToken);

        if (existingItem != null)
        {
            // If it was soft-deleted, reactivate it
            existingItem.SavedForLater = false;
            existingItem.Quantity = request.Quantity;
        }
        else
        {
            context.CartItems.Add(new CartItems
            {
                CartId = cart.Id,
                BookId = request.BookId,
                Quantity = request.Quantity,
                DateAdded = DateTime.UtcNow,
                SavedForLater = false
            });
        }

        await context.SaveChangesAsync(cancellationToken);
        return "Book added to cart successfully.";
    }
}
