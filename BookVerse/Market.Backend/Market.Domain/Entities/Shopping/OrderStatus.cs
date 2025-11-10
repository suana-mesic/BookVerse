using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class OrderStatus:BaseEntity
    {
        public string StatusName { get; set; }

        public static class Constraints
        {
            public const int StatusNameMaxLength = 30;
        }
    }
}
