using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Interfaces
{
    // Final money breakdown for an order. SubTotal is items only, ShippingPrice is the
    // delivery fee (0 for store pickup), DiscountAmount is the combined coupon discount
    // and TotalPrice is what the customer actually pays.
    public record CheckoutPricingResult(decimal SubTotal, decimal ShippingPrice, decimal DiscountAmount, decimal TotalPrice);

    // Pure pricing logic pulled out of CreateOrderOrderItemsCommandHandler so the handler
    // only orchestrates and the math can be unit tested in isolation.
    public interface ICheckoutPricingService
    {
        // Adds up the items in the cart, the shipping fee and subtracts the discount.
        // Throws BookVerseConflictException if the total ends up negative (a combined coupon
        // discount larger than the subtotal would otherwise produce a negative charge).
        CheckoutPricingResult Calculate(IEnumerable<CartItems> cartItems, decimal shippingPrice, decimal discountAmount);

        // Converts a decimal money amount (e.g. 9.99 BAM) to Stripe's smallest-unit long (999 cents).
        // The same rounding (AwayFromZero) is used when creating the PaymentIntent and when comparing
        // the amount in the webhook so both sides always agree.
        long ToStripeAmount(decimal amount);
    }
}
