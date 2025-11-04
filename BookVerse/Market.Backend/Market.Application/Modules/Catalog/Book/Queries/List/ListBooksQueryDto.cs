using Market.Application.Modules.Catalog.Authors.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Book.Queries.List;
    public sealed class ListBooksQueryDto
    {
    public string ISBN { get; set; }
    public string Title { get; set; }
    public List<ListAuthorsQueryDto> Authors { get; set; }
    public string PublisherName{ get; set; }
    public string BookFormatName { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string? Description { get; set; }
    public int PageCount { get; set; }
    public int? QuantityInStockForOnlineOrders { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
}

