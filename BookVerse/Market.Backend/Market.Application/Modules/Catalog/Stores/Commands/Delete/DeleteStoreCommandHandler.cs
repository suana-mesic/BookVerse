using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Commands.Delete
{
    public class DeleteStoreCommandHandler(IAppDbContext context): IRequestHandler<DeleteStoreCommand,Unit>
    {
        public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Stores.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new MarketNotFoundException($"Store with Id {request.Id} not found.");
            }

            context.Stores.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
