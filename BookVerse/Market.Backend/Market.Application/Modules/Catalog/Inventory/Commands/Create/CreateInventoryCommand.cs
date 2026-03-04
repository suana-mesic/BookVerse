using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Inventory.Commands.Create
{
    public class CreateInventoryCommand : IRequest<Unit>
    {
        public List<InventoryInfo> InventoryInfo { get; set; } = [];

    }
    public class InventoryInfo
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
        public int QuantityInStock { get; set; }
        public int ReorderTreshold { get; set; }
        public string? Location { get; set; } //npr. Polica 3
    }
}
