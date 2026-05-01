namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.GetFormConfig;

public class GetFormConfigQueryHandler
    : IRequestHandler<GetFormConfigQuery, List<GetFormConfigQueryDto>>
{
    public Task<List<GetFormConfigQueryDto>> Handle(GetFormConfigQuery request, CancellationToken ct)
    {
        var discountField = request.CouponType == "percent"
            ? new GetFormConfigQueryDto { Name = "percentOff", Label = "Discount (%)", Type = "number", Required = true }
            : new GetFormConfigQueryDto { Name = "amountOff", Label = "Discount (BAM)", Type = "number", Required = true };

        var fields = new List<GetFormConfigQueryDto>
        {
            discountField,
            new() { Name = "name", Label = "Coupon name", Type = "text", Required = true },
            new() { Name = "promotionCode", Label = "Promotion code", Type = "text", Required = true },
            new() { Name = "startDate", Label = "Start date", Type = "date", Required = true },
            new() { Name = "endDate", Label = "Expiration date", Type = "date", Required = true },
            new() { Name = "description", Label = "Description", Type = "text", Required = false }
        };

        return Task.FromResult(fields);
    }
}
