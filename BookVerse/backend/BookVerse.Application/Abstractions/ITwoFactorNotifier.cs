namespace BookVerse.Application.Abstractions
{
    // Domain-language interface used by LoginCommandHandler when a user with 2FA enabled signs in.
    // The handler asks for "notify the user with this 2FA code" - it does not need to know that
    // delivery happens by SMTP today. Tomorrow it could switch to SMS or push without changing
    // the handler.
    public interface ITwoFactorNotifier
    {
        // Sends the freshly generated 2FA code to the user. Implementations decide the channel
        // (email today, possibly SMS later) and the message format.
        Task NotifyCodeAsync(string toEmail, string code, CancellationToken ct = default);
    }
}
