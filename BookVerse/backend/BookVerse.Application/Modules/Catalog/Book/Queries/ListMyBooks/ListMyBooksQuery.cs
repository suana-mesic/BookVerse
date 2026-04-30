using BookVerse.Application.Common;
using BookVerse.Application.Modules.Catalog.Book.Queries.List;

namespace BookVerse.Application.Modules.Catalog.Book.Queries.ListMyBooks
{
    public class ListMyBooksQuery :  BasePagedQuery<ListMyBooksQueryDto>
    {
        public string? Search { get; set; }
        // List of category IDs used as tags for filtering
        public List<int> CategoryIds { get; set; } = new();
        public string? Language { get; set; }
    }
}
