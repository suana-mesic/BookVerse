namespace Market.Application.Modules.Shopping.Cart.Commands.Update;

public class UpdateCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<UpdateCartItemCommand, string>
{
    public async Task<string> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

        if (request.Quantity <= 0)
            throw new MarketConflictException("Količina mora biti veća od 0.");

        var cartItem = await context.CartItems
            .Include(x => x.Cart)
            .FirstOrDefaultAsync(x => x.CartId == request.CartId
                && x.BookId == request.BookId
                && x.Cart.UserId == userId, cancellationToken);

        if (cartItem is null)
            throw new MarketNotFoundException("Stavka korpe ne postoji.");

        cartItem.Quantity = request.Quantity;

        await context.SaveChangesAsync(cancellationToken);
        return "Količina uspješno ažurirana.";
    }
}