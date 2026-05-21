using BookVerse.Application.Abstractions;
using BookVerse.Application.Common.Interfaces;

namespace BookVerse.Infrastructure.Common;

// IEmailService used to do the SMTP work directly on the request thread, which made
// login (with 2FA) and forgot-password hang whenever SMTP was slow or down. Now it
// only builds the message and drops it on IEmailQueue, so the HTTP request returns
// immediately. EmailSenderBackgroundService picks the message up and does the SMTP
// part outside the request pipeline.
public class EmailService : IEmailService
{
    private readonly IEmailQueue _queue;

    public EmailService(IEmailQueue queue)
    {
        _queue = queue;
    }

    public Task SendPasswordResetAsync(string toEmail, string resetLink, CancellationToken ct = default)
    {
        var body = $"""
            <h2>Password reset</h2>
            <p>Click the link below to reset your password:</p>
            <p><a href="{resetLink}" style="background:#1976d2;color:white;padding:12px 24px;text-decoration:none;border-radius:4px;display:inline-block;">Reset password</a></p>
            <p>This link is valid for 1 hour.</p>
            <p>If you did not request a password reset, please ignore this email.</p>
            """;

        _queue.Enqueue(new EmailMessage(toEmail, "Password reset", body));

        // Returning a completed task because the caller only needs to know we accepted
        // the request - the actual SMTP send happens later in the background.
        return Task.CompletedTask;
    }

    public Task SendTwoFactorCodeAsync(string toEmail, string code, CancellationToken ct = default)
    {
        var body = $"""
            <h2>Two-factor authentication code</h2>
            <p>Your login code is:</p>
            <h1 style="letter-spacing: 8px; color: #1976d2;">{code}</h1>
            <p>The code is valid for 10 minutes.</p>
            """;

        _queue.Enqueue(new EmailMessage(toEmail, "Your login code", body));

        return Task.CompletedTask;
    }
}
