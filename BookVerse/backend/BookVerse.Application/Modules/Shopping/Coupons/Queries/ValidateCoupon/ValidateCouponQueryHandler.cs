using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

// IAppCurrentUser is injected so the MaxUses check is per-customer, matching the rule
// in CouponValidationService. Same coupon code can be redeemed by many customers, but
// each customer is capped at MaxUses redemptions of their own.
public class ValidateCouponQueryHandler(
    IAppDbContext context,
    IAppCurrentUser currentUser,
    TimeProvider time)
    : IRequestHandler<ValidateCouponQuery, ValidateCouponQueryDto>
{
    //user enters a coupon code; if found, it is returned as an object from the database
    //if not found, an exception is thrown
    public async Task<ValidateCouponQueryDto> Handle(ValidateCouponQuery request, CancellationToken ct)
    {
        // TimeProvider so unit tests can pin "today" and assert the date-window filter behavior.
        var today = time.GetUtcNow().UtcDateTime.Date;

        var coupon = await context.Coupons
            .AsNoTracking()
            .Where(x => !x.IsDeleted
                && x.PromotionCode.ToLower() == request.PromotionCode.ToLower()
                && x.StartDate.Date <= today
                && x.EndDate.Date >= today)
            .Select(x => new
            {
                x.Id,
                x.Name,
                x.PromotionCode,
                x.AmountOff,
                x.PercentOff,
                x.Description,
                x.MinOrderAmount,
                x.MaxUses
            })
            .FirstOrDefaultAsync(ct);

        if (coupon is null)
            throw new BookVerseNotFoundException("Coupon was not found or has expired.");

        // Per-customer MaxUses check: count how many of THIS user's past non-cancelled
        // orders already carry this coupon. If we hit the cap, treat the coupon as if
        // it does not exist for this user (same 404 the frontend already handles).
        if (coupon.MaxUses.HasValue)
        {
            // Use BookVerseUnauthorizedException (401) instead of NotFound so the frontend's
            // auth interceptor can react correctly. Returning 404 here masks an auth failure
            // as "coupon not found" and prevents the refresh/logout flow from kicking in.
            var userId = currentUser.UserId
                ?? throw new BookVerseUnauthorizedException("User is not logged in.");

            var usedCount = await context.Orders
                .Where(o => !o.IsDeleted
                    && o.UserId == userId
                    && o.OrderStatusId != (int)OrderStatusType.Draft
                    && o.OrderStatusId != (int)OrderStatusType.Cancelled
                    && o.Coupons.Any(c => c.Id == coupon.Id))
                .CountAsync(ct);

            if (usedCount >= coupon.MaxUses.Value)
                throw new BookVerseBusinessRuleException(
                    BusinessRuleCodes.COUPON_MAX_USES_REACHED,
                    $"Coupon '{coupon.PromotionCode}' has reached its maximum number of uses for your account.");
        }

        return new ValidateCouponQueryDto
        {
            Id = coupon.Id,
            Name = coupon.Name,
            PromotionCode = coupon.PromotionCode,
            AmountOff = coupon.AmountOff,
            PercentOff = coupon.PercentOff,
            Description = coupon.Description,
            MinOrderAmount = coupon.MinOrderAmount
        };
    }
}
