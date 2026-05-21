using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.CancelOrder;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.StripeWebhook;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.List;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.EnsurePaymentIntent;
using BookVerse.Domain.Entities.Shopping;
using System.IO.Pipelines;
using System.Text;
namespace BookVerse.API.Controllers;

[ApiController]
// Renamed from "/OrdersOrderItems" to the cleaner public path "/api/orders".
// The class name still says OrdersOrderItems because it handles both Orders and OrderItems
// internally, but the URL no longer leaks that internal split.
[Route("api/orders")]
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

    [HttpGet("{id:int}")]
    [Authorize(Policy = "Staff")]

    public async Task<GetOrderByIdQueryDto> List([FromRoute] int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetOrderByIdQuery { Id = id }, ct);
        return result;
    }

    // Called when the user clicks "Confirm order" in the checkout component.
    [HttpPost]
    [Authorize(Policy = "Customer")]
    public async Task<ActionResult<CreateOrderOrderItemsCommandDto>> Create(
    [FromBody] CreateOrderOrderItemsCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    // Called by staff when they want to change the order status
    [HttpPut("{id:int}/change-status")]
    [Authorize(Policy = "Staff")]
    public async Task Create(
   [FromRoute] int id, [FromBody] ChangeStatusRequest request, CancellationToken ct)
    {
        await sender.Send(new ChangeOrderStatusCommand { Id = id, NewStatus = request.NewStatus }, ct);
    }

    // Called from user-orders.component.ts when the user wants to (re)pay an order that is in PaymentPending.
    // Returns PublishableKey, ClientSecret and TotalPrice so the Stripe form on the frontend can open.
    // POST because the handler may create a new PaymentIntent on Stripe and persist its id on the order
    // (state-changing operation, not a pure read), which is why it lives in Commands now and not Queries.
    [HttpPost("{id}/payment-intent")]
    [Authorize(Policy = "Customer")]
    public async Task<IActionResult> EnsurePaymentIntent(int id)
    {
        var result = await sender.Send(new EnsurePaymentIntentForOrderCommand { OrderId = id });
        return Ok(result);
    }
    

    // Called automatically by Stripe after the user pays.
    [HttpPost("stripe-webhook")]
    [AllowAnonymous] // this must be enabled because Stripe does not send JWT tokens
    public async Task<IActionResult> StripeWebhook(CancellationToken ct)
    {
        // We need the EXACT raw bytes Stripe sent, because the Stripe-Signature header is an
        // HMAC over those bytes. A StreamReader runs the body through UTF-8 decoding first,
        // which would silently mangle anything that isn't valid UTF-8 and break signature
        // verification. Request.BodyReader (PipeReader) hands us the raw bytes directly,
        // and the request-logging middleware already enabled buffering so we can re-read
        // from position 0.
        var bodyBytes = await ReadRequestBodyBytesAsync(Request.Body, ct);
        var payload = Encoding.UTF8.GetString(bodyBytes);
        var signature = Request.Headers["Stripe-Signature"].ToString();

        await sender.Send(new StripeWebhookCommand
        {
            Payload = payload,
            StripeSignature = signature
        }, ct);

        return Ok();
    }

    // Reads the request body into a byte[] via PipeReader. We loop until ReadResult.IsCompleted
    // because a single ReadAsync call is NOT guaranteed to return the full body in one shot.
    // The returned array contains the bytes exactly as Stripe sent them, which is what the
    // signature check needs.
    private static async Task<byte[]> ReadRequestBodyBytesAsync(Stream body, CancellationToken ct)
    {
        var reader = PipeReader.Create(body);
        using var buffer = new MemoryStream();
        while (true)
        {
            var result = await reader.ReadAsync(ct);
            foreach (var segment in result.Buffer)
                buffer.Write(segment.Span);

            reader.AdvanceTo(result.Buffer.End);

            if (result.IsCompleted)
                break;
        }
        await reader.CompleteAsync();
        return buffer.ToArray();
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
