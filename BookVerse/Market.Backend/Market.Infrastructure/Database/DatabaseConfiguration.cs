using Market.Domain.Common;
using Market.Domain.Entities.Review;
using Market.Infrastructure.Database.Seeders;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext
{
    private DateTime UtcNow => _clock.GetUtcNow().UtcDateTime;

    private void ApplyAuditAndSoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAtUtc = UtcNow;
                    entry.Entity.ModifiedAtUtc = null; // ili = UtcNow
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.ModifiedAtUtc = UtcNow;
                    break;

                case EntityState.Deleted:
                    // soft-delete: set is Modified and IsDeleted
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.ModifiedAtUtc = UtcNow;
                    break;
            }
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        configurationBuilder.Properties<decimal?>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>()
            .HasMany(s => s.Authors)
        .WithMany(k => k.Books)
        .UsingEntity(j => j.ToTable("BookAuthors").HasData(
            new { BooksId = 1, AuthorsId = 1 },
            new { BooksId = 2, AuthorsId = 2 },
            new { BooksId = 2, AuthorsId = 3 } ,
            new { BooksId = 3, AuthorsId = 3 }
        ));

        modelBuilder.Entity<Books>().HasMany(c => c.Categories).WithMany(b => b.Books)
            .UsingEntity(j => j.ToTable("BooksCategories").HasData(
                new { BooksId = 1, CategoriesId = 1 },
                new { BooksId = 1, CategoriesId = 2 },
                new { BooksId = 2, CategoriesId = 1 },
                new { BooksId = 3, CategoriesId = 3 }
            ));

        modelBuilder.Entity<Reviews>().HasKey(x => new { x.BookId, x.UserId });

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

        ApplyGlobalFielters(modelBuilder);

        StaticDataSeeder.Seed(modelBuilder); // static data
    }

    private void ApplyGlobalFielters(ModelBuilder modelBuilder)
    {
        // Apply a global filter to all entities inheriting from BaseEntity
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var prop = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var compare = Expression.Equal(prop, Expression.Constant(false));
                var lambda = Expression.Lambda(compare, parameter);

                modelBuilder.Entity(entityType.ClrType)
                            .HasQueryFilter(lambda);
            }
        }
    }

    public override int SaveChanges()
    {
        ApplyAuditAndSoftDelete();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ApplyAuditAndSoftDelete();

        return base.SaveChangesAsync(cancellationToken);
    }
}