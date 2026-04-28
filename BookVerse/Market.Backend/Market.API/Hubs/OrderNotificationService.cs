using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;
using Microsoft.AspNetCore.SignalR;

namespace Market.API.Hubs
{
    public class OrderNotificationService(
        IHubContext<AdminOrderHub> adminOrderHub,
        IHubContext<UserOrderHub> userOrderHub) : IOrderNotificationService
    {
        // Grupa admins dobijaju notifikaciju o novoj plaćenoj narudžbi

        public async Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, string customerName, CancellationToken ct)
        {
            await adminOrderHub.Clients.Group("admins").SendAsync("NewPaidOrder", new
            {
                orderId,
                orderNumber,
                customerName,
                paidAt = DateTime.UtcNow
            }, ct);
        }

        // Korisnik dobija notifikaciju o promjeni statusa svoje narudžbe 

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
