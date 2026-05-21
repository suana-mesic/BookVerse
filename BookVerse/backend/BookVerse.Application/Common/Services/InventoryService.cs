using BookVerse.Application.Abstractions;
using BookVerse.Application.Common.Interfaces;
using BookVerse.Domain.Entities.Catalog;
using BookVerse.Domain.Entities.Shopping;
using Microsoft.Extensions.Logging;

namespace BookVerse.Application.Common.Services
{
    // Implementation of IInventoryService. All stock-related logic that used to be inlined
    // in CreateOrderOrderItemsCommandHandler, StripeWebhookCommandHandler and CancelOrderCommandHandler.
    public sealed class InventoryService(
        IAppDbContext context,
        ILogger<InventoryService> logger) : IInventoryService
    {
        public async Task<Dictionary<int, StoreInventory>?> LoadPickupInventoryAsync(int? storeId, CancellationToken ct)
        {
            // No pickup store selected: shipping flow, no per-store data needed.
            if (!storeId.HasValue) return null;

            // ToDictionaryAsync (not ToDictionary) on an IQueryable: the sync version blocks the
            // thread on the DB call and triggers an EF Core warning when used with a scoped DbContext.
            return await context.StoreInventory
                .Where(si => si.StoreId == storeId.Value && !si.IsDeleted)
                .ToDictionaryAsync(si => si.BookId, ct);
        }

        public void ValidateCartAvailability(IEnumerable<CartItems> cartItems, int? shippingMethodId, int? storeId, Dictionary<int, StoreInventory>? pickupInventory)
        {
            // Snapshot + validate every book before payment. Three concerns are checked together so
            // the user sees a single clear error and we never hit Stripe with an order that cannot
            // legally be fulfilled.
            foreach (var cartItem in cartItems)
            {
                var book = cartItem.Book;

                // (1) Book may have been removed from the catalog while it sat in the cart.
                if (book.IsDeleted)
                    throw new BookVerseConflictException(
                        $"Book '{book.Title}' is no longer available and must be removed from the cart.");

                // (2) Price must still be positive. A zero/negative price means the book is not
                // properly configured for sale and must not be ordered.
                if (book.Price <= 0)
                    throw new BookVerseConflictException(
                        $"Book '{book.Title}' has an invalid price and cannot be ordered.");

                // (3) Stock per delivery mode.
                if (shippingMethodId.HasValue)
                {
                    if (!book.QuantityInStockForOnlineOrders.HasValue
                        || book.QuantityInStockForOnlineOrders.Value < cartItem.Quantity)
                    {
                        throw new BookVerseConflictException(
                            $"Book '{book.Title}' does not have enough stock for shipping ({cartItem.Quantity} requested).");
                    }
                }
                else if (storeId.HasValue)
                {
                    if (pickupInventory == null
                        || !pickupInventory.TryGetValue(book.Id, out var inventory)
                        || inventory.QuantityInStock < cartItem.Quantity)
                    {
                        throw new BookVerseConflictException(
                            $"Book '{book.Title}' is not available in the selected store ({cartItem.Quantity} requested).");
                    }
                }
            }
        }

        public void DecrementCartItemsForShipping(IEnumerable<CartItems> cartItems)
        {
            // Math.Max(0, ...) guards against a race between two concurrent orders for the same
            // last copy: even if validation just slipped past, stock can never go below zero.
            foreach (var cartItem in cartItems)
            {
                var available = cartItem.Book.QuantityInStockForOnlineOrders ?? 0;
                cartItem.Book.QuantityInStockForOnlineOrders = Math.Max(0, available - cartItem.Quantity);
            }
        }

        public void DecrementCartItemsForPickup(IEnumerable<CartItems> cartItems, Dictionary<int, StoreInventory> pickupInventory)
        {
            foreach (var cartItem in cartItems)
            {
                if (pickupInventory.TryGetValue(cartItem.BookId, out var inv))
                    inv.QuantityInStock = Math.Max(0, inv.QuantityInStock - cartItem.Quantity);
            }
        }

        public void DecrementOrderForShipping(Orders order)
        {
            // Same Math.Max(0, ...) safety net as the cart variant. Logs a warning so staff can
            // investigate a stock underflow (the customer already paid, so the order itself stands).
            foreach (var item in order.OrderItems)
            {
                var available = item.Book.QuantityInStockForOnlineOrders ?? 0;
                if (available < item.Quantity)
                {
                    logger.LogWarning(
                        "InventoryService: online stock underflow for book {BookId} on order {OrderId}. Available {Available}, requested {Requested}",
                        item.BookId, order.Id, available, item.Quantity);
                }
                item.Book.QuantityInStockForOnlineOrders = Math.Max(0, available - item.Quantity);
            }
        }

        public async Task DecrementOrderForPickupAsync(Orders order, CancellationToken ct)
        {
            var inventoryDictionary = await context.StoreInventory
                .Where(x => x.StoreId == order.PickupStoreId)
                .ToDictionaryAsync(x => x.BookId, ct);

            foreach (var item in order.OrderItems)
            {
                if (inventoryDictionary.TryGetValue(item.BookId, out var inventoryForBook))
                {
                    if (inventoryForBook.QuantityInStock < item.Quantity)
                    {
                        logger.LogWarning(
                            "InventoryService: store stock underflow for book {BookId} at store {StoreId} on order {OrderId}. Available {Available}, requested {Requested}",
                            item.BookId, order.PickupStoreId, order.Id, inventoryForBook.QuantityInStock, item.Quantity);
                    }
                    inventoryForBook.QuantityInStock = Math.Max(0, inventoryForBook.QuantityInStock - item.Quantity);
                }
                else
                {
                    // A book sold for pickup must have an inventory row for the chosen store.
                    // Missing row means the data is inconsistent and we can't safely proceed.
                    throw new Exception($"Book {item.BookId} is not in StoreInventory for Store {order.PickupStoreId}");
                }
            }
        }

        public async Task RestoreOrderInventoryAsync(Orders order, CancellationToken ct)
        {
            // If the order was to be shipped, add back QuantityInStockForOnlineOrders.
            if (order.ShippingMethodId != null)
            {
                foreach (var item in order.OrderItems)
                    item.Book.QuantityInStockForOnlineOrders += item.Quantity;
            }

            // If the order was to be picked up in-store, add back the per-store inventory.
            if (order.PickupStoreId != null)
            {
                var inventoryDictionary = await context.StoreInventory
                    .Where(x => x.StoreId == order.PickupStoreId)
                    .ToDictionaryAsync(x => x.BookId, ct);

                foreach (var item in order.OrderItems)
                {
                    if (inventoryDictionary.TryGetValue(item.BookId, out var inventoryForBook))
                        inventoryForBook.QuantityInStock += item.Quantity;
                }
            }
        }
    }
}
