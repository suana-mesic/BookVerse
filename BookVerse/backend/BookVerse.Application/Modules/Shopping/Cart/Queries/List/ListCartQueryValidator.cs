namespace BookVerse.Application.Modules.Shopping.Cart.Queries.List;

public sealed class ListCartQueryValidator : AbstractValidator<ListCartQuery>
{
    public ListCartQueryValidator()
    {
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
    }
}
