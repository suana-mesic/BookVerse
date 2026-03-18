using Market.Application.Modules.Catalog.Categories.Commands.Create;
using Market.Application.Modules.Catalog.Categories.Commands.Delete;
using Market.Application.Modules.Catalog.Categories.Commands.Status.Disable;
using Market.Application.Modules.Catalog.Categories.Commands.Status.Enable;
using Market.Application.Modules.Catalog.Categories.Commands.Update;
using Market.Application.Modules.Catalog.Categories.Queries.GetById;
using Market.Application.Modules.Catalog.Categories.Queries.List;
using Market.Application.Modules.Catalog.Categories.Queries.ListPaged;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(ISender sender) : ControllerBase
{
    //Only enabled categories -> used for adding books
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<ListCategoriesQueryDto>> List([FromQuery] ListCategoriesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    //Paged result
    [HttpGet("list-paged")]
    [AllowAnonymous]
    public async Task<PageResult<ListCategoriesPagedQueryDto>> ListPaged([FromQuery] ListCategoriesPagedQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    public async Task<GetCategoryByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var category = await sender.Send(new GetCategoryByIdQuery { Id = id }, ct);
        return category; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]
    [Authorize(Policy = "Staff")]
    public async Task<ActionResult<int>> CreateCategory(CreateCategoryCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpPut("{id:int}")]
    [Authorize(Policy = "Staff")]
    public async Task UpdateCategory(int id, UpdateCategoryCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteCategoryCommand { Id = id }, ct);
        return NoContent();
    }

    [HttpPut("{id:int}/disable")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DisableCategory(int id, CancellationToken ct)
    {
        await sender.Send(new DisableCategoryComamnd { Id = id }, ct);
        return NoContent();
    }

    [HttpPut("{id:int}/enable")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> EnableCategory(int id, CancellationToken ct)
    {
        await sender.Send(new EnableCategoryComamnd { Id = id }, ct);
        return NoContent();
    }
}

