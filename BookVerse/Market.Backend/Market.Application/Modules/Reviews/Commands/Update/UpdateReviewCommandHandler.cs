namespace Market.Application.Modules.Review.Commands.Update;

public sealed class UpdateReviewCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        var entity = await ctx.Reviews
          .Where(x => x.UserId == request.UserId && x.BookId == request.BookId)
          .FirstOrDefaultAsync(ct);

        if (entity is null)
            throw new MarketNotFoundException($"Recenzija (User ID={request.UserId}, Book ID={request.BookId}) nije pronađena.");

        entity.Rating = request.Rating;
        entity.Comment = request.Comment;

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}