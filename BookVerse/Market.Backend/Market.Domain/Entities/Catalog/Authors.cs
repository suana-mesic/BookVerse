using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Authors:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
    }
}
