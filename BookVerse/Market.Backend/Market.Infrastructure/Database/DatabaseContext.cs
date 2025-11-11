using Market.Application.Abstractions;
using Market.Domain.Entities.Review;
using Market.Domain.Entities.Shopping;
using Market.Domain.Entities.Whishlist;
using Market.Infrastructure.Database.Configurations.Shopping;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    //public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
    //public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<MarketUserEntity> Users => Set<MarketUserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<Addresses> Addresses => Set<Addresses>();
    public DbSet<Authors> Authors => Set<Authors>();
    public DbSet<Books> Books => Set<Books>();
    public DbSet<Categories> Categories => Set<Categories>();
    public DbSet<Publishers> Publishers => Set<Publishers>();
    public DbSet<BookFormats> BookFormats => Set<BookFormats>();
    public DbSet<Reviews> Reviews => Set<Reviews>();
    public DbSet<WishlistItems> WishlistItems => Set<WishlistItems>();
    public DbSet<Stores> Stores => Set<Stores>();
    public DbSet<StoreInventory> StoreInventory => Set<StoreInventory>();
    public DbSet<Carts> Carts => Set<Carts>();
    public DbSet<Coupons> Coupons => Set<Coupons>();
    public DbSet<OrderStatus> OrderStatus => Set<OrderStatus>();
    public DbSet<ShippingMethods> ShippingMethods => Set<ShippingMethods>();
    public DbSet<PaymentSummaries> PaymentSummaries => Set<PaymentSummaries>();
    public DbSet<Orders> Orders => Set<Orders>();
    public DbSet<CartItems> CartItems => Set<CartItems>();
    public DbSet<ShippingUpdates> ShippingUpdates => Set<ShippingUpdates>();
    public DbSet<OrderItems> OrderItems => Set<OrderItems>();
    public DbSet<Refunds> Refunds => Set<Refunds>();
    public DbSet<InventoryLog> InventoryLog => Set<InventoryLog>();
    public DbSet<ChangeTypes> ChangeTypes => Set<ChangeTypes>();















    private readonly TimeProvider _clock;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }
}