namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

public class ValidateCouponQuery : IRequest<ValidateCouponQueryDto>
{
    public string PromotionCode { get; set; }
}