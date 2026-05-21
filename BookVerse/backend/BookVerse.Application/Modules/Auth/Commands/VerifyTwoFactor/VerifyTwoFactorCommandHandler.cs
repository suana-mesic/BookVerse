using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Modules.Auth.Commands.Login;

namespace BookVerse.Application.Modules.Auth.Commands.VerifyTwoFactor
{
    //Handler checks whether the code matches and has not expired; if everything is correct, it returns JWT tokens just like the normal login.
    //VerifyTwoFactorCommandHandler receives the email and code from the frontend, verifies that the user entered the correct code, and if so issues a token and returns LoginCommandDto.
    public sealed class VerifyTwoFactorCommandHandler
        (IAppDbContext ctx,
        IJwtTokenService jwt,
        ITwoFactorCodeHasher twoFactorCodeHasher,
        TimeProvider time)
    : IRequestHandler<VerifyTwoFactorCommand, LoginCommandDto>
    {
        // After this many failed attempts the user is locked out for LockoutDuration.
        private const int MaxFailedAttempts = 5;
        private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);

        public  async Task<LoginCommandDto> Handle(VerifyTwoFactorCommand request, CancellationToken ct)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var user = await ctx.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
                ?? throw new BookVerseNotFoundException("User not found.");

            // TimeProvider is used instead of DateTime.UtcNow so unit tests can pin "now" and
            // exercise the lockout / expiry paths deterministically.
            var nowUtc = time.GetUtcNow().UtcDateTime;

            // Lockout guard: refuse to verify while the user is locked out, even if they somehow
            // got a code. The lockout was set after too many earlier wrong attempts.
            if (user.TwoFactorLockoutUntilUtc.HasValue && user.TwoFactorLockoutUntilUtc.Value > nowUtc)
                throw new BookVerseUnauthorizedException("Too many failed attempts. Please try again later.");

            // Hash the code coming from the user the same way Login hashed it before storing.
            // We compare hash to hash so we never need the plaintext code from the DB.
            var incomingHash = twoFactorCodeHasher.Hash(request.Code);

            var codeMismatch = user.TwoFactorCode != incomingHash;
            var codeExpired = user.TwoFactorCodeExpiresAtUtc is null
                              || user.TwoFactorCodeExpiresAtUtc < nowUtc;

            if (codeMismatch || codeExpired)
            {
                // Failed verification:
                //   1. Invalidate the current code immediately so the user MUST request a new one
                //      (the same wrong code can never be retried).
                //   2. Increase the failed-attempts counter.
                //   3. If the counter hits the threshold, set a lockout window.
                user.TwoFactorCode = null;
                user.TwoFactorCodeExpiresAtUtc = null;
                user.TwoFactorFailedAttempts += 1;

                if (user.TwoFactorFailedAttempts >= MaxFailedAttempts)
                    user.TwoFactorLockoutUntilUtc = nowUtc.Add(LockoutDuration);

                await ctx.SaveChangesAsync(ct);

                throw new BookVerseUnauthorizedException("Code is invalid or expired.");
            }

            // Successful verification: clear the code and reset all failure tracking.
            user.TwoFactorCode = null;
            user.TwoFactorCodeExpiresAtUtc = null;
            user.TwoFactorFailedAttempts = 0;
            user.TwoFactorLockoutUntilUtc = null;

            var tokens = jwt.IssueTokens(user);
            ctx.RefreshTokens.Add(new RefreshTokenEntity
            {
                TokenHash = tokens.RefreshTokenHash,
                ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc,
                UserId = user.Id,
                Fingerprint = null
            });
            await ctx.SaveChangesAsync(ct);

            return new LoginCommandDto
            {
                AccessToken = tokens.AccessToken,
                RefreshToken = tokens.RefreshTokenRaw,
                ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc
            };
        }
    }
}
