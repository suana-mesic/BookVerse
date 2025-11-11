using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Authors.Commands.Create
{
    public class CreateAuthorCommandHandler(IAppDbContext context)
        : IRequestHandler<CreateAuthorCommand, int>
    {
        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            bool exists = await context.Authors.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName);

            if(exists)
                throw new MarketConflictException("Autor sa unesenim imenom i prezimenom već postoji.");
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Biography = request.Biography ?? "",
                Country = request.Country,
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync(cancellationToken);

            return author.Id;
        }
    }
}
