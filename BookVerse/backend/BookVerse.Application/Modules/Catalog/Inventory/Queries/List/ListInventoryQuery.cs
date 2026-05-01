using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Inventory.Queries.List
{
    public class ListInventoryQuery: BasePagedQuery<ListInventoryQueryDto> 
    {
        public string ? Search { get; set; } //property location
        public string? Book { get; set; }
        public string? Store { get; set; }
    }
}
