using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Statistics.Queries.DashboardCardsSummary
{
    public class GetDashboardCardSummaryHandler(IAppDbContext context, TimeProvider time) : IRequestHandler<GetDashboardCardSummary, GetDashboardCardSummaryDto>
    {
        public async Task<GetDashboardCardSummaryDto> Handle(GetDashboardCardSummary request, CancellationToken ct)
        {
            // Single "now" snapshot so the month/year used across all four KPI calculations
            // (revenue, orders, users, books) is internally consistent. TimeProvider also lets
            // unit tests pin "now" and assert the resulting percentages deterministically.
            var nowUtc = time.GetUtcNow().UtcDateTime;
            var thisMonth = nowUtc.Month;
            var thisYear = nowUtc.Year;
            var lastMonth = thisMonth == 1 ? 12 : thisMonth - 1;
            var lastMonthYear = thisMonth == 1 ? thisYear - 1 : thisYear; //the year in which last month falls

            //RevenueChangePercent
            var thisMonthRevenue = await context.Orders
                .Where(x => x.PaidAt != null && x.PaidAt.Value.Month == thisMonth && x.PaidAt.Value.Year == thisYear)
                 .SumAsync(x => x.TotalPrice, ct);

            var lastMonthRevenue = await context.Orders
                .Where(x => x.PaidAt != null && x.PaidAt.Value.Month == lastMonth && x.PaidAt.Value.Year == lastMonthYear)
                .SumAsync(x => x.TotalPrice, ct);

            var revenueChange = lastMonthRevenue == 0 ? 0 :
                Math.Round((thisMonthRevenue - lastMonthRevenue) / lastMonthRevenue * 100, 1);

            //OrdersChangePercent
            var thisMonthOrdersCount = await context.Orders
                .Where(x => x.OrderDate.Month == thisMonth && x.OrderDate.Year == thisYear)
                .CountAsync(ct);

            var lastMonthOrdersCount = await context.Orders
                .Where(x => x.OrderDate.Month == lastMonth && x.OrderDate.Year == lastMonthYear)
                .CountAsync(ct);

            var ordersCountChange = lastMonthOrdersCount == 0 ? 0 :
                Math.Round((decimal)(thisMonthOrdersCount - lastMonthOrdersCount) / lastMonthOrdersCount * 100, 1);


            //UsersChangePercent
            var thisMonthUsersCount = await context.Users
                .Where(x => x.CreatedAtUtc.Month == thisMonth && x.CreatedAtUtc.Year == thisYear)
                .CountAsync(ct);

            var lastMonthUsersCount = await context.Users
                .Where(x => x.CreatedAtUtc.Month == lastMonth && x.CreatedAtUtc.Year == lastMonthYear)
                .CountAsync(ct);

            var usersCountChange = lastMonthUsersCount == 0 ? 0 :
                Math.Round((decimal)(thisMonthUsersCount - lastMonthUsersCount) / lastMonthUsersCount * 100 * 1.0m, 1);

            //BooksSoldChangePercent
            var thisMonthBooksQuantity = await context.OrderItems
                .Include(x => x.Order)
                .Where(x => x.Order.PaidAt != null && x.Order.PaidAt.Value.Month == thisMonth && x.Order.PaidAt.Value.Year == thisYear)
                .CountAsync(ct);

            var lastMonthBooksQuantity = await context.OrderItems
                .Include(x => x.Order)
                .Where(x => x.Order.PaidAt != null && x.Order.PaidAt.Value.Month == lastMonth && x.Order.PaidAt.Value.Year == lastMonthYear)
                .CountAsync(ct);

            var booksQuantityChange = lastMonthBooksQuantity == 0 ? 0 :
                Math.Round((decimal)(thisMonthBooksQuantity - lastMonthBooksQuantity) / lastMonthBooksQuantity * 100 * 1.0m, 1);


            var summary = new GetDashboardCardSummaryDto
            {
                TotalRevenue = await context.Orders
                .Where(x => x.OrderStatusId == (int)OrderStatusType.Paid)
                .SumAsync(x => x.TotalPrice, ct),

                TotalOrders = await context.Orders.CountAsync(ct),

                TotalUsers = await context.Users.CountAsync(ct),

                TotalBooksSold = await context.OrderItems
                .Include(x => x.Order)
                .Where(x => x.Order.PaidAt != null)
                .SumAsync(x => x.Quantity, ct),

                RevenueChangePercent = revenueChange,
                OrdersChangePercent = ordersCountChange,
                UsersChangePercent = usersCountChange,
                BooksSoldChangePercent = booksQuantityChange

            };


            return summary;
        }
    }
}
