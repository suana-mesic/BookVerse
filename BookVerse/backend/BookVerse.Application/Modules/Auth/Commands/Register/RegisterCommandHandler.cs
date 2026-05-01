using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Auth.Commands.Register
{
    public class RegisterCommandHandler(
        IAppDbContext context,
        IJwtTokenService jwt,
        IPasswordHasher<BookVerseUserEntity> hasher)
        : IRequestHandler<RegisterCommand, RegisterCommandDto>
    {
        public async Task<RegisterCommandDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var usr = await context.Users.AnyAsync(x => x.Email.ToLower() == request.Email, cancellationToken);

            if (usr)
                throw new BookVerseConflictException("User with this email already exists.");

            var address = new Address
            {
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                Line1 = request.Line1,
                Line2 = request.Line2,
                City = request.City,
                Country = request.Country
            };

            context.Addresses.Add(address);
            await context.SaveChangesAsync(cancellationToken);

            var user = new BookVerseUserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AddressId = address.Id,
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
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
