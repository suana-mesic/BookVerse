using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.ValidateCoupon
{
    public class ValidateCouponQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PromotionCode { get; set; }
        public decimal? AmountOff { get; set; }
        public decimal? PercentOff { get; set; }
        public string? Description { get; set; }
        public decimal? MinOrderAmount { get; set; }
    }
}
