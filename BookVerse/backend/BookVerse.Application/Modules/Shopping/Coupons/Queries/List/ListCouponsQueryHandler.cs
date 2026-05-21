using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.Coupons.Queries.List
{
    public class ListCouponsQueryHandler(IAppDbContext context, TimeProvider time) : IRequestHandler<ListCouponsQuery, List<ListCouponsQueryDto>>
    {
        public async Task<List<ListCouponsQueryDto>> Handle(ListCouponsQuery request, CancellationToken ct)
        {
            // Single "now" snapshot - both StartDate and EndDate compare against the same value
            // so the filter is internally consistent. TimeProvider also lets unit tests pin "now".
            var nowUtc = time.GetUtcNow().UtcDateTime;
            return await context.Coupons
                .AsNoTracking()
                .Where(x => !x.IsDeleted && x.StartDate <= nowUtc && x.EndDate >= nowUtc)
                .Select(x => new ListCouponsQueryDto
                {
                    Name = x.PromotionCode
                }).ToListAsync(ct);
        }
    }
}
