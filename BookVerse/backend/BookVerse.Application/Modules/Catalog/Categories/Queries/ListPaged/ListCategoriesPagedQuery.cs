using Stripe;

namespace BookVerse.Application.Modules.Catalog.Categories.Queries.ListPaged
{
    public sealed class ListCategoriesPagedQuery:BasePagedQuery<ListCategoriesPagedQueryDto>
    {
        public string? Search { get; init; }
        public bool? OnlyEnabled { get; init; }
        public string? Language { get; init; }

    }
}
