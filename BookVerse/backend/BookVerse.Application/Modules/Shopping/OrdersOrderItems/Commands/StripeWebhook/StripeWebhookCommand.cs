namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook
{
    public class StripeWebhookCommand : IRequest
    {
        public string Payload { get; set; } = string.Empty; //Stripe sends a JSON with all payment details in the Payload
        public string StripeSignature { get; set; } = string.Empty; // signature that Stripe uses to prove it sent the message
    }
}