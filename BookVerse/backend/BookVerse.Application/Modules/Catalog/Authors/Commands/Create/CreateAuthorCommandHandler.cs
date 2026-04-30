using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Authors.Commands.Create
{
    public class CreateAuthorCommandHandler(IAppDbContext context)
        : IRequestHandler<CreateAuthorCommand, int>
    {
        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            bool exists = await context.Authors.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName, cancellationToken);

            if(exists)
                throw new BookVerseConflictException("An author with the provided first and last name already exists.");
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
