using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.OrdersOrderItems.Commands.Create
{
    // Orchestrator only. All real work lives in the domain services:
    //   - CouponValidationService : coupon rules + discount math
    //   - CheckoutPricingService  : subtotal/shipping/total math
    //   - InventoryService        : stock load/validate/decrement
    //   - PaymentService          : Stripe PaymentIntent creation
    //   - OrderStateMachine       : status transitions and matching timestamps
    public class CreateOrderOrderItemsCommandHandler(
        IAppDbContext context,
        IAppCurrentUser currentUser,
        IStripeSettings stripeSettings,
        IPaidOrderNotificationQueue paidOrderNotificationQueue,
        ICheckoutPricingService pricingService,
        ICouponValidationService couponService,
        IInventoryService inventoryService,
        IPaymentService paymentService,
        IOrderStateMachine stateMachine,
        TimeProvider time)
    : IRequestHandler<CreateOrderOrderItemsCommand, CreateOrderOrderItemsCommandDto>
    {
        public async Task<CreateOrderOrderItemsCommandDto> Handle(CreateOrderOrderItemsCommand request, CancellationToken ct)
        {
            var userId = currentUser.UserId ?? throw new BookVerseNotFoundException("User is not logged in.");

            // Load the active cart (savedForLater items are excluded from this order).
            var cart = await context.Carts
                .Include(c => c.CartItems.Where(x => !x.SavedForLater))
                .ThenInclude(ci => ci.Book)
                .FirstOrDefaultAsync(c => c.UserId == userId, ct) ?? throw new BookVerseNotFoundException("Cart not found.");

            if (!cart.CartItems.Any())
                throw new BookVerseConflictException("Cart is empty.");

            // Open an explicit transaction that covers EVERY write in this handler:
            //   (1) optional new Address insert
            //   (2) Order insert (with status Draft)
            //   (3) either the free-order finalize, OR the post-Stripe Order update
            // If anything below throws (Stripe call, DB error, etc.), `await using` disposes
            // the transaction without commit -> SQL Server rolls back, so no orphan address
            // or draft order is left behind.
            await using var tx = await context.BeginTransactionAsync(ct);

            // Resolve the shipping address: either reuse the one on the user, or insert the
            // new address fields from the request.
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

            // Defense-in-depth XOR guard: the validator already rejects "both set" and "neither set",
            // but the handler must repeat the check in case the request reaches us through a path that
            // bypasses validation (e.g. internal callers, future endpoints, or a misconfigured pipeline).
            // Without this guard, a request with BOTH ShippingMethodId and StoreId would silently set
            // shippingPrice to 0, persist both fields, and the webhook would decrement BOTH online stock
            // AND store inventory - double inventory loss for a single order.
            if (!request.StoreId.HasValue && !request.ShippingMethodId.HasValue)
                throw new BookVerseConflictException("You must select a delivery method or a pickup store.");

            if (request.StoreId.HasValue && request.ShippingMethodId.HasValue)
                throw new BookVerseConflictException("Choose either shipping method or pickup store, not both.");

            // Load shipping method or pickup store - whichever the user picked.
            // Fully qualified because there is an Application-side sibling namespace called
            // "BookVerse.Application.Modules.Shopping.ShippingMethods" that would otherwise shadow the entity.
            Domain.Entities.Shopping.ShippingMethods? shippingMethod = null;
            Store? pickupStore = null;

            if (request.ShippingMethodId != null)
            {
                shippingMethod = await context.ShippingMethods
                    .FirstOrDefaultAsync(x => x.Id == request.ShippingMethodId && !x.IsDeleted, ct)
                    ?? throw new BookVerseNotFoundException("Shipping method not found.");
            }

            if (request.StoreId != null)
            {
                pickupStore = await context.Stores
                    .FirstOrDefaultAsync(x => x.Id == request.StoreId && !x.IsDeleted, ct)
                    ?? throw new BookVerseNotFoundException("Store not found.");
            }

            // Load pickup-store inventory (or null for shipping) and validate each cart item
            // against book flags + the chosen delivery mode's stock.
            var pickupInventory = await inventoryService.LoadPickupInventoryAsync(request.StoreId, ct);
            inventoryService.ValidateCartAvailability(cart.CartItems, request.ShippingMethodId, request.StoreId, pickupInventory);

            // Compute subtotal upfront because the coupon validator needs it for MinOrderAmount checks.
            var subTotalForCouponCheck = cart.CartItems.Sum(x => x.Book.Price * x.Quantity);

            // Validate and load coupons, then compute the combined discount.
            var coupons = await couponService.ValidateAndLoadAsync(request.CouponIds, subTotalForCouponCheck, ct);
            var discountAmount = couponService.CalculateDiscount(coupons, subTotalForCouponCheck);

            // Final pricing: items + shipping - discount (0 shipping for pickup).
            var shippingPrice = request.StoreId.HasValue ? 0 : shippingMethod!.Price;
            var pricing = pricingService.Calculate(cart.CartItems, shippingPrice, discountAmount);

            // Build the order in Draft status. Timestamps come from TimeProvider so unit tests
            // can pin "now" without patching DateTime.UtcNow.
            var order = new Orders
            {
                UserId = userId,
                OrderDate = time.GetUtcNow().UtcDateTime,
                TotalPrice = pricing.TotalPrice,
                SubTotal = pricing.SubTotal,
                ShippingPriceAtTheTime = pricing.ShippingPrice,
                DiscountAmount = pricing.DiscountAmount,
                OrderStatusId = (int)OrderStatusType.Draft,
                ShipToAddressId = shipToAddressId,
                TrackingNumber = "",
                PaymentIntentId = ""
            };

            if (shippingMethod != null) order.ShippingMethodId = shippingMethod.Id;
            if (pickupStore != null) order.PickupStoreId = pickupStore.Id;

            foreach (var cartItem in cart.CartItems)
            {
                order.OrderItems.Add(new OrderItems
                {
                    BookId = cartItem.BookId,
                    Quantity = cartItem.Quantity,
                    PriceAtTime = cartItem.Book.Price
                });
            }

            foreach (var coupon in coupons)
                order.Coupons.Add(coupon);

            context.Orders.Add(order);
            await context.SaveChangesAsync(ct);

            // Free-order flow: when coupons (or a zero subtotal combined with pickup) bring the total
            // to exactly zero, Stripe must NOT be invoked - it rejects PaymentIntent with Amount = 0
            // for normal card flows. A "free order" is a distinct business case that deserves its own
            // path: status goes Draft -> Paid immediately, stock decrements, cart clears, and staff is notified.
            if (pricing.TotalPrice == 0)
            {
                // Decrement the appropriate inventory.
                if (request.ShippingMethodId.HasValue)
                    inventoryService.DecrementCartItemsForShipping(cart.CartItems);
                else if (request.StoreId.HasValue && pickupInventory != null)
                    inventoryService.DecrementCartItemsForPickup(cart.CartItems, pickupInventory);

                // Clear the cart so the user cannot repurchase the same items.
                var itemsToDelete = cart.CartItems.Where(x => !x.SavedForLater).ToList();
                foreach (var item in itemsToDelete)
                    context.CartItems.Remove(item);

                if (!cart.CartItems.Any(x => x.SavedForLater))
                    context.Carts.Remove(cart);

                // Transition Draft -> Paid through the state machine. It validates the transition
                // and stamps PaidAt from TimeProvider.
                stateMachine.Transition(order, OrderStatusType.Paid);
                await context.SaveChangesAsync(ct);

                // Commit: address (if new), order, status update and cart cleanup all become
                // permanent together. If we crash after this the user already has a paid order,
                // so a missing notification is acceptable.
                await tx.CommitAsync(ct);

                // Resolve customer name for the notification. The earlier code only loads the user
                // when UseExistingAddress is true, so for the new-address path we fetch it here.
                var customer = await context.Users.FirstOrDefaultAsync(x => x.Id == userId, ct);
                var customerName = customer != null ? $"{customer.FirstName} {customer.LastName}" : string.Empty;

                paidOrderNotificationQueue.Enqueue(new PaidOrderNotification(order.Id, order.TrackingNumber, customerName));

                // Empty ClientSecret signals to the frontend that no payment step is required.
                return new CreateOrderOrderItemsCommandDto
                {
                    OrderId = order.Id,
                    ClientSecret = string.Empty,
                    PublishableKey = string.Empty,
                    TotalPrice = 0m
                };
            }

            // Paid-order flow: create the Stripe PaymentIntent and transition to PaymentPending.
            // If the Stripe call throws, we never reach tx.CommitAsync, so dispose rolls back the
            // address + order rows automatically - no manual cleanup needed.
            var paymentIntent = await paymentService.CreatePaymentIntentAsync(pricing.TotalPrice, order.Id, ct);

            order.PaymentIntentId = paymentIntent.Id;
            stateMachine.Transition(order, OrderStatusType.PaymentPending);
            await context.SaveChangesAsync(ct);

            // All DB writes succeeded AND Stripe replied - commit so the rows stick.
            await tx.CommitAsync(ct);

            return new CreateOrderOrderItemsCommandDto
            {
                OrderId = order.Id,
                ClientSecret = paymentIntent.ClientSecret, // one-way: the frontend uses it only to render the payment form; the card number never passes through our backend.
                PublishableKey = stripeSettings.PublishableKey,
                TotalPrice = pricing.TotalPrice
            };
        }
    }
}
