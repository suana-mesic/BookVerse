using BookVerse.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Domain.Entities.Shopping
{
    public class OrderStatus:BaseEntity
    {
        public OrderStatusType StatusName { get; set; }

        public static class Constraints
        {
            public const int StatusNameMaxLength = 30;
        }

    }
        public enum OrderStatusType
        {
            Draft = 1,
            Packed = 2,
            Paid = 3,
            Shipped = 4,
            Cancelled = 5,
            //Order created in DB but the Stripe PaymentIntent has been generated and the user is in the checkout flow.
            PaymentPending = 6,
            //Stripe webhook reported payment_intent.payment_failed. Order is dead, refund (if any) is handled by Stripe.
            PaymentFailed = 7,
            //Background cleanup expired the order because it sat in Draft/PaymentPending past the cutoff.
            Expired = 8
        }
}
