using Market.Application.Modules.Shopping.Cart.Commands.Create;
using Market.Application.Modules.Shopping.Cart.Commands.Delete;
using Market.Application.Modules.Shopping.Cart.Commands.Update;
using Market.Application.Modules.Shopping.Cart.Commands.SaveForLater;
using Market.Application.Modules.Shopping.Cart.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class CartController(IMediator mediator) : ControllerBase
{
    [HttpGet]

    public async Task<IActionResult> GetCart([FromQuery] string? language, CancellationToken ct)
    {
        var result = await mediator.Send(new ListCartQuery { Language = language }, ct);
        return Ok(result);
    }

    [HttpPost]

    public async Task<IActionResult> AddToCart([FromBody] CreateCartItemCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }

    [HttpPut("quantity")]

    public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartItemCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }

    [HttpPut("save-for-later")]

    public async Task<IActionResult> SaveForLater([FromBody] SaveForLaterCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }

    [HttpDelete]

    public async Task<IActionResult> RemoveFromCart([FromBody] DeleteCartItemCommand command, CancellationToken ct)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }
}