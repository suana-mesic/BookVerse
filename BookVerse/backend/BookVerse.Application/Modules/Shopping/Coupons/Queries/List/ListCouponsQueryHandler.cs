using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.List
{
    public class ListCouponsQueryHandler(IAppDbContext context) : IRequestHandler<ListCouponsQuery, List<ListCouponsQueryDto>>
    {
        public async Task<List<ListCouponsQueryDto>> Handle(ListCouponsQuery request, CancellationToken ct)
        {
            return await context.Coupons
                .AsNoTracking()
                .Where(x => !x.IsDeleted && x.StartDate <= DateTime.UtcNow && x.EndDate >= DateTime.UtcNow)
                .Select(x => new ListCouponsQueryDto
                {
                    Name = x.PromotionCode
                }).ToListAsync(ct);
        }
    }
}
