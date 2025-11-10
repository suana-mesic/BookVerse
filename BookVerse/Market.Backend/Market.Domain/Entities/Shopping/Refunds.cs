using Market.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class Refunds
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }


        public static class Constraints
        {
            public const int StatusMaxLength = 50;
            public const int ReasonMaxLength = 255;
        }
    }
}
