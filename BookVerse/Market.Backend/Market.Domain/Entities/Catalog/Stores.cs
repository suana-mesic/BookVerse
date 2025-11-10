using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Catalog
{
    public class Stores:BaseEntity
    {
        public int StoreName { get; set; }
        public int AddressId { get; set; }
        public Addresses Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }

        public static class Constraints
        {
            public const int StoreNameMaxLength = 100;
            public const int PhoneMaxLength = 20;
            public const int EmailMaxLength = 100;
            public const int OpeningHoursMaxLength = 200;
        }
    }
}
