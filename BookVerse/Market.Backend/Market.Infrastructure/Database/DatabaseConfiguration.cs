using Market.Domain.Common;
using Market.Domain.Entities.UserReviews;
using Market.Domain.Entities.Shopping;
using Market.Domain.Entities.Whishlist;
using Market.Infrastructure.Database.Seeders;
using Microsoft.EntityFrameworkCore;
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        modelBuilder.Entity<Books>()
            .HasMany(s => s.Authors)
        .WithMany(k => k.Books)
        .UsingEntity(j => j.ToTable("BookAuthors").HasData(
            new { BooksId = 1, AuthorsId = 1 },
            new { BooksId = 2, AuthorsId = 2 },
            new { BooksId = 2, AuthorsId = 3 },
            new { BooksId = 3, AuthorsId = 3 }
        ));

        modelBuilder.Entity<Books>().HasMany(c => c.Categories).WithMany(b => b.Books)
            .UsingEntity(j => j.ToTable("BooksCategories").HasData(
                new { BooksId = 1, CategoriesId = 1 },
                new { BooksId = 1, CategoriesId = 2 },
                new { BooksId = 2, CategoriesId = 1 },
                new { BooksId = 3, CategoriesId = 3 }
            ));

        modelBuilder.Entity<Review>().HasKey(x => new { x.BookId, x.UserId });
        modelBuilder.Entity<Review>().HasQueryFilter(x => !x.IsDeleted && !x.Book.IsDeleted && !x.User.IsDeleted);


        modelBuilder.Entity<WishlistItems>().HasKey(x => new { x.UserId, x.BookId });
        modelBuilder.Entity<WishlistItems>().HasQueryFilter(x => !x.Book.IsDeleted && !x.User.IsDeleted);

        modelBuilder.Entity<StoreInventory>().HasKey(x => new { x.StoreId, x.BookId });
        modelBuilder.Entity<StoreInventory>().HasQueryFilter(x => !x.IsDeleted && !x.Book.IsDeleted && !x.Store.IsDeleted);

        modelBuilder.Entity<CartItems>().HasKey(x => new { x.CartId, x.BookId });

        modelBuilder.Entity<Carts>()
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItems>().HasKey(x => new { x.OrderId, x.BookId });
        modelBuilder.Entity<OrderItems>().HasQueryFilter(x => !x.Order.IsDeleted && !x.Book.IsDeleted);

        modelBuilder.Entity<Refunds>()
        .HasKey(r => new { r.OrderId, r.BookId }); 

        modelBuilder.Entity<Refunds>().HasOne<OrderItems>()
            .WithMany()
            .HasForeignKey(r => new { r.OrderId, r.BookId })
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Orders>()
            .HasMany(s => s.Coupons)
            .WithMany()
            .UsingEntity(j => j.ToTable("OrderCoupons"));

        //zbog višestrukog cascade delete-a

        modelBuilder.Entity<ShippingUpdates>()
        .HasOne(s => s.Order)
        .WithMany()
        .HasForeignKey(s => s.OrderId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Orders>()
       .HasOne(s => s.User)
       .WithMany()
       .HasForeignKey(s => s.UserId)
       .OnDelete(DeleteBehavior.NoAction);


        base.OnModelCreating(modelBuilder);

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