using System.Threading.Channels;
using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Infrastructure.Common
{
    // In-memory queue that holds email jobs between the request thread that produces them
    // and the background worker that actually sends them. Unbounded because emails are
    // tiny and the producer (HTTP request) must never block. SingleReader is true because
    // exactly one hosted service drains this queue.
    public class EmailQueue : IEmailQueue
    {
        private readonly Channel<EmailMessage> _channel =
            Channel.CreateUnbounded<EmailMessage>(new UnboundedChannelOptions
            {
                SingleReader = true,
                SingleWriter = false
            });

        public void Enqueue(EmailMessage message)
        {
            // TryWrite on an unbounded channel only returns false if the channel has been
            // completed, which we never do at runtime, so ignoring the result is safe.
            _channel.Writer.TryWrite(message);
        }

        public IAsyncEnumerable<EmailMessage> DequeueAllAsync(CancellationToken ct)
            => _channel.Reader.ReadAllAsync(ct);
    }
}
