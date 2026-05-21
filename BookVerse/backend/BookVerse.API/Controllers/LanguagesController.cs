using BookVerse.Application.Modules.Catalog.Languages.Queries.List;

namespace BookVerse.API.Controllers;

[ApiController]
[Route("api/languages")]
public class LanguagesController(ISender sender) : Controller
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<List<ListLanguagesQueryDto>> List([FromQuery] ListLanguagesQuery query, CancellationToken ct)
    {
        return await sender.Send(query, ct);
    }
}
