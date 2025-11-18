using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Publishers.Queries.GetById
{
    public class GetPublisherByIdQueryDto
    {
        public required int Id { get; init; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}
