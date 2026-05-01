namespace BookVerse.Application.Modules.Catalog.Book.Queries.GetById;

public sealed class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
        RuleFor(x => x.Language).MaximumLength(10).When(x => x.Language is not null);
    }
}
