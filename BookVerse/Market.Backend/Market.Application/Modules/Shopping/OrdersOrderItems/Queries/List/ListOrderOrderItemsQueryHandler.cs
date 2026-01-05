using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public sealed class ListOrderOrderItemsQueryHandler (IAppDbContext ctx): IRequestHandler<ListOrderOrderItemsQuery, PageResult<ListOrderOrderItemsQueryDto>>
    {
        public async Task<PageResult<ListOrderOrderItemsQueryDto>> Handle(ListOrderOrderItemsQuery request, CancellationToken ct)
        {
            var q =  ctx.Orders.Include(x=>x.User).Include(x => x.OrderStatus).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
            var searchFilter = request.Search.ToLower();
                q = q.Where(x =>
                    (x.OrderStatus.StatusName.ToString() != null && x.OrderStatus.StatusName.ToString().ToLower().Contains(searchFilter)) ||
                    (x.User != null && x.User.FirstName != null && x.User.FirstName.ToLower().Contains(searchFilter)) ||
                    (x.User != null && x.User.LastName != null && x.User.LastName.ToLower().Contains(searchFilter)) ||
                    (x.OrderDate != null && x.OrderDate.ToString().Contains(searchFilter)) ||
                    (x.TrackingNumber != null && x.TrackingNumber.ToString().Contains(searchFilter)) ||
                    (x.OrderStatus != null && x.OrderStatus.StatusName.ToString().ToLower().Contains(request.Status.ToLower()))
                );
            }

            var query = q.OrderBy(x => x.TrackingNumber).Select(x=> new ListOrderOrderItemsQueryDto
            {
                OrderId = x.Id,
                TrackingNumber = x.TrackingNumber,
                UserInfo = new OrderItemsUserInfo
                {
                    UserId = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName
                },
                OrderDate = x.OrderDate,
                Total = x.TotalPrice,
                StatusNameEnum = x.OrderStatus.StatusName
            });

            return await PageResult<ListOrderOrderItemsQueryDto>.FromQueryableAsync(query, request.Paging, ct);
        }
    }
}
