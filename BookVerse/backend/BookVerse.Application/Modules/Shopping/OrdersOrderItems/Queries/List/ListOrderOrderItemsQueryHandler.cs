using BookVerse.Domain.Entities.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.List
{
    public sealed class ListOrderOrderItemsQueryHandler(IAppDbContext ctx) : IRequestHandler<ListOrderOrderItemsQuery, PageResult<ListOrderOrderItemsQueryDto>>
    {
        public async Task<PageResult<ListOrderOrderItemsQueryDto>> Handle(ListOrderOrderItemsQuery request, CancellationToken ct)
        {
            var q = ctx.Orders.Include(x => x.User).ThenInclude(u => u.Address).Include(x => x.OrderStatus).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchFilter = request.Search.ToLower();
                q = q.Where(x =>
                    (x.User.FirstName != null && x.User.FirstName.ToLower().Contains(searchFilter)) ||
                    (x.User.LastName != null && x.User.LastName.ToLower().Contains(searchFilter)) ||
                    (x.User.FirstName != null && x.User.LastName != null && (x.User.FirstName.ToLower() + " " + x.User.LastName.ToLower()).Contains(searchFilter)) ||
                    (x.TrackingNumber != null && x.TrackingNumber.ToLower().Contains(searchFilter)) ||
                    (x.User.Address != null && x.User.Address.Line1 != null && x.User.Address.Line1.ToLower().Contains(searchFilter)) ||
                    (x.User.Address != null && x.User.Address.City != null && x.User.Address.City.ToLower().Contains(searchFilter))
                );
            }

            if (request.Status!=null)
            {
              
                    q = q.Where(x => x.OrderStatus.StatusName == request.Status);
            }

            var query = q.OrderBy(x => x.TrackingNumber).Select(x => new ListOrderOrderItemsQueryDto
            {
                OrderId = x.Id,
                TrackingNumber = x.TrackingNumber,
                UserInfo = new OrderItemsUserInfo
                {
                    UserId = x.User.Id,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    UserAddress = x.User.Address != null ? x.User.Address.Line1 : null,
                    UserCity = x.User.Address != null ? x.User.Address.City : null
                },
                OrderDate = x.OrderDate,
                Total = x.TotalPrice,
                StatusNameEnum = x.OrderStatus.StatusName
            });

            return await PageResult<ListOrderOrderItemsQueryDto>.FromQueryableAsync(query, request.Paging, ct);
        }
    }
}
