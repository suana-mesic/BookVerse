using Market.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class CartItems
    {
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int CartId { get; set; }
        public Carts Cart { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
