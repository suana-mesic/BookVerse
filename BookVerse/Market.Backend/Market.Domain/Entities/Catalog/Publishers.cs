using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Publishers:BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
