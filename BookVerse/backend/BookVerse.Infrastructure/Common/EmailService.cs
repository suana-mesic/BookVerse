using MailKit.Net.Smtp;
using MailKit.Security;
using BookVerse.Application.Abstractions;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BookVerse.Infrastructure.Common;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IOptions<EmailSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken ct = default)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "Password reset";

        message.Body = new TextPart("html")
        {
            Text = $"""
                <h2>Password reset</h2>
                <p>Click the link below to reset your password:</p>
                <p><a href="{resetLink}" style="background:#1976d2;color:white;padding:12px 24px;text-decoration:none;border-radius:4px;display:inline-block;">Reset password</a></p>
                <p>This link is valid for 1 hour.</p>
                <p>If you did not request a password reset, please ignore this email.</p>
                """
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
        await smtp.AuthenticateAsync(_settings.Username, _settings.Password, ct);
        await smtp.SendAsync(message, ct);
        await smtp.DisconnectAsync(true, ct);
    }

    public async Task SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken ct = default)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "Your login code";

        message.Body = new TextPart("html")
        {
            Text = $"""
                <h2>Two-factor authentication code</h2>
                <p>Your login code is:</p>
                <h1 style="letter-spacing: 8px; color: #1976d2;">{code}</h1>
                <p>The code is valid for 10 minutes.</p>
                """
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
        await smtp.AuthenticateAsync(_settings.Username, _settings.Password, ct);
        await smtp.SendAsync(message, ct);
        await smtp.DisconnectAsync(true, ct);
    }
}
