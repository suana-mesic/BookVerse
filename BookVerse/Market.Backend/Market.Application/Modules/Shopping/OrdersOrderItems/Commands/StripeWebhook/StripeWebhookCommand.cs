namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    public class StripeWebhookCommand : IRequest
    {
        public string Payload { get; set; } = string.Empty; //Stripe će u Payload-u poslati JSON sa svim detaljima plaćanja
        public string StripeSignature { get; set; } = string.Empty; // potpis kojim Stripe dokazuje da je zaista on poslao poruku
    }
}