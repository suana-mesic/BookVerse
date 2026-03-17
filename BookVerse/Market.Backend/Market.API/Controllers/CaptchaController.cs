using Market.Shared.Options;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Security.Cryptography;
using System.Text;

namespace Market.API.Controllers;
[ApiController]
[Route("[controller]")]

public class CaptchaController(IOptions<CaptchaOptions> options) : ControllerBase
{
    private readonly CaptchaOptions _captchaOptions = options.Value;
    private static readonly string Chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";


    [HttpGet("generate")]
    [Authorize]
    public IActionResult Generate()
    {
        var random = new Random();
        var captchaChars = new char[5];
        for (int i = 0; i < 5; i++)
            captchaChars[i] = Chars[random.Next(Chars.Length)];
        var captchaText = new string(captchaChars);

        var imageBytes = GenerateImage(captchaText);
        var imageBase64 = Convert.ToBase64String(imageBytes);

        // Dodajemo expiry - captcha vrijedi samo 5 minuta
        // Bez ovoga isti token bi mogao biti korišten zauvijek
        var expiry = DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds();

        //Spajamo tačan odgovor i expiry u jedan string
        var payload = $"{captchaText}:{expiry}";

        // Enkodiramo payload u Base64 da izbjegnemo problematične karaktere u tokenu
        var payloadB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));

        // Potpisujemo payload sa SecretKey-om - samo server može napraviti ovaj potpis
        // Bez ovoga neko bi mogao izmjeniti payload i napraviti vlastiti token

        var signature = ComputeHmac(payloadB64);

        //spajamo payload i potpis tačkom - standardni format
        var token = $"{payloadB64}.{signature}";

        return Ok(new
        {
            image = $"data:image/png;base64,{imageBase64}",
            token = token,
        });
    }

    [HttpPost("verify")]
    [Authorize]

    public IActionResult Verify([FromBody] CaptchaVerifyRequest request)
    {
        //Token se sastoji iz 2 dijela
        //1. dio -> payload (u base64 formatu)
        //2. dio -> signature
        //Razdvajamo token na payload i signature na osnovu tačke
        var parts = request.Token.Split('.');

        // Token mora imati tačno 2 dijela - ako ne, neko je poslao lažni token
        if (parts.Length != 2)
            return BadRequest(new { message = "Neispravan token." });

        //Računamo očekivani potpis na osnovu payload-a (payload je prvi dio tokena)
        //Na osnovu prvog dijela tokena pokušavamo dobiti drugi dio
        var expectedSignature = ComputeHmac(parts[0]);

        // Ako se prvi i drugi dio tokena ne poklapaju, onda je neko mijenjao token
        if (expectedSignature != parts[1])
            return BadRequest(new { message = "Neispravan token." });

        //Dekodiramo 1. dio tokena (payload) iz Base64 u string
        var payload = Encoding.UTF8.GetString(Convert.FromBase64String(parts[0]));

        //Payload se sastoji iz 2 dijela tačan_odgovor:expiry
        //1. dio -> tačan odgovor
        //2. dio -> expiry

        var segments = payload.Split(':');

        // Pretvaramo expiry broj nazad u datum
        var expiry = DateTimeOffset.FromUnixTimeSeconds(long.Parse(segments[1]));


        // Provjeravamo je li captcha istekla (starija od 5 minuta)
        if (expiry < DateTimeOffset.UtcNow)
            return BadRequest(new { message = "Captcha je istekla. Generiši novu." });

        // Poredimo korisnikov odgovor sa tačnim odgovorom
        // Tačan odgovor je sada pohranjen u segments[0]
        // OrdinalIgnoreCase znači da nije bitno da li je malo ili veliko slovo
        if (!string.Equals(request.Answer, segments[0], StringComparison.OrdinalIgnoreCase))
            return BadRequest(new { message = "Pogrešan odgovor. Pokušajte ponovo." });

        return Ok(new { message = "Captcha uspješno verificirana." });
    }

    private static byte[] GenerateImage(string text)
    {
        using var image = new Image<Rgba32>(200, 70);

        image.Mutate(ctx =>
        {
            // Bijela pozadina
            ctx.Fill(Color.White);

            // Crtamo tekst
            var font = SixLabors.Fonts.SystemFonts.CreateFont("Arial", 36);
            ctx.DrawText(text, font, Color.DarkBlue, new PointF(20, 15));

            // Dodajemo šum — nasumične linije koje otežavaju botovima čitanje
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

    // Ovo je jednosmjerno hashiranje
    // Ova metoda potpisuje data (payload) koji je u Base64 formatu
    // Payload = tačan odgovor + expiry time
    // Za potpisivanje koristi SecretKey kojeg može znati samo server
    // Koristi HMACSHA256 algoritam
    // Nakon što metoda vrati potpis, nije moguće iz potpisa nazad dobiti original data (jednosmjerno hashiranje)
    private string ComputeHmac(string data)
    {
        //Pretvaramo secret key iz stringa u byte array jer HMAC radi sa bytovima
        var key = Encoding.UTF8.GetBytes(_captchaOptions.SecretKey);

        // Kreiramo HMAC-SHA256 instancu sa našim tajnim ključem
        using var hmac = new HMACSHA256(key);

        //Računamo hash od podataka
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

        // Vraćamo hash kao Base64 string
        return Convert.ToBase64String(hash);
    }

    public class CaptchaVerifyRequest
    {
        public string Token { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
