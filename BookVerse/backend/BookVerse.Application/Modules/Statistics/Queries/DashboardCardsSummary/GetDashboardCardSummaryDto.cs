namespace BookVerse.Application.Modules.Statistics.Queries.DashboardCardsSummary
{
    public class GetDashboardCardSummaryDto
    {
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalUsers { get; set; }
        public int TotalBooksSold { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        // Trends - comparison with the previous month
        public decimal RevenueChangePercent { get; set; }
        public decimal OrdersChangePercent { get; set; }
        public decimal UsersChangePercent { get; set; }
        public decimal BooksSoldChangePercent { get; set; }
    }
}
