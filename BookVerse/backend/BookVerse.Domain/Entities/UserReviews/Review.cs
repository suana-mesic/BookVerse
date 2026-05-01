using BookVerse.Domain.Entities.Catalog;
using BookVerse.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Domain.Entities.UserReviews
{
    public class Review
    {
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int UserId { get; set; }
        public BookVerseUserEntity User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
