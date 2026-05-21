using BookVerse.Application.Abstractions;
using BookVerse.Domain.Entities.Shopping;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.API.BackgroundServices
{
    //Sweeps abandoned orders to the Expired status. Two paths land here:
    //  Draft           = order row saved but the Stripe call never completed (process crash, network drop, etc.)
    //  PaymentPending  = PaymentIntent created but the user walked away from the checkout form
    //Anything older than ExpiryThreshold is considered abandoned. Runs on a Polly-style fixed interval; the
    //first sweep happens shortly after startup so leftovers from a crashed process get cleaned up promptly.
    public class OrderCleanupBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<OrderCleanupBackgroundService> logger) : BackgroundService
    {
        private static readonly TimeSpan SweepInterval = TimeSpan.FromMinutes(15);
        private static readonly TimeSpan ExpiryThreshold = TimeSpan.FromHours(1);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(SweepInterval);

            //Run an immediate sweep before entering the wait-loop so crash leftovers from the previous process don't sit around for a full interval.
            await SweepOnceAsync(stoppingToken);

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    await SweepOnceAsync(stoppingToken);
                }
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                //Normal shutdown.
            }

        }

        private async Task SweepOnceAsync(CancellationToken ct)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<IAppDbContext>();

                var cutoff = DateTime.UtcNow - ExpiryThreshold;

                var staleOrders = await context.Orders
                    .Where(o =>
                        (o.OrderStatusId == (int)OrderStatusType.Draft ||
                         o.OrderStatusId == (int)OrderStatusType.PaymentPending)
                        && o.OrderDate < cutoff)
                    .ToListAsync(ct);

                if (staleOrders.Count == 0)
                    return;

                foreach (var order in staleOrders)
                    order.OrderStatusId = (int)OrderStatusType.Expired;

                await context.SaveChangesAsync(ct);

                logger.LogInformation("OrderCleanupBackgroundService: expired {Count} abandoned orders", staleOrders.Count);
            }
            catch (Exception ex)
            {
                //Cleanup failure must never crash the host; log and try again next tick.
                logger.LogError(ex, "OrderCleanupBackgroundService: sweep failed");
            }
        }
    }
}
