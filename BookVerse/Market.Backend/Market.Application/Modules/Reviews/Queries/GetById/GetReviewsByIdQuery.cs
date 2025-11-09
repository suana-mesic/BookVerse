namespace Market.Application.Modules.Review.Queries.GetById;

public class GetReviewsByIdQuery : IRequest<GetReviewsByIdQueryDto>
{
    public int UserId { get; set; }
    public int BookId { get; set; }
}