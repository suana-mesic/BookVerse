using Market.Application.Common.Interfaces;
using Market.Domain.Entities.Shopping;
using Stripe;

namespace Market.Application.Modules.Shopping.OrdersOrderItems.Commands.Create
{
    public class CreateOrderOrderItemsCommandHandler(
        IAppDbContext context,
        IAppCurrentUser currentUser,
        IStripeSettings stripeSettings)
    : IRequestHandler<CreateOrderOrderItemsCommand, CreateOrderOrderItemsCommandDto>
    {
        public async Task<CreateOrderOrderItemsCommandDto> Handle(CreateOrderOrderItemsCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new MarketNotFoundException("Korisnik nije prijavljen");

            var cart = await context.Carts
                .Include(c => c.CartItems.Where(x => !x.IsDeleted && !x.SavedForLater))
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsDeleted, ct) ?? throw new MarketNotFoundException("Korpa nije pronađena");

            if (!cart.CartItems.Any())
                throw new MarketConflictException("Korpa je prazna");

            //adresa dostave
            int shipToAddressId;
            if (request.UseExistingAddress)
            {
                var user = await context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(ct) ?? throw new MarketNotFoundException("Korisnik nije pronađen");

                shipToAddressId = user.AddressId;
            }
            else
            {
                var newAdress = new Domain.Entities.Catalog.Address
                {
                    Line1 = request.Line1,
                    Line2 = request.Line2,
                    City = request.City,
                    Country = request.Country
                };

                context.Addresses.Add(newAdress);
                await context.SaveChangesAsync(ct);
                shipToAddressId = newAdress.Id;
            }

            //shipping metoda
            var shippingMethod = await context.ShippingMethods
            .FirstOrDefaultAsync(x => x.Id == request.ShippingMethodId && !x.IsDeleted, ct)
            ?? throw new MarketNotFoundException("Način dostave nije pronađen.");

            //izračunavanje cijena
            var subTotal = cart.CartItems.Sum(x => x.Book.Price * x.Quantity);
            var shippingPrice = request.StoreId.HasValue ? 0 : shippingMethod.Price;
            var totalPrice = subTotal + shippingPrice;

            var coupons = new List<Market.Domain.Entities.Shopping.Coupons>();
            if (request.CouponIds.Any())
            {
                coupons = await context.Coupons
                    .Where(x=>request.CouponIds.Contains(x.Id) && !x.IsDeleted)
                    .ToListAsync(ct);

                foreach (var coupon in coupons)
                {
                    if (coupon.AmountOff.HasValue)
                        totalPrice -= coupon.AmountOff.Value;
                    else if (coupon.PercentOff.HasValue)
                        totalPrice -= totalPrice * (coupon.PercentOff.Value / 100);
                }
            }

            if (totalPrice < 0) totalPrice = 0;

            //kreiranje payment summary-a
            var paymentSummary = new PaymentSummaries
            {
                Last4Digits = 0,
                Brand = "Unknown",
                ExpMonth = 0,
                ExpYear = 0
            };

            context.PaymentSummaries.Add(paymentSummary);
            await context.SaveChangesAsync(ct);

            //kreiranje narudžbe
            var order = new Orders
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                SubTotal = subTotal,
                TotalPrice = totalPrice,
                OrderStatusId = (int)OrderStatusType.Draft,
                ShipToAddressId = shipToAddressId,
                ShippingMethodId = request.ShippingMethodId,
                ShippingPriceAtTheTime = shippingPrice,
                PaymentSummaryId = paymentSummary.Id,
                TrackingNumber = Guid.NewGuid().ToString("N")[..10].ToUpper(),
                PaymentIntentId = ""
            };

            //dodavanje stavki narudžbe
            foreach(var cartItem in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItems
                {
                    BookId = cartItem.BookId,
                    Quantity = cartItem.Quantity,
                    PriceAtTime = cartItem.Book.Price
                });
            }

            //dodavanje kupona u order
            foreach (var coupon in coupons)
                order.Coupons.Add(coupon);

            context.Orders.Add(order);
            await context.SaveChangesAsync(ct);

            //kreiranje Stripe PaymentIntent-a
            var paymentIntentService = new PaymentIntentService();

            var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = (long)(totalPrice * 100),
                Currency = "bam",
                Metadata = new Dictionary<string, string>
    {
        { "orderId", order.Id.ToString() }
    },
                Expand = new List<string> { "latest_charge" }
            });

            //spremanje payment intenta u Order
            order.PaymentIntentId = paymentIntent.Id;
            await context.SaveChangesAsync(ct);

            return new CreateOrderOrderItemsCommandDto
            {
                OrderId = order.Id,
                ClientSecret = paymentIntent.ClientSecret,
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = totalPrice
            };
        }
    }
}
