namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Create;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(x => x.BookId)
            .GreaterThan(0).WithMessage("BookId must be greater than zero.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
            .LessThanOrEqualTo(1000).WithMessage("Quantity can be at most 1000.");
    }
}
