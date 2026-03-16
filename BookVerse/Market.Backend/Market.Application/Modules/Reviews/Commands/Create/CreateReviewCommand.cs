namespace Market.Application.Modules.Reviews.Commands.Create;

public class CreateReviewCommand : IRequest<Unit>
{
    public required int BookId { get; set; }
    public required int Rating { get; set; }
    public required string Comment { get; set; }
}