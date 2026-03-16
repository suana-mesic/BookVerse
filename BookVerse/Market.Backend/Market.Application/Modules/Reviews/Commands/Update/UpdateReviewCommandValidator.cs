namespace Market.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommandValidator
    : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(x => x.Rating)
           .InclusiveBetween(1, 5)
           .WithMessage("Recenzija mora imati vrijednost između 1 i 5.");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("Komentar je obavezan.")
            .MaximumLength(2000)
            .WithMessage("Komentar ne može biti duži od 2000 karaktera.");
    }
}