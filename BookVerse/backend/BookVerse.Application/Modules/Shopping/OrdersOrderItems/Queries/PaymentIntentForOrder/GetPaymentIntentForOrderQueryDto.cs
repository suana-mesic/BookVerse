namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder
{
    public class GetPaymentIntentForOrderQueryDto
    {
        public string ClientSecret { get; set; } = string.Empty;
        public string PublishableKey { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
