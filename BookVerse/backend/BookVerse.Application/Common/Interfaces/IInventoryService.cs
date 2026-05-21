using BookVerse.Domain.Entities.Catalog;
using BookVerse.Domain.Entities.Shopping;

namespace BookVerse.Application.Common.Interfaces
{
    // All stock-related concerns: loading the pickup store inventory, validating that the
    // cart can be fulfilled, decrementing stock on payment and restoring it on cancel.
    // Extracted from CreateOrderOrderItemsCommandHandler / StripeWebhookCommandHandler /
    // CancelOrderCommandHandler so each operation can be unit tested without spinning up
    // the full handler pipeline.
    public interface IInventoryService
    {
        // Loads StoreInventory rows for the given pickup store keyed by BookId.
        // Returns null when no store was selected (shipping flow).
        Task<Dictionary<int, StoreInventory>?> LoadPickupInventoryAsync(int? storeId, CancellationToken ct);

        // Validates each cart item against the selected delivery mode's stock and against the
        // book's own flags (not soft-deleted, price > 0). Throws BookVerseConflictException
        // with a per-book message so the user knows which item is the problem.
        void ValidateCartAvailability(IEnumerable<CartItems> cartItems, int? shippingMethodId, int? storeId, Dictionary<int, StoreInventory>? pickupInventory);

        // Decrements online stock for every cart item (free-order shipping flow).
        // Uses Math.Max(0, ...) so a race can never push stock below zero.
        void DecrementCartItemsForShipping(IEnumerable<CartItems> cartItems);

        // Decrements store stock for every cart item (free-order pickup flow).
        void DecrementCartItemsForPickup(IEnumerable<CartItems> cartItems, Dictionary<int, StoreInventory> pickupInventory);

        // Decrements online stock for an order whose items were loaded from the DB (webhook flow).
        void DecrementOrderForShipping(Orders order);

        // Decrements store stock for an order whose items were loaded from the DB (webhook flow).
        Task DecrementOrderForPickupAsync(Orders order, CancellationToken ct);

        // Adds stock back on order cancellation (online or per-store, depending on the order).
        Task RestoreOrderInventoryAsync(Orders order, CancellationToken ct);
    }
}
