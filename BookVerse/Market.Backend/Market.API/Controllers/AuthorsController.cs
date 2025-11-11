using Market.Application.Modules.Catalog.Authors.Commands.Create;
using Market.Application.Modules.Catalog.Authors.Commands.Delete;
using Market.Application.Modules.Catalog.Authors.Commands.Update;
using Market.Application.Modules.Catalog.Authors.Queries.GetById;
using Market.Application.Modules.Catalog.Authors.Queries.List;
using Market.Application.Modules.Catalog.Book.Commands.Create;
using Market.Application.Modules.Catalog.Book.Queries.List;
using Market.Application.Modules.Catalog.Publishers.Queries;
namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController(ISender sender) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListAuthorsQueryDto>> List([FromQuery] ListAuthorsQuery query,CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetAuthorByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var category = await sender.Send(new GetAuthorByIdQuery { Id = id }, ct);
        return category; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateAuthor(CreateAuthorCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [AllowAnonymous]
    public async Task UpdateAuthor(int id, UpdateAuthorCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAuthor(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteAuthorCommand { Id = id }, ct);
        return NoContent();
    }
}
