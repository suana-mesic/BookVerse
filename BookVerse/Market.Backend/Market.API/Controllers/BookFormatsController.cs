using Market.Application.Modules.Catalog.BookFormats.Queries.List;
using Market.Application.Modules.Catalog.Categories.Commands.Create;
using Market.Application.Modules.Catalog.Categories.Commands.Delete;
using Market.Application.Modules.Catalog.Categories.Commands.Update;
using Market.Application.Modules.Catalog.Categories.Queries.GetById;
using Market.Application.Modules.Catalog.Categories.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookFormatsController(ISender sender) : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListBookFormatsQueryDto>> List([FromQuery] ListBookFormatsQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    //[HttpGet("{id:int}")]
    //[AllowAnonymous]
    //public async Task<GetCategoryByIdQueryDto> GetById(int id, CancellationToken ct)
    //{
    //    var category = await sender.Send(new GetCategoryByIdQuery { Id = id }, ct);
    //    return category; // if NotFoundException -> 404 via middleware
    //}

    //[HttpPost]
    //[AllowAnonymous]
    //public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand command, CancellationToken ct)
    //{
    //    int id = await sender.Send(command, ct);

    //    return CreatedAtAction(nameof(GetById), new { id }, new { id });
    //}

    //[HttpPut("{id:int}")]
    //[AllowAnonymous]
    //public async Task UpdateCategory(int id, UpdateCategoryCommand command, CancellationToken ct)
    //{
    //    // ID from the route takes precedence
    //    command.Id = id;
    //    await sender.Send(command, ct);
    //    // no return -> 204 No Content
    //}

    //[HttpDelete("{id:int}")]
    //[AllowAnonymous]
    //public async Task<IActionResult> DeleteCategory(int id, CancellationToken ct)
    //{
    //    await sender.Send(new DeleteCategoryCommand { Id = id }, ct);
    //    return NoContent();
    //}
}

