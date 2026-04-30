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
            var trkNumbers = await db.Orders
                .Where(o => o.TrackingNumber.StartsWith("TRK"))
                .Select(o => o.TrackingNumber)
                .ToListAsync(ct);

            int nextNumber = trkNumbers
                .Select(t => int.TryParse(t[3..], out int n) ? n : 0)
                .DefaultIfEmpty(0)
                .Max() + 1;

            order.TrackingNumber = $"TRK{nextNumber:D4}";
        }

        await db.SaveChangesAsync(ct);

        //Sending notification to user
        await notificationService.NotifyOrderStatusChangedAsync(order.Id, order.TrackingNumber, order.UserId.ToString(), request.NewStatus, ct);
    }

    private static void ValidateStatusTransition(OrderStatusType current, OrderStatusType next)
    {
        // Define valid transitions
        var validTransitions = new Dictionary<OrderStatusType, OrderStatusType[]>
        {
            { OrderStatusType.Draft, new[] { OrderStatusType.Cancelled } },
            { OrderStatusType.Paid, new[] { OrderStatusType.Packed, OrderStatusType.Cancelled } },
            { OrderStatusType.Packed, new[] { OrderStatusType.Shipped, OrderStatusType.Cancelled } },
            { OrderStatusType.Cancelled, Array.Empty<OrderStatusType>() }
        };

        if (!validTransitions.ContainsKey(current))
        {
            throw new BookVerseBusinessRuleException("123", $"Unknown current status: {current}");
        }

        if (!validTransitions[current].Contains(next))
        {
            throw new BookVerseBusinessRuleException("323",
                $"Invalid status transition from {current} to {next}. " +
                $"Allowed transitions: {string.Join(", ", validTransitions[current])}");
        }
    }
}