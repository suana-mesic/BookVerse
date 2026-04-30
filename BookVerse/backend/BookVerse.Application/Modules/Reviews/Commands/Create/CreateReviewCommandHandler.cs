using BookVerse.Domain.Entities.UserReviews;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Application.Modules.Reviews.Commands.Create;

public class CreateReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<CreateReviewCommand, Unit>
{
    public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        // Authentication check
        if (currentUser.UserId == null)
            throw new BookVerseNotFoundException("You are not authenticated!");

        var userId = currentUser.UserId.Value;

        // Check if the user has purchased the book
        var hasPurchased = await context.Books
            .AnyAsync(b => b.Id == request.BookId &&
                          b.OrderItems.Any(oi => oi.Order.UserId == userId),
                          cancellationToken);

        if (!hasPurchased)
            throw new BookVerseNotFoundException("You can only review books you have purchased.");

        // Check if the book exists
        var bookExists = await context.Books.AnyAsync(x => x.Id == request.BookId, cancellationToken);
        if (!bookExists)
            throw new BookVerseNotFoundException("The book you want to review does not exist.");

        var alreadyReviewed = await context.Reviews
            .AnyAsync(x => x.UserId == userId && x.BookId == request.BookId,
                     cancellationToken);

        if (alreadyReviewed)
            throw new BookVerseConflictException("You have already reviewed this book.");

        var review = new Review
        {
            UserId = userId, 
            BookId = request.BookId,
            Rating = request.Rating,
            Comment = request.Comment,
            IsDeleted = false,
            DatePosted = DateTime.UtcNow
        };

        context.Reviews.Add(review);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}