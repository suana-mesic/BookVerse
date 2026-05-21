using System.Threading.Channels;
using BookVerse.Application.Common.Interfaces;

namespace BookVerse.API.BackgroundServices
{
    //In-memory queue used to hand SignalR notifications off the payment-handling thread.
    //Unbounded because notifications are tiny and we want enqueue to never block the webhook;
    //if the process dies before delivery the notification is lost, which is acceptable per the
    //comment in StripeWebhookCommandHandler.
    public class PaidOrderNotificationQueue : IPaidOrderNotificationQueue
    {
        private readonly Channel<PaidOrderNotification> _channel =
            Channel.CreateUnbounded<PaidOrderNotification>(new UnboundedChannelOptions
            {
                SingleReader = true,
                SingleWriter = false
            });

        public void Enqueue(PaidOrderNotification notification)
        {
            //Writer.TryWrite on an unbounded channel only fails if the channel was completed,
            //which we never do at runtime, so dropping the result is safe.
            _channel.Writer.TryWrite(notification);
        }

        public IAsyncEnumerable<PaidOrderNotification> DequeueAllAsync(CancellationToken ct)
            => _channel.Reader.ReadAllAsync(ct);
    }
}
