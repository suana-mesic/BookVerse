using Market.Application.Modules.Statistics.Queries.CategoriesPopularity;
using Market.Application.Modules.Statistics.Queries.DashboardCardsSummary;
using Market.Application.Modules.Statistics.Queries.MonthlyOrdersCount;
using Market.Application.Modules.Statistics.Queries.MonthlyRevenue;
using Market.Application.Modules.Statistics.Queries.RevenueByMonthAndCategory;
using Market.Application.Modules.Statistics.Queries.ShippersOrdersCount;
using Market.Application.Modules.Statistics.Queries.Top5Books;
namespace Market.API.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class StatisticsController(ISender sender) : ControllerBase
{

    [HttpGet("monthly-revenue")]
    public async Task<List<GetMonthlyRevenueQueryDto>> GetMonthlyRevene(CancellationToken ct)
    {
        return await sender.Send(new GetMonthlyRevenueQuery(), ct);
    }

    [HttpGet("monthly-orders-count")]
    public async Task<List<GetMonthlyOrdersCountQueryDto>> GetMonthlyOrderCount(CancellationToken ct)
    {
        return await sender.Send(new GetMonthlyOrdersCountQuery(), ct);
    }

    [HttpGet("top-5-books")]
    public async Task<List<GetTopFiveBooksQueryDto>> GetTop5Books(CancellationToken ct)
    {
        return await sender.Send(new GetTopFiveBooksQuery(), ct);
    }

    [HttpGet("shipper-orders-count")]
    public async Task<List<GetShippersOrdersQueryDto>> GetShippersOrdersCount(CancellationToken ct)
    {
        return await sender.Send(new GetShippersOrdersQuery(), ct);
    }


    [HttpGet("categories-popularity")]
    public async Task<List<GetCategoriesPopularityQueryDto>> GetCategoriesPopularity(CancellationToken ct)
    {
        return await sender.Send(new GetCategoriesPopularityQuery(), ct);
    }

    [HttpGet("revenue-by-month-and-category")]
    public async Task<List<GetRevenueByMonthAndCategoryQueryDto>> GetRevenueByMonthAndCategory(CancellationToken ct)
    {
        return await sender.Send(new GetRevenueByMonthAndCategoryQuery(), ct);
    }


    [HttpGet("dashboard-card-summary")]
    public async Task<GetDashboardCardSummaryDto> GetDashboardCardSummary(CancellationToken ct)
    {
        return await sender.Send(new GetDashboardCardSummary(), ct);
    }
}
