using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder;
using Market.Domain.Entities.Shopping;
namespace Market.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrdersOrderItemsController(ISender sender) : ControllerBase
{
    //Kada korisnik želi pregledati vlastite narudžbe -> DONE
    [HttpGet ("my-orders")]
    public async Task<PageResult<ListOrdersForUserQueryDto>> ListOrdersForUser([FromQuery] ListOrdersForUserQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    //Za pregled liste narudžbi svih korisnika -> DONE
    [HttpGet]
    [Authorize(Policy = "Staff")]
    public async Task<PageResult<ListOrderOrderItemsQueryDto>> ListOrdersForAdmin([FromQuery] ListOrderOrderItemsQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    // -> DONE
    [HttpGet("{id:int}")]
    [Authorize(Policy = "Staff")]

    public async Task<GetOrderByIdQueryDto> List([FromRoute] int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetOrderByIdQuery { Id = id }, ct);
        return result;
    }

    // -> DONE
    // Poziva se kada korisnik klikne na "Potvrdi narudžbu" u checkout komponenti.
    [HttpPost]
    public async Task<ActionResult<CreateOrderOrderItemsCommandDto>> Create(
    [FromBody] CreateOrderOrderItemsCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    // -> DONE
    //Poziva osoblje kada želi promijeniti status narudžbe
    [HttpPut("{id:int}/change-status")]
    [Authorize(Policy = "Staff")]
    public async Task Create(
   [FromRoute] int id, [FromBody] ChangeStatusRequest request, CancellationToken ct)
    {
        await sender.Send(new ChangeOrderStatusCommand { Id = id, NewStatus = request.NewStatus }, ct);
    }

    // Poziva se kada je narudžba već u statusu Draft i kada korisnik želi da je plati
    // iz modula za pregled svih narudžbi (user-orders.component.ts)
    // ovaj endpoint vraća: PublishableKey, ClientSecret i TotalPrice 
    // ti elementi su potrebni da bi se Stripe forma na frontendu uopšte otvorila
    // dakle, bez njih se ona ne može prikazati
    [HttpGet("{id}/payment-intent")]
    public async Task<IActionResult> GetPaymentIntent(int id)
    {
        var result = await sender.Send(new GetPaymentIntentForOrderQuery { OrderId = id });
        return Ok(result);
    }
    

    // Poziva se automatski od strane Stripea nakon što korisnik plati.
    [HttpPost("stripe-webhook")]
    [AllowAnonymous] //ovo mora biti omogućeno jer Stripe ne šalje JWT tokene
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

    //Poziva user kada želi otkazati narudžbu
    [HttpPost("{id}/cancel")]
    public async Task<IActionResult> CancelOrder(int id)
    {
        await sender.Send(new CancelOrderCommand { OrderId = id });
        return Ok();
    }
}

public class ChangeStatusRequest
{
    public OrderStatusType NewStatus { get; set; }
}