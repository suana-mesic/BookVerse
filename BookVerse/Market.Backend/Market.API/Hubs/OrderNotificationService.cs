using Market.Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Market.API.Hubs
{
    public class OrderNotificationService(IHubContext<OrderNotificationHub> hubContext) : IOrderNotificationService
    {
        public async Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, CancellationToken ct)
        {
            await hubContext.Clients.Group("admins").SendAsync("NewPaidOrder", new
            {
                orderId,
                orderNumber,
                paidAt = DateTime.UtcNow
            }, ct);
        }
    }
}
