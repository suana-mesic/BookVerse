namespace Market.Application.Modules.Catalog.Publishers.Queries.List;

public sealed class ListPublishersQuery : BasePagedQuery<ListPublishersQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyEnabled { get; init; }
}
