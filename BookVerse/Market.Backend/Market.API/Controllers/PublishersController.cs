using Market.Application.Modules.Catalog.Book.Queries.List;
using Market.Application.Modules.Catalog.Publishers.Queries;
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
}
