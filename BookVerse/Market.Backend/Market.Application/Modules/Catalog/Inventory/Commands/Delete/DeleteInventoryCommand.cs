using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Delete
{
    public class DeleteInventoryCommand:IRequest<Unit>
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
    }
}
