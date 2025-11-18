using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Publishers.Queries.GetById
{
    public class GetPublisherByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetPublisherByIdQuery, GetPublisherByIdQueryDto>
    {
        public async Task<GetPublisherByIdQueryDto> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Publishers
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new MarketNotFoundException($"Publisher with Id {request.Id} not found.");
            }

            var dto = new GetPublisherByIdQueryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
                Country = entity.Country
            };

            return dto;
        }
    }
}
