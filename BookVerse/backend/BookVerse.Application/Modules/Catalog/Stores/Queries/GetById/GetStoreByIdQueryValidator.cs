namespace BookVerse.Application.Modules.Catalog.Stores.Queries.GetById;

public sealed class GetStoreByIdQueryValidator : AbstractValidator<GetStoreByIdQuery>
{
    public GetStoreByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
