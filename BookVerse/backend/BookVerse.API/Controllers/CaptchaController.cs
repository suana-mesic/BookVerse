using BookVerse.Application.Modules.Captcha.Commands.Verify;
using BookVerse.Application.Modules.Captcha.Queries.Generate;
using MediatR;

namespace BookVerse.API.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CaptchaController(IMediator mediator) : ControllerBase
{
    [HttpGet("generate")]
    [Authorize]
    public async Task<ActionResult<GenerateCaptchaQueryDto>> Generate(CancellationToken ct)
    {
        return Ok(await mediator.Send(new GenerateCaptchaQuery(), ct));
    }

    [HttpPost("verify")]
    [Authorize]
    public async Task<IActionResult> Verify([FromBody] VerifyCaptchaCommand command, CancellationToken ct)
    {
        await mediator.Send(command, ct);
        return Ok();
    }
}
