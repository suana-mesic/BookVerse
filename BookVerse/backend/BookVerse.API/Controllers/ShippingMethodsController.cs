using BookVerse.Application.Modules.Shopping.ShippingMethods.Queries.List;

namespace BookVerse.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class ShippingMethodsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetShippingMethods([FromQuery] string? language, CancellationToken ct)
    {
        var result = await sender.Send(new ListShippingMethodsQuery { Language = language }, ct);
        return Ok(result);
    }
}
