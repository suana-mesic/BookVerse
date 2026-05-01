namespace BookVerse.Application.Modules.Catalog.Addresses.Queries.List;

public sealed class ListAddressesQueryValidator : AbstractValidator<ListAddressesQuery>
{
    public ListAddressesQueryValidator()
    {
        RuleFor(x => x.Paging.Page).GreaterThan(0).WithMessage("Page must be greater than zero.");
        RuleFor(x => x.Paging.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than zero.");
        RuleFor(x => x.Search).MaximumLength(200).When(x => x.Search is not null);
    }
}
