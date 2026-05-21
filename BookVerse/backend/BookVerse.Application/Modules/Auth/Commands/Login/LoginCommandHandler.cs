using BookVerse.Application.Common.Interfaces;
using BookVerse.Application.Modules.Auth.Commands.Login;
using System.Security.Cryptography;

// LoginCommandHandler depends on ITwoFactorNotifier instead of IEmailService so the handler
// speaks the domain language ("notify the user with this code") and never names the transport
// (SMTP). Swapping email for SMS later would only touch the infrastructure binding.
public sealed class LoginCommandHandler(
    IAppDbContext ctx,
    IJwtTokenService jwt,
    IPasswordHasher<BookVerseUserEntity> hasher,
    ITwoFactorNotifier twoFactorNotifier,
    ITwoFactorCodeHasher twoFactorCodeHasher,
    ICaptchaVerifier captchaVerifier,
    TimeProvider time)
    : IRequestHandler<LoginCommand, LoginCommandDto>
{
    public async Task<LoginCommandDto> Handle(LoginCommand request, CancellationToken ct)
    {
        // Verify the captcha before doing any DB work. If the captcha fails we never even
        // touch the Users table, so this also acts as a cheap rate limiter against credential
        // stuffing.
        await captchaVerifier.VerifyAsync(request.CaptchaToken, request.CaptchaAnswer, ct);

        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new BookVerseNotFoundException("User not found or is disabled.");

        var verify = hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (verify == PasswordVerificationResult.Failed)
            // 401 (Unauthorized) - the frontend's auth interceptor only reacts to 401 for auth failures,
            // not to 409 Conflict, so this must NOT be a ConflictException.
            throw new BookVerseUnauthorizedException("Incorrect credentials.");

        //Check whether the user has 2FA enabled.
        //Reason: if TwoFactorEnabled=true, we do not return a JWT immediately; instead we generate
        //a 6-digit code, store it in the database with a 10-minute expiry, and send it by email.
        //The frontend receives RequiresTwoFactor=true and shows an input for the code.

        if (user.TwoFactorEnabled)
        {
            // TimeProvider is used instead of DateTime.UtcNow so unit tests can pin "now" and exercise
            // the lockout/expiry paths deterministically.
            var nowUtc = time.GetUtcNow().UtcDateTime;

            // Lockout guard: if the user is currently locked out (too many wrong codes earlier),
            // refuse to even generate a new code until the lockout expires.
            if (user.TwoFactorLockoutUntilUtc.HasValue && user.TwoFactorLockoutUntilUtc.Value > nowUtc)
                throw new BookVerseUnauthorizedException("Too many failed attempts. Please try again later.");

            // Cryptographically secure RNG (GetInt32 upper bound 1000000 includes 999999).
            var code = RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
            // Store only the HMAC-SHA256 hash of the code. The raw code is emailed to the user
            // and never persisted - if the DB leaks, the attacker still cannot log in.
            user.TwoFactorCode = twoFactorCodeHasher.Hash(code);
            user.TwoFactorCodeExpiresAtUtc = nowUtc.AddMinutes(10);
            await ctx.SaveChangesAsync(ct);

            // Domain-language call: "notify the user with this code". The notifier picks
            // the channel (email today, possibly SMS later).
            await twoFactorNotifier.NotifyCodeAsync(user.Email, code, ct);

            return new LoginCommandDto
            {
                RequiresTwoFactor = true,
                Email = user.Email
            };
        }

        var tokens = jwt.IssueTokens(user);

        ctx.RefreshTokens.Add(new RefreshTokenEntity
        {
            TokenHash = tokens.RefreshTokenHash,
            ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc,
            UserId = user.Id,
            Fingerprint = request.Fingerprint
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
