using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Microsoft.AspNetCore.SignalR;

namespace BookVerse.API.Hubs
{
    public class OrderNotificationService(
        IHubContext<StaffOrderHub> staffOrderHub,
        IHubContext<UserOrderHub> userOrderHub) : IOrderNotificationService
    {
        public async Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, string customerName, CancellationToken ct)
        {
            await staffOrderHub.Clients.Group("staff").SendAsync("NewPaidOrder", new
            {
                orderId,
                orderNumber,
                customerName,
                paidAt = DateTime.UtcNow
            }, ct);
        }

        // The user receives a notification about a status change on their order

        public async Task NotifyOrderStatusChangedAsync(int orderId, string orderNumber, string userId, OrderStatusType newStatus, CancellationToken ct)
        {
            await userOrderHub.Clients.Group($"user-{userId}").SendAsync("OrderStatusChanged", new
            {
                orderId,
                orderNumber,
                newStatus,
                updatedAt = DateTime.UtcNow
            }, ct);
        }
    }
}
