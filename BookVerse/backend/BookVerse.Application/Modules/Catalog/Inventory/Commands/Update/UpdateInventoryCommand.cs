using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Commands.Update
{
    public class UpdateInventoryCommand : IRequest<Unit>
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
        public int OldStoreId { get; set; }
        public int OldBookId { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderTreshold { get; set; }
        public string? Location { get; set; } // e.g. Shelf 3
    }
}
