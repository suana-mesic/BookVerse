namespace Market.Application.Modules.Review.Commands.Create;

public class CreateReviewCommand : IRequest<string>
{
    public required int UserId { get; set; }
    public required int BookId { get; set; }
    public required int Rating { get; set; }
    public required string Comment { get; set; }
}