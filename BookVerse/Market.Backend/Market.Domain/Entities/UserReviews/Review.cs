using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.UserReviews
{
    public class Review
    {
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
