using BookVerse.Application.Common.Interfaces;
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
        IPasswordHasher<BookVerseUserEntity> hasher,
        ICaptchaVerifier captchaVerifier,
        TimeProvider time)
        : IRequestHandler<RegisterCommand, RegisterCommandDto>
    {
        public async Task<RegisterCommandDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Verify the captcha first. Bots that hit /Auth/register without a valid captcha
            // are stopped here, before we hit the DB or create an Address row.
            await captchaVerifier.VerifyAsync(request.CaptchaToken, request.CaptchaAnswer, cancellationToken);

            var email = request.Email.Trim().ToLowerInvariant();

            var usr = await context.Users.AnyAsync(x => x.Email.ToLower() == request.Email, cancellationToken);

            if (usr)
                throw new BookVerseConflictException("User with this email already exists.");

            // Wrap everything in an explicit transaction so the THREE writes (address, user,
            // refresh token) either all commit together or all roll back. Without it, if the
            // refresh-token insert fails the user is left in the DB without a session, and a
            // second register attempt with the same email then crashes on the duplicate check.
            await using var tx = await context.BeginTransactionAsync(cancellationToken);

            // Single "now" snapshot so address and user share the exact same timestamp.
            // TimeProvider so unit tests can control creation time.
            var nowUtc = time.GetUtcNow().UtcDateTime;

            var address = new Address
            {
                IsDeleted = false,
                CreatedAtUtc = nowUtc,
                Line1 = request.Line1,
                Line2 = request.Line2,
                City = request.City,
                Country = request.Country
            };

            // Setting the navigation property (Address = address) instead of just AddressId
            // lets EF insert BOTH rows in a SINGLE SaveChangesAsync round-trip - it inserts
            // Address first, takes its generated Id, and uses it for User.AddressId.
            var user = new BookVerseUserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = address,
                IsDeleted = false,
                CreatedAtUtc = nowUtc,
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

            // Now that user.Id is populated, we can mint JWT + refresh tokens and persist
            // the refresh token hash. The transaction below guards this second save.
            var tokens = jwt.IssueTokens(user);

            context.RefreshTokens.Add(new RefreshTokenEntity
            {
                TokenHash = tokens.RefreshTokenHash,
                ExpiresAtUtc = tokens.RefreshTokenExpiresAtUtc,
                UserId = user.Id,
                Fingerprint = request.Fingerprint
            });
            await context.SaveChangesAsync(cancellationToken);

            await tx.CommitAsync(cancellationToken);

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
