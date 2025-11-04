using Market.Application.Modules.Catalog.Categories.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(ISender sender) : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<ListCategoriesQueryDto>> List([FromQuery] ListCategoriesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }
}

