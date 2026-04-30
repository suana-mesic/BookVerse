using BookVerse.Application.Modules.Auth.Commands.Login;

public sealed class LoginCommandHandler(
    IAppDbContext ctx,
    IJwtTokenService jwt,
    IPasswordHasher<BookVerseUserEntity> hasher,
    IEmailService emailService)
    : IRequestHandler<LoginCommand, LoginCommandDto>
{
    public async Task<LoginCommandDto> Handle(LoginCommand request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new BookVerseNotFoundException("User not found or is disabled.");

        var verify = hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (verify == PasswordVerificationResult.Failed)
            throw new BookVerseConflictException("Incorrect credentials.");

        //Check whether the user has 2FA enabled.
        //Reason: if TwoFactorEnabled=true, we do not return a JWT immediately; instead we generate
        //a 6-digit code, store it in the database with a 10-minute expiry, and send it by email.
        //The frontend receives RequiresTwoFactor=true and shows an input for the code.

        if (user.TwoFactorEnabled)
        {
            var code = new Random().Next(100000, 999999).ToString();
            user.TwoFactorCode = code;
            user.TwoFactorCodeExpiresAtUtc = DateTime.UtcNow.AddMinutes(10);
            await ctx.SaveChangesAsync(ct);

            await emailService.SendTwoFactorCodeAsync(user.Email, code, ct);

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
