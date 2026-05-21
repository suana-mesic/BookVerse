namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.EnsurePaymentIntent
{
    public class EnsurePaymentIntentForOrderCommandDto
    {
        public string ClientSecret { get; set; } = string.Empty;
        public string PublishableKey { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
    }
}
