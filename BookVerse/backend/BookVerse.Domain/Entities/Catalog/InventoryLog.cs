using BookVerse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Domain.Entities.Catalog
{
    public class InventoryLog:BaseEntity
    {
        public int BookId { get; set; }
        public Books Book{ get; set; }
        public int ChangeTypeId { get; set; }
        public ChangeTypes  ChangeType { get; set; }
        public int QuantityChanged { get; set; }
        public DateTime DateChanged { get; set; }

    }
}
