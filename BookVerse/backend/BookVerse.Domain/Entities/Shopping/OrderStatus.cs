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
            Cancelled = 5
        }
}
