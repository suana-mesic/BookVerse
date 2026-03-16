using Market.Application.Modules.Reviews.Commands.Create;
using Market.Application.Modules.Reviews.Queries.GetById;
using Market.Application.Modules.Reviews.Commands.Update;
using Market.Application.Modules.Reviews.Commands.Delete;
using Market.Application.Modules.Reviews.Queries.ListForBook;

namespace Market.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class ReviewsController(ISender sender) : ControllerBase
{
    //Recenzija za neku knjigu ali samo za trenutnog korisnika
    [HttpGet("{bookId:int}")]
    public async Task<GetReviewsByIdQueryDto> GetById(int bookId, CancellationToken ct)
    {
        var review = await sender.Send(new GetReviewsByIdQuery { BookId = bookId }, ct);
        return review; // if NotFoundException -> 404 via middleware
    }

    //Dohvati sve recenzije za neku knjigu, koristi se za prikaz knjiga u sekciji detalji knjige
    [AllowAnonymous]
    [HttpGet("{bookId:int}/all")]
    public async Task<PageResult<ListReviewsForBookQueryDto>> GetAllReviewsForBook(int bookId, [FromQuery] ListReviewsForBookQuery request, CancellationToken ct)
    {
        request.BookId = bookId;
        var reviews = await sender.Send(request, ct);
        return reviews;
    }

    //Poziva se kada korisnik želi napisati novu recenziju
    [HttpPost]
    public async Task<ActionResult> Create(CreateReviewCommand command, CancellationToken ct)
    {
        var poruka = await sender.Send(command, ct);
        return Ok(poruka);
    }

    //Poziva se kada korisnik želi urediti postojeću recenziju
    [HttpPut("{bookId:int}")]
    public async Task<ActionResult> Update(int bookId, int userId, UpdateReviewCommand command, CancellationToken ct)
    {
        command.BookId = bookId;
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    [HttpDelete("{bookId:int}")]
    public async Task Delete(int bookId, CancellationToken ct)
    {
        await sender.Send(new DeleteReviewCommand { BookId = bookId }, ct);
    }
}