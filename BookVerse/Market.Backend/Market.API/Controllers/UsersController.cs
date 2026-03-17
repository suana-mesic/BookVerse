using Market.Application.Modules.Users.Commands.UpdateMyProfile;
using Market.Application.Modules.Users.Commands.UpdateUserRolesForAdmin;
using Market.Application.Modules.Users.Queries.GetById;
using Market.Application.Modules.Users.Queries.GetByIdForAdmin;
using Market.Application.Modules.Users.Queries.GetUserAddress;
using Market.Application.Modules.Users.Queries.ListForAdmin;
namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]

public class UsersController(ISender sender) : ControllerBase
{
    [HttpGet("my-profile")]
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
    public async Task<IActionResult> GetUserAddress(CancellationToken ct)
    {
        var result = await sender.Send(new GetUserAddressQuery(), ct);
        return Ok(result);
    }

    //Vraća sve ID-eve i Full Names u modulu za statistiku
    [HttpGet("all-user-names")]
    [Authorize(Policy = "Management")]

    public async Task<List<ListUserNamesQueryDto>> GetAllUserNames(CancellationToken ct)
    {
        var result = await sender.Send(new ListUserNamesQuery(), ct);
        return result;
    }

    //Vraća sve korisnike za tabelarni prikaz u admin panelu
    [HttpGet("all-users")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<PageResult<ListUsersQueryDto>> GetAllUsers(
    [FromQuery] ListUsersQuery query, CancellationToken ct)
    {
        return await sender.Send(query, ct);
    }

    [HttpGet("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetById(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetUserByIdQuery { Id = id }, ct);
        return Ok(result);
    }

    [HttpPut("{id:int}/roles")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> UpdateRoles(int id, [FromBody] UpdateUserRolesCommand command, CancellationToken ct)
    {
        // ID iz route-a ima prednost
        command.Id = id;
        await sender.Send(command, ct);
        return NoContent();
    }
}
