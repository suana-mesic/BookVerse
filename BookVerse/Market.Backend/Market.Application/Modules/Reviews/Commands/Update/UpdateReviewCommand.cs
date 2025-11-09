namespace Market.Application.Modules.Review.Commands.Update;

public sealed class UpdateReviewCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int UserId { get; set; }
    [JsonIgnore]
    public int BookId { get; set; }
    public required string Comment { get; set; }
    public required int Rating { get; set; }
}
