namespace BookVerse.Application.Modules.Shopping.Cart.Commands.SaveForLater;

public class SaveForLaterCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<SaveForLaterCommand, string>
{
    public async Task<string> Handle(SaveForLaterCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new BookVerseNotFoundException("User is not logged in.");

        var cartItem = await context.CartItems
            .Include(x => x.Cart)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId
                && x.BookId == request.BookId
                && x.Cart.UserId == userId, cancellationToken);

        if (cartItem is null)
            throw new BookVerseNotFoundException("Cart item does not exist.");

        cartItem.SavedForLater = request.SavedForLater;

        await context.SaveChangesAsync(cancellationToken);

        return request.SavedForLater
            ? "Item saved for later."
            : "Item returned to the cart.";
    }
}
