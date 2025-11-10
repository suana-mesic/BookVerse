using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Whishlist
{
    public class WishlistItems
    {
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
