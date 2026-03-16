namespace Market.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
            : IRequestHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        if (currentUser.UserId == null)
            throw new MarketNotFoundException("Niste autentificirani!");

        var userId = currentUser.UserId.Value;

        // Pronađi recenziju trenutnog korisnika za ovu knjigu
        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.UserId == userId &&
                                     r.BookId == request.BookId &&
                                     !r.IsDeleted, ct);
        if (review == null)
            throw new MarketNotFoundException("Recenzija nije pronađena ili ste je već obrisali.");

        // Ažuriraj podatke
        review.Rating = request.Rating;
        review.Comment = request.Comment;
        review.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync(ct);

        return Unit.Value;
    }
}