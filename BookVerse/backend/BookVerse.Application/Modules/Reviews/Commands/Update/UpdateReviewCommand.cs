namespace BookVerse.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommand : IRequest<Unit>
{
    [JsonIgnore] // BookId comes from the route parameter
    public int BookId { get; set; }
    public required string Comment { get; set; }
    public required int Rating { get; set; }
}
