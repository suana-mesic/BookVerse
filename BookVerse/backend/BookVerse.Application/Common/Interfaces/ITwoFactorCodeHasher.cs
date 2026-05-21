namespace BookVerse.Application.Common.Interfaces
{
    // Hashes short-lived auth codes (currently the 6-digit 2FA code) with HMAC-SHA256
    // before they go into the DB. Plain SHA-256 is too weak for 6-digit codes because
    // an attacker who gets a DB dump can hash all 900000 possibilities in milliseconds.
    // HMAC mixes in a server-side secret, so without that secret the dump is useless.
    public interface ITwoFactorCodeHasher
    {
        string Hash(string rawCode);
    }
}
