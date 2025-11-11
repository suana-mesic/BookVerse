using Market.Domain.Entities.Review;
using Market.Domain.Entities.Shopping;
using Market.Domain.Entities.Whishlist;

namespace Market.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
    //DbSet<ProductEntity> Products { get; }
    //DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<Addresses> Addresses { get; }
    DbSet<Authors> Authors { get; }
    DbSet<Books> Books { get;  }
    DbSet<Categories> Categories { get; }
    DbSet<Publishers> Publishers { get; }
    DbSet<BookFormats> BookFormats { get; }
    DbSet<Reviews> Reviews { get; }
    DbSet<WishlistItems> WishlistItems { get; }
    DbSet<Stores> Stores { get; }
    DbSet<StoreInventory> StoreInventory { get; }
    DbSet<Carts> Carts { get; }
    DbSet<Coupons> Coupons { get; }
    DbSet<OrderStatus> OrderStatus { get; }
    DbSet<ShippingMethods> ShippingMethods { get; }
    DbSet<PaymentSummaries> PaymentSummaries { get; }
    DbSet<Orders> Orders { get; }
    DbSet<CartItems> CartItems { get; }
    DbSet<ShippingUpdates> ShippingUpdates { get; }
    DbSet<Refunds> Refunds { get; }
    DbSet<InventoryLog> InventoryLog { get; }
    DbSet<ChangeTypes> ChangeTypes { get; }


    Task<int> SaveChangesAsync(CancellationToken ct);
}