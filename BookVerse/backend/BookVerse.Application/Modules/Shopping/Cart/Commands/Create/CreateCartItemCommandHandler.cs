using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Modules.Shopping.Cart.Commands.Create;

public class CreateCartItemCommandHandler(
    IAppDbContext context,
    IAppCurrentUser currentUser,
    TimeProvider time)
    : IRequestHandler<CreateCartItemCommand, Unit>
{
    public async Task<Unit> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUser.UserId
            ?? throw new BookVerseNotFoundException("User is not logged in.");

        //Load the book itself so we can inspect IsDeleted, price and stock at add-to-cart time.
        //A simple AnyAsync hides bugs where a soft-deleted book or one with no stock is queued for purchase.
        var book = await context.Books
            .FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);

        if (book == null || book.IsDeleted)
            throw new BookVerseNotFoundException("Book does not exist.");

        if (book.Price <= 0)
            throw new BookVerseConflictException("Book is not available for purchase.");

        var cart = await context.Carts
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);

        if (cart == null)
        {
            cart = new Carts { UserId = userId};
            context.Carts.Add(cart);
            await context.SaveChangesAsync(cancellationToken);
        }

        // Include soft-deleted items to avoid duplicate key conflicts
        var existingItem = await context.CartItems
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(ci => ci.CartId == cart.Id
                                    && ci.BookId == request.BookId, cancellationToken);

        // Compute the quantity that will end up in the cart after this call.
        // - New item: just the requested quantity.
        // - Existing active item: current quantity PLUS the requested quantity (true "add to cart").
        // - SavedForLater item being reactivated: treat as fresh add, so the requested quantity replaces
        //   the saved-aside one. (The user explicitly chose how many to bring back into the active cart.)
        // We compute this BEFORE the stock check so we validate against the FINAL total, not just the delta.
        int targetQuantity;
        if (existingItem != null && !existingItem.SavedForLater)
            targetQuantity = existingItem.Quantity + request.Quantity;
        else
            targetQuantity = request.Quantity;

        //Stock check at add-to-cart time. Delivery mode isn't known yet, so the item is allowed if either
        //the online stock or any store inventory can fulfil the FINAL quantity (after the increment above).
        //The strict per-mode recheck happens again in CreateOrderOrderItemsCommandHandler before any Stripe call.
        var onlineHasStock = book.QuantityInStockForOnlineOrders.HasValue
            && book.QuantityInStockForOnlineOrders.Value >= targetQuantity;

        var anyStoreHasStock = await context.StoreInventory
            .AnyAsync(si => si.BookId == request.BookId
                && !si.IsDeleted
                && si.QuantityInStock >= targetQuantity, cancellationToken);

        if (!onlineHasStock && !anyStoreHasStock)
            throw new BookVerseConflictException("Requested quantity is not available in stock.");

        if (existingItem != null)
        {
            // If it was soft-deleted (SavedForLater), bring it back into the active cart and use the
            // requested quantity directly. Otherwise this is a real "Add to cart" click, so we INCREMENT
            // the existing quantity rather than overwriting it - three clicks of "Add to cart" must
            // result in a quantity of 3, not 1.
            if (existingItem.SavedForLater)
            {
                existingItem.SavedForLater = false;
                existingItem.Quantity = request.Quantity;
            }
            else
            {
                existingItem.Quantity += request.Quantity;
            }
        }
        else
        {
            context.CartItems.Add(new CartItems
            {
                CartId = cart.Id,
                BookId = request.BookId,
                Quantity = request.Quantity,
                // TimeProvider so unit tests can pin DateAdded and verify ordering behavior.
                DateAdded = time.GetUtcNow().UtcDateTime,
                SavedForLater = false
            });
        }

        await context.SaveChangesAsync(cancellationToken);
        // No payload: the controller turns this into a 204 NoContent. The frontend shows
        // its own localized success toast, so the backend doesn't need to provide a message.
        return Unit.Value;
    }
}
