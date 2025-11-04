namespace Market.Application.Abstractions;

// Application layer
public interface IAppDbContext
{
    DbSet<ProductEntity> Products { get; }
    DbSet<ProductCategoryEntity> ProductCategories { get; }
    DbSet<MarketUserEntity> Users { get; }
    DbSet<RefreshTokenEntity> RefreshTokens { get; }
    DbSet<Addresses> Addresses { get; }
    DbSet<Authors> Authors { get; }
    DbSet<Books> Books { get;  }
    DbSet<Categories> Categories { get; }
    DbSet<Publishers> Publishers { get; }
    DbSet<BookFormats> BookFormats { get; }



    Task<int> SaveChangesAsync(CancellationToken ct);
}