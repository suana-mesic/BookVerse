using BookVerse.Application.Modules.Reviews.Commands.Create;
using BookVerse.Application.Modules.Reviews.Queries.GetById;
using BookVerse.Application.Modules.Reviews.Commands.Update;
using BookVerse.Application.Modules.Reviews.Commands.Delete;
using BookVerse.Application.Modules.Reviews.Queries.ListForBook;

namespace BookVerse.API.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewsController(ISender sender) : ControllerBase
{
    //Review for a book but only for the current user
    [HttpGet("{bookId:int}")]
    [Authorize(Policy = "Customer")]
    public async Task<GetReviewsByIdQueryDto> GetById(int bookId, CancellationToken ct)
    {
        var review = await sender.Send(new GetReviewsByIdQuery { BookId = bookId }, ct);
        return review; // if NotFoundException -> 404 via middleware
    }

    //Fetch all reviews for a book, used for displaying books in the book details section
    [AllowAnonymous]
    [HttpGet("{bookId:int}/all")]
    public async Task<PageResult<ListReviewsForBookQueryDto>> GetAllReviewsForBook(int bookId, [FromQuery] ListReviewsForBookQuery request, CancellationToken ct)
    {
        request.BookId = bookId;
        var reviews = await sender.Send(request, ct);
        return reviews;
    }

    //Called when the user wants to write a new review
    [HttpPost]
    [Authorize(Policy = "Customer")]
    public async Task<ActionResult> Create(CreateReviewCommand command, CancellationToken ct)
    {
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    //Called when the user wants to edit an existing review
    [HttpPut("{bookId:int}")]
    [Authorize(Policy = "Customer")]
    public async Task<ActionResult> Update(int bookId, UpdateReviewCommand command, CancellationToken ct)
    {
        command.BookId = bookId;
        var result = await sender.Send(command, ct);
        return Ok(result);
    }

    //Called when the user wants to delete their review
    [HttpDelete("{bookId:int}")]
    [Authorize(Policy = "Customer")]
    public async Task Delete(int bookId, CancellationToken ct)
    {
        await sender.Send(new DeleteReviewCommand { BookId = bookId }, ct);
    }
}