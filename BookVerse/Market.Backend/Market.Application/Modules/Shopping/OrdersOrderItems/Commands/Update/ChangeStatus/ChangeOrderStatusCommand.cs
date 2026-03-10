using Market.Domain.Entities.Shopping;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus
{
    public class ChangeOrderStatusCommand:IRequest
    {
        public int Id { get; set; }
        public OrderStatusType NewStatus { get; set; }
    }
}
