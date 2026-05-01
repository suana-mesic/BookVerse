namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Delete;

public class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        RuleFor(x => x.CartId)
            .GreaterThan(0).WithMessage("CartId must be greater than zero.");

        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("BookId must be greater than zero.");
    }
}
