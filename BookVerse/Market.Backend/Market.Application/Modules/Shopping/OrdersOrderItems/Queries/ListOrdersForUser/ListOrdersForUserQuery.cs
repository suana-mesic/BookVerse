using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
using Market.Domain.Entities.Shopping;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser
{
    public class ListOrdersForUserQuery: BasePagedQuery<ListOrdersForUserQueryDto> 
    {
        public string? Search { get; set; }
        public OrderStatusType? Status { get; set; }
        public string? Language { get; set; }
    }
}
