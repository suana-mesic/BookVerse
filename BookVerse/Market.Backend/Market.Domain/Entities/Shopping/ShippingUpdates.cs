using Market.Domain.Common;
using Market.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain.Entities.Shopping
{
    public class ShippingUpdates : BaseEntity
    {
        public int OrderId { get; set; }
        public Orders Order { get; set; }
        public int UpdatedByUserId { get; set; }
        public MarketUserEntity UpdatedByUser { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Notes { get; set; }
        public bool isCurrent { get; set; }
        public int RowNumber { get; set; }

        public static class Constraints
        {
            public const int NotesMaxLength = 200;
        }
    }
}
