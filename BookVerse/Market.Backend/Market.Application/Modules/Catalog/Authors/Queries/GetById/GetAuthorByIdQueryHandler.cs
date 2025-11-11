using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Queries.GetById;
    public class GetAuthorByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryDto>
    {
    public async Task<GetAuthorByIdQueryDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {

        var author = await context.Authors
            .Where(a => a.Id == request.Id)
            .Select(x => new GetAuthorByIdQueryDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Biography = x.Biography
            }).FirstOrDefaultAsync(cancellationToken);

        if (author == null)
        {
            throw new MarketNotFoundException($"Autor sa unesenom vrijednošću Id-a: {request.Id} nije pronađen.");
        }

        return author;
    }
}

