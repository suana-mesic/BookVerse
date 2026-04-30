using BookVerse.Application.Modules.Catalog.Book.Commands.Create;
using BookVerse.Application.Modules.Catalog.Book.Commands.Delete;
using BookVerse.Application.Modules.Catalog.Book.Commands.Update;
using BookVerse.Application.Modules.Catalog.Book.Queries.GetById;
using BookVerse.Application.Modules.Catalog.Book.Queries.List;
using BookVerse.Application.Modules.Catalog.Book.Queries.ListForAutocomplete;
using BookVerse.Application.Modules.Catalog.Book.Queries.ListMyBooks;
namespace BookVerse.API.Controllers;

[ApiController]
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

    [HttpGet("my-books")]
    [Authorize(Policy = "Customer")]
    public async Task<PageResult<ListMyBooksQueryDto>> ListMyBooks([FromQuery] ListMyBooksQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetBookByIdQueryDto> GetById(int id, [FromQuery] string? language, CancellationToken ct)
    {
        var category = await sender.Send(new GetBookByIdQuery { Id = id, Language = language }, ct);
        return category; // if NotFoundException -> 404 via middleware
    }

    [HttpGet("dropdown")]
    [Authorize(Policy = "Staff")]
    public async Task<List<ListBooksForAutocompleteQueryDto>> ListBooksForAutocomplete(CancellationToken ct)
    {
        var result = await sender.Send(new ListBooksForAutocompleteQuery(), ct);
        return result;
    }

    [HttpPost]
    [Authorize(Policy = "Staff")]

    public async Task<ActionResult<int>> CreateBook(CreateBookCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "Staff")]

    public async Task UpdatBook(int id, UpdateBookCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
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
