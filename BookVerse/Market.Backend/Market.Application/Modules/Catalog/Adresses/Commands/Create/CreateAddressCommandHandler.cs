using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Commands.Create
{
    public class CreateAddressCommandHandler(IAppDbContext context): IRequestHandler<CreateAddressCommand, int>
    {
        public async Task<int> Handle(CreateAddressCommand request, CancellationToken ct)
        {
            var entity = new Address
            {
                Line1 = request.Line1,
                Line2 = request.Line2,
                City = request.City,
                Country = request.Country
            };

            context.Addresses.Add(entity);
            await context.SaveChangesAsync(ct);

            return entity.Id;
        }
    }
}
