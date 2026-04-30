using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Application.Modules.Reviews.Queries.GetById;

public class GetReviewsByIdQueryHandler(
    IAppDbContext context,
    IAppCurrentUser currentUser)
    : IRequestHandler<GetReviewsByIdQuery, GetReviewsByIdQueryDto>
{
    public async Task<GetReviewsByIdQueryDto> Handle(
        GetReviewsByIdQuery request,
        CancellationToken ct)
    {
        if (currentUser.UserId == null)
            throw new BookVerseNotFoundException("You are not authenticated.");

        var userId = currentUser.UserId.Value;

        var review = await context.Reviews
            .Where(r => r.UserId == userId &&
                       r.BookId == request.BookId &&
                       !r.IsDeleted)
            .Select(r => new GetReviewsByIdQueryDto
            {
                BookId = r.BookId,
                UserId = r.UserId,
                Rating = r.Rating,
                Comment = r.Comment,
                DatePosted = r.DatePosted,
                UpdatedAt = r.UpdatedAt
            })
            .FirstOrDefaultAsync(ct);

        if (review == null)
            throw new BookVerseNotFoundException("Review not found.");

        return review;
    }
}
