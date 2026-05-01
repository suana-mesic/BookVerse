namespace BookVerse.Application.Modules.Shopping.Cart.Commands.SaveForLater;

public class SaveForLaterCommandValidator : AbstractValidator<SaveForLaterCommand>
{
    public SaveForLaterCommandValidator()
    {
        RuleFor(x => x.CartId)
            .GreaterThan(0).WithMessage("CartId must be greater than zero.");

        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("BookId must be greater than zero.");
    }
}
