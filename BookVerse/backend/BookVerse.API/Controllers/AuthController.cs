using BookVerse.Application.Modules.Auth.Commands.ForgotPassword;
using BookVerse.Application.Modules.Auth.Commands.Login;
using BookVerse.Application.Modules.Auth.Commands.Logout;
using BookVerse.Application.Modules.Auth.Commands.Refresh;
using BookVerse.Application.Modules.Auth.Commands.Register;
using BookVerse.Application.Modules.Auth.Commands.ResetPassword;
using BookVerse.Application.Modules.Auth.Commands.VerifyTwoFactor;
using MediatR;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Login([FromBody] LoginCommand command, CancellationToken ct)
    {
        return Ok(await mediator.Send(command, ct));
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<RegisterCommandDto>> Register([FromBody] RegisterCommand command, CancellationToken ct)
    {
        return Ok(await mediator.Send(command, ct));
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> Refresh([FromBody] RefreshTokenCommand command, CancellationToken ct)
    {
        return Ok(await mediator.Send(command, ct));
    }

    // Logout should work even with expired tokens since it only requires a valid refresh token.
    [HttpPost("logout")]
    [AllowAnonymous]
    public async Task Logout([FromBody] LogoutCommand command, CancellationToken ct)
    {
        await mediator.Send(command, ct);
    }

    // Receives (from the frontend) -> { email, code }
    // Returns (to the frontend) -> LoginCommandDto with JWT tokens if the code is valid

    [HttpPost("verify-2fa")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginCommandDto>> VerifyTwoFactor([FromBody] VerifyTwoFactorCommand command, CancellationToken ct)
    {
        return Ok(await mediator.Send(command, ct));
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command, CancellationToken ct)
    {
        await mediator.Send(command, ct);
        return Ok();
    }

    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command, CancellationToken ct)
    {
        await mediator.Send(command, ct);
        return Ok();
    }
}
