using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Books : BaseEntity
    {
        public string ISBN { get; set; }
        public string Title { get; set; }

        public ICollection<Authors> Authors { get; set; } = new List<Authors>();
        public ICollection <Categories> Categories { get; set; } = new List<Categories>();

        public int PublisherId { get; set; }
        public Publishers Publisher { get; set; }
        public int BookFormatId { get; set; }
        public BookFormats BookFormat { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public string? Description { get; set; }
        public int PageCount { get; set; }
        public int? QuantityInStockForOnlineOrders { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }

        public static class Constraints
        {
            public const int ISBNMaxLength = 20;
            public const int TitleMaxLength = 150;
            public const int LanguageMaxLength = 60;
        }
    }
}
