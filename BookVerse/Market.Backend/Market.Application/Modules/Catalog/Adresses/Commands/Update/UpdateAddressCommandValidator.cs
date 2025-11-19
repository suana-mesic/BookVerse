using Market.Application.Modules.Catalog.Adresses.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Commands.Update
{
    public class UpdateAddressCommandValidator: AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator() {
                RuleFor(x => x.Line1)
                    .MaximumLength(Address.Constraints.LineMaxLength);

                RuleFor(x => x.Line2)
                    .MaximumLength(Address.Constraints.LineMaxLength);

                RuleFor(x => x.City)
                    .MaximumLength(Address.Constraints.CityMaxLength);

                RuleFor(x => x.Country)
                    .MaximumLength(Address.Constraints.CountryMaxLength);
            }
        }
    
}
