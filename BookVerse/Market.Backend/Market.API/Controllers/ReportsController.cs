using Market.Application.Modules.Reports.Orders;
namespace Market.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class ReportsController(ISender sender) : ControllerBase
{
    [HttpGet("orders-report")]
    [AllowAnonymous]
    public async Task<IActionResult> List([FromQuery] GenerateOrdersReportQuery query, CancellationToken ct)
    {
        var pdf = await sender.Send(query, ct);
        return File(pdf, "application/pdf", $"narudzbe-{query.DateFrom:yyyyMMdd}-{query.DateTo:yyyyMMdd}.pdf");
    }
}
