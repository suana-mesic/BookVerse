using BookVerse.Application.Abstractions;
using BookVerse.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace BookVerse.Application.Modules.Auth.Commands.ForgotPassword;

// ForgotPasswordCommandHandler depends on IPasswordResetNotifier instead of IEmailService so
// it speaks the domain ("notify the user with this reset link") without knowing the transport.
public sealed class ForgotPasswordCommandHandler(
    IAppDbContext ctx,
    IPasswordResetNotifier passwordResetNotifier,
    IConfiguration configuration,
    IJwtTokenService jwt,
    ICaptchaVerifier captchaVerifier,
    TimeProvider time)
    : IRequestHandler<ForgotPasswordCommand>
{
    public async Task Handle(ForgotPasswordCommand request, CancellationToken ct)
    {
        // Captcha first - protects the endpoint from being used to spam reset emails or
        // probe which addresses exist in the system.
        await captchaVerifier.VerifyAsync(request.CaptchaToken, request.CaptchaAnswer, ct);

        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && !x.IsDeleted, ct);

        // Don't reveal whether the email exists in the system
        if (user is null) return;

        // Generate the raw token from a cryptographically secure RNG (32 random bytes).
        // Guid.NewGuid() is NOT guaranteed to be crypto-random, so it shouldn't be used for secrets.
        var rawToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        // Store only the hash of the token (same SHA-256 helper used for refresh tokens).
        // If the DB leaks, the attacker sees the hash but cannot reverse it to get the raw token
        // they would need to actually use the reset link.
        user.PasswordResetToken = jwt.HashRefreshToken(rawToken);
        // TimeProvider so unit tests can pin "now" and verify the expiry math.
        user.PasswordResetTokenExpiresAtUtc = time.GetUtcNow().UtcDateTime.AddHours(1);
        await ctx.SaveChangesAsync(ct);

        var frontendUrl = configuration["FrontendUrl"] ?? "http://localhost:4200";
        // The user gets the RAW token in the email; only they know it. ResetPasswordCommandHandler
        // hashes whatever the user submits and compares it against the stored hash.
        var resetLink = $"{frontendUrl}/auth/reset-password?token={Uri.EscapeDataString(rawToken)}&email={Uri.EscapeDataString(email)}";

        // Domain-language call: "notify the user with this reset link". The notifier picks
        // the channel (email today).
        await passwordResetNotifier.NotifyResetLinkAsync(email, resetLink, ct);
    }
}
