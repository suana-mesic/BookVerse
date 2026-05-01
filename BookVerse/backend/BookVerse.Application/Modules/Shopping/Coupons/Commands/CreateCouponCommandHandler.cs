
namespace BookVerse.Application.Modules.Shopping.Coupons.Commands
{
    public class CreateCouponCommandHandler(IAppDbContext context) : IRequestHandler<CreateCouponCommand, int>
    {
        public async Task<int> Handle(CreateCouponCommand request, CancellationToken ct)
        {
            Console.WriteLine(request.StartDate);
            var cleanCode = request.PromotionCode.ToLower();
            var exists = await context.Coupons
                .AnyAsync(c => c.PromotionCode.ToLower() == cleanCode && !c.IsDeleted, ct);

            if (exists)
                throw new BookVerseConflictException("A coupon with this promotion code already exists.");

            if (request.AmountOff.HasValue && request.PercentOff.HasValue)
                throw new BookVerseBusinessRuleException("123", "A coupon can only have one discount type.");

            var coupon = new BookVerse.Domain.Entities.Shopping.Coupons
            {
                Name = request.Name,
                AmountOff = request.AmountOff,
                PercentOff = request.PercentOff,
                PromotionCode = request.PromotionCode,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            context.Coupons.Add(coupon);
            await context.SaveChangesAsync(ct);

            return coupon.Id;
        }
    }
}
