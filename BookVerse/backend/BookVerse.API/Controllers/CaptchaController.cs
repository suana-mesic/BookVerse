using BookVerse.Application.Modules.Captcha.Commands.Verify;
using BookVerse.Application.Modules.Captcha.Queries.Generate;
using MediatR;

namespace BookVerse.API.Controllers;

[ApiController]
// Lowercase + api/ prefix per route standardization. Keeps URLs uniform across the API
// and prevents case-sensitivity surprises behind proxies or rewrite rules.
[Route("api/captcha")]
public sealed class CaptchaController(IMediator mediator) : ControllerBase
{
    // Captcha must be reachable WITHOUT a login: register, login and forgot-password screens
    // are anonymous endpoints, and the whole point of captcha is to protect them.
    // The token returned here is server-signed and short-lived (5 min), so making it anonymous
    // does not leak anything sensitive.
    [HttpGet("generate")]
    [AllowAnonymous]
    public async Task<ActionResult<GenerateCaptchaQueryDto>> Generate(CancellationToken ct)
    {
        return Ok(await mediator.Send(new GenerateCaptchaQuery(), ct));
    }

    // Standalone verify endpoint also anonymous - useful for the frontend to pre-check the answer
    // before submitting the full auth request. The auth handlers re-verify on their side regardless.
    [HttpPost("verify")]
    [AllowAnonymous]
    public async Task<IActionResult> Verify([FromBody] VerifyCaptchaCommand command, CancellationToken ct)
    {
        await mediator.Send(command, ct);
        return Ok();
    }
}
