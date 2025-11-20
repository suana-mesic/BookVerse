using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Catalog.Stores.Queries.GetById
{
    public class GetStoreByIdQueryDto
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
    }
}
