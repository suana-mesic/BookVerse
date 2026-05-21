using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Sales.Orders.Commands.ChangeStatus;



/// <summary>
/// Handler for changing order status
/// </summary>
public class ChangeOrderStatusCommandHandler(IAppDbContext db, IOrderNotificationService notificationService) : IRequestHandler<ChangeOrderStatusCommand>
{
    public async Task Handle(ChangeOrderStatusCommand request, CancellationToken ct)
    {
        var order = await db.Orders
            .Include(x => x.OrderStatus)
            .FirstOrDefaultAsync(o => o.Id == request.Id, ct)
            ?? throw new BookVerseNotFoundException($"{nameof(Orders)}, {request.Id}");

        // Validate status transition
        ValidateStatusTransition(order.OrderStatus.StatusName, request.NewStatus);

        //// Update status
        order.OrderStatusId = (int)request.NewStatus;

        if (request.NewStatus == OrderStatusType.Shipped)
        {
            // The old generator loaded every "TRK..." row from Orders into memory, parsed the
            // numeric suffix and took the max. That gets slower with every shipment and is also
            // racy: two staff members marking orders Shipped at the same time can pick the same
            // next number.
            //
            // Replacement: a GUID's first 12 hex characters. "N" format strips dashes, so the
            // result is plain hex like "9b1deb4d3b7d". 12 hex chars = 48 bits of randomness,
            // which gives effectively no chance of a collision in this app's volume, and we
            // never have to query the DB to generate one.
            order.TrackingNumber = $"TRK{Guid.NewGuid().ToString("N").Substring(0, 12).ToUpperInvariant()}";
        }

        await db.SaveChangesAsync(ct);

        //Sending notification to user
        await notificationService.NotifyOrderStatusChangedAsync(order.Id, order.TrackingNumber, order.UserId.ToString(), request.NewStatus, ct);
    }

    private static void ValidateStatusTransition(OrderStatusType current, OrderStatusType next)
    {
        // Allowed staff status transitions.
        //
        // IMPORTANT: Cancelled is intentionally NOT in this list, even though the order workflow
        // does have a Cancelled state. The reason: a proper cancellation must also issue a Stripe
        // refund and restore the inventory that was decremented on payment. That logic currently
        // lives ONLY in CancelOrderCommandHandler (the customer endpoint). If we let staff cancel
        // here, the money would stay at Stripe and stock would stay decremented, leaving the system
        // in an inconsistent state.
        //
        // Until that logic is extracted into a shared service that both handlers can call,
        // staff cannot cancel via this endpoint. Customers can still cancel their own orders
        // through CancelOrderCommandHandler, which does the refund + restore correctly.
        //
        // Draft and PaymentPending have no manual outlet at all - they are managed by the webhook
        // (payment success/failure) and by OrderCleanupBackgroundService (expiry sweep).
        // PaymentFailed, Expired and Cancelled are terminal: no transitions out.
        var validTransitions = new Dictionary<OrderStatusType, OrderStatusType[]>
        {
            { OrderStatusType.Draft, Array.Empty<OrderStatusType>() },
            { OrderStatusType.PaymentPending, Array.Empty<OrderStatusType>() },
            { OrderStatusType.Paid, new[] { OrderStatusType.Packed } },
            { OrderStatusType.Packed, new[] { OrderStatusType.Shipped } },
            { OrderStatusType.Shipped, Array.Empty<OrderStatusType>() },
            { OrderStatusType.Cancelled, Array.Empty<OrderStatusType>() },
            { OrderStatusType.PaymentFailed, Array.Empty<OrderStatusType>() },
            { OrderStatusType.Expired, Array.Empty<OrderStatusType>() }
        };

        // BusinessRuleCodes give the frontend a stable identifier to look up the localized
        // message; the English text below is the fallback (and what shows up in logs).
        if (!validTransitions.ContainsKey(current))
        {
            throw new BookVerseBusinessRuleException(BusinessRuleCodes.ORDER_STATUS_UNKNOWN, $"Unknown current status: {current}");
        }

        if (!validTransitions[current].Contains(next))
        {
            throw new BookVerseBusinessRuleException(BusinessRuleCodes.ORDER_STATUS_TRANSITION_INVALID,
                $"Invalid status transition from {current} to {next}. " +
                $"Allowed transitions: {string.Join(", ", validTransitions[current])}");
        }
    }
}