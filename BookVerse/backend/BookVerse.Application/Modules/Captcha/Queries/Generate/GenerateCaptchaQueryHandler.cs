using BookVerse.Shared.Options;
using Microsoft.Extensions.Options;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;
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
        // Use a cryptographically secure RNG for the captcha characters. System.Random is
        // predictable from its seed and would let an attacker brute-force or replay tokens.
        // GetInt32(0, Chars.Length) picks a uniformly random index into the character pool.
        var captchaChars = new char[5];
        for (int i = 0; i < 5; i++)
            captchaChars[i] = Chars[RandomNumberGenerator.GetInt32(0, Chars.Length)];
        var captchaText = new string(captchaChars);

        var imageBytes = GenerateImage(captchaText);
        var imageBase64 = Convert.ToBase64String(imageBytes);

        var expiry = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds();

        // Normalize the answer the same way the verifier will normalize user input,
        // so case-insensitive comparison still works without storing the plaintext.
        var normalizedAnswer = captchaText.ToUpperInvariant();

        // HMAC the answer together with the expiry so each token gets a unique hash.
        // Without it, the same answer would always produce the same hash, and an
        // attacker could reuse hashes collected from past captchas to solve new ones.
        var answerHmac = ComputeHmac($"answer:{normalizedAnswer}:{expiry}");

        // Payload no longer contains the plaintext answer - only its HMAC and expiry.
        var payload = $"{answerHmac}:{expiry}";

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

    // Picks a font that is reasonably guaranteed to exist on Linux containers.
    // "Arial" is hardcoded by default on Windows but is missing from most Linux Docker images
    // (debian-slim, alpine, etc.). DejaVu Sans and Liberation Sans are the typical fallbacks.
    // If none of those are installed we fall back to the first font the system has, so we
    // never crash with FontFamilyNotFoundException at runtime.
    private static Font CreateCaptchaFont(float size)
    {
        string[] preferred = { "DejaVu Sans", "Liberation Sans", "Verdana", "Arial" };
        foreach (var name in preferred)
        {
            if (SystemFonts.TryGet(name, out var family))
                return family.CreateFont(size);
        }
        // Last resort - any installed font keeps the captcha working.
        return SystemFonts.Families.First().CreateFont(size);
    }

    //ImageSharp library
    private static byte[] GenerateImage(string text)
    {
        const int width = 200;
        const int height = 70;
        using var image = new Image<Rgba32>(width, height);

        image.Mutate(ctx =>
        {
            // White background
            ctx.Fill(Color.White);

            var font = CreateCaptchaFont(36);

            // Draw each character separately so each one can have its OWN rotation and vertical
            // offset. Drawing the whole string in one DrawText call would put every character
            // on the same baseline, which OCR tools handle very easily.
            for (int i = 0; i < text.Length; i++)
            {
                var ch = text[i].ToString();
                // Horizontal layout: 30 px between characters, plus a tiny random jitter.
                var x = 20f + i * 30f + RandomNumberGenerator.GetInt32(-3, 4);
                // Vertical jitter so the baseline is uneven.
                var y = 15f + RandomNumberGenerator.GetInt32(-6, 7);
                // Per-character rotation between -20 and +20 degrees. Small enough to stay readable
                // for humans, large enough to confuse template-based OCR.
                var angleDeg = RandomNumberGenerator.GetInt32(-20, 21);
                var angleRad = angleDeg * MathF.PI / 180f;
                // Pivot rotation around the character's approximate centre so it spins in place
                // instead of sliding off to the side.
                var pivot = new Vector2(x + 10f, y + 18f);
                var transform = Matrix3x2.CreateRotation(angleRad, pivot);

                var charOptions = new DrawingOptions { Transform = transform };
                ctx.DrawText(charOptions, ch, font, Color.DarkBlue, new PointF(x, y));
            }

            // Noise lines - more than before and in varied colors so a simple "remove gray lines"
            // pre-processing step cannot just delete them.
            for (int i = 0; i < 12; i++)
            {
                var color = i % 2 == 0 ? Color.Gray : Color.LightSlateGray;
                var pen = Pens.Solid(color, 1);
                ctx.DrawLine(pen,
                    new PointF(RandomNumberGenerator.GetInt32(0, width), RandomNumberGenerator.GetInt32(0, height)),
                    new PointF(RandomNumberGenerator.GetInt32(0, width), RandomNumberGenerator.GetInt32(0, height)));
            }

            // Distortion: scatter small dots across the image. This breaks pixel-perfect template
            // matching that OCR engines rely on without making the text unreadable for humans.
            for (int i = 0; i < 200; i++)
            {
                var px = RandomNumberGenerator.GetInt32(0, width);
                var py = RandomNumberGenerator.GetInt32(0, height);
                image[px, py] = i % 2 == 0 ? new Rgba32(80, 80, 80) : new Rgba32(150, 150, 150);
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
