using System.ComponentModel.DataAnnotations;

namespace BookVerse.Shared.Options
{
    // Class that maps configuration from appsettings.json
    public class CaptchaOptions
    {
        // Section name in appsettings.json
        public const string SectionName = "CaptchaOptions";
        // SecretKey used to sign tokens
        [Required]
        public string SecretKey { get; set; } = string.Empty;
    }
}
