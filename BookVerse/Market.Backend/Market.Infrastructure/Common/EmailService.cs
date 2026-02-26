using MailKit.Net.Smtp;
using MailKit.Security;
using Market.Application.Abstractions;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Market.Infrastructure.Common;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken ct = default)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "Vaš kod za prijavu";

        message.Body = new TextPart("html")
        {
            Text = $"""
                <h2>Kod za dvofaktorsku autentifikaciju</h2>
                <p>Vaš kod za prijavu je:</p>
                <h1 style="letter-spacing: 8px; color: #1976d2;">{code}</h1>
                <p>Kod je važeći 10 minuta.</p>
                """
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
        await smtp.AuthenticateAsync(_settings.Username, _settings.Password, ct);
        await smtp.SendAsync(message, ct);
        await smtp.DisconnectAsync(true, ct);
    }
}