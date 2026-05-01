namespace BookVerse.Application.Modules.Shopping.Cart.Commands.EmptyCart
{
    public class EmptyCartCommandHandler(IAppDbContext context, IAppCurrentUser currentUser) : IRequestHandler<EmptyCartCommand>
    {
        public async Task Handle(EmptyCartCommand request, CancellationToken ct)
        {
            if (!currentUser.IsAuthenticated)
                throw new BookVerseConflictException("User is not logged in.");

            var userBooksFromCart = await context.Carts
                .Where(x => x.UserId == currentUser.UserId)
                .ToListAsync(ct);

            foreach (var record in userBooksFromCart)
                context.Carts.Remove(record);

            await context.SaveChangesAsync(ct);
        }
    }
}
