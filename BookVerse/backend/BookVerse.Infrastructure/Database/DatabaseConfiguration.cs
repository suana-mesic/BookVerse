using BookVerse.Domain.Common;
using BookVerse.Domain.Entities.UserReviews;
using BookVerse.Domain.Entities.Shopping;
using BookVerse.Domain.Entities.Whishlist;
using BookVerse.Infrastructure.Database.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace BookVerse.Infrastructure.Database;

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
                    entry.Entity.ModifiedAtUtc = null; // or = UtcNow
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
            new { BooksId = 3, AuthorsId = 3 },
            new { BooksId = 4, AuthorsId = 4 },
            new { BooksId = 5, AuthorsId = 5 },
            new { BooksId = 6, AuthorsId = 6 },
            new { BooksId = 7, AuthorsId = 7 },
            new { BooksId = 8, AuthorsId = 2 },
            new { BooksId = 9, AuthorsId = 1 },
            new { BooksId = 10, AuthorsId = 4 },
            new { BooksId = 11, AuthorsId = 5 },
            new { BooksId = 12, AuthorsId = 10 },
            new { BooksId = 13, AuthorsId = 11 },
            new { BooksId = 14, AuthorsId = 12 },
            new { BooksId = 15, AuthorsId = 13 },
            new { BooksId = 16, AuthorsId = 14 },
            new { BooksId = 17, AuthorsId = 15 },
            new { BooksId = 18, AuthorsId = 16 },
            new { BooksId = 19, AuthorsId = 4 },
            new { BooksId = 20, AuthorsId = 17 },
            new { BooksId = 21, AuthorsId = 18 }
        ));

        modelBuilder.Entity<Books>().HasMany(c => c.Categories).WithMany(b => b.Books)
            .UsingEntity(j => j.ToTable("BooksCategories").HasData(
                new { BooksId = 1, CategoriesId = 1 },
                new { BooksId = 1, CategoriesId = 2 },
                new { BooksId = 2, CategoriesId = 1 },
                new { BooksId = 3, CategoriesId = 3 },
                new { BooksId = 4, CategoriesId = 2 },
                new { BooksId = 4, CategoriesId = 1 },
                new { BooksId = 5, CategoriesId = 1 },
                new { BooksId = 6, CategoriesId = 1 },
                new { BooksId = 7, CategoriesId = 2 },
                new { BooksId = 8, CategoriesId = 1 },
                new { BooksId = 8, CategoriesId = 3 },
                new { BooksId = 9, CategoriesId = 1 },
                new { BooksId = 10, CategoriesId = 1 },
                new { BooksId = 11, CategoriesId = 4 },
                new { BooksId = 12, CategoriesId = 2 },
                new { BooksId = 13, CategoriesId = 7 },
                new { BooksId = 14, CategoriesId = 8 },
                new { BooksId = 15, CategoriesId = 5 },
                new { BooksId = 16, CategoriesId = 9 },
                new { BooksId = 17, CategoriesId = 1 },
                new { BooksId = 18, CategoriesId = 2 },
                new { BooksId = 19, CategoriesId = 1 },
                new { BooksId = 20, CategoriesId = 1 },
                new { BooksId = 21, CategoriesId = 1 }
            ));

        // Review filter MUST include !x.IsDeleted on the review itself. Without it,
        // CreateReviewCommandHandler's "alreadyReviewed" check still sees rows the user
        // soft-deleted, so a user who deletes their own review could never write a new one.
        modelBuilder.Entity<Review>().HasKey(x => new { x.BookId, x.UserId });
        modelBuilder.Entity<Review>().HasQueryFilter(x => !x.IsDeleted && !x.Book.IsDeleted && !x.User.IsDeleted);


        // WishlistItems has no own IsDeleted column, so we only hide rows whose Book or User
        // has been soft-deleted.
        modelBuilder.Entity<WishlistItems>().HasKey(x => new { x.UserId, x.BookId });
        modelBuilder.Entity<WishlistItems>().HasQueryFilter(x => !x.Book.IsDeleted && !x.User.IsDeleted);

        // StoreInventory already checks its own IsDeleted plus related entities.
        modelBuilder.Entity<StoreInventory>().HasKey(x => new { x.StoreId, x.BookId });
        modelBuilder.Entity<StoreInventory>().HasQueryFilter(x => !x.IsDeleted && !x.Book.IsDeleted && !x.Store.IsDeleted);

        // CartItems has no own IsDeleted; we hide rows whose Book was soft-deleted so the
        // cart never shows entries the user could never actually order.
        modelBuilder.Entity<CartItems>()
            .HasQueryFilter(x => !x.Book.IsDeleted)
            .HasKey(x => new { x.CartId, x.BookId });

        modelBuilder.Entity<Carts>()
            .HasQueryFilter(c => !c.User.IsDeleted)
            .HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId);

        // OrderItems has no own IsDeleted; the filter hides items whose parent order or book
        // has been soft-deleted.
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

        //due to multiple cascade delete paths

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

        ApplyGlobalFilters(modelBuilder);

        StaticDataSeeder.Seed(modelBuilder); // static data
    }

    private void ApplyGlobalFilters(ModelBuilder modelBuilder)
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
        CascadeSoftDeleteForBooks();

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ApplyAuditAndSoftDelete();
        await CascadeSoftDeleteForBooksAsync(cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }

    // Soft-delete on a Book does NOT automatically reach related rows in EF Core, so without
    // this method a "deleted" book would still have orphan Reviews and StoreInventory records
    // visible if anyone bypassed the global query filters.
    //
    // We only cascade to entities that have their OWN IsDeleted column:
    //   - Review          (has IsDeleted)
    //   - StoreInventory  (has IsDeleted)
    // CartItems and OrderItems have NO IsDeleted - their global query filter (!x.Book.IsDeleted)
    // already hides them, so nothing to do there.
    private async Task CascadeSoftDeleteForBooksAsync(CancellationToken ct)
    {
        var bookIds = GetBookIdsBeingSoftDeleted();
        if (bookIds.Count == 0) return;

        // Reviews: find every active review for these books and mark it deleted.
        // IgnoreQueryFilters() so the Review filter (!x.IsDeleted && !x.Book.IsDeleted ...)
        // doesn't already hide rows we still need to update.
        var reviewsToDelete = await Set<Review>()
            .IgnoreQueryFilters()
            .Where(r => bookIds.Contains(r.BookId) && !r.IsDeleted)
            .ToListAsync(ct);
        foreach (var review in reviewsToDelete)
            review.IsDeleted = true;

        // StoreInventory: same idea, mark all active inventory rows for these books as deleted.
        var inventoriesToDelete = await Set<StoreInventory>()
            .IgnoreQueryFilters()
            .Where(si => bookIds.Contains(si.BookId) && !si.IsDeleted)
            .ToListAsync(ct);
        foreach (var inv in inventoriesToDelete)
            inv.IsDeleted = true;
    }

    // Sync counterpart used by the sync SaveChanges override.
    private void CascadeSoftDeleteForBooks()
    {
        var bookIds = GetBookIdsBeingSoftDeleted();
        if (bookIds.Count == 0) return;

        var reviewsToDelete = Set<Review>()
            .IgnoreQueryFilters()
            .Where(r => bookIds.Contains(r.BookId) && !r.IsDeleted)
            .ToList();
        foreach (var review in reviewsToDelete)
            review.IsDeleted = true;

        var inventoriesToDelete = Set<StoreInventory>()
            .IgnoreQueryFilters()
            .Where(si => bookIds.Contains(si.BookId) && !si.IsDeleted)
            .ToList();
        foreach (var inv in inventoriesToDelete)
            inv.IsDeleted = true;
    }

    // Returns ids of Books that were JUST soft-deleted in this SaveChanges batch.
    // We require BOTH:
    //   - the entity's IsDeleted property is currently true, AND
    //   - that property was actually changed in this transaction (IsModified)
    // so we don't keep re-cascading every time anyone touches an already-deleted Book.
    private List<int> GetBookIdsBeingSoftDeleted()
    {
        return ChangeTracker.Entries<Books>()
            .Where(e => e.State == EntityState.Modified
                && e.Entity.IsDeleted
                // Use BaseEntity.IsDeleted (not Books.IsDeleted) because in this partial class
                // "Books" already refers to the DbSet<Books> property, not the entity type.
                && e.Property(nameof(BaseEntity.IsDeleted)).IsModified)
            .Select(e => e.Entity.Id)
            .ToList();
    }
}
