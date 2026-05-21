namespace BookVerse.Application.Modules.Catalog.Book.Queries.GetById;

// DTO returned by GET /api/books/{id} (anonymous endpoint).
// IMPORTANT: same security rule as ListBooksQueryDto. The by-id endpoint is also public,
// so QuantityInStockForOnlineOrders is NOT exposed - otherwise anyone could scrape stock
// counts one book at a time by hitting /api/books/1, /api/books/2, etc. IsDeleted is never
// in the payload either; the global query filter already hides soft-deleted books from
// the response.
public class GetBookByIdQueryDto
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public int PublisherId { get; set; }
    public int[] AuthorIds { get; set; }
    public int[] CategoryIds { get; set; }
    public string PublisherName { get; set; }
    public int BookFormatId { get; set; }
    public string BookFormatName { get; set; }
    public decimal Price { get; set; }
    public int LanguageId { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public int PageCount { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
}
