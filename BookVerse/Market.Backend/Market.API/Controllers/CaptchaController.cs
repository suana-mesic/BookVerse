using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Text;

namespace Market.API.Controllers;
[ApiController]
[Route("[controller]")]
[AllowAnonymous]

public class CaptchaController : ControllerBase
{
    private static readonly string Chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
    [HttpGet("generate")]
    public IActionResult Generate()
    {
        //generišemo random string od 5 znakova
        var random = new Random();
        var captchaCars = new char[5];

        for (int i = 0; i < 5; i++)
            captchaCars[i] = Chars[random.Next(Chars.Length)];

        var captchaText = new string(captchaCars);
        // Generišemo sliku sa tim tekstom
        var imageBytes = GenerateImage(captchaText);
        var imageBase64 = Convert.ToBase64String(imageBytes);

        // Enkriptujemo tačan odgovor u token
        var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(captchaText));

        return Ok(new
        {
            image = $"data:image/png;base64,{imageBase64}",
            token = token
        });
    }
    [HttpPost("verify")]
    public IActionResult Verify([FromBody] CaptchaVerifyRequest request)
    {
        // Dekriptujemo token i poredimo sa odgovorom korisnika
        var correctAnswer = Encoding.UTF8.GetString(Convert.FromBase64String(request.Token));
        if (!string.Equals(request.Answer, correctAnswer, StringComparison.OrdinalIgnoreCase))
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
    public class CaptchaVerifyRequest
    {
        public string Token { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
