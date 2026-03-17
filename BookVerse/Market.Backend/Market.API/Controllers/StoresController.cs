using Market.Application.Modules.Catalog.Stores.Commands.Create;
using Market.Application.Modules.Catalog.Stores.Commands.Delete;
using Market.Application.Modules.Catalog.Stores.Commands.Update;
using Market.Application.Modules.Catalog.Stores.Queries.GetById;
using Market.Application.Modules.Catalog.Stores.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoresController(ISender sender) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListStoresQueryDto>> List([FromQuery] ListStoresQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetStoreByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var query = new GetStoreByIdQuery { Id = id };
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Create(CreateStoreCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return CreatedAtAction(nameof(GetById), new { id = result }, null);
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(int id, UpdateStoreCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var command = new DeleteStoreCommand { Id = id };
        await sender.Send(command, ct);
        return NoContent();
    }
}
