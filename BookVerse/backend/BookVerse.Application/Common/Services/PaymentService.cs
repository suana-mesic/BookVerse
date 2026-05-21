using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Stripe;

namespace BookVerse.Application.Common.Services
{
    // Implementation of IPaymentService. Owns every call into the Stripe SDK so handlers
    // don't need to know option shapes or signature parsing details.
    public sealed class PaymentService(
        IStripeSettings stripeSettings,
        IPaymentOptions paymentOptions,
        ICheckoutPricingService pricingService) : IPaymentService
    {
        public async Task<PaymentIntent> CreatePaymentIntentAsync(decimal totalPrice, int orderId, CancellationToken ct)
        {
            var paymentIntentService = new PaymentIntentService();

            return await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                // ToStripeAmount uses AwayFromZero rounding so the value we send matches the one
                // we compare in the webhook (otherwise 7.999 becomes 800 here and 799 there).
                Amount = pricingService.ToStripeAmount(totalPrice),
                // Currency comes from PaymentOptions (appsettings.json), so we can switch markets
                // by editing config instead of touching code.
                Currency = paymentOptions.Currency,
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true
                },
                Metadata = new Dictionary<string, string>
                {
                    // The webhook uses this as a fallback when PaymentIntentId lookups miss.
                    { "orderId", orderId.ToString() }
                },
                Expand = new List<string> { "latest_charge" }
            }, cancellationToken: ct);
        }

        public Event ConstructWebhookEvent(string payload, string signature)
        {
            // Stripe's helper verifies the HMAC signature against WebhookSecret and parses the JSON.
            // Throws StripeException if the signature is missing or wrong.
            return EventUtility.ConstructEvent(payload, signature, stripeSettings.WebhookSecret);
        }

        public async Task<PaymentSummaries?> BuildPaymentSummaryAsync(string? latestChargeId, CancellationToken ct)
        {
            // No charge yet means Stripe is still processing; nothing to summarise.
            if (string.IsNullOrEmpty(latestChargeId)) return null;

            var chargeService = new ChargeService();
            var charge = await chargeService.GetAsync(latestChargeId, cancellationToken: ct);

            if (charge?.PaymentMethodDetails?.Card is not { } card) return null;

            // Store only the safe-to-display card info (last 4, brand, expiry). We never store
            // the full PAN or CVC - those never even reach our backend.
            return new PaymentSummaries
            {
                Last4Digits = card.Last4,
                Brand = card.Brand ?? "Unknown",
                ExpMonth = (int)card.ExpMonth,
                ExpYear = (int)card.ExpYear,
            };
        }

        public async Task<Refund> CreateRefundAsync(string paymentIntentId, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(paymentIntentId))
                throw new BookVerseNotFoundException("PaymentIntentId was not found for this order.");

            // Look up the PaymentIntent to get its latest Charge - the refund has to be issued
            // against a charge, not the intent itself.
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = await paymentIntentService.GetAsync(paymentIntentId, cancellationToken: ct);

            if (string.IsNullOrEmpty(paymentIntent.LatestChargeId))
                throw new BookVerseNotFoundException("Charge was not found for this PaymentIntent.");

            var refundService = new RefundService();
            var refund = await refundService.CreateAsync(new RefundCreateOptions
            {
                Charge = paymentIntent.LatestChargeId
                // No explicit amount = Stripe refunds the full charge.
            }, cancellationToken: ct);

            if (refund.Status == "failed")
                throw new BookVerseConflictException($"Stripe refund failed: {refund.FailureReason}");

            return refund;
        }
    }
}
