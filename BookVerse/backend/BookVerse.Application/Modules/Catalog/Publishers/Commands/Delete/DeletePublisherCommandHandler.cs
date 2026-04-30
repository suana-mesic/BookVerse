using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Publishers.Commands.Delete
{
    public class DeletePublisherCommandHandler(IAppDbContext context) : IRequestHandler<DeletePublisherCommand, Unit>
    {
        public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Publishers.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new BookVerseNotFoundException($"Publisher with Id {request.Id} not found.");
            }

            context.Publishers.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
