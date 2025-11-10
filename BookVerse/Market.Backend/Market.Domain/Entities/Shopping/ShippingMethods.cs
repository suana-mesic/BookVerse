using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class ShippingMethods:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static class Constraints
        {
            public const int NameMaxLength = 50;
            public const int DescriptionMaxLength = 200;
        }
    }
}
