namespace BookVerse.Application.Common.Interfaces
{
    // Typed options for payment-related settings (currently just the currency code).
    // Handlers depend on this interface so they never see a hardcoded "bam" again - the value
    // comes from appsettings.json and can be changed per environment without touching code.
    public interface IPaymentOptions
    {
        // ISO 4217 currency code (e.g. "bam", "eur", "usd") used for every Stripe PaymentIntent.
        string Currency { get; }
    }
}
