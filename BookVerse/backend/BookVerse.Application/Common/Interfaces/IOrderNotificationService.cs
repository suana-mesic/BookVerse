using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Interfaces
{
    public interface IOrderNotificationService
    {
        Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, string customerName, CancellationToken ct);
        Task NotifyOrderStatusChangedAsync(int orderId, string orderNumber, string userId, OrderStatusType newStatus, CancellationToken ct);
    }
}
