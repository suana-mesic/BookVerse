namespace BookVerse.Application.Modules.Reviews.Queries.GetById;

public class GetReviewsByIdQuery : IRequest<GetReviewsByIdQueryDto>
{
    [JsonIgnore]
    public int BookId { get; set; }
}