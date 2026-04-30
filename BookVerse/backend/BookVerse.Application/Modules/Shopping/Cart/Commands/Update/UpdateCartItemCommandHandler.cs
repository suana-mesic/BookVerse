namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Update;

public class UpdateCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<UpdateCartItemCommand, string>
{
    public async Task<string> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new BookVerseNotFoundException("User is not logged in.");

        if (request.Quantity <= 0)
            throw new BookVerseConflictException("Quantity must be greater than 0.");

        var cartItem = await context.CartItems
            .Include(x => x.Cart)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId
                && x.BookId == request.BookId
                && x.Cart.UserId == userId, cancellationToken);

        if (cartItem is null)
            throw new BookVerseNotFoundException("Cart item does not exist.");

        cartItem.Quantity = request.Quantity;

        await context.SaveChangesAsync(cancellationToken);
        return "Quantity updated successfully.";
    }
}
