namespace Market.Application.Modules.Catalog.Languages.Queries.List
{
    public class ListLanguagesQuery : IRequest<List<ListLanguagesQueryDto>>
    {
        public string? Language { get; init; }
    }
}
