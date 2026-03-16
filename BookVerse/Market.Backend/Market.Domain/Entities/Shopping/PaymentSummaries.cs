using Market.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class PaymentSummaries:BaseEntity
    {
        public string Last4Digits { get; set; }
        public string Brand { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }

        public static class Constraints
        {
            public const int BrandMaxLength = 30;
        }
    }
}
