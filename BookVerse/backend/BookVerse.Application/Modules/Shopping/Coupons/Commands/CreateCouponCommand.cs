namespace BookVerse.Application.Modules.Shopping.Coupons.Commands
{
    public class CreateCouponCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal? AmountOff { get; set; }
        public decimal? PercentOff { get; set; }
        public string PromotionCode { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}