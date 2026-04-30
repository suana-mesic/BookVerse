namespace BookVerse.Application.Modules.Reviews.Commands.Create;

public sealed class CreateReviewCommandValidator
    : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.Rating)
              .InclusiveBetween(1, 5)
              .WithMessage("The rating must be between 1 and 5.");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("You must enter a review comment.")
            .MaximumLength(2000)
            .WithMessage("The comment cannot be longer than 2000 characters.");
    }
}
