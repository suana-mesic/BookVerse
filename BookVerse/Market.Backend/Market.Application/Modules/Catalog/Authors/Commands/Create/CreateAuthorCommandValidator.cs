using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Commands.Create;

    public sealed class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ime je obavezno");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Prezime je obavezno");
        RuleFor(x=> x.Country).NotEmpty().WithMessage("Država je obavezna");
    }
}

