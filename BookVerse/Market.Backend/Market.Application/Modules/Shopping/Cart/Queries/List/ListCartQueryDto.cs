using Market.Application.Modules.Catalog.Stores.Queries.GetById;

namespace Market.Application.Modules.Shopping.Cart.Queries.List;

public class ListCartQueryDto
{
    public List<CartItemDto> ActiveItems { get; set; } = new();
    public List<CartItemDto> SavedForLaterItems { get; set; } = new();
    public decimal TotalPrice { get; set; }
}

public class CartItemDto
{
    public int CartId { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; }
    public int? QuantityInStockForOnlineOrders { get; set; }
    public Dictionary <int, decimal>? QuantityInStockInStores { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    public DateTime DateAdded { get; set; }
}