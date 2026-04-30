using BookVerse.Application.Modules.Shopping.Coupons.Commands;
using BookVerse.Application.Modules.Shopping.Coupons.Queries.GetFormConfig;
using BookVerse.Application.Modules.Shopping.Coupons.Queries.List;
using BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;

namespace BookVerse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponsController(ISender sender) : ControllerBase
{
    [HttpGet("validate-coupon/{code}")]
    [Authorize(Policy = "Customer")]

    public async Task<IActionResult> ValidateCoupon(string code, CancellationToken ct)
    {
        var result = await sender.Send(new ValidateCouponQuery { PromotionCode = code }, ct);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Policy = "Management")]

    public async Task<List<ListCouponsQueryDto>> List(CancellationToken ct)
    {
        var result = await sender.Send(new ListCouponsQuery(), ct);
        return result;
    }

    [HttpPost]
    [Authorize(Policy = "Management")]

    public async Task<ActionResult<int>> Create([FromBody] CreateCouponCommand request, CancellationToken ct)
    {
        var result = await sender.Send(request, ct);
        return Ok(result);
    }

    [HttpGet("form-config/{couponType}")]
    [Authorize(Policy = "Management")]
    public async Task<IActionResult> GetFormConfig(string couponType, CancellationToken ct)
    {
        var result = await sender.Send(new GetFormConfigQuery { CouponType = couponType }, ct);
        return Ok(result);
    }
}
