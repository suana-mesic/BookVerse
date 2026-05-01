namespace BookVerse.Application.Modules.Auth.Commands.ForgotPassword;

public sealed class ForgotPasswordCommand : IRequest
{
    public string Email { get; init; }
}
