using Market.Application.Modules.Users.Commands.UpdateMyProfile;
using Market.Application.Modules.Users.Queries.GetById;
using Market.Application.Modules.Users.Queries.GetUserAddress;
namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet("my-profile")]
    [AllowAnonymous]
    public async Task<ActionResult<GetMyProfileQueryDto>> GetMyProfile(CancellationToken ct)
    {
        return Ok(await sender.Send(new GetMyProfileQuery(), ct));
    }

    [HttpPut("my-profile")]
    public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateMyProfileCommand command, CancellationToken ct)
    {
        await sender.Send(command, ct);
        return NoContent();
    }

    [HttpGet("user-address")]
    [Authorize]
    public async Task<IActionResult> GetUserAddress(CancellationToken ct)
    {
        var result = await sender.Send(new GetUserAddressQuery(), ct);
        return Ok(result);
    }
}
