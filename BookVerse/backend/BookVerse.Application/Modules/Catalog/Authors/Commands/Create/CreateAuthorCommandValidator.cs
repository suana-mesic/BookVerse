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
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x=> x.Country).NotEmpty().WithMessage("Country is required.");
    }
}

