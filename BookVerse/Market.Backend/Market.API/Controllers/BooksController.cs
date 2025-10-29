using Market.Application.Modules.Book.Queries.List;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers;

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
}
