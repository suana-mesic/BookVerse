namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Delete;

public class DeleteCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<DeleteCartItemCommand, string>
{
    public async Task<string> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
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

        context.CartItems.Remove(cartItem);
        await context.SaveChangesAsync(cancellationToken);
        return "Item removed from cart successfully.";
    }
}
