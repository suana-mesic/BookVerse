using System.ComponentModel.DataAnnotations;
using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Infrastructure.Common
{
    // Concrete options class bound from the "Payment" section of appsettings.json.
    // The DataAnnotations below are checked at application startup (see Program.cs ValidateOnStart)
    // so a missing or malformed Currency stops the app from booting instead of failing later
    // on the first Stripe call.
    public class PaymentOptions : IPaymentOptions
    {
        // Required: the app cannot create a PaymentIntent without a currency.
        // StringLength enforces ISO 4217 length (3 characters), e.g. "bam", "eur", "usd".
        [Required(AllowEmptyStrings = false, ErrorMessage = "Payment:Currency must be set in configuration.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Payment:Currency must be a 3-letter ISO 4217 code.")]
        public string Currency { get; set; } = string.Empty;
    }
}
