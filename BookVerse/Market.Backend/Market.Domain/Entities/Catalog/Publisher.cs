using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Publisher:BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public static class Constraints
        {
            public const int NameMaxLength = 100;
            public const int CityMaxLength = 60;
            public const int CountryMaxLength = 60;

        }
    }
}
