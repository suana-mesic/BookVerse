using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Create;

    public sealed class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
    public CreateAuthorCommandValidator()
    {
        // MaximumLength values pulled from Author.Constraints so the validator and the DB
        // schema never drift apart. NotEmpty alone would let the frontend POST megabytes of
        // "FirstName" and only crash at the EF Core layer, which is much worse UX.
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(Author.Constraints.FirstNameMaxLength)
                .WithMessage($"First name can be at most {Author.Constraints.FirstNameMaxLength} characters long.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(Author.Constraints.LastNameMaxLength)
                .WithMessage($"Last name can be at most {Author.Constraints.LastNameMaxLength} characters long.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(Author.Constraints.CountryMaxLength)
                .WithMessage($"Country can be at most {Author.Constraints.CountryMaxLength} characters long.");
    }
}

