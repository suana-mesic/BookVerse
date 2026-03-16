using Market.Application.Modules.Reviews.Queries.GetById;

public sealed class GetReviewsByIdQueryValidator : AbstractValidator<GetReviewsByIdQuery>
{
    public GetReviewsByIdQueryValidator()
    {
        RuleFor(x => x.BookId).GreaterThan(0).WithMessage("Book ID mora imati pozitivnu vrijednost.");
    }
}