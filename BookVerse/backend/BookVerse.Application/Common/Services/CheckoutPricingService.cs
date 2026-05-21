using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Services
{
    // Implementation of ICheckoutPricingService. Pure math, no DB, no Stripe.
    public sealed class CheckoutPricingService : ICheckoutPricingService
    {
        public CheckoutPricingResult Calculate(IEnumerable<CartItems> cartItems, decimal shippingPrice, decimal discountAmount)
        {
            // Sum every cart line: book price at time of order * quantity.
            var subTotal = cartItems.Sum(x => x.Book.Price * x.Quantity);

            // Total = items + shipping - discount. Discount was already validated against
            // subtotal by CouponValidationService, so this should never go negative in
            // practice. We still guard the result as a safety net.
            var totalPrice = subTotal + shippingPrice - discountAmount;

            if (totalPrice < 0)
                throw new BookVerseConflictException("Total price cannot be negative after applying coupons.");

            return new CheckoutPricingResult(subTotal, shippingPrice, discountAmount, totalPrice);
        }

        public long ToStripeAmount(decimal amount)
        {
            // Multiply by 100 to convert BAM (or any 2-decimal currency) into Stripe's smallest unit.
            // AwayFromZero rounding keeps the value we send and the value we compare in the webhook
            // in agreement even for fractional fillers like 7.999 -> 800 cents (not 799).
            return (long)Math.Round(amount * 100, MidpointRounding.AwayFromZero);
        }
    }
}
