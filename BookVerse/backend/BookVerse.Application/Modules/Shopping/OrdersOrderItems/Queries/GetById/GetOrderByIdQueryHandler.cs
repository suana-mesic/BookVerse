namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Queries.GetById
{
    public class GetOrderByIdQueryHandler(IAppDbContext context, IAppCurrentUser currentUser)
        : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryDto>
    {
        public async Task<GetOrderByIdQueryDto> Handle(GetOrderByIdQuery request, CancellationToken ct)
        {
            var q = context.Orders
                    .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Book)
                    .Include(x => x.User)
                    .ThenInclude(x => x.Address)
                    .Include(x => x.OrderStatus)
                    .Include(x => x.PaymentSummary)
                    .Where(x => x.Id == request.Id);

            if (!currentUser.IsAdmin && !currentUser.IsManager && !currentUser.IsEmployee)
                q = q.Where(x => x.UserId == currentUser.UserId);

            var dto = await q
                .OrderBy(x => x.OrderDate)
                .Select(x => new GetOrderByIdQueryDto
                {
                    Id = x.Id,
                    TrackingNumber = x.TrackingNumber,
                    User = new GetByIdOrderQueryDtoUser
                    {
                        UserFirstname = x.User.FirstName,
                        UserLastname = x.User.LastName,
                        UserAddress = $"{x.User.Address.Line1} {x.User.Address.Line2}",
                        UserCity = x.User.Address.City
                    },
                    OrderedAtUtc = x.OrderDate,
                    PaidAtUtc = x.PaidAt,
                    Status = x.OrderStatus.StatusName,
                    TotalAmount = x.TotalPrice,
                    Subtotal = x.SubTotal,
                    DiscountAmount = x.DiscountAmount,
                    ShippingPriceAtTheTime = x.ShippingPriceAtTheTime,
                    Items = x.OrderItems.Select(i => new GetByIdOrderQueryDtoItem
                    {
                        Book = new GetByIdOrderQueryDtoItemBook
                        {
                            BookId = i.BookId,
                            Title = i.Book.Title
                        },
                        Quantity = i.Quantity,
                        UnitPrice = i.PriceAtTime,
                    }).ToList(),
                }).FirstOrDefaultAsync(ct);

            if (dto == null)
                throw new BookVerseNotFoundException($"Order with ID {request.Id} was not found.");
            return dto;

        }
    }
}
