using Market.Application.Modules.Review.Queries.List;
using Market.Domain.Entities.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public class ListOrderOrderItemsQueryDto
    {
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public OrderItemsUserInfo UserInfo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public OrderStatusType StatusNameEnum { get; set; }
    }
    public class OrderItemsUserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
