using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Catalog.Stores.Queries.List
{
    public class ListStoresQueryDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string City { get; set; }
        public string Line1 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
    }
}
