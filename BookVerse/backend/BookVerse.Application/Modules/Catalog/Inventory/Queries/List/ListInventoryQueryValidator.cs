namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.List;

public sealed class ListInventoryQueryValidator : AbstractValidator<ListInventoryQuery>
{
    public ListInventoryQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
        RuleFor(x => x.Book).MaximumLength(200).When(x => x.Book is not null);
        RuleFor(x => x.Store).MaximumLength(200).When(x => x.Store is not null);
    }
}
