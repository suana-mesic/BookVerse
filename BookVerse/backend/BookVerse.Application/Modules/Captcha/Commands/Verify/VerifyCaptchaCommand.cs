namespace BookVerse.Application.Modules.Captcha.Commands.Verify;

// Command that verifies a captcha challenge: the signed token issued by
// <c>GenerateCaptchaQuery</c> together with the answer the user typed.
public sealed class VerifyCaptchaCommand : IRequest
{
    // Server-signed token in the format "{payloadBase64}.{hmacSignature}".
    public string Token { get; init; } = string.Empty;

    // Characters the user typed in response to the captcha image.
    public string Answer { get; init; } = string.Empty;
}
