using Market.Application.Abstractions;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    public DbSet<ProductCategoryEntity> ProductCategories => Set<ProductCategoryEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<MarketUserEntity> Users => Set<MarketUserEntity>();
    public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();
    public DbSet<Addresses> Addresses => Set<Addresses>();

    public DbSet<Authors> Authors => Set<Authors>();
    public DbSet<Books> Books => Set<Books>();
    public DbSet<Publishers> Publishers => Set<Publishers>();
    public DbSet<BookFormats> BookFormats => Set<BookFormats>();

    private readonly TimeProvider _clock;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }
}