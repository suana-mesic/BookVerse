using Market.Application.Modules.Catalog.Adresses.Commands.Create;
using Market.Application.Modules.Catalog.Adresses.Commands.Delete;
using Market.Application.Modules.Catalog.Adresses.Commands.Update;
using Market.Application.Modules.Catalog.Adresses.Queries.GetById;
using Market.Application.Modules.Catalog.Adresses.Queries.List;
using Market.Application.Modules.Users.Commands.UpdateMyProfile;
using Market.Application.Modules.Users.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

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
}
