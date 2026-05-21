namespace BookVerse.Application.Abstractions
{
    // Domain-language interface used by ForgotPasswordCommandHandler.
    // Same idea as ITwoFactorNotifier: the handler asks for "notify the user with this reset link"
    // and never names the transport (SMTP) so the infrastructure can change later without
    // touching the handler.
    public interface IPasswordResetNotifier
    {
        // Sends the reset-link to the user. Implementations decide channel and formatting.
        Task NotifyResetLinkAsync(string toEmail, string resetLink, CancellationToken ct = default);
    }
}
