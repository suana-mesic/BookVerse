using Market.Application.Modules.Catalog.Authors.Queries;
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
}
