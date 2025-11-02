namespace Market.Application.Modules.Catalog.Book.Commands.Create;

public class CreateBookCommand : IRequest<int>
{
    public required string ISBN { get; set; }
    public required string Title { get; set; }
    public required int PublisherId { get; set; }
    public required int BookFormatId { get; set; }
    public  required decimal Price { get; set; }
    public required string Language { get; set; }
    public string? Description { get; set; }
    public required int PageCount { get; set; }
    public int? QuantityInStockForOnlineOrders { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
}