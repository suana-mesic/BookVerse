namespace Market.Application.Modules.Reviews.Commands.Delete;

public class DeleteReviewCommand : IRequest<Unit>
{
    public required int UserId { get; set; }
    public required int BookId { get; set; }
}
