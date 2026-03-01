using Market.Application.Modules.Shopping.Coupons.Commands;
using Market.Application.Modules.Shopping.Coupons.Queries.List;
using Market.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon;
using SixLabors.ImageSharp;

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

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCouponCommand request, CancellationToken ct)
    {
        var result = await sender.Send(request, ct);
        return Ok(result);
    }

    [HttpGet("form-config/{couponType}")]
    public IActionResult GetFormConfig(string couponType)
    {
        var commonFields = new[]
        {
            new {name="name", label="Naziv kupona", type="text", required=true},
            new {name="promotionCode", label="Promocijski kod", type="text", required=true},
            new {name="startDate", label="Datum početka", type="date", required=true},
            new {name="endDate", label="Datum isteka", type="date", required=true},
            new {name="description", label="Opis", type="text", required=false}
        };

        var discountField = couponType == "percent" ?
            new { name = "percentOff", label = "Popust (%)", type = "number", required = true } :
              new { name = "amountOff", label = "Popust (KM)", type = "number", required = true };
        var allFields = commonFields.Prepend(discountField);
        return Ok(allFields);
    }
}
