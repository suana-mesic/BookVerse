namespace Market.Domain.Entities.Catalog
{
    public class StoreInventory
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastRestocked { get; set; }
        public int ReorderTreshold { get; set; }
        public string? Location { get; set; } //npr. Polica 3
        public bool IsDeleted { get; set; }
    }
}
