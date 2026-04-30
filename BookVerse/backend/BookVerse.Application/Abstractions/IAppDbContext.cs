using BookVerse.Domain.Entities.UserReviews;
using BookVerse.Domain.Entities.Shopping;
using BookVerse.Domain.Entities.Whishlist;

namespace BookVerse.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
    //DbSet<ProductEntity> Products { get; }
    //DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<BookVerseUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<Address> Addresses { get; }
    DbSet<Author> Authors { get; }
    DbSet<Books> Books { get;  }
    DbSet<Category> Categories { get; }
    DbSet<Publisher> Publishers { get; }
    DbSet<BookFormat> BookFormats { get; }
    DbSet<Language> Languages { get; }
    DbSet<Review> Reviews { get; }
    DbSet<WishlistItems> WishlistItems { get; }
    DbSet<Store> Stores { get; }
    DbSet<StoreInventory> StoreInventory { get; }
    DbSet<Carts> Carts { get; }
    DbSet<Coupons> Coupons { get; }
    DbSet<OrderStatus> OrderStatus { get; }
    DbSet<ShippingMethods> ShippingMethods { get; }
    DbSet<PaymentSummaries> PaymentSummaries { get; }
    DbSet<Orders> Orders { get; }
    DbSet<OrderItems> OrderItems { get; }
    DbSet<CartItems> CartItems { get; }
    DbSet<ShippingUpdates> ShippingUpdates { get; }
    DbSet<Refunds> Refunds { get; }
    DbSet<InventoryLog> InventoryLog { get; }
    DbSet<ChangeTypes> ChangeTypes { get; }


    Task<int> SaveChangesAsync(CancellationToken ct);
}