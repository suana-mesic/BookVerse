namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.GetFormConfig;

public class GetFormConfigQuery : IRequest<List<GetFormConfigQueryDto>>
{
    public string CouponType { get; set; }
}
