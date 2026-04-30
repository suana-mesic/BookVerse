namespace BookVerse.Application.Modules.Auth.Commands.ResetPassword;

public sealed class ResetPasswordCommand : IRequest
{
    public string Email { get; init; }
    public string Token { get; init; }
    public string NewPassword { get; init; }
}
