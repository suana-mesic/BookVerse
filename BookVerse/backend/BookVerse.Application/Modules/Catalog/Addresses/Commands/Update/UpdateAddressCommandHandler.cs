using BookVerse.Application.Modules.Catalog.Authors.Commands.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Addresses.Commands.Update
{
    public class UpdateAddressCommandHandler(IAppDbContext context): IRequestHandler<UpdateAddressCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Addresses
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new BookVerseNotFoundException($"Address with Id {request.Id} not found.");
            }

            if (!string.IsNullOrWhiteSpace(request.Line1))
                entity.Line1 = request.Line1;
            if (!string.IsNullOrWhiteSpace(request.Line2))
                entity.Line2 = request.Line2;
            if (!string.IsNullOrWhiteSpace(request.City))
                entity.City = request.City;
            if (!string.IsNullOrWhiteSpace(request.Country))
                entity.Country = request.Country;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
