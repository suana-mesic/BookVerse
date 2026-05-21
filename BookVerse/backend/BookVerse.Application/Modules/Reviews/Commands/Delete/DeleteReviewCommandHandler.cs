namespace BookVerse.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
      : IRequestHandler<DeleteReviewCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        // BusinessRuleCodes.USER_NOT_AUTHENTICATED lets the frontend show a localized message.
        if (currentUser.UserId is null)
            throw new BookVerseBusinessRuleException(BusinessRuleCodes.USER_NOT_AUTHENTICATED, "User is not authenticated.");

        var review = await context.Reviews
            .FirstOrDefaultAsync(x => x.UserId == currentUser.UserId && x.BookId == request.BookId, ct);

        if (review is null)
            throw new BookVerseNotFoundException("Review not found.");

        context.Reviews.Remove(review);
        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
