namespace Market.Application.Modules.Review.Queries.GetById;

public class GetReviewsByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetReviewsByIdQuery, GetReviewsByIdQueryDto>
{
    public async Task<GetReviewsByIdQueryDto> Handle(GetReviewsByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await context.Reviews
            .Where(x => x.UserId == request.UserId)
            .Where(x => x.BookId == request.BookId)
            .Select(x => new GetReviewsByIdQueryDto
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