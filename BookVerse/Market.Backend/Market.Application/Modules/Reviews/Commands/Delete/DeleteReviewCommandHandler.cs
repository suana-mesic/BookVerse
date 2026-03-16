namespace Market.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
      : IRequestHandler<DeleteReviewCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        if (currentUser.UserId is null)
            throw new MarketBusinessRuleException("123", "Korisnik nije autentifikovan.");

        var review = await context.Reviews
            .FirstOrDefaultAsync(x => x.UserId == currentUser.UserId && x.BookId == request.BookId, ct);

        if (review is null)
            throw new MarketNotFoundException("Recenzija nije pronađena.");

        context.Reviews.Remove(review);
        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
