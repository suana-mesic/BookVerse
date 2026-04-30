using BookVerse.Domain.Entities.Shopping;
using BookVerse.Domain.Entities.Catalog;
using BookVerse.Domain.Entities.Whishlist;
using BookVerse.Domain.Entities.UserReviews;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Database.Seeders;

public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        await SeedPaymentSummariesAsync(context);
        await SeedOrdersAsync(context);
        await SeedCartsAsync(context);
        await SeedWishlistAsync(context);
        await SeedInventoryLogAsync(context);
        await SeedAdditionalReviewsAsync(context);
    }

    private static async Task SeedPaymentSummariesAsync(DatabaseContext context)
    {
        if (await context.PaymentSummaries.AnyAsync()) return;

        var summaries = new List<PaymentSummaries>
        {
            new PaymentSummaries { Last4Digits = "4242", Brand = "Visa", ExpMonth = 12, ExpYear = 2027 },
            new PaymentSummaries { Last4Digits = "5555", Brand = "Mastercard", ExpMonth = 6, ExpYear = 2026 },
            new PaymentSummaries { Last4Digits = "1234", Brand = "Visa", ExpMonth = 9, ExpYear = 2028 },
            new PaymentSummaries { Last4Digits = "9999", Brand = "Mastercard", ExpMonth = 3, ExpYear = 2027 },
            new PaymentSummaries { Last4Digits = "3456", Brand = "Visa", ExpMonth = 11, ExpYear = 2026 },
            new PaymentSummaries { Last4Digits = "7890", Brand = "Mastercard", ExpMonth = 8, ExpYear = 2027 },
            new PaymentSummaries { Last4Digits = "2222", Brand = "Visa", ExpMonth = 5, ExpYear = 2028 },
            new PaymentSummaries { Last4Digits = "3333", Brand = "Mastercard", ExpMonth = 7, ExpYear = 2027 },
        };

        context.PaymentSummaries.AddRange(summaries);
        await context.SaveChangesAsync();
    }

    private static async Task SeedOrdersAsync(DatabaseContext context)
    {
        if (await context.Orders.AnyAsync()) return;

        var ps = await context.PaymentSummaries.OrderBy(x => x.Id).ToListAsync();

        var bookPrices = new Dictionary<int, decimal>
        {
            [1] = 29.99m,
            [2] = 34.99m,
            [3] = 24.99m,
            [4] = 19.99m,
            [5] = 22.99m,
            [6] = 26.99m,
            [7] = 21.99m,
            [8] = 27.99m,
        };

        decimal ShipPrice(int sm) => sm == 1 ? 9.50m : sm == 2 ? 8.00m : 9.00m;

        var configs = new List<(int userId, DateTime date, int status, int psIdx, int addrId, int sm, int[] books)>
        {
            (3, new DateTime(2025,1,10), 3, 0, 4, 1, new[]{1,2}),
            (5, new DateTime(2025,1,18), 3, 1, 5, 2, new[]{1}),
            (6, new DateTime(2025,1,25), 4, 2, 6, 3, new[]{3,8}),

            (7, new DateTime(2025,2,7),  3, 3, 7, 1, new[]{2}),
            (8, new DateTime(2025,2,14), 3, 4, 8, 2, new[]{1,5}),
            (9, new DateTime(2025,2,22), 3, 5, 4, 1, new[]{6}),

            (3, new DateTime(2025,3,5),  3, 6, 5, 2, new[]{1}),
            (5, new DateTime(2025,3,12), 3, 7, 6, 3, new[]{2,8}),
            (6, new DateTime(2025,3,19), 4, 0, 7, 1, new[]{7}),
            (7, new DateTime(2025,3,26), 5,-1, 8, 2, new[]{1}),

            (8, new DateTime(2025,4,8),  3, 1, 4, 3, new[]{1,3}),
            (9, new DateTime(2025,4,15), 3, 2, 5, 1, new[]{2}),
            (3, new DateTime(2025,4,22), 3, 3, 6, 2, new[]{5,4}),

            (5, new DateTime(2025,5,6),  3, 4, 7, 3, new[]{1}),
            (6, new DateTime(2025,5,14), 3, 5, 8, 1, new[]{8}),
            (7, new DateTime(2025,5,21), 4, 6, 4, 2, new[]{2,7}),

            (8, new DateTime(2025,6,4),  3, 7, 5, 3, new[]{1}),
            (9, new DateTime(2025,6,11), 3, 0, 6, 1, new[]{3,6}),
            (3, new DateTime(2025,6,18), 3, 1, 7, 2, new[]{2}),
            (5, new DateTime(2025,6,25), 3, 2, 8, 1, new[]{1,5}),

            (6, new DateTime(2025,7,3),  3, 3, 4, 2, new[]{1}),
            (7, new DateTime(2025,7,10), 3, 4, 5, 3, new[]{2,8}),
            (8, new DateTime(2025,7,17), 3, 5, 6, 1, new[]{6,4}),
            (9, new DateTime(2025,7,24), 4, 6, 7, 2, new[]{1,3}),
            (3, new DateTime(2025,7,31), 5,-1, 8, 3, new[]{5}),

            (5, new DateTime(2025,8,7),  3, 7, 4, 1, new[]{1}),
            (6, new DateTime(2025,8,14), 3, 0, 5, 2, new[]{2,7}),
            (7, new DateTime(2025,8,21), 3, 1, 6, 3, new[]{8}),
            (8, new DateTime(2025,8,28), 3, 2, 7, 1, new[]{1,3}),

            (9, new DateTime(2025,9,5),  3, 3, 8, 2, new[]{1}),
            (3, new DateTime(2025,9,12), 3, 4, 4, 3, new[]{2,6}),
            (5, new DateTime(2025,9,19), 4, 5, 5, 1, new[]{5,4}),

            (6, new DateTime(2025,10,7),  3, 6, 6, 2, new[]{1}),
            (7, new DateTime(2025,10,15), 3, 7, 7, 1, new[]{2,8}),
            (8, new DateTime(2025,10,23), 3, 0, 8, 3, new[]{1,7}),

            (9, new DateTime(2025,11,6),  3, 1, 4, 2, new[]{1}),
            (3, new DateTime(2025,11,13), 3, 2, 5, 1, new[]{2,3}),
            (5, new DateTime(2025,11,20), 4, 3, 6, 3, new[]{6,5}),
            (6, new DateTime(2025,11,27), 3, 4, 7, 2, new[]{8,4}),

            (7, new DateTime(2025,12,4),  3, 5, 8, 1, new[]{1}),
            (8, new DateTime(2025,12,11), 3, 6, 4, 2, new[]{2,8}),
            (9, new DateTime(2025,12,18), 3, 7, 5, 3, new[]{1,6}),
            (3, new DateTime(2025,12,23), 3, 0, 6, 1, new[]{5,4}),
            (5, new DateTime(2025,12,29), 5,-1, 7, 2, new[]{2}),

            (6, new DateTime(2026,3,4),  3, 1, 4, 1, new[]{1,2}),
            (7, new DateTime(2026,3,7),  3, 2, 5, 2, new[]{8}),
            (8, new DateTime(2026,3,10), 3, 3, 6, 3, new[]{1,3}),
            (9, new DateTime(2026,3,13), 3, 4, 7, 1, new[]{2,6}),
            (3, new DateTime(2026,3,17), 3, 5, 8, 2, new[]{1}),
            (5, new DateTime(2026,3,20), 4, 6, 4, 1, new[]{5,7}),
            (6, new DateTime(2026,3,25), 3, 7, 5, 3, new[]{1,8}),
            (7, new DateTime(2026,3,28), 3, 0, 6, 2, new[]{2,4}),

            (8, new DateTime(2026,4,2),  3, 1, 7, 1, new[]{1,8}),
            (9, new DateTime(2026,4,4),  3, 2, 8, 2, new[]{2}),
            (3, new DateTime(2026,4,6),  3, 3, 4, 3, new[]{1,3}),
            (5, new DateTime(2026,4,7),  3, 4, 5, 1, new[]{6,5}),
            (6, new DateTime(2026,4,8),  4, 5, 6, 2, new[]{1}),
            (7, new DateTime(2026,4,9),  3, 6, 7, 3, new[]{7,4}),
        };

        var orders = new List<Orders>();
        int piCounter = 1;

        foreach (var (userId, date, status, psIdx, addrId, sm, books) in configs)
        {
            decimal subTotal = books.Sum(b => bookPrices[b]);
            decimal shipPrice = ShipPrice(sm);
            decimal totalPrice = subTotal + shipPrice;

            bool isPaid = status == 3 || status == 4;

            var order = new Orders
            {
                UserId = userId,
                OrderDate = date,
                SubTotal = subTotal,
                DiscountAmount = 0,
                ShippingPriceAtTheTime = shipPrice,
                TotalPrice = totalPrice,
                OrderStatusId = status,
                ShipToAddressId = addrId,
                ShippingMethodId = sm,
                PaymentSummaryId = isPaid && psIdx >= 0 ? ps[psIdx % ps.Count].Id : null,
                PaymentIntentId = isPaid ? $"pi_seed_{piCounter:D3}" : string.Empty,
                TrackingNumber = status == (int)OrderStatusType.Shipped ? $"TRK{piCounter:D4}" : "",
                PaidAt = isPaid ? date.AddHours(1) : null,
                CancelledAt = status == 5 ? date.AddDays(2) : null,
            };

            orders.Add(order);
            piCounter++;
        }

        context.Orders.AddRange(orders);
        await context.SaveChangesAsync();

        var orderItems = new List<OrderItems>();
        for (int i = 0; i < configs.Count; i++)
        {
            var (_, _, _, _, _, _, books) = configs[i];
            var order = orders[i];
            foreach (var bookId in books)
            {
                orderItems.Add(new OrderItems
                {
                    OrderId = order.Id,
                    BookId = bookId,
                    Quantity = 1,
                    PriceAtTime = bookPrices[bookId],
                });
            }
        }

        context.OrderItems.AddRange(orderItems);
        await context.SaveChangesAsync();

        var shippingUpdates = new List<ShippingUpdates>();
        foreach (var order in orders)
        {
            shippingUpdates.Add(new ShippingUpdates
            {
                OrderId = order.Id,
                UpdatedByUserId = 2,
                OrderStatusId = order.OrderStatusId,
                UpdatedAt = order.OrderDate.AddHours(2),
                Notes = "Status ažuriran",
                isCurrent = true,
                RowNumber = 1,
            });
        }

        context.ShippingUpdates.AddRange(shippingUpdates);
        await context.SaveChangesAsync();

        var cancelledOrders = orders.Zip(configs, (o, c) => (o, c))
            .Where(x => x.c.status == 5)
            .ToList();

        foreach (var (order, config) in cancelledOrders)
        {
            var firstBook = config.books[0];
            context.Refunds.Add(new Refunds
            {
                OrderId = order.Id,
                BookId = firstBook,
                RefundAmount = bookPrices[firstBook],
                RefundDate = order.OrderDate.AddDays(3),
                Reason = "Narudžba otkazana na zahtjev kupca",
                Status = "Odobreno",
            });
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedCartsAsync(DatabaseContext context)
    {
        if (await context.Carts.AnyAsync()) return;

        var cart1 = new Carts { UserId = 3 };
        var cart2 = new Carts { UserId = 5 };
        var cart3 = new Carts { UserId = 6 };

        context.Carts.AddRange(cart1, cart2, cart3);
        await context.SaveChangesAsync();

        context.CartItems.AddRange(
            new CartItems { CartId = cart1.Id, BookId = 2, Quantity = 1, DateAdded = new DateTime(2026, 4, 1), SavedForLater = false },
            new CartItems { CartId = cart1.Id, BookId = 7, Quantity = 1, DateAdded = new DateTime(2026, 4, 1), SavedForLater = false },
            new CartItems { CartId = cart2.Id, BookId = 1, Quantity = 2, DateAdded = new DateTime(2026, 4, 5), SavedForLater = false },
            new CartItems { CartId = cart3.Id, BookId = 4, Quantity = 1, DateAdded = new DateTime(2026, 4, 8), SavedForLater = false },
            new CartItems { CartId = cart3.Id, BookId = 8, Quantity = 1, DateAdded = new DateTime(2026, 4, 8), SavedForLater = false },
            new CartItems { CartId = cart3.Id, BookId = 5, Quantity = 1, DateAdded = new DateTime(2026, 4, 8), SavedForLater = true }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedWishlistAsync(DatabaseContext context)
    {
        if (await context.WishlistItems.AnyAsync()) return;

        context.WishlistItems.AddRange(
            new WishlistItems { UserId = 3, BookId = 2, DateAdded = new DateTime(2026, 3, 10) },
            new WishlistItems { UserId = 3, BookId = 5, DateAdded = new DateTime(2026, 3, 15) },
            new WishlistItems { UserId = 5, BookId = 1, DateAdded = new DateTime(2026, 3, 20) },
            new WishlistItems { UserId = 5, BookId = 8, DateAdded = new DateTime(2026, 3, 25) },
            new WishlistItems { UserId = 7, BookId = 3, DateAdded = new DateTime(2026, 4, 1) },
            new WishlistItems { UserId = 7, BookId = 4, DateAdded = new DateTime(2026, 4, 2) },
            new WishlistItems { UserId = 8, BookId = 6, DateAdded = new DateTime(2026, 4, 3) },
            new WishlistItems { UserId = 9, BookId = 7, DateAdded = new DateTime(2026, 4, 5) }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedInventoryLogAsync(DatabaseContext context)
    {
        if (await context.InventoryLog.AnyAsync()) return;

        context.InventoryLog.AddRange(
            new InventoryLog { BookId = 1, ChangeTypeId = 1, QuantityChanged = 200, DateChanged = new DateTime(2025, 1, 1) },
            new InventoryLog { BookId = 2, ChangeTypeId = 1, QuantityChanged = 150, DateChanged = new DateTime(2025, 1, 1) },
            new InventoryLog { BookId = 3, ChangeTypeId = 1, QuantityChanged = 120, DateChanged = new DateTime(2025, 1, 1) },
            new InventoryLog { BookId = 4, ChangeTypeId = 1, QuantityChanged = 100, DateChanged = new DateTime(2025, 2, 1) },
            new InventoryLog { BookId = 5, ChangeTypeId = 1, QuantityChanged = 80, DateChanged = new DateTime(2025, 2, 1) },
            new InventoryLog { BookId = 6, ChangeTypeId = 1, QuantityChanged = 90, DateChanged = new DateTime(2025, 2, 1) },
            new InventoryLog { BookId = 7, ChangeTypeId = 1, QuantityChanged = 75, DateChanged = new DateTime(2025, 3, 1) },
            new InventoryLog { BookId = 8, ChangeTypeId = 1, QuantityChanged = 130, DateChanged = new DateTime(2025, 3, 1) },
            new InventoryLog { BookId = 1, ChangeTypeId = 2, QuantityChanged = 45, DateChanged = new DateTime(2025, 6, 30) },
            new InventoryLog { BookId = 2, ChangeTypeId = 2, QuantityChanged = 30, DateChanged = new DateTime(2025, 6, 30) },
            new InventoryLog { BookId = 1, ChangeTypeId = 1, QuantityChanged = 100, DateChanged = new DateTime(2025, 7, 5) },
            new InventoryLog { BookId = 8, ChangeTypeId = 2, QuantityChanged = 20, DateChanged = new DateTime(2025, 9, 15) },
            new InventoryLog { BookId = 3, ChangeTypeId = 2, QuantityChanged = 15, DateChanged = new DateTime(2025, 12, 1) },
            new InventoryLog { BookId = 1, ChangeTypeId = 2, QuantityChanged = 60, DateChanged = new DateTime(2025, 12, 31) }
        );

        await context.SaveChangesAsync();
    }

    private static async Task SeedAdditionalReviewsAsync(DatabaseContext context)
    {
        var existingCount = await context.Reviews.CountAsync();
        if (existingCount >= 6) return;

        context.Reviews.AddRange(
            new Review { BookId = 1, UserId = 5, Rating = 5, Comment = "Remek-djelo bosanske književnosti. Selimović piše o sudbini i vjeri na način koji te u potpunosti uvuče.", DatePosted = new DateTime(2025, 3, 15), IsDeleted = false },
            new Review { BookId = 2, UserId = 6, Rating = 4, Comment = "Andrićevo majstorstvo pripovijedanja dolazi do punog izražaja u ovom romanu.", DatePosted = new DateTime(2025, 5, 20), IsDeleted = false },
            new Review { BookId = 8, UserId = 7, Rating = 5, Comment = "Prokleta avlija je briljantna novela o zatočeništvu i slobodi. Kratko ali duboko.", DatePosted = new DateTime(2025, 7, 10), IsDeleted = false },
            new Review { BookId = 5, UserId = 8, Rating = 3, Comment = "Sušić piše angažovano i s mnogo emocija, mada mi se ponekad čini preromantizirano.", DatePosted = new DateTime(2025, 9, 5), IsDeleted = false },
            new Review { BookId = 7, UserId = 9, Rating = 5, Comment = "Sarajevo Blues je nešto posebno. Čitaš ga i osjećaš svaki red kao udarac u srce.", DatePosted = new DateTime(2025, 11, 22), IsDeleted = false },
            new Review { BookId = 6, UserId = 3, Rating = 4, Comment = "Ugursuz je duhovita i topla knjiga, puna bosanske duše i humora.", DatePosted = new DateTime(2026, 1, 14), IsDeleted = false }
        );

        await context.SaveChangesAsync();
    }
}
