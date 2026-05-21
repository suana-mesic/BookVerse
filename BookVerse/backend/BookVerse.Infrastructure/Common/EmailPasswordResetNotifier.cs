using BookVerse.Application.Abstractions;

namespace BookVerse.Infrastructure.Common
{
    // Concrete notifier that delivers the password-reset link via email. Same pattern as
    // EmailTwoFactorNotifier: keeps the SMTP detail in infrastructure and exposes only the
    // domain-language method to the handler.
    public sealed class EmailPasswordResetNotifier : IPasswordResetNotifier
    {
        private readonly IEmailService _email;

        public EmailPasswordResetNotifier(IEmailService email)
        {
            _email = email;
        }

        public Task NotifyResetLinkAsync(string toEmail, string resetLink, CancellationToken ct = default)
            => _email.SendPasswordResetAsync(toEmail, resetLink, ct);
    }
}
