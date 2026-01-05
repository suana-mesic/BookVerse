namespace Market.Application.Modules.Reviews.Queries.GetById;

public class GetReviewsByIdQuery : IRequest<GetReviewsByIdQueryDto>
{
    public int? UserId { get; set; }
    public int? BookId { get; set; }
}