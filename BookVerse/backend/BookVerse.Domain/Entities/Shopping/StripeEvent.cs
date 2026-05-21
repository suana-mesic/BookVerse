namespace BookVerse.Domain.Entities.Shopping
{
    //Append-only ledger of Stripe webhook events that have been processed.
    //Used as an idempotency guard so that a redelivered event (Stripe retries on 5xx, network blips,
    //or a process crash mid-handling) cannot be applied twice, regardless of the order's current status.
    public class StripeEvent
    {
        public int Id { get; set; }
        public string StripeEventId { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public DateTime ProcessedAtUtc { get; set; }

        public static class Constraints
        {
            public const int StripeEventIdMaxLength = 100;
            public const int EventTypeMaxLength = 100;
        }
    }
}
