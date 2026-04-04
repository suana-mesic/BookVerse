namespace Market.Application.Common.Interfaces
{
    public interface IOrderNotificationService
    {
        Task NotifyNewPaidOrderAsync(int orderId, string orderNumber, CancellationToken ct);
    }
}
