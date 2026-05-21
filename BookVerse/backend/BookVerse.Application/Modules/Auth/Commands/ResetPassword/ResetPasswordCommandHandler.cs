namespace BookVerse.Application.Modules.Auth.Commands.ResetPassword;

public sealed class ResetPasswordCommandHandler(
    IAppDbContext ctx,
    IPasswordHasher<BookVerseUserEntity> hasher,
    IJwtTokenService jwt,
    TimeProvider time)
    : IRequestHandler<ResetPasswordCommand>
{
    public async Task Handle(ResetPasswordCommand request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new BookVerseNotFoundException("User not found.");

        // The DB stores the HASH of the original token, not the raw value. We hash the token
        // the user submits with the same helper and compare hash to hash.
        var incomingHash = jwt.HashRefreshToken(request.Token);

        // TimeProvider so unit tests can prove the expiry guard fires correctly.
        var nowUtc = time.GetUtcNow().UtcDateTime;

        if (user.PasswordResetToken != incomingHash ||
            user.PasswordResetTokenExpiresAtUtc is null ||
            user.PasswordResetTokenExpiresAtUtc < nowUtc)
            throw new BookVerseUnauthorizedException("Token is invalid or expired.");

        user.PasswordHash = hasher.HashPassword(user, request.NewPassword);
        user.PasswordResetToken = null;
        user.PasswordResetTokenExpiresAtUtc = null;

        await ctx.SaveChangesAsync(ct);
    }
}
