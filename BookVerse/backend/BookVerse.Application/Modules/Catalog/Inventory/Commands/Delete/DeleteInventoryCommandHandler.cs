using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Delete
{
    public class DeleteInventoryCommandHandler(IAppDbContext context) : IRequestHandler<DeleteInventoryCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken ct)
        {
            var zapisZaBrisanje = await context.StoreInventory.Where(x => x.StoreId == request.StoreId && x.BookId==request.BookId).FirstOrDefaultAsync(ct);

            if (zapisZaBrisanje == null)
                throw new BookVerseNotFoundException("No inventory exists for the given book and store.");
            zapisZaBrisanje.IsDeleted = true;
            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
