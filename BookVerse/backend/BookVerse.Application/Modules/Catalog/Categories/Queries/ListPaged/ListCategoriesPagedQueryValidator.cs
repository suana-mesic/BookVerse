namespace BookVerse.Application.Modules.Catalog.Categories.Queries.ListPaged;

public sealed class ListCategoriesPagedQueryValidator : AbstractValidator<ListCategoriesPagedQuery>
{
    public ListCategoriesPagedQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
    }
}
