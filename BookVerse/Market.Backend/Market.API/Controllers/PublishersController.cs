using Market.Application.Modules.Catalog.Publishers.Commands.Create;
using Market.Application.Modules.Catalog.Publishers.Commands.Delete;
using Market.Application.Modules.Catalog.Publishers.Commands.Update;
using Market.Application.Modules.Catalog.Publishers.Queries.GetById;
using Market.Application.Modules.Catalog.Publishers.Queries.List;
namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PublisherController(ISender sender) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListPublishersQueryDto>> List([FromQuery] ListPublishersQuery query,CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetPublisherByIdQueryDto> GetById([FromRoute] int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetPublisherByIdQuery { Id = id }, ct);
        return result;
    }

    [HttpPost]
    [Authorize(Policy = "Staff")]
    public async Task<IActionResult> CreatePublisher(CreatePublisherCommand command,CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "Staff")]
    public async Task UpdatePublisher(int id, UpdatePublisherCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeletePublisher(int id, CancellationToken ct)
    {
        await sender.Send(new DeletePublisherCommand { Id = id }, ct);
        return NoContent();
    }

}
