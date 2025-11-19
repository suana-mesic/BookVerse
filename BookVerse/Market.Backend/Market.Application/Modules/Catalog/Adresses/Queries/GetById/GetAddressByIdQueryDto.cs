using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Adresses.Queries.GetById
{
    public class GetAddressByIdQueryDto
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
