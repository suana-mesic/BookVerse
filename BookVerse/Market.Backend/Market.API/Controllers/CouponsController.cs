using Market.Application.Modules.Shopping.Coupons.Queries.List;
using Market.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

namespace Market.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class CouponsController(ISender sender) : ControllerBase
{
    [HttpGet("validate-coupon/{code}")]
    public async Task<IActionResult> ValidateCoupon(string code, CancellationToken ct)
    {
        var result = await sender.Send(new ValidateCouponQuery { PromotionCode = code }, ct);
        return Ok(result);
    }

    [HttpGet]
    public async Task<List<ListCouponsQueryDto>> List(CancellationToken ct)
    {
        var result = await sender.Send(new ListCouponsQuery(), ct);
        return result;
    }
}
