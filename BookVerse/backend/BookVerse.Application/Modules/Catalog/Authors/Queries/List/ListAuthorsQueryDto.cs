namespace BookVerse.Application.Modules.Catalog.Authors.Queries.List;

public sealed class ListAuthorsQueryDto
{
    public required int Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    public string Country { get; set; }
}
