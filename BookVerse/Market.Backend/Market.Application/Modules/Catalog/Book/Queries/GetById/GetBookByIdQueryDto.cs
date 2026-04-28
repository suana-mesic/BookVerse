namespace Market.Application.Modules.Catalog.Book.Queries.GetById;

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
    public int? QuantityInStockForOnlineOrders { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
}
