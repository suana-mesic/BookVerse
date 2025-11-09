using Market.Application.Modules.Review.Commands.Create;
using Market.Application.Modules.Review.Queries.GetById;
using Market.Application.Modules.Review.Queries.List;
using Market.Application.Modules.Review.Commands.Update;
using Market.Application.Modules.Reviews.Commands.Delete;

namespace Market.API.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class ReviewsController(ISender sender) : ControllerBase
{
    [HttpGet("{bookId:int}/{userId:int}")]
    public async Task<GetReviewsByIdQueryDto> GetById(int bookId, int userId, CancellationToken ct)
    {
        var review = await sender.Send(new GetReviewsByIdQuery { BookId = bookId, UserId = userId }, ct);
        return review; // if NotFoundException -> 404 via middleware
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateProductCategory(CreateReviewCommand command, CancellationToken ct)
    {
        var poruka = await sender.Send(command, ct);
        return poruka;
    }

    [HttpGet]
    public async Task<PageResult<ListReviewsQueryDto>> List([FromQuery] ListReviewsQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpPut("{bookId:int}/{userId:int}")]
    public async Task Update(int bookId, int userId, UpdateReviewCommand command, CancellationToken ct)
    {
        command.UserId = userId;
        command.BookId = bookId;

        await sender.Send(command, ct);
    }

    [HttpDelete("{bookId:int}/{userId:int}")]
    public async Task Delete(int bookId, int userId, CancellationToken ct)
    {
        await sender.Send(new DeleteReviewCommand { UserId = userId, BookId = bookId }, ct);
        // no return -> 204 No Content
    }
}