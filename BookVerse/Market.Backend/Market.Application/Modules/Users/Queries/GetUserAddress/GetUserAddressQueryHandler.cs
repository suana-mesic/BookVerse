using Market.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Users.Queries.GetUserAddress
{
    public class GetUserAddressQueryHandler(IAppDbContext context, IAppCurrentUser currentUser) : IRequestHandler<GetUserAddressQuery, GetUserAddressQueryDto>
    {
        public async Task<GetUserAddressQueryDto> Handle(GetUserAddressQuery request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new MarketNotFoundException("Korisnik nije prijavljen");

            var user = await context.Users
                .AsNoTracking()
                .Where(x => x.Id == userId)
                .Include(x => x.Address)
                .Select(x => new GetUserAddressQueryDto
                {
                    AddressId = x.AddressId,
                    Line1 = x.Address!=null?x.Address.Line1:null,
                    Line2 = x.Address != null? x.Address.Line2:null,
                    City = x.Address != null ? x.Address.City : null,
                    Country = x.Address != null ? x.Address.Country : null
                }).FirstOrDefaultAsync(ct);

            return user ?? new GetUserAddressQueryDto();
        }
    }
}
