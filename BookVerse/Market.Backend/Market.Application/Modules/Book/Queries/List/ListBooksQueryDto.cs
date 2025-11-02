using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Book.Queries.List;
    public sealed class ListBooksQueryDto
    {
    public int Id { get; set; }
    public string ISBN { get; set; }
    public string BookTitle { get; set; }
    public string PublisherName { get; set; } 
    public string BookFormatName { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public int PageCount { get; set; }
    public int? QuantityInStockForOnlineOrders { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
}

