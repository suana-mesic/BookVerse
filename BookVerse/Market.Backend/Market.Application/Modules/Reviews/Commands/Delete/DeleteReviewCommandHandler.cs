namespace Market.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(IAppDbContext context, IAppCurrentUser appCurrentUser)
      : IRequestHandler<DeleteReviewCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        if (appCurrentUser.UserId is null)
            throw new MarketBusinessRuleException("123", "Korisnik nije autentifikovan.");

        var category = await context.Reviews
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.BookId == request.BookId, cancellationToken);

        if (category is null)
            throw new MarketNotFoundException("Recenzija nije pronađena.");

        category.IsDeleted = true;
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
