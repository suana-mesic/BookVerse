using BookVerse.Domain.Entities.Identity;

namespace BookVerse.Domain.Entities.Shopping
{
   public class Carts
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public BookVerseUserEntity User { get; set; }

        public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}
