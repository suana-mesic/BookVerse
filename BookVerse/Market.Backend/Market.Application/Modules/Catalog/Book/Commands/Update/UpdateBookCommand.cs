namespace Market.Application.Modules.Catalog.Book.Commands.Update;

public sealed class UpdateBookCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; } // ID se prosleđuje u ruti, a ne u body-ju!
    public string? ISBN { get; set; } = string.Empty;
    public string? Title { get; set; } = string.Empty;
    public int? PublisherId { get; set; }
    public int? BookFormatId { get; set; }
    public int[]? AuthorIds { get; set; }
    public int[]? CategoryIds { get; set; }
    public decimal? Price { get; set; }
    public int? LanguageId { get; set; }
    public string? Description { get; set; }
    public int? PageCount { get; set; }
    public int? QuantityInStockForOnlineOrders { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime? PublishedDate { get; set; }
}
