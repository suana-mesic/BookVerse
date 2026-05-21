namespace BookVerse.Application.Common.Interfaces
{
    //Decouples the payment webhook from SignalR: the webhook enqueues a notification and returns,
    //and a hosted background service drains the queue and delivers it. A SignalR outage can therefore
    //never roll back or stall a successful payment.
    public record PaidOrderNotification(int OrderId, string OrderNumber, string CustomerName);

    public interface IPaidOrderNotificationQueue
    {
        void Enqueue(PaidOrderNotification notification);
        IAsyncEnumerable<PaidOrderNotification> DequeueAllAsync(CancellationToken ct);
    }
}
