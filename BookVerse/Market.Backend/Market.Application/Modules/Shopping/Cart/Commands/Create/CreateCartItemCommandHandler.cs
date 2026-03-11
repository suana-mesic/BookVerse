using Market.Domain.Entities.Shopping;

namespace Market.Application.Modules.Shopping.Cart.Commands.Create;

public class CreateCartItemCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<CreateCartItemCommand, string>
{
    public async Task<string> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new MarketNotFoundException("Korisnik nije prijavljen.");

        var bookExists = await context.Books.AnyAsync(x => x.Id == request.BookId, cancellationToken);
        if (!bookExists)
            throw new MarketNotFoundException("Knjiga ne postoji.");

        var cart = await context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        if (cart == null)
        {
            cart = new Carts { UserId = userId};
            context.Carts.Add(cart);
            await context.SaveChangesAsync(cancellationToken);
        }

        // Tražimo i soft-deleted stavke da izbjegnemo duplicate key
        var existingItem = await context.CartItems
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(ci => ci.CartId == cart.Id
                                    && ci.BookId == request.BookId, cancellationToken);

        if (existingItem != null)
        {
            // Ako je bila soft-deleted, reaktiviraj je
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
        return "Knjiga uspješno dodana u korpu.";
    }
}