using Market.Application.Modules.Auth.Commands.Login;

public sealed class LoginCommandHandler(
    IAppDbContext ctx,
    IJwtTokenService jwt,
    IPasswordHasher<MarketUserEntity> hasher,
    IEmailService emailService)
    : IRequestHandler<LoginCommand, LoginCommandDto>
{
    public async Task<LoginCommandDto> Handle(LoginCommand request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && x.IsEnabled && !x.IsDeleted, ct)
            ?? throw new MarketNotFoundException("Korisnik nije pronađen ili je onemogućen.");

        var verify = hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
        if (verify == PasswordVerificationResult.Failed)
            throw new MarketConflictException("Pogrešni kredencijali.");

        //Provjera da li korisnik ima uključen 2FA
        //Razlog: ako ima TwoFactorEnabled=true, ne vraćamo JWT odmah nego generišemo
        //6-znamenkasti kod, spremamo ga u bazu sa rokom od 10 minuta i šaljemo emailom.
        //Frontend dobije RequiresTwoFactor=true i prikazuje input za unos koda.

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
