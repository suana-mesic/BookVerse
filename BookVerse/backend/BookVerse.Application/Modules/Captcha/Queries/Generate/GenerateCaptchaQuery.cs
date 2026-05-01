namespace BookVerse.Application.Modules.Captcha.Queries.Generate;

// Query that generates a fresh captcha challenge: a PNG image with random
// characters and a server-signed token containing the correct answer and
// expiry, both required to later verify the user's input.
public sealed class GenerateCaptchaQuery : IRequest<GenerateCaptchaQueryDto>
{
}
