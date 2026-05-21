namespace BookVerse.Application.Common.Interfaces
{
    // Lets any handler verify a captcha challenge without duplicating the HMAC + expiry logic.
    // Throws BookVerseConflictException on any failure (invalid token, expired, wrong answer),
    // so callers can simply call Verify(...) at the start of their flow and stop on failure.
    public interface ICaptchaVerifier
    {
        Task VerifyAsync(string token, string answer, CancellationToken ct);
    }
}
