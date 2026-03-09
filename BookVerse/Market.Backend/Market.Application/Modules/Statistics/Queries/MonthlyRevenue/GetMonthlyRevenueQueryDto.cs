namespace Market.Application.Modules.Statistics.Queries.MonthlyRevenue
{
    public class GetMonthlyRevenueQueryDto
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
