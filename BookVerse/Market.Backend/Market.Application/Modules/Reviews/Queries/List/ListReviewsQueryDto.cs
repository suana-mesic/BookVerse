using Market.Application.Modules.Review.Queries.GetById;

namespace Market.Application.Modules.Review.Queries.List;

public sealed class ListReviewsQueryDto : BasePagedQuery<ListReviewsQueryDto>
{
    public required int Rating { get; init; }
    public required string Comment { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public required GetReviewsByIdQueryBookDto Book { get; init; }
    public required GetReviewsByIdQueryUserDto  User { get; init; }
}