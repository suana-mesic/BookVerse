using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Auth.Commands.Register
{
    public class RegisterCommandHandler(
        IAppDbContext context,
        IJwtTokenService jwt,
        IPasswordHasher<MarketUserEntity> hasher)
        : IRequestHandler<RegisterCommand, RegisterCommandDto>
    {
        public async Task<RegisterCommandDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var usr = await context.Users.AnyAsync(x => x.Email.ToLower() == request.Email);

            if (usr)
                throw new MarketConflictException("Korisnik sa unsenim mailom već postoji");

            var adresa = new Addresses
            {
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now,
                Line1 = request.Line1,
                Line2 = request.Line2,
                City = request.City,
                Country = request.Country
            };

            context.Addresses.Add(adresa);
            await context.SaveChangesAsync(cancellationToken);

            var user = new MarketUserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AddressId = adresa.Id,
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now,
                Email = request.Email,
                PasswordHash = hasher.HashPassword(null, request.Password),
                IsAdmin = false,
                IsManager = false,
                IsEmployee = false,
                TokenVersion = 0,
                IsEnabled = true
            };

            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);

            var tokens = jwt.IssueTokens(user);

            context.RefreshTokens.Add(new RefreshTokenEntity
            {
                TokenHash = tokens.RefreshTokenHash,
                ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc,
                UserId = user.Id,
                Fingerprint = request.Fingerprint

            });
            await context.SaveChangesAsync(cancellationToken);

            return new RegisterCommandDto
            {
                UserId = user.Id,
                AccessToken = tokens.AccessToken,
                RefreshToken = tokens.RefreshTokenRaw,
                ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc
            };
        }
    }
}
