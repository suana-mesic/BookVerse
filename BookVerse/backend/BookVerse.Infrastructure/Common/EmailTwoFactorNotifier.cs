using BookVerse.Application.Abstractions;

namespace BookVerse.Infrastructure.Common
{
    // Concrete notifier that delivers the 2FA code via email. It is intentionally a thin wrapper
    // around IEmailService: the handler depends on the domain-language interface
    // (ITwoFactorNotifier) and the infrastructure detail (SMTP via IEmailService) stays here,
    // where it can be swapped without touching the handler.
    public sealed class EmailTwoFactorNotifier : ITwoFactorNotifier
    {
        private readonly IEmailService _email;

        public EmailTwoFactorNotifier(IEmailService email)
        {
            _email = email;
        }

        public Task NotifyCodeAsync(string toEmail, string code, CancellationToken ct = default)
            => _email.SendTwoFactorCodeAsync(toEmail, code, ct);
    }
}
