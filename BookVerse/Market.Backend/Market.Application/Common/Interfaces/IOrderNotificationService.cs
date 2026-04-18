using Market.Domain.Entities.Shopping;

namespace Market.Application.Common.Interfaces
{
    public interface IOrderNotificationService
    {
        Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, string customerName, CancellationToken ct); //for admins
        Task NotifyOrderStatusChangedAsync(int orderId, string orderNumber, string userId, OrderStatusType newStatus, CancellationToken ct); //for users
    }
}
