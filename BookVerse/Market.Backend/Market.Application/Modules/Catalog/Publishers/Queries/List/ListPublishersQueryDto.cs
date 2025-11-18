namespace Market.Application.Modules.Catalog.Publishers.Queries.List;

public sealed class ListPublishersQueryDto
{
    public required int Id { get; init; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
}
