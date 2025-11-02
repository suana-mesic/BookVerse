using Market.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Market.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);


    public static void Seed(ModelBuilder modelBuilder)
    {
        // Static data is added in the migration
        // if it does not exist in the DB at the time of creating the migration
        // example of static data: roles
        SeedAddresses(modelBuilder);
        SeedUsers(modelBuilder);
        seedBookFormats(modelBuilder);
        SeedPublishers(modelBuilder);
        SeedBooks(modelBuilder);
    }

    private static void SeedPublishers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publishers>().HasData(
            new Publishers
        {
            Id = 1,
            Name = "Buybook",
            City = "Sarajevo",
            Country ="Bosna i Hercegovina",
            IsDeleted = false,
            CreatedAtUtc = DateTime.Now
        },
        new Publishers
        {
             Id = 2,
             Name = "Svjetlost",
             City = "Sarajevo",
             Country = "Bosna i Hercegovina",
             IsDeleted = false,
             CreatedAtUtc = DateTime.Now
         },
         new Publishers
         {
             Id = 3,
             Name = "Laguna",
             City = "Beograd",
             Country = "Srbija",
             IsDeleted = false,
             CreatedAtUtc = DateTime.Now
         });
    }

    private static void seedBookFormats(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookFormats>().HasData(
            new BookFormats
        {
                Id = 1,
                Format = "Tvrdi uvez",
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
        },
        new BookFormats
        {
            Id = 2,
            Format = "Tvrdi papirni uvez",
            IsDeleted = false,
            CreatedAtUtc = DateTime.Now
        },
        new BookFormats
        {
            Id = 3,
            Format = "Spiralni uvez",
            IsDeleted = false,
            CreatedAtUtc = DateTime.Now
        });
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<MarketUserEntity>();

        modelBuilder.Entity<MarketUserEntity>().HasData(new List<MarketUserEntity>
        {
                new MarketUserEntity
            {
            Id = 1,
            FirstName = "Admin",
            LastName = "User",
            Email = "admin@gmail.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = true,
            IsManager=false,
            IsEmployee=true,
            IsEnabled = true,
            IsDeleted=false,
            AddressId =1,
            CreatedAtUtc = DateTime.Now
            },
                new MarketUserEntity
            {
            Id = 2,
            FirstName = "string",
            LastName = "string",
            Email = "string@gmail.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager=false,
            IsEmployee=true,
            IsEnabled = true,
            IsDeleted=false,
            AddressId =2,
            CreatedAtUtc = DateTime.Now
            },
            
                new MarketUserEntity
            {
            Id = 3,
            FirstName = "manager@market.local",
            LastName = "string",
            Email = "string@gmail.com",
            PasswordHash = hasher.HashPassword(null!, "User123!"),
            IsAdmin = false,
            IsManager = true,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted = false,
            AddressId = 2,
            CreatedAtUtc = DateTime.Now
            }
        });

    }

    private static void SeedAddresses(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Addresses>().HasData(new List<Addresses>
        {
            new Addresses{
               Id = 1,
               Line1="Maršala Tita",
               City="Mostar",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
            new Addresses{
               Id = 2,
               Line1="Vrbanja 1",
               City="Sarajevo",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
             new Addresses{
               Id = 3,
               Line1 = "Gornja Kolonija SP 100",
               City ="Jablanica",
               Country = "BiH",
               IsDeleted = false,
               CreatedAtUtc = DateTime.Now
            }
        });
    }


    private static void SeedBooks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>().HasData(new List<Books>
        {
            new Books {
                Id = 1,
                ISBN = "978-0-316-76948-0",
                Title = "The Catcher in the Rye",
                PublisherId = 1,
                BookFormatId = 2,
                Price = 19.99m,
                Language = "English",
                Description = "A story about a young man, Holden Caulfield, and his experiences in New York City after being expelled from prep school.",
                PageCount = 277,
                QuantityInStockForOnlineOrders = 150,
                ImageUrl = "https://example.com/images/catcher_in_the_rye.jpg",
                PublishedDate = new DateTime(1951, 7, 16),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
            new Books{
                Id = 2,
                ISBN = "978-0-618-00221-3",
                Title = "The Hobbit",
                PublisherId = 2,
                BookFormatId = 1,
                Price = 25.99m,
                Language = "English",
                Description = "A fantasy novel by J.R.R. Tolkien, following the adventures of Bilbo Baggins in Middle-earth.",
                PageCount = 310,
                QuantityInStockForOnlineOrders = 120,
                ImageUrl = "https://example.com/images/the_hobbit.jpg",
                PublishedDate = new DateTime(1937, 9, 21),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
            new Books{
                Id = 3,
                ISBN = "978-1-84293-719-6",
                Title = "The Secret of Secrets",
                PublisherId = 2,
                BookFormatId = 2,
                Price = 19.99m,
                Language = "English",
                Description = "A spiritual guidebook written by a spiritual teacher, exploring hidden knowledge and insights, offering guidance on life, peace, and inner wisdom.",
                PageCount = 400,
                QuantityInStockForOnlineOrders = 150,
                ImageUrl = "https://example.com/images/the_secret_of_secrets.jpg",
                PublishedDate = new DateTime(2005, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            }
          }
        );
    }
}