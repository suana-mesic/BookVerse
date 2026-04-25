using Market.Application.Common;
using Market.Application.Modules.Catalog.Book.Queries.List;

namespace Market.Application.Modules.Catalog.Book.Queries.ListMyBooks
{
    public class ListMyBooksQuery :  BasePagedQuery<ListMyBooksQueryDto>
    {
        public string? Search { get; set; }
        // Lista category ID-eva koji služe kao tagovi za filtriranje
        public List<int> CategoryIds { get; set; } = new();
        public string? Language { get; set; }
    }
}
