using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Commands.Update
{
    public class UpdateStoreCommandHandler(IAppDbContext context) : IRequestHandler<UpdateStoreCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Stores.FindAsync(new object?[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new BookVerseNotFoundException($"Store with Id {request.Id} not found.");
            }

            if (!string.IsNullOrEmpty(request.StoreName))
                entity.StoreName = request.StoreName;
            if (request.AddressId != null)
                entity.AddressId = (int)request.AddressId;
            if (!string.IsNullOrEmpty(request.Phone))
                entity.Phone = request.Phone;
            if (!string.IsNullOrEmpty(request.Email))
                entity.Email = request.Email;
            if (!string.IsNullOrEmpty(request.OpeningHours))
                entity.OpeningHours = request.OpeningHours;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
