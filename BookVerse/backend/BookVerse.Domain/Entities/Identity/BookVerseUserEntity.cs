// BookVerseUserEntity.cs
using BookVerse.Domain.Common;
using BookVerse.Domain.Entities.Catalog;

namespace BookVerse.Domain.Entities.Identity;

public sealed class BookVerseUserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsManager { get; set; }
    public bool IsEmployee { get; set; }
    public int TokenVersion { get; set; } = 0;// For global revocation
    public bool IsEnabled { get; set; }
    public int AddressId { get; set; }
    public Address? Address { get; set; }
    public bool TwoFactorEnabled { get; set; } = false;
    // Stores the HMAC-SHA256 hash of the 2FA code (never the raw code itself), so a DB leak
    // does not give an attacker the plaintext to log in with.
    public string? TwoFactorCode { get; set; }
    public DateTime? TwoFactorCodeExpiresAtUtc { get; set; }
    // Counts how many wrong codes the user has entered since the last successful 2FA verification.
    // Resets to 0 on success. Used to trigger a temporary lockout after too many failures.
    public int TwoFactorFailedAttempts { get; set; } = 0;
    // When set in the future, the user is locked out from 2FA (and from requesting a new code)
    // until this timestamp passes. Null means no active lockout.
    public DateTime? TwoFactorLockoutUntilUtc { get; set; }
    // PasswordResetToken stores the hash of the raw token sent in the reset email, NOT the raw value.
    public string? PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpiresAtUtc { get; set; }
    public ICollection<RefreshTokenEntity> RefreshTokens { get; private set; } = new List<RefreshTokenEntity>();
}