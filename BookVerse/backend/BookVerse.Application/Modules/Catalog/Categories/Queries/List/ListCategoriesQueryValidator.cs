namespace BookVerse.Application.Modules.Catalog.Categories.Queries.List;

public sealed class ListCategoriesQueryValidator : AbstractValidator<ListCategoriesQuery>
{
    public ListCategoriesQueryValidator()
    {
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
    }
}
