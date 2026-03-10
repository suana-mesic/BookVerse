using Market.Domain.Entities.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public class ListOrderOrderItemsQuery:BasePagedQuery<ListOrderOrderItemsQueryDto> //provjeriti 
    {
        public string ? Search { get; set; }
        public OrderStatusType? Status { get; set; }
    }
}
