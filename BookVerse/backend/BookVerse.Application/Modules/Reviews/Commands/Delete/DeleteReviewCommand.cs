namespace BookVerse.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
}
