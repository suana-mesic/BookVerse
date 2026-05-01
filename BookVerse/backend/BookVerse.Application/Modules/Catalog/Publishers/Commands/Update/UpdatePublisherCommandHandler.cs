using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Commands.Update
{
    public class UpdatePublisherCommandHandler(IAppDbContext context) : IRequestHandler<UpdatePublisherCommand, Unit>
    {
        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Publishers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new BookVerseNotFoundException($"Publisher with Id {request.Id} not found.");
            }
            if(!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;
            if (!string.IsNullOrEmpty(request.City))
                entity.City = request.City;
            if (!string.IsNullOrEmpty(request.Country))
                entity.Country = request.Country;

            context.Publishers.Update(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
