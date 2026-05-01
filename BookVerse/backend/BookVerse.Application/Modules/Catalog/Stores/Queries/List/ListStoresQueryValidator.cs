namespace BookVerse.Application.Modules.Catalog.Stores.Queries.List;

public sealed class ListStoresQueryValidator : AbstractValidator<ListStoresQuery>
{
    public ListStoresQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
    }
}
