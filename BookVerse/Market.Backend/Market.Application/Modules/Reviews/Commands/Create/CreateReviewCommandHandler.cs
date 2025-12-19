using Market.Domain.Entities.UserReviews;

namespace Market.Application.Modules.Reviews.Commands.Create;

public class CreateReviewCommandHandler(IAppDbContext context)
    : IRequestHandler<CreateReviewCommand, string>
{
    public async Task<string> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context.Users.AnyAsync(x => x.Id == request.UserId);
        var bookExists = await context.Books.AnyAsync(x => x.Id == request.BookId);
        var alreadyReviewed = await context.Reviews
            .AnyAsync(x => x.UserId == request.UserId && x.BookId == request.BookId, cancellationToken);

        if (!userExists)
            throw new MarketNotFoundException("Korisnik ne postoji.");

        if (!bookExists)
            throw new MarketNotFoundException("Knjiga ne postoji.");

        if (alreadyReviewed)
            throw new MarketConflictException("Korisnik je već recenzirao ovu knjigu.");

        var review = new Review
        {
            UserId = request.UserId,
            BookId = request.BookId,
            Rating = request.Rating,
            Comment = request.Comment,
            IsDeleted = false,
            DatePosted = DateTime.UtcNow
        };

        context.Reviews.Add(review);
        await context.SaveChangesAsync(cancellationToken);

        return "Uspješno dodana recenzija";
    }
}