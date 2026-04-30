using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;
using Stripe;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create
{
    public class CreateOrderOrderItemsCommandHandler(
        IAppDbContext context,
        IAppCurrentUser currentUser,
        IStripeSettings stripeSettings)
    : IRequestHandler<CreateOrderOrderItemsCommand, CreateOrderOrderItemsCommandDto>
    {
        public async Task<CreateOrderOrderItemsCommandDto> Handle(CreateOrderOrderItemsCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new BookVerseNotFoundException("User is not logged in.");

            var cart = await context.Carts
                .Include(c => c.CartItems.Where(x => !x.SavedForLater))
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync(c => c.UserId == userId, ct) ?? throw new BookVerseNotFoundException("Cart not found.");

            if (!cart.CartItems.Any())
                throw new BookVerseConflictException("Cart is empty.");

            //shipping address
            int shipToAddressId;
            if (request.UseExistingAddress)
            {
                var user = await context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(ct) ?? throw new BookVerseNotFoundException("User not found.");

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

            var shippingMethod = new Domain.Entities.Shopping.ShippingMethods();
            var pickupStore = new Store();

            if (!request.StoreId.HasValue && !request.ShippingMethodId.HasValue)
                throw new BookVerseConflictException("You must select a delivery method or a pickup store.");

            //if a shipping method was provided
            if (request.ShippingMethodId != null)
            {
                shippingMethod = await context.ShippingMethods
                .FirstOrDefaultAsync(x => x.Id == request.ShippingMethodId && !x.IsDeleted, ct)
                ?? throw new BookVerseNotFoundException("Shipping method not found.");
            }

            // if a pickup store was provided
            if (request.StoreId != null)
            {
                pickupStore = await context.Stores
                .FirstOrDefaultAsync(x => x.Id == request.StoreId && !x.IsDeleted, ct)
                ?? throw new BookVerseNotFoundException("Store not found.");
            }

            //price calculation
            var subTotal = cart.CartItems.Sum(x => x.Book.Price * x.Quantity);
            var shippingPrice = request.StoreId.HasValue ? 0 : shippingMethod.Price;
            var totalPrice = subTotal + shippingPrice;
            var discountAmount = 0m;

            var coupons = new List<BookVerse.Domain.Entities.Shopping.Coupons>();
            if (request.CouponIds.Any())
            {
                coupons = await context.Coupons
                    .Where(x => request.CouponIds.Contains(x.Id) && !x.IsDeleted)
                    .ToListAsync(ct);

                foreach (var coupon in coupons)
                {
                    decimal couponDiscount = 0;
                    if (coupon.AmountOff.HasValue)
                        couponDiscount = coupon.AmountOff.Value;
                    else if (coupon.PercentOff.HasValue)
                        couponDiscount = subTotal * (coupon.PercentOff.Value / 100); // ← on subTotal, not totalPrice

                    discountAmount += couponDiscount;
                    totalPrice -= couponDiscount;
                }
            }

            if (totalPrice < 0) totalPrice = 0;


            //create the order
            var order = new Orders
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalPrice = totalPrice,
                SubTotal = subTotal,
                ShippingPriceAtTheTime = shippingPrice,
                DiscountAmount = discountAmount,
                OrderStatusId = (int)OrderStatusType.Draft,
                ShipToAddressId = shipToAddressId,
                TrackingNumber = "",
                PaymentIntentId = ""
            };

            if (request.ShippingMethodId != null)
                order.ShippingMethodId = shippingMethod.Id;

            if (request.StoreId != null)
                order.PickupStoreId = pickupStore.Id;

            //add order items
            foreach (var cartItem in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItems
                {
                    BookId = cartItem.BookId,
                    Quantity = cartItem.Quantity,
                    PriceAtTime = cartItem.Book.Price
                });
            }

            //adding coupons to the order
            foreach (var coupon in coupons)
                order.Coupons.Add(coupon);

            context.Orders.Add(order);
            await context.SaveChangesAsync(ct);

            //creating Stripe PaymentIntent
            var paymentIntentService = new PaymentIntentService();

            var paymentIntent = await paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
            {
                Amount = (long)(totalPrice * 100),
                Currency = "bam",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true
                },
                Metadata = new Dictionary<string, string>
                {
                    { "orderId", order.Id.ToString() }
                },
                Expand = new List<string> { "latest_charge" }
            });

            //saving payment intent to Order
            order.PaymentIntentId = paymentIntent.Id;
            await context.SaveChangesAsync(ct);

            return new CreateOrderOrderItemsCommandDto
            {
                OrderId = order.Id,
                ClientSecret = paymentIntent.ClientSecret, //ClientSecret is one-way — the frontend uses it only to render the payment form; the card number never passes through our backend.
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = totalPrice
            };
        }
    }
}
