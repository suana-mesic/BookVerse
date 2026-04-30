namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Update;

public sealed class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than zero.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty.")
            .MaximumLength(Author.Constraints.FirstNameMaxLength)
                .WithMessage($"First name can be at most {Author.Constraints.FirstNameMaxLength} characters long.")
            .When(x => x.FirstName is not null);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty.")
            .MaximumLength(Author.Constraints.LastNameMaxLength)
                .WithMessage($"Last name can be at most {Author.Constraints.LastNameMaxLength} characters long.")
            .When(x => x.LastName is not null);

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country cannot be empty.")
            .MaximumLength(Author.Constraints.CountryMaxLength)
                .WithMessage($"Country can be at most {Author.Constraints.CountryMaxLength} characters long.")
            .When(x => x.Country is not null);
    }
}
