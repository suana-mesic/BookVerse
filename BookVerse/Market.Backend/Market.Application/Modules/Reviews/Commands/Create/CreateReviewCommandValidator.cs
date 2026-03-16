namespace Market.Application.Modules.Reviews.Commands.Create;

public sealed class CreateReviewCommandValidator
    : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.Rating)
              .InclusiveBetween(1, 5)
              .WithMessage("Recenzija mora imati vrijednost između 1 i 5.");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("Morate unijeti komentar za recenziju.")
            .MaximumLength(2000)
            .WithMessage("Komentar ne može biti duži od 2000 karaktera.");
    }
}