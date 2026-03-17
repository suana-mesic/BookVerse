using Market.Application.Modules.Catalog.Adresses.Commands.Create;
using Market.Application.Modules.Catalog.Adresses.Commands.Delete;
using Market.Application.Modules.Catalog.Adresses.Commands.Update;
using Market.Application.Modules.Catalog.Adresses.Queries.GetById;
using Market.Application.Modules.Catalog.Adresses.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressesController(ISender sender): ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<PageResult<ListAddressesQueryDto>> List([FromQuery] ListAddressesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<GetAddressByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var address = await sender.Send(new GetAddressByIdQuery { Id = id }, ct);
        return address; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<int>> CreateAddress(CreateAddressCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task UpdateAddress(int id, UpdateAddressCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteAddress(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteAddressCommand { Id = id }, ct);
        return NoContent();
    }
}
