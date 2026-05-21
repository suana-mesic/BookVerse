namespace BookVerse.Application.Modules.Auth.Commands.ForgotPassword;

public sealed class ForgotPasswordCommand : IRequest
{
    public string Email { get; init; }

    // Captcha protects this endpoint against bots spamming reset emails to enumerate users.
    public string CaptchaToken { get; init; } = string.Empty;
    public string CaptchaAnswer { get; init; } = string.Empty;
}
