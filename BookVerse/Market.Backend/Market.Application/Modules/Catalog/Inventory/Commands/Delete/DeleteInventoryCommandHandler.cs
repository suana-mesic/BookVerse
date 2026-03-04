using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Delete
{
    public class DeleteInventoryCommandHandler(IAppDbContext context) : IRequestHandler<DeleteInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken ct)
        {
            var zapisZaBrisanje = await context.StoreInventory.Where(x => x.StoreId == request.StoreId && x.BookId==request.BookId).FirstOrDefaultAsync(ct);

            if (zapisZaBrisanje == null)
                throw new MarketNotFoundException("Ne postoji inventar za datu knjigu i prodavnicu.");
            zapisZaBrisanje.IsDeleted = true;
            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
