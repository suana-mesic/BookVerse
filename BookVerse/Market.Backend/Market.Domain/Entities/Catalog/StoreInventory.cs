using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class StoreInventory
    {
        public int StoreId { get; set; }
        public Stores Store { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastRestocked { get; set; }
        public int ReorderTreshold { get; set; }
    }
}
