using System.ComponentModel.DataAnnotations;

namespace Market.Shared.Options
{
    // Klasa koja mapira konfiguraciju iz appsettings.json
    public class CaptchaOptions
    {
        // Naziv sekcije u appsettings.json
        public const string SectionName = "CaptchaOptions";
        // SecretKey koji koristimo za potpisivanje tokena
        [Required]
        public string SecretKey { get; set; } = string.Empty;
    }
}
