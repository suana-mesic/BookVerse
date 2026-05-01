using BookVerse.Application.Modules.Auth.Commands.Login;

namespace BookVerse.Application.Modules.Auth.Commands.VerifyTwoFactor
{
    //Handler checks whether the code matches and has not expired; if everything is correct, it returns JWT tokens just like the normal login.
    //VerifyTwoFactorCommandHandler receives the email and code from the frontend, verifies that the user entered the correct code, and if so issues a token and returns LoginCommandDto.
    public sealed class VerifyTwoFactorCommandHandler
        (IAppDbContext ctx,
        IJwtTokenService jwt)
    : IRequestHandler<VerifyTwoFactorCommand, LoginCommandDto>
    {
        public  async Task<LoginCommandDto> Handle(VerifyTwoFactorCommand request, CancellationToken ct)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var user = await ctx.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
                ?? throw new BookVerseNotFoundException("User not found.");

            // Check whether the code matches and has not expired
            if (user.TwoFactorCode != request.Code ||
                user.TwoFactorCodeExpiresAtUtc < DateTime.UtcNow)
                throw new BookVerseConflictException("Code is invalid or expired.");

            // Clear the code after successful verification
            user.TwoFactorCode = null;
            user.TwoFactorCodeExpiresAtUtc = null;

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
