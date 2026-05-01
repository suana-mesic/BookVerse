namespace BookVerse.Application.Modules.Catalog.Publishers.Queries.GetById;

public sealed class GetPublisherByIdQueryValidator : AbstractValidator<GetPublisherByIdQuery>
{
    public GetPublisherByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
