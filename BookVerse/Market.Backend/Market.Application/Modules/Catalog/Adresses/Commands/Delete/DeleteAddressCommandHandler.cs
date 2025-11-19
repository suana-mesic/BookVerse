using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Commands.Delete
{
    public class DeleteAddressCommandHandler(IAppDbContext context) : IRequestHandler<DeleteAddressCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Addresses
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new MarketNotFoundException($"Address with Id {request.Id} not found.");
            }

            context.Addresses.Remove(entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
