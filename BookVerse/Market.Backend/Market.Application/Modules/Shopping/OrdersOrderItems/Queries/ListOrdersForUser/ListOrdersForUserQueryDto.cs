using Market.Domain.Entities.Shopping;
namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public class ListOrdersForUserQueryDto
    {
        public required int Id { get; init; }
        public required string TrackingNumber { get; init; }
        public required DateTime OrderedAtUtc { get; set; }
        public required DateTime? PaidAtUtc { get; set; }
        public required OrderStatusType Status { get; set; }
        public required decimal TotalAmount { get; set; }
        public required decimal Subtotal { get; set; }
        public decimal ShippingPriceAtTheTime { get; set; }
        public required decimal? DiscountAmount { get; set; }
        public required List<ListOrdersForUserQueryDtoItem> Items { get; set; }
    }
    public class ListOrdersForUserQueryDtoItem
    {
        public required ListOrdersForUserQueryDtoItemBook Book { get; set; }
        public required decimal Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
    }

    public class ListOrdersForUserQueryDtoItemBook
    {
        public required int BookId { get; set; }
        public required string Title { get; set; }
        public string? ImageUrl { get; set; } 
    }
}
