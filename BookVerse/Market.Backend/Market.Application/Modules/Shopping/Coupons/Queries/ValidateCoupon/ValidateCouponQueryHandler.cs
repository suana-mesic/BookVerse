namespace Market.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

public class ValidateCouponQueryHandler(IAppDbContext context)
    : IRequestHandler<ValidateCouponQuery, ValidateCouponQueryDto>
{
    //korisnik unosi kupon, ako je pronađen vraća se kao objekat iz baze
    //ako nije pronađen, baca se exception
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
            throw new MarketNotFoundException("Kupon nije pronađen ili je istekao.");

        return coupon;
    }
}