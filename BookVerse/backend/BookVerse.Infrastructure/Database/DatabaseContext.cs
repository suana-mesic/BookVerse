using BookVerse.Application.Abstractions;
using BookVerse.Domain.Entities.UserReviews;
using BookVerse.Domain.Entities.Shopping;
using BookVerse.Domain.Entities.Whishlist;
using BookVerse.Infrastructure.Database.Configurations.Shopping;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookVerse.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    //public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
    //public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<BookVerseUserEntity> Users => Set<BookVerseUserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Books> Books => Set<Books>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<BookFormat> BookFormats => Set<BookFormat>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<WishlistItems> WishlistItems => Set<WishlistItems>();
    public DbSet<Store> Stores => Set<Store>();
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
    public DbSet<StripeEvent> StripeEvents => Set<StripeEvent>();















    private readonly TimeProvider _clock;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct)
        => Database.BeginTransactionAsync(ct);
}