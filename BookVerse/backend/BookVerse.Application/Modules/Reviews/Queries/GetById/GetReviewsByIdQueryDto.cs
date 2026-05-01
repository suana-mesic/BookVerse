namespace BookVerse.Application.Modules.Reviews.Queries.GetById;

public class GetReviewsByIdQueryDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime DatePosted { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
