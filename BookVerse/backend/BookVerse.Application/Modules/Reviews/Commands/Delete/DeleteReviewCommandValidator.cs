namespace BookVerse.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommandValidator : AbstractValidator<DeleteReviewCommand>
{
    public DeleteReviewCommandValidator()
    {
        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("BookId must be greater than zero.");
    }
}
