using BookVerse.Shared.Options;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace BookVerse.Application.Modules.Captcha.Commands.Verify;

public sealed class VerifyCaptchaCommandHandler(IOptions<CaptchaOptions> options)
    : IRequestHandler<VerifyCaptchaCommand>
{
    private readonly CaptchaOptions _captchaOptions = options.Value;

    public Task Handle(VerifyCaptchaCommand request, CancellationToken ct)
    {
        // The token consists of 2 parts
        // The 1st part is the payload (in Base64 format)
        // The 2nd part is the signature
        // Split the token into payload and signature at the dot
        var parts = request.Token.Split('.');

        // The token must have exactly 2 parts - otherwise, someone sent a fake token
        if (parts.Length != 2)
            throw new BookVerseConflictException("Invalid token.");

        // Compute the expected signature based on the payload, which is the first part of the token
        // We derive the expected second part from the first part of the token
        var expectedSignature = ComputeHmac(parts[0]);

        // If the first and second parts of the token do not match, someone tampered with the token
        if (expectedSignature != parts[1])
            throw new BookVerseConflictException("Invalid token.");

        // Decode the 1st part of the token (payload) from Base64 into a string
        var payload = Encoding.UTF8.GetString(Convert.FromBase64String(parts[0]));

        // The payload consists of 2 parts: correct_answer:expiry
        // The 1st part is the correct answer
        // The 2nd part is the expiry time

        var segments = payload.Split(':');

        // Convert the expiry number back to a date
        var expiry = DateTimeOffset.FromUnixTimeSeconds(long.Parse(segments[1]));


        // Check if the captcha has expired (older than 5 minutes)
        if (expiry < DateTimeOffset.UtcNow)
            throw new BookVerseConflictException("Captcha has expired. Generate a new one.");

        // Compare the user's answer with the correct answer
        // The correct answer is now stored in segments[0]
        // OrdinalIgnoreCase means it does not matter whether the letter is uppercase or lowercase
        if (!string.Equals(request.Answer, segments[0], StringComparison.OrdinalIgnoreCase))
            throw new BookVerseConflictException("Incorrect answer. Please try again.");

        return Task.CompletedTask;
    }

    // This is one-way hashing
    // This method signs the data (payload) which is in Base64 format
    // Payload = correct answer + expiry time
    // For signing it uses a SecretKey that only the server can know
    // Uses the HMACSHA256 algorithm
    // After the method returns the signature, it is not possible to recover the original data from the signature (one-way hashing)
    private string ComputeHmac(string data)
    {
        // Convert the secret key from a string to a byte array because HMAC works with bytes
        var key = Encoding.UTF8.GetBytes(_captchaOptions.SecretKey);

        // Create a HMAC-SHA256 instance with our secret key
        using var hmac = new HMACSHA256(key);

        // Compute the hash of the data
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

        // Return the hash as a Base64 string
        return Convert.ToBase64String(hash);
    }
}
