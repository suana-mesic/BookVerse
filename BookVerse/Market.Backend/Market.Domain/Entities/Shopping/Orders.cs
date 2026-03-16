using Market.Domain.Common;
using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class Orders : BaseEntity
    {
        public int UserId { get; set; }
        public MarketUserEntity User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ShippingPriceAtTheTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int ShipToAddressId { get; set; }
        public Address ShipToAddress { get; set; }
        public int? ShippingMethodId { get; set; }
        public int? PickupStoreId { get; set; }
        public ShippingMethods ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public int? PaymentSummaryId { get; set; }
        public PaymentSummaries? PaymentSummary { get; set; }
        public string PaymentIntentId { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? CancelledAt { get; set; }

        public ICollection<Coupons> Coupons { get; set; } = new List<Coupons>();
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        public static class Constraints
        {
            public const int TrackingNumberMaxLength = 50;
        }
    }
}
