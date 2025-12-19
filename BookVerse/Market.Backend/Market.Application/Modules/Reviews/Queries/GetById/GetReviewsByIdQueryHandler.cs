using Market.Domain.Entities.UserReviews;

namespace Market.Application.Modules.Reviews.Queries.GetById;

public class GetReviewsByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetReviewsByIdQuery, GetReviewsByIdQueryDto>
{
    public async Task<GetReviewsByIdQueryDto> Handle(GetReviewsByIdQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Review> query = context.Reviews.AsNoTracking();

        if (request.BookId is null)
        {
            query = context.Reviews
            .Where(x => x.UserId == request.UserId);
        }
        else if (request.UserId is null)
        {
            query = context.Reviews.Where(x => x.BookId == request.BookId);
        }
        else
        {
            query = context.Reviews
            .Where(x => x.UserId == request.UserId && x.BookId == request.BookId);
        }
       
        GetReviewsByIdQueryDto? review = await query.Select(x => new GetReviewsByIdQueryDto
        {
            Rating = x.Rating,
            Comment = x.Comment,
            DatePosted = x.DatePosted,
            Book = new GetReviewsByIdQueryBookDto
            {
                ISBN = x.Book.ISBN,
                Title = x.Book.Title
            },
            User = new GetReviewsByIdQueryUserDto
            {
                FirstName = x.User.FirstName,
                LastName = x.User.LastName
            }
        }).FirstOrDefaultAsync(cancellationToken);

        if (review == null)
        {
            throw new MarketNotFoundException($"Recenzija sa unesenim UserId: {request.UserId} i BookId: {request.BookId} nije pronađena");
        }

        return review;
    }
}