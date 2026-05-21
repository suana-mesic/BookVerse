using BookVerse.Application.Common.Interfaces;
using BookVerse.Shared.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace BookVerse.Application.Modules.Captcha
{
    // Single implementation of "is this captcha token + answer valid?" used by both the standalone
    // /Captcha/verify endpoint and the auth handlers (Login, Register, ForgotPassword) so the
    // logic stays in one place.
    public sealed class CaptchaVerifier(IOptions<CaptchaOptions> options) : ICaptchaVerifier
    {
        private readonly CaptchaOptions _captchaOptions = options.Value;

        public Task VerifyAsync(string token, string answer, CancellationToken ct)
        {
            // BusinessRuleCodes.CAPTCHA_INVALID covers every failure path here so the
            // frontend can show one localized "Wrong CAPTCHA" message regardless of which
            // exact check failed. The English text after the code is the developer-facing
            // detail (visible in logs and Swagger), the user sees only the i18n message.

            // Token format: "{payloadBase64}.{signatureBase64}"
            var parts = token?.Split('.') ?? Array.Empty<string>();
            if (parts.Length != 2)
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.CAPTCHA_INVALID, "Invalid captcha token.");

            // Re-compute the signature from the payload and compare. If it does not match,
            // someone tampered with the payload or the token wasn't ours to begin with.
            var expectedSignature = ComputeHmac(parts[0]);
            if (expectedSignature != parts[1])
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.CAPTCHA_INVALID, "Invalid captcha token.");

            // Payload = "{answerHmac}:{expiryUnixSeconds}"
            var payload = Encoding.UTF8.GetString(Convert.FromBase64String(parts[0]));
            var segments = payload.Split(':');
            if (segments.Length != 2 || !long.TryParse(segments[1], out var expiryUnix))
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.CAPTCHA_INVALID, "Invalid captcha token.");

            var expiry = DateTimeOffset.FromUnixTimeSeconds(expiryUnix);
            if (expiry < DateTimeOffset.UtcNow)
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.CAPTCHA_INVALID, "Captcha has expired. Generate a new one.");

            // Normalize user input the same way the generator normalized the answer,
            // then HMAC it with the same expiry and compare in constant time.
            var normalizedAnswer = (answer ?? string.Empty).Trim().ToUpperInvariant();
            var expectedAnswerHmac = ComputeHmac($"answer:{normalizedAnswer}:{expiryUnix}");

            var expectedBytes = Encoding.UTF8.GetBytes(expectedAnswerHmac);
            var actualBytes = Encoding.UTF8.GetBytes(segments[0]);

            if (expectedBytes.Length != actualBytes.Length ||
                !CryptographicOperations.FixedTimeEquals(expectedBytes, actualBytes))
                throw new BookVerseBusinessRuleException(BusinessRuleCodes.CAPTCHA_INVALID, "Incorrect captcha answer. Please try again.");

            return Task.CompletedTask;
        }

        // HMAC-SHA256 with the server-only secret key. Without the key an attacker cannot
        // forge a valid token, so the only way to get a valid one is to ask /Captcha/generate.
        private string ComputeHmac(string data)
        {
            var key = Encoding.UTF8.GetBytes(_captchaOptions.SecretKey);
            using var hmac = new HMACSHA256(key);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hash);
        }
    }
}
