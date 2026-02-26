using Market.Application.Modules.Auth.Commands.Login;

namespace Market.Application.Modules.Auth.Commands.VerifyTwoFactor
{
    //Handler provjerava da li kod odgovara, da li nije istekao, i ako je sve ispravno vraća JWT tokene kao i kod normalnog logina.
    //VerifyTwoFactorCommandHandler će sa frontenda dobiti email i kod i provjeriti da li je korisnik unio ispravno kod, ako jeste onda će issue-ati token i vratit  će LoginCommandDto
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
                ?? throw new MarketNotFoundException("Korisnik nije pronađen.");

            // Provjerimo da li kod odgovara i da li nije istekao
            if (user.TwoFactorCode != request.Code ||
                user.TwoFactorCodeExpiresAtUtc < DateTime.UtcNow)
                throw new MarketConflictException("Kod je neispravan ili je istekao.");

            // Očisti kod nakon uspješne verifikacije
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
