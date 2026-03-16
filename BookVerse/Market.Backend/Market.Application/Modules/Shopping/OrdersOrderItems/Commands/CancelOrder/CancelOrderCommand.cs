namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest
    {
        public int OrderId { get; set; }
    }
}
