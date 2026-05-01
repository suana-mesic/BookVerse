namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

public class ValidateCouponQueryHandler(IAppDbContext context)
    : IRequestHandler<ValidateCouponQuery, ValidateCouponQueryDto>
{
    //user enters a coupon code; if found, it is returned as an object from the database
    //if not found, an exception is thrown
    public async Task<ValidateCouponQueryDto> Handle(ValidateCouponQuery request, CancellationToken ct)
    {
        var today = DateTime.UtcNow.Date;

        var coupon = await context.Coupons
            .AsNoTracking()
            .Where(x => !x.IsDeleted
                && x.PromotionCode.ToLower() == request.PromotionCode.ToLower()
                && x.StartDate.Date <= today
                && x.EndDate.Date >= today)
            .Select(x => new ValidateCouponQueryDto
            {
                Id = x.Id,
                Name = x.Name,
                PromotionCode = x.PromotionCode,
                AmountOff = x.AmountOff,
                PercentOff = x.PercentOff,
                Description = x.Description
            })
            .FirstOrDefaultAsync(ct);

        if (coupon is null)
            throw new BookVerseNotFoundException("Coupon was not found or has expired.");

        return coupon;
    }
}
