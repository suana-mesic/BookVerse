using BookVerse.Application.Modules.Catalog.Authors.Queries.List;
using BookVerse.Application.Modules.Catalog.Categories.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Book.Queries.List;

// DTO returned by GET /Books (anonymous endpoint).
// IMPORTANT: this is a PUBLIC payload, so it intentionally does NOT include:
//   - QuantityInStockForOnlineOrders : leaking exact stock would let competitors scrape inventory.
//   - IsDeleted                      : a public listing should never even know that flag exists.
// Staff/admin views that need those fields must call a dedicated, authenticated endpoint.
public sealed class ListBooksQueryDto
    {
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public List<ListAuthorsQueryDto> Authors { get; set; }
    public List<ListCategoriesQueryDto> Categories { get; set; }
    public string PublisherName{ get; set; }
    public string BookFormatName { get; set; }
    public decimal Price { get; set; }
    public int LanguageId { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public int PageCount { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }

}

