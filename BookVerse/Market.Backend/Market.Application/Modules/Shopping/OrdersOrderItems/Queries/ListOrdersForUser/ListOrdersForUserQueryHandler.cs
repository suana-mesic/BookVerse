using Market.Application.Common.Interfaces;
using Market.Application.Modules.Shopping.OrdersOrderItems.Queries.List;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Queries.ListOrdersForUser
{
    public class ListOrdersForUserQueryHandler(IAppDbContext context, IAppCurrentUser currentUser, ITranslationService translationService) : IRequestHandler<ListOrdersForUserQuery, PageResult<ListOrdersForUserQueryDto>>
    {
        public async Task<PageResult<ListOrdersForUserQueryDto>> Handle(ListOrdersForUserQuery request, CancellationToken ct)
        {
            if (!currentUser.IsAuthenticated)
                throw new MarketConflictException("User not authenticated!");

            var query = context.Orders
                  .Include(x => x.OrderItems)
                  .ThenInclude(x => x.Book)
                  .Where(x => x.UserId == currentUser.UserId)
                  .Where(x => request.Status == null || x.OrderStatus.StatusName == request.Status)
                  .Where(x => string.IsNullOrWhiteSpace(request.Search) || x.TrackingNumber.Contains(request.Search))
                  .Select(x => new ListOrdersForUserQueryDto
                  {
                      Id = x.Id,
                      TrackingNumber = x.TrackingNumber,
                      OrderedAtUtc = x.OrderDate,
                      PaidAtUtc = x.PaidAt,
                      Status = x.OrderStatus.StatusName,
                      TotalAmount = x.TotalPrice,
                      Subtotal = x.SubTotal,
                      ShippingPriceAtTheTime = x.ShippingPriceAtTheTime,
                      DiscountAmount = x.DiscountAmount,
                      Items = x.OrderItems.Select(oi => new ListOrdersForUserQueryDtoItem
                      {
                          Book = new ListOrdersForUserQueryDtoItemBook
                          {
                              BookId = oi.BookId,
                              Title = oi.Book.Title,
                              ImageUrl = oi.Book.ImageUrl
                          },
                          Quantity = oi.Quantity,
                          UnitPrice = oi.PriceAtTime
                      }).ToList()
                  });

            return await PageResult<ListOrdersForUserQueryDto>.FromQueryableAsync(query, request.Paging, ct,
                postProcess: async items =>
                {
                    if (string.IsNullOrWhiteSpace(request.Language) || request.Language == "bs")
                        return;

                    await Task.WhenAll(items.SelectMany(o => o.Items).Select(async i =>
                    {
                        i.Book.Title = await translationService.Translate(i.Book.Title ?? string.Empty, request.Language);
                    }));
                });

        }
    }
}
