using Market.Application.Modules.Reports.Books;
using Market.Application.Modules.Reports.Orders;
namespace Market.API.Controllers;

[ApiController]
[Authorize(Policy = "Management")] //admin i manager
[Route("[controller]")]
public class ReportsController(ISender sender) : ControllerBase
{
    [HttpGet("orders-report")]
    public async Task<IActionResult> GenerateOrdersReport([FromQuery] GenerateOrdersReportQuery query, CancellationToken ct)
    {
        var pdf = await sender.Send(query, ct);
        return File(pdf, "application/pdf", $"narudzbe-{query.DateFrom:yyyyMMdd}-{query.DateTo:yyyyMMdd}.pdf");
    }

    [HttpGet("books-report")]
    public async Task<IActionResult> GenerateBooksReport([FromQuery] GenerateBooksReportQuery query, CancellationToken ct)
    {
        var pdf = await sender.Send(query, ct);
        return File(pdf, "application/pdf", $"knjiga-{query.DateFrom:yyyyMMdd}-{query.DateTo:yyyyMMdd}.pdf");
    }
}
