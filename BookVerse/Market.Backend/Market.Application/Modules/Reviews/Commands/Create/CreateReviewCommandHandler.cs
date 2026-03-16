using Market.Domain.Entities.UserReviews;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Modules.Reviews.Commands.Create;

public class CreateReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<CreateReviewCommand, Unit>
{
    public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        // Provjera autentifikacije
        if (currentUser.UserId == null)
            throw new MarketNotFoundException("Niste autentificirani!");

        var userId = currentUser.UserId.Value;

        // Provjera da li je korisnik kupio knjigu
        var hasPurchased = await context.Books
            .AnyAsync(b => b.Id == request.BookId &&
                          b.OrderItems.Any(oi => oi.Order.UserId == userId),
                          cancellationToken);

        if (!hasPurchased)
            throw new MarketNotFoundException("Možete recenzirati samo knjige koje ste kupili.");

        // Provjera da li knjiga postoji
        var bookExists = await context.Books.AnyAsync(x => x.Id == request.BookId, cancellationToken);
        if (!bookExists)
            throw new MarketNotFoundException("Knjiga koju želite recenzirati ne postoji.");

        var alreadyReviewed = await context.Reviews
            .AnyAsync(x => x.UserId == userId && x.BookId == request.BookId,
                     cancellationToken);

        if (alreadyReviewed)
            throw new MarketConflictException("Već ste recenzirali ovu knjigu.");

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