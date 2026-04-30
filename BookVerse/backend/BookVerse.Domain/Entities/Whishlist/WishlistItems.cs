using BookVerse.Domain.Entities.Catalog;
using BookVerse.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Domain.Entities.Whishlist
{
    public class WishlistItems
    {
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int UserId { get; set; }
        public BookVerseUserEntity User { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
