using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Queries.GetById
{
    public class GetStoreByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetStoreByIdQuery, GetStoreByIdQueryDto>
    {
        public async Task<GetStoreByIdQueryDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var store = await context.Stores
                .Where(s => s.Id == request.Id)
                .Select(s => new GetStoreByIdQueryDto
                {
                    Id = s.Id,
                    StoreName = s.StoreName,
                    AddressId = s.AddressId,
                    Address = s.Address,
                    Phone = s.Phone,
                    Email = s.Email,
                    OpeningHours = s.OpeningHours
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (store == null)
            {
                throw new BookVerseNotFoundException($"Store with Id {request.Id} not found.");
            }

            return store;
        }
    }
}
