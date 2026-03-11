using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.Shopping
{
   public class Carts
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }

        public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();
    }
}
