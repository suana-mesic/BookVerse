namespace Market.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommandValidator
    : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
        RuleFor(x => x.BookId).GreaterThan(0);
        RuleFor(x => x.Rating).InclusiveBetween(1,5).WithMessage("Recenzija mora imati vrijednost 1-5.");
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Komentar je obavezan.");
    }
}