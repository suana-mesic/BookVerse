using BookVerse.Domain.Common;

namespace BookVerse.Domain.Entities.Shopping
{
    public class Coupons:BaseEntity
    {
        public string Name { get; set; }
        public decimal? AmountOff { get; set; }
        public decimal? PercentOff { get; set; }
        public string PromotionCode { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static class Constraints
        {
            public const int NameMaxLength = 100;
            public const int PromotionCodeMaxLength = 50;
            public const int DescriptionMaxLength = 200;
        }

    }
}
