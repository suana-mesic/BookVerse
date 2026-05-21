using BookVerse.Domain.Entities.Shopping;
using Stripe;

namespace BookVerse.Application.Common.Interfaces
{
    // Thin wrapper around the Stripe SDK so handlers don't talk to Stripe directly.
    // Keeps the Stripe-specific knowledge (option building, signature parsing, charge
    // lookups) in one place that can be mocked in tests.
    public interface IPaymentService
    {
        // Creates a Stripe PaymentIntent for the given order total. The orderId is attached
        // as metadata so the webhook can find the order even if our PaymentIntentId column
        // is somehow out of sync.
        Task<PaymentIntent> CreatePaymentIntentAsync(decimal totalPrice, int orderId, CancellationToken ct);

        // Verifies the Stripe signature header and returns the parsed Event.
        // Throws StripeException on a forged or tampered payload.
        Event ConstructWebhookEvent(string payload, string signature);

        // Stripe does not include the Charge in webhook events automatically. We fetch it
        // separately and convert the card details into a PaymentSummaries entity ready to
        // be attached to the order. Returns null when the charge has no card details.
        Task<PaymentSummaries?> BuildPaymentSummaryAsync(string? latestChargeId, CancellationToken ct);

        // Issues a full refund for the order's most recent successful Charge.
        // Throws BookVerseConflictException if Stripe reports the refund as failed.
        Task<Refund> CreateRefundAsync(string paymentIntentId, CancellationToken ct);
    }
}
