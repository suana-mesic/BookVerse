namespace BookVerse.Application.Modules.Auth.Commands.Login;

/// <summary>
/// Command for user login and issuing an access/refresh token pair.
/// </summary>
public sealed class LoginCommand : IRequest<LoginCommandDto>
{
    /// <summary>
    /// User's email.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// User's password.
    /// </summary>
    public string Password { get; init; }

    /// <summary>
    /// (Optional) Client "fingerprint" / device identifier for device-bound refresh tokens.
    /// </summary>
    public string? Fingerprint { get; init; }

    // Captcha token issued by /Captcha/generate. The auth handler re-verifies it server-side
    // before doing anything else, so a missing or bogus token rejects the login.
    public string CaptchaToken { get; init; } = string.Empty;
    // The 5-character answer the user typed in response to the captcha image.
    public string CaptchaAnswer { get; init; } = string.Empty;
}