namespace Market.Application.Modules.Catalog.Categories.Queries.List
{
    public sealed class ListCategoriesQuery : IRequest<List<ListCategoriesQueryDto>>
    {
        public string? Search { get; init; }
        public string? Language { get; init; }
    }
}
