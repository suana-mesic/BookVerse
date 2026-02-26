namespace Market.Application.Modules.Auth.Commands.Login;

/// <summary>
/// Represents a pair of tokens (access + refresh) that the client receives upon login or token refresh.
/// </summary>
public sealed class LoginCommandDto
{
    //pošto imamo 2way auth morala sam dodati da su AccessToken, RefreshToken i ExpiresAtUtc nullable, jer prvo moramo uraditi 2way auth i poslati mail

    /// <summary>
    /// JWT access token – used for authorized API calls.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// Refresh token that the client stores locally and uses to obtain a new access token.
    /// </summary>
    public string? RefreshToken { get; set; }

    /// <summary>
    /// Expiration time of the access token in UTC format.
    /// </summary>
    public DateTime? ExpiresAtUtc { get; set; }

    //pošto želimo 2fa
    public bool RequiresTwoFactor { get; set; } = false;
    public string? Email { get; set; }
}