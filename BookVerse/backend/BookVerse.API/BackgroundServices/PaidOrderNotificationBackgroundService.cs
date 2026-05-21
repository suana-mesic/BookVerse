using BookVerse.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookVerse.API.BackgroundServices
{
    //Drains PaidOrderNotificationQueue and forwards each notification to IOrderNotificationService.
    //Runs as a singleton hosted service so a SignalR exception only impacts this loop, never the
    //webhook transaction that produced the notification.
    public class PaidOrderNotificationBackgroundService(
        IPaidOrderNotificationQueue queue,
        IServiceProvider serviceProvider,
        ILogger<PaidOrderNotificationBackgroundService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var notification in queue.DequeueAllAsync(stoppingToken))
            {
                try
                {
                    //IOrderNotificationService is scoped (it depends on SignalR hub contexts), so we resolve it
                    //per notification rather than capturing a singleton instance at construction time.
                    using var scope = serviceProvider.CreateScope();
                    var notificationService = scope.ServiceProvider.GetRequiredService<IOrderNotificationService>();

                    await notificationService.NotifyNewPaidOrderAsync(
                        notification.OrderId,
                        notification.OrderNumber,
                        notification.CustomerName,
                        stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    //Host is shutting down, exit cleanly.
                    break;
                }
                catch (Exception ex)
                {
                    //One notification failing must not stop the loop; log and continue with the next item.
                    logger.LogError(ex, "Failed to deliver paid-order notification for order {OrderId}", notification.OrderId);
                }
            }

        }
    }
}
