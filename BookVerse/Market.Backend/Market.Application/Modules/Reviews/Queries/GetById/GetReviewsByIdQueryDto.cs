namespace Market.Application.Modules.Review.Queries.GetById;

public class GetReviewsByIdQueryDto
{
    public required int Rating { get; init; }
    public required string Comment { get; init; }
    public required DateTime DatePosted { get; init; }
    public required GetReviewsByIdQueryBookDto Book { get; init; }
    public required GetReviewsByIdQueryUserDto User { get; init; }
}

public class GetReviewsByIdQueryBookDto
{
    public required string ISBN { get; init; }
    public required string Title { get; init; }
}

public class GetReviewsByIdQueryUserDto
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}