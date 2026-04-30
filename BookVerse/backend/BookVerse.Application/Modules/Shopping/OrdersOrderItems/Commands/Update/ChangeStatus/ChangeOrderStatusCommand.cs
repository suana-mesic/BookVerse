using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus
{
    public class ChangeOrderStatusCommand:IRequest
    {
        public int Id { get; set; }
        public OrderStatusType NewStatus { get; set; }
    }
}
