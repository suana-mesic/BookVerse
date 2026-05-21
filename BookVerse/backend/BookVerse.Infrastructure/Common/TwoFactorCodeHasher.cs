using System.Security.Cryptography;
using System.Text;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Shared.Options;
using Microsoft.Extensions.Options;

namespace BookVerse.Infrastructure.Common
{
    // HMAC-SHA256 implementation. The secret key is the JWT signing key (Jwt:Key) so we don't have
    // to manage a second secret for this small feature. The 2FA code is prefixed with "2fa:" before
    // hashing to keep its hash space separate from any other thing that might use the same key in
    // the future (this is called "domain separation" in crypto).
    public class TwoFactorCodeHasher : ITwoFactorCodeHasher
    {
        private readonly byte[] _key;

        public TwoFactorCodeHasher(IOptions<JwtOptions> jwtOptions)
        {
            _key = Encoding.UTF8.GetBytes(jwtOptions.Value.Key);
        }

        public string Hash(string rawCode)
        {
            using var hmac = new HMACSHA256(_key);
            // Domain separator "2fa:" - protects against accidental collisions if Jwt:Key is ever
            // reused to hash something else (e.g. an admin token).
            var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes("2fa:" + rawCode));
            return Convert.ToBase64String(bytes);
        }
    }
}
