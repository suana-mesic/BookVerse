namespace BookVerse.Application.Modules.Catalog.Book.Queries.ListMyBooks;

public sealed class ListMyBooksQueryValidator : AbstractValidator<ListMyBooksQuery>
{
    public ListMyBooksQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
        RuleForEach(x => x.CategoryIds).GreaterThan(0).WithMessage("Each category id must be greater than zero.");
    }
}
