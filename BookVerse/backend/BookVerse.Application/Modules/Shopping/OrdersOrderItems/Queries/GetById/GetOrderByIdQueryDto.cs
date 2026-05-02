using BookVerse.Domain.Entities.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById
{
    public class GetOrderByIdQueryDto
    {
        public required int Id { get; init; }
        public required string TrackingNumber { get; init; }
        public required GetByIdOrderQueryDtoUser User { get; init; }
        public required GetByIdOrderQueryDtoShipToAddress ShipToAddress { get; init; }
        public required DateTime OrderedAtUtc { get; set; }
        public required DateTime? PaidAtUtc { get; set; }
        public required OrderStatusType Status { get; set; }
        public required decimal TotalAmount { get; set; }
        public required decimal Subtotal { get; set; }
        public decimal ShippingPriceAtTheTime { get; set; }
        public required decimal? DiscountAmount { get; set; }
        public required List<GetByIdOrderQueryDtoItem> Items { get; set; }
    }
    public sealed class GetByIdOrderQueryDtoUser
    {
        public required string UserFirstname { get; set; }
        public required string UserLastname { get; set; }
    }

    public sealed class GetByIdOrderQueryDtoShipToAddress
    {
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
    public class GetByIdOrderQueryDtoItem
    {
        public required GetByIdOrderQueryDtoItemBook Book { get; set; }
        public required decimal Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
    }

    public class GetByIdOrderQueryDtoItemBook
    {
        public required int BookId { get; set; }
        public required string Title { get; set; }

    }

}
