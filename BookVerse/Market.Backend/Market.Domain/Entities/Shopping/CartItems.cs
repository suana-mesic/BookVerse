using Market.Domain.Entities.Catalog;

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
        public bool SavedForLater { get; set; } = false;

    }
}
