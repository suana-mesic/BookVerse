namespace BookVerse.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
            : IRequestHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        if (currentUser.UserId == null)
            throw new BookVerseNotFoundException("You are not authenticated!");

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
        review.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}