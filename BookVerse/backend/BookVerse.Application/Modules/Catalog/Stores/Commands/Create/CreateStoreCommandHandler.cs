using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Commands.Create
{
    public class CreateStoreCommandHandler(IAppDbContext context) : IRequestHandler<CreateStoreCommand, int>
    {
        public async Task<int> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = new Store
            {
                StoreName = request.StoreName,
                AddressId = request.AddressId,
                Phone = request.Phone,
                Email = request.Email,
                OpeningHours = request.OpeningHours
            };

            context.Stores.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
