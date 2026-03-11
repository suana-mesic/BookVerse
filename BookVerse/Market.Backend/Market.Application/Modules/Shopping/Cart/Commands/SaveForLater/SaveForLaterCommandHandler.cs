namespace Market.Application.Modules.Shopping.Cart.Commands.SaveForLater;

public class SaveForLaterCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<SaveForLaterCommand, string>
{
    public async Task<string> Handle(SaveForLaterCommand request, CancellationToken cancellationToken)
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

        cartItem.SavedForLater = request.SavedForLater;

        await context.SaveChangesAsync(cancellationToken);

        return request.SavedForLater
            ? "Stavka sačuvana za kasnije."
            : "Stavka vraćena u korpu.";
    }
}