namespace Market.Application.Modules.Catalog.Authors.Queries;

public sealed class ListAuthorsQuery : BasePagedQuery<ListAuthorsQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyEnabled { get; init; }
}
