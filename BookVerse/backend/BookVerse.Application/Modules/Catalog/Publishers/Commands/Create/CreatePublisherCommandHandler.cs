using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Commands.Create
{
    public class CreatePublisherCommandHandler(IAppDbContext context) : IRequestHandler<CreatePublisherCommand, int>
    {
        public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = new Publisher
            {
                Name = request.Name,
                City = request.City,
                Country = request.Country
            };

            context.Publishers.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
