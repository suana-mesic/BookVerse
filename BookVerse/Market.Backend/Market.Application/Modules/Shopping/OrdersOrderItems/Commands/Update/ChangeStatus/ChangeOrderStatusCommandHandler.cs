using Market.Application.Common.Interfaces;
using Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Update.ChangeStatus;
using Market.Domain.Entities.Shopping;

namespace Market.Application.Modules.Sales.Orders.Commands.ChangeStatus;



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
            ?? throw new MarketNotFoundException($"{nameof(Orders)}, {request.Id}");

        // Validate status transition
        ValidateStatusTransition(order.OrderStatus.StatusName, request.NewStatus);

        //// Update status
        order.OrderStatusId = (int)request.NewStatus;


        //// If marking as paid, set paid date
        //if (request.NewStatus == OrderStatusType.Paid && !order.PaidAtUtc.HasValue)
        //{
        //    order.PaidAtUtc = DateTime.UtcNow;
        //}

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
            throw new MarketBusinessRuleException("123", $"Unknown current status: {current}");
        }

        if (!validTransitions[current].Contains(next))
        {
            throw new MarketBusinessRuleException("323",
                $"Invalid status transition from {current} to {next}. " +
                $"Allowed transitions: {string.Join(", ", validTransitions[current])}");
        }
    }
}