using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Auth.Commands.Register
{
   public class RegisterCommand:IRequest<RegisterCommandDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Line1 { get; init; }
        public string? Line2 { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string? Fingerprint { get; init; }

        // Captcha challenge issued by /Captcha/generate. The register handler verifies the token
        // and the answer before creating the account, so bots without a valid captcha are blocked.
        public string CaptchaToken { get; init; } = string.Empty;
        public string CaptchaAnswer { get; init; } = string.Empty;
    }
}
