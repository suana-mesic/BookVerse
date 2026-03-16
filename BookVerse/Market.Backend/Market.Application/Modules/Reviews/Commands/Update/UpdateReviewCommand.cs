namespace Market.Application.Modules.Reviews.Commands.Update;

public sealed class UpdateReviewCommand : IRequest<Unit>
{
    [JsonIgnore] // BookId dolazi iz route parametra
    public int BookId { get; set; }
    public required string Comment { get; set; }
    public required int Rating { get; set; }
}
