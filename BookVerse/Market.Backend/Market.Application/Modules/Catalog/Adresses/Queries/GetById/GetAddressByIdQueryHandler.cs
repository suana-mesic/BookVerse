using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Queries.GetById
{
    public class GetAddressByIdQueryHandler(IAppDbContext context): IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryDto>
    {
        public async Task<GetAddressByIdQueryDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await context.Addresses
                .Where(a => a.Id == request.Id)
                .Select(a => new GetAddressByIdQueryDto
                {
                    Id = a.Id,
                    Line1 = a.Line1,
                    Line2 = a.Line2,
                    City = a.City,
                    Country = a.Country
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (address == null)
            {
                throw new MarketNotFoundException($"Address with Id {request.Id} not found.");
            }

            return address;
        }
    }
}
