using BookVerse.Application.Common.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BookVerse.Infrastructure.Common
{
    // Reads EmailMessage jobs from the queue and actually talks to SMTP. Runs as a
    // singleton hosted service so a slow or broken SMTP server only affects this loop -
    // it can never make the HTTP request that triggered the email hang or fail.
    public class EmailSenderBackgroundService(
        IEmailQueue queue,
        IOptions<EmailSettings> settings,
        ILogger<EmailSenderBackgroundService> logger) : BackgroundService
    {
        private readonly EmailSettings _settings = settings.Value;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var message in queue.DequeueAllAsync(stoppingToken))
            {
                try
                {
                    await SendAsync(message, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    // Host is shutting down, exit the loop cleanly.
                    break;
                }
                catch (Exception ex)
                {
                    // One failed email must not stop the loop or crash the process; log and move on.
                    logger.LogError(ex,
                        "Failed to send email to {ToEmail} with subject {Subject}",
                        message.ToEmail, message.Subject);
                }
            }

        }

        private async Task SendAsync(EmailMessage message, CancellationToken ct)
        {
            var mime = new MimeMessage();
            mime.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
            mime.To.Add(MailboxAddress.Parse(message.ToEmail));
            mime.Subject = message.Subject;
            mime.Body = new TextPart("html") { Text = message.HtmlBody };

            var smtp = new SmtpClient();
            try
            {
                // SecureSocketOptions is now read from EmailSettings (and therefore from
                // appsettings.json) instead of being hardcoded to StartTls.
                await smtp.ConnectAsync(_settings.Host, _settings.Port, _settings.SecureSocketOptions, ct);
                await smtp.AuthenticateAsync(_settings.Username, _settings.Password, ct);
                await smtp.SendAsync(mime, ct);
                await smtp.DisconnectAsync(true, ct);
            }
            finally
            {
                smtp.Dispose();
            }
        }
    }
}
