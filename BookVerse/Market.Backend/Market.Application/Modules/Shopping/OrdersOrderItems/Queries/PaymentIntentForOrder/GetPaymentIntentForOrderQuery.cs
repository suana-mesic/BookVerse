namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder
{
    public class GetPaymentIntentForOrderQuery : IRequest<GetPaymentIntentForOrderQueryDto>
    {
        public int OrderId { get; set; }
    }
}
