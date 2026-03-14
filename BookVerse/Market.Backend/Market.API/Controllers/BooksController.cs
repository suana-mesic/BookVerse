using Market.Application.Modules.Catalog.Book.Commands.Create;
using Market.Application.Modules.Catalog.Book.Commands.Delete;
using Market.Application.Modules.Catalog.Book.Commands.Update;
using Market.Application.Modules.Catalog.Book.Queries.GetById;
using Market.Application.Modules.Catalog.Book.Queries.List;
using Market.Application.Modules.Catalog.Book.Queries.ListForAutocomplete;
namespace Market.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class BooksController(ISender sender) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListBooksQueryDto>> List([FromQuery] ListBooksQuery query,CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetBookByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var category = await sender.Send(new GetBookByIdQuery { Id = id }, ct);
        return category; // if NotFoundException -> 404 via middleware
    }

    [HttpGet("dropdown")]
    public async Task<List<ListBooksForAutocompleteQueryDto>> ListBooksForAutocomplete(CancellationToken ct)
    {
        var result = await sender.Send(new ListBooksForAutocompleteQuery(), ct);
        return result;
    }

    [HttpPost]
    [AllowAnonymous]

    public async Task<ActionResult<int>> CreateBook(CreateBookCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [AllowAnonymous]

    public async Task UpdatBook(int id, UpdateBookCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteBook(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteBookCommand { Id = id }, ct);
        return NoContent();
    }

    //[HttpPut("{id:int}/disable")]
    //public async Task Disable(int id, CancellationToken ct)
    //{
    //    await sender.Send(new DisableProductCategoryCommand { Id = id }, ct);
    //    // no return -> 204 No Content
    //}

    //[HttpPut("{id:int}/enable")]
    //public async Task Enable(int id, CancellationToken ct)
    //{
    //    await sender.Send(new EnableProductCategoryCommand { Id = id }, ct);
    //    // no return -> 204 No Content
    //}
}
