using BookVerse.Application.Abstractions;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Services
{
    // Implementation of ICouponValidationService. All "is this coupon usable right now?"
    // rules live here so the order handler never needs to know about them.
    //
    // IAppCurrentUser is injected so the MaxUses rule counts THIS user's past redemptions
    // only - the limit is per-customer, not a global "first N customers" cap.
    public sealed class CouponValidationService(
        IAppDbContext context,
        IAppCurrentUser currentUser,
        TimeProvider time) : ICouponValidationService
    {
        // Business cap: an order can carry at most this many DIFFERENT coupons.
        // Together with the "no duplicate" rule below and the "combined discount cannot exceed
        // subtotal" rule in CalculateDiscount, this is the concrete "combination rule"
        // the professor asked for in tačka 1.
        public const int MaxCouponsPerOrder = 2;

        public async Task<List<Coupons>> ValidateAndLoadAsync(IReadOnlyCollection<int> couponIds, decimal subTotal, CancellationToken ct)
        {
            // Empty input means the user did not apply any coupon, so there is nothing to validate.
            if (couponIds == null || couponIds.Count == 0)
                return new List<Coupons>();

            // Combination rule, part 1: cap the number of coupons per order. This protects against
            // stacking a long list of small discounts and also keeps the UX simple - the frontend
            // mirrors the same limit on the checkout page.
            if (couponIds.Count > MaxCouponsPerOrder)
                throw new BookVerseConflictException($"At most {MaxCouponsPerOrder} coupons can be applied per order.");

            // Combination rule, part 2: a coupon must not appear twice in the same order.
            var distinctCouponIds = couponIds.Distinct().ToList();
            if (distinctCouponIds.Count != couponIds.Count)
                throw new BookVerseConflictException("The same coupon cannot be applied more than once.");

            // Use TimeProvider so unit tests can pin "today" to a fixed value.
            var today = time.GetUtcNow().UtcDateTime.Date;

            // Step 1: every requested coupon must exist and not be soft-deleted.
            var foundCoupons = await context.Coupons
                .Where(x => distinctCouponIds.Contains(x.Id) && !x.IsDeleted)
                .ToListAsync(ct);

            if (foundCoupons.Count != distinctCouponIds.Count)
                throw new BookVerseConflictException("One or more coupons do not exist.");

            // Step 2: every coupon must be inside its validity window (StartDate <= today <= EndDate).
            var coupons = foundCoupons
                .Where(x => x.StartDate.Date <= today && x.EndDate.Date >= today)
                .ToList();

            if (coupons.Count != distinctCouponIds.Count)
                throw new BookVerseConflictException("One or more coupons are expired or not yet active.");

            // Step 3: each coupon may require a minimum subtotal before it can be applied.
            foreach (var coupon in coupons)
            {
                if (coupon.MinOrderAmount.HasValue && subTotal < coupon.MinOrderAmount.Value)
                    throw new BookVerseConflictException(
                        $"Coupon '{coupon.PromotionCode}' requires a minimum order amount of {coupon.MinOrderAmount.Value}.");
            }

            // Step 4: per-customer usage limit. Count how many times THIS user has already
            // redeemed each coupon across their non-cancelled orders. MaxUses is the limit
            // per individual customer, not a global cap - so MaxUses=2 means the same user
            // can apply this coupon in at most 2 of their own orders.
            // An order participates in the count as soon as it leaves Draft, so a redemption
            // is only "spent" once payment succeeds.
            // Use BookVerseUnauthorizedException (401) instead of NotFound: a missing user
            // identity is an auth failure, not a "row not found" - returning 401 lets the
            // frontend's auth interceptor handle refresh/logout consistently across endpoints.
            var userId = currentUser.UserId
                ?? throw new BookVerseUnauthorizedException("User is not logged in.");

            var couponUsage = await context.Orders
                .Where(o => !o.IsDeleted
                    && o.UserId == userId
                    && o.OrderStatusId != (int)OrderStatusType.Draft
                    && o.OrderStatusId != (int)OrderStatusType.Cancelled
                    && o.Coupons.Any(c => distinctCouponIds.Contains(c.Id)))
                .SelectMany(o => o.Coupons)
                .Where(c => distinctCouponIds.Contains(c.Id))
                .GroupBy(c => c.Id)
                .Select(g => new { CouponId = g.Key, UsedCount = g.Count() })
                .ToListAsync(ct);

            foreach (var coupon in coupons)
            {
                if (!coupon.MaxUses.HasValue) continue;

                var usedCount = couponUsage.FirstOrDefault(u => u.CouponId == coupon.Id)?.UsedCount ?? 0;
                if (usedCount >= coupon.MaxUses.Value)
                    throw new BookVerseBusinessRuleException(
                        BusinessRuleCodes.COUPON_MAX_USES_REACHED,
                        $"Coupon '{coupon.PromotionCode}' has reached its maximum number of uses for your account.");
            }

            return coupons;
        }

        public decimal CalculateDiscount(IEnumerable<Coupons> coupons, decimal subTotal)
        {
            // Sum the per-coupon discount (either a fixed amount or a percentage of subTotal).
            decimal discountAmount = 0m;
            foreach (var coupon in coupons)
            {
                decimal couponDiscount = 0m;
                if (coupon.AmountOff.HasValue)
                    couponDiscount = coupon.AmountOff.Value;
                else if (coupon.PercentOff.HasValue)
                    couponDiscount = subTotal * (coupon.PercentOff.Value / 100);

                discountAmount += couponDiscount;
            }

            // Cap the combined discount at subTotal: even with stacked coupons the order can
            // never become free or negative through this code path.
            if (discountAmount > subTotal)
                throw new BookVerseConflictException("Combined coupon discount exceeds the order subtotal.");

            return discountAmount;
        }
    }
}
