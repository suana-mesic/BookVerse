namespace Market.Application.Modules.Shopping.Cart.Commands.Delete;

public class DeleteCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<DeleteCartItemCommand, string>
{
    public async Task<string> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

        var cartItem = await context.CartItems
            .Include(x => x.Cart)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId
                && x.BookId == request.BookId
                && x.Cart.UserId == userId, cancellationToken);

        if (cartItem is null)
            throw new MarketNotFoundException("Stavka korpe ne postoji.");

        context.CartItems.Remove(cartItem);
        await context.SaveChangesAsync(cancellationToken);
        return "Stavka uspješno uklonjena iz korpe.";
    }
}