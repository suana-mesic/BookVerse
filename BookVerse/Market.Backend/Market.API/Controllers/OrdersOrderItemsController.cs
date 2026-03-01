using Market.Application.Modules.Catalog.Book.Queries.List;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
namespace Market.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrdersOrderItemsController(ISender sender) : ControllerBase
{
    //Za pregled liste narudžbi
    [HttpGet]
    public async Task<PageResult<ListOrderOrderItemsQueryDto>> List([FromQuery] ListOrderOrderItemsQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    // Poziva se kada korisnik klikne na "Potvrdi narudžbu" u checkout komponenti.
    [HttpPost]
    public async Task<ActionResult<CreateOrderOrderItemsCommandDto>> Create(
    [FromBody] CreateOrderOrderItemsCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    // Poziva se automatski od strane Stripea nakon što korisnik plati.
    [HttpPost("stripe-webhook")]
    [AllowAnonymous]
    public async Task<IActionResult> StripeWebhook(CancellationToken ct)
    {
        using var reader = new StreamReader(Request.Body);
        var payload = await reader.ReadToEndAsync(ct);
        var signature = Request.Headers["Stripe-Signature"].ToString();

        await sender.Send(new StripeWebhookCommand
        {
            Payload = payload,
            StripeSignature = signature
        }, ct);

        return Ok();
    }
}
