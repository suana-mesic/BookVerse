namespace BookVerse.Application.Common.Interfaces
{
    // One email job sitting in the in-memory queue. The handler that calls IEmailService
    // builds one of these, enqueues it and returns right away, so the HTTP request never
    // waits on SMTP. A background worker reads these and actually sends them.
    public record EmailMessage(string ToEmail, string Subject, string HtmlBody);

    // Pass-through between IEmailService (producer) and the background sender (consumer).
    // Same shape as IPaidOrderNotificationQueue so the email subsystem follows the same
    // pattern that is already used for SignalR notifications.
    public interface IEmailQueue
    {
        void Enqueue(EmailMessage message);
        IAsyncEnumerable<EmailMessage> DequeueAllAsync(CancellationToken ct);
    }
}
