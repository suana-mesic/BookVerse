using BookVerse.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Domain.Entities.Shopping
{
    public class Refunds
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        // The ID returned by Stripe for this refund (e.g. "re_..."). Without it we cannot
        // reconcile our refund records with what actually happened on Stripe's side, which
        // is the whole point of keeping the table: an auditable trail of every refund.
        public string StripeRefundId { get; set; } = string.Empty;


        public static class Constraints
        {
            public const int StatusMaxLength = 50;
            public const int ReasonMaxLength = 255;
            public const int StripeRefundIdMaxLength = 100;
        }
    }
}
