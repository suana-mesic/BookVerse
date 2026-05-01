using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser
{
    public class ListOrdersForUserQuery: BasePagedQuery<ListOrdersForUserQueryDto> 
    {
        public string? Search { get; set; }
        public OrderStatusType? Status { get; set; }
        public string? Language { get; set; }
    }
}
