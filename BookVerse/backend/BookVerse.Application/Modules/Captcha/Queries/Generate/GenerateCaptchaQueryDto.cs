namespace BookVerse.Application.Modules.Captcha.Queries.Generate;

// Result of a captcha challenge: the rendered image (data URI) and the
// server-signed token that the client must echo back when verifying.
public sealed class GenerateCaptchaQueryDto
{
    /// Base64-encoded PNG image as a data URI (e.g. "data:image/png;base64,...").
    public string Image { get; set; } = string.Empty;

    // Signed token in the format "{payloadBase64}.{hmacSignature}" carrying
    // the correct answer and expiry timestamp.
    public string Token { get; set; } = string.Empty;
}
