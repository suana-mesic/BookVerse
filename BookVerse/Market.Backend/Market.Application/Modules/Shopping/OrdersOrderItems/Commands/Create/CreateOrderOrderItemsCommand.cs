using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Create
{
    public class CreateOrderOrderItemsCommand : IRequest<CreateOrderOrderItemsCommandDto>
    {
        public int? ShippingMethodId { get; set; }
        public int? StoreId { get; set; }
        public bool UseExistingAddress { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<int> CouponIds { get; set; } = new List<int>();
    }
}
