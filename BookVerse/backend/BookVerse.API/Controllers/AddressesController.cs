using BookVerse.Application.Modules.Catalog.Addresses.Commands.Create;
using BookVerse.Application.Modules.Catalog.Addresses.Commands.Delete;
using BookVerse.Application.Modules.Catalog.Addresses.Commands.Update;
using BookVerse.Application.Modules.Catalog.Addresses.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Addresses.Queries.List;

namespace BookVerse.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = "Staff")]
public class AddressesController(ISender sender): ControllerBase
{
    [HttpGet]
    public async Task<PageResult<ListAddressesQueryDto>> List([FromQuery] ListAddressesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<GetAddressByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var address = await sender.Send(new GetAddressByIdQuery { Id = id }, ct);
        return address; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateAddress(CreateAddressCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    public async Task UpdateAddress(int id, UpdateAddressCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAddress(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteAddressCommand { Id = id }, ct);
        return NoContent();
    }
}
