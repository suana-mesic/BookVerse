using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Commands.Update
{
    public class UpdatePublisherCommandValidator: AbstractValidator<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator() { 
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name)
                .MaximumLength(Publisher.Constraints.NameMaxLength).WithMessage($"Name can be at most {Publisher.Constraints.NameMaxLength} characters long.");
            RuleFor(x => x.City)
                .MaximumLength(Publisher.Constraints.CityMaxLength).WithMessage($"City can be at most {Publisher.Constraints.CityMaxLength} characters long.");
            RuleFor(x => x.Country)
                .MaximumLength(Publisher.Constraints.CountryMaxLength).WithMessage($"Country can be at most {Publisher.Constraints.CountryMaxLength} characters long.");    
        }
    }
}
