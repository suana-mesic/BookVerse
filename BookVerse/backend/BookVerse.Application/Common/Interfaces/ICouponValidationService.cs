using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Interfaces
{
    // Owns every coupon-related rule used during checkout (existence, date window,
    // minimum order amount, usage limit and combination rules). Pulled out of
    // CreateOrderOrderItemsCommandHandler so the handler only orchestrates and the
    // rules can be unit tested in isolation.
    public interface ICouponValidationService
    {
        // Validates the requested coupon ids against the given subtotal and returns the
        // matched, still-active coupon entities ready to be attached to the order.
        // Throws BookVerseConflictException on any rule violation.
        Task<List<Coupons>> ValidateAndLoadAsync(IReadOnlyCollection<int> couponIds, decimal subTotal, CancellationToken ct);

        // Sums per-coupon discounts (AmountOff or PercentOff) and caps the total at subTotal,
        // so combined coupons can never make the order free or negative.
        decimal CalculateDiscount(IEnumerable<Coupons> coupons, decimal subTotal);
    }
}
