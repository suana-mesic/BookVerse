using BookVerse.Application.Abstractions;
using Microsoft.Extensions.Configuration;

namespace BookVerse.Application.Modules.Auth.Commands.ForgotPassword;

public sealed class ForgotPasswordCommandHandler(
    IAppDbContext ctx,
    IEmailService emailService,
    IConfiguration configuration)
    : IRequestHandler<ForgotPasswordCommand>
{
    public async Task Handle(ForgotPasswordCommand request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await ctx.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email && !x.IsDeleted, ct);

        // Don't reveal whether the email exists in the system
        if (user is null) return;

        var token = Guid.NewGuid().ToString("N");
        user.PasswordResetToken = token;
        user.PasswordResetTokenExpiresAtUtc = DateTime.UtcNow.AddHours(1);
        await ctx.SaveChangesAsync(ct);

        var frontendUrl = configuration["FrontendUrl"] ?? "http://localhost:4200";
        var resetLink = $"{frontendUrl}/auth/reset-password?token={token}&email={Uri.EscapeDataString(email)}";

        await emailService.SendPasswordResetAsync(email, resetLink, ct);
    }
}
