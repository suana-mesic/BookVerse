namespace BookVerse.Application.Modules.Reviews.Queries.ListForBook;

public sealed class ListReviewsForBookQueryValidator : AbstractValidator<ListReviewsForBookQuery>
{
    public ListReviewsForBookQueryValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0).WithMessage("BookId must be greater than zero.");
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
    }
}
