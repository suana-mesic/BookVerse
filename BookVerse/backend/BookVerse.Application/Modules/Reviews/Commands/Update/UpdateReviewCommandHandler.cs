namespace BookVerse.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommandHandler(
    IAppDbContext context,
    IAppCurrentUser currentUser,
    TimeProvider time)
            : IRequestHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        // Use BookVerseUnauthorizedException (401) instead of NotFound so the frontend's
        // auth interceptor can react correctly. A missing user identity is an auth failure,
        // not a "row not found".
        if (currentUser.UserId == null)
            throw new BookVerseUnauthorizedException("You are not authenticated.");

        var userId = currentUser.UserId.Value;

        // Find the current user's review for this book
        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.UserId == userId &&
                                     r.BookId == request.BookId &&
                                     !r.IsDeleted, ct);
        if (review == null)
            throw new BookVerseNotFoundException("Review not found or you have already deleted it.");

        // Update the review data
        review.Rating = request.Rating;
        review.Comment = request.Comment;
        // TimeProvider so unit tests can pin "now" and assert the UpdatedAt stamp.
        review.UpdatedAt = time.GetUtcNow().UtcDateTime;

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}