using BookVerse.Application.Modules.Reports.Books;
using BookVerse.Application.Modules.Reports.Orders;
namespace BookVerse.API.Controllers;

[ApiController]
[Authorize(Policy = "Management")] // admin and manager
[Route("api/reports")]
public class ReportsController(ISender sender) : ControllerBase
{
    [HttpGet("orders-report")]
    public async Task<IActionResult> GenerateOrdersReport([FromQuery] GenerateOrdersReportQuery query, CancellationToken ct)
    {
        var pdf = await sender.Send(query, ct);
        return File(pdf, "application/pdf", $"orders-{query.DateFrom:yyyyMMdd}-{query.DateTo:yyyyMMdd}.pdf");
    }

    [HttpGet("books-report")]
    public async Task<IActionResult> GenerateBooksReport([FromQuery] GenerateBooksReportQuery query, CancellationToken ct)
    {
        var pdf = await sender.Send(query, ct);
        return File(pdf, "application/pdf", $"books-{query.DateFrom:yyyyMMdd}-{query.DateTo:yyyyMMdd}.pdf");
    }
}
