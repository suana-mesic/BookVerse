using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.PaymentIntentForOrder;
using BookVerse.Domain.Entities.Shopping;
namespace BookVerse.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersOrderItemsController(ISender sender) : ControllerBase
{
    // When the user wants to view their own orders -> DONE
    [HttpGet ("my-orders")]
    [Authorize(Policy = "Customer")]
    public async Task<PageResult<ListOrdersForUserQueryDto>> ListOrdersForUser([FromQuery] ListOrdersForUserQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    // For viewing the list of all users' orders -> DONE
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
    // Called when the user clicks "Confirm order" in the checkout component.
    [HttpPost]
    [Authorize(Policy = "Customer")]
    public async Task<ActionResult<CreateOrderOrderItemsCommandDto>> Create(
    [FromBody] CreateOrderOrderItemsCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    // -> DONE
    // Called by staff when they want to change the order status
    [HttpPut("{id:int}/change-status")]
    [Authorize(Policy = "Staff")]
    public async Task Create(
   [FromRoute] int id, [FromBody] ChangeStatusRequest request, CancellationToken ct)
    {
        await sender.Send(new ChangeOrderStatusCommand { Id = id, NewStatus = request.NewStatus }, ct);
    }

    // Called when the order is already in Draft status and the user wants to pay for it
    // from the user orders module (user-orders.component.ts)
    // this endpoint returns: PublishableKey, ClientSecret and TotalPrice
    // these are required for the Stripe form on the frontend to open at all
    // without them, it cannot be displayed
    [HttpGet("{id}/payment-intent")]
    [Authorize(Policy = "Customer")]
    public async Task<IActionResult> GetPaymentIntent(int id)
    {
        var result = await sender.Send(new GetPaymentIntentForOrderQuery { OrderId = id });
        return Ok(result);
    }
    

    // Called automatically by Stripe after the user pays.
    [HttpPost("stripe-webhook")]
    [AllowAnonymous] // this must be enabled because Stripe does not send JWT tokens
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

    // Called when the user wants to cancel an order
    [HttpPost("{id}/cancel")]
    [Authorize(Policy = "Customer")]
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
