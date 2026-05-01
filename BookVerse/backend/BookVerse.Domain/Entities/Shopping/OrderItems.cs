using BookVerse.Domain.Entities.Catalog;

namespace BookVerse.Domain.Entities.Shopping
{
    public class OrderItems
    {
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
    }
}
