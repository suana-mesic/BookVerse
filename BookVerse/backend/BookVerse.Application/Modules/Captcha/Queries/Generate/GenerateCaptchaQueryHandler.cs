using BookVerse.Shared.Options;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Security.Cryptography;
using System.Text;

namespace BookVerse.Application.Modules.Captcha.Queries.Generate;

public sealed class GenerateCaptchaQueryHandler(IOptions<CaptchaOptions> options)
    : IRequestHandler<GenerateCaptchaQuery, GenerateCaptchaQueryDto>
{
    private readonly CaptchaOptions _captchaOptions = options.Value;
    // Avoid visually ambiguous characters: I/L/O and 0/1.
    private static readonly string Chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

    public Task<GenerateCaptchaQueryDto> Handle(GenerateCaptchaQuery request, CancellationToken ct)
    {
        var random = new Random();
        var captchaChars = new char[5];
        for (int i = 0; i < 5; i++)
            captchaChars[i] = Chars[random.Next(Chars.Length)];
        var captchaText = new string(captchaChars);

        var imageBytes = GenerateImage(captchaText);
        var imageBase64 = Convert.ToBase64String(imageBytes);

        // Add an expiry time - the captcha is valid for only 5 minutes
        // Without this, the same token could be reused indefinitely
        var expiry = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds();

        // Concatenate the correct answer and expiry into a single string
        var payload = $"{captchaText}:{expiry}";

        // Encode the payload in Base64 to avoid problematic characters in the token
        var payloadB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));

        // Sign the payload with the SecretKey - only the server can create this signature
        // Without this, someone could modify the payload and create their own token

        var signature = ComputeHmac(payloadB64);

        // Join the payload and signature with a dot - the standard token format
        var token = $"{payloadB64}.{signature}";

        return Task.FromResult(new GenerateCaptchaQueryDto
        {
            Image = $"data:image/png;base64,{imageBase64}",
            Token = token
        });
    }

    private static byte[] GenerateImage(string text)
    {
        using var image = new Image<Rgba32>(200, 70);

        image.Mutate(ctx =>
        {
            // White background
            ctx.Fill(Color.White);

            // Draw text
            var font = SixLabors.Fonts.SystemFonts.CreateFont("Arial", 36);
            ctx.DrawText(text, font, Color.DarkBlue, new PointF(20, 15));

            // Add noise — random lines that make it harder for bots to read
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                var pen = Pens.Solid(Color.Gray, 1);
                ctx.DrawLine(pen,
                    new PointF(random.Next(0, 200), random.Next(0, 70)),
                    new PointF(random.Next(0, 200), random.Next(0, 70)));
            }
        });
        using var ms = new MemoryStream();
        image.SaveAsPng(ms);
        return ms.ToArray();


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
