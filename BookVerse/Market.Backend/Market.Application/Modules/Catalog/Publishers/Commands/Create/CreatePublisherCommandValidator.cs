using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Publishers.Commands.Create
{
    public class CreatePublisherCommandValidator: AbstractValidator<CreatePublisherCommand>
    {
        public CreatePublisherCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(Publisher.Constraints.NameMaxLength).WithMessage($"Name can be at most {Publisher.Constraints.NameMaxLength} characters long.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(Publisher.Constraints.CityMaxLength).WithMessage($"City can be at most {Publisher.Constraints.CityMaxLength} characters long.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(Publisher.Constraints.CountryMaxLength).WithMessage($"Country can be at most {Publisher.Constraints.CountryMaxLength} characters long.");
        }
    }
}
