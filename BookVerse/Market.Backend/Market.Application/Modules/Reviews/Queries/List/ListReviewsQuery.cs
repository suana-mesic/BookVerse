using Market.Application.Modules.Review.Queries.List;

namespace Market.Application.Modules.Review.Queries.List;

public sealed class ListReviewsQuery : BasePagedQuery<ListReviewsQueryDto>
{
    public string? BookTitle { get; init; }
    public string? UserFirstName { get; init; }
    public string? Comment { get; init; }
    public int? Rating { get; set; }
    public DateTime? DateCreatedFrom { get; init; }
    public DateTime? DateCreatedTo { get; init; }
}
