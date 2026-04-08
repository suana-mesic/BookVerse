using Market.Domain.Entities.Catalog;
using Market.Domain.Entities.Shopping;
using Market.Domain.Entities.UserReviews;
using Market.Infrastructure.Database.Configurations.Shopping;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
        SeedCategories(modelBuilder);
        SeedAuthors(modelBuilder);
        SeedBooks(modelBuilder);
        SeedReviews(modelBuilder);
        SeedStores(modelBuilder);
        SeedShippingMethods(modelBuilder);
        SeedOrderStatuses(modelBuilder);
        SeedInventory(modelBuilder);
        SeedCoupons(modelBuilder);
    }

    private static void SeedReviews(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasData(
             new Review
             {
                 BookId = 1,
                 UserId = 1,
                 Rating = 5,
                 Comment = "Izuzetna knjiga koja me potpuno očarala. Meša Selimović majstorski oslikava duboke filozofske dileme i emocije likova, ostavljajući snažan utisak.",
                 DatePosted = DateTime.UtcNow,
                 IsDeleted = false

             },
             new Review
             {
                 BookId = 2,
                 UserId = 2,
                 Rating = 4,
                 Comment = "Dobra knjiga, ali nije me potpuno oduševila. Andrić je stvorio bogate likove i prikazao historijske procese, ali nekim dijelovima nedostaje dinamike.",
                 DatePosted = DateTime.UtcNow,
                 IsDeleted = false
             },
               new Review
               {
                   BookId = 3,
                   UserId = 3,
                   Rating = 3,
                   Comment = "Knjiga mi nije bila loša, ali nisam doživio neku posebnu emociju. Iako Ćopić piše o važnim temama, nisam se mogao potpuno povezati s likovima.",
                   DatePosted = DateTime.UtcNow,
                   IsDeleted = false
               });
    }

    private static void SeedPublishers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>().HasData(
        new Publisher
            {
                Id = 1,
                Name = "Buybook",
                City = "Sarajevo",
                Country = "Bosna i Hercegovina",
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
        new Publisher
        {
            Id = 2,
            Name = "Svjetlost",
            City = "Sarajevo",
            Country = "Bosna i Hercegovina",
            IsDeleted = false,
            CreatedAtUtc = DateTime.Now
        },
         new Publisher
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
        modelBuilder.Entity<BookFormat>().HasData(
            new BookFormat
            {
                Id = 1,
                Format = "Tvrdi uvez",
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
        new BookFormat
        {
            Id = 2,
            Format = "Tvrdi papirni uvez",
            IsDeleted = false,
            CreatedAtUtc = DateTime.Now
        },
        new BookFormat
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
            FirstName = "admin",
            LastName = "admin",
            Email = "admin@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = true,
            IsManager = false,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted=false,
            AddressId =1,
            TwoFactorEnabled=false,
            CreatedAtUtc = DateTime.Now
            },
               new MarketUserEntity
            {
            Id = 2,
            FirstName = "manager",
            LastName = "manager",
            Email = "manager@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager = true,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted = false,
            AddressId = 2,
            TwoFactorEnabled=false,
            CreatedAtUtc = DateTime.Now
            },
                new MarketUserEntity
            {
            Id = 3,
            FirstName = "korisnik",
            LastName = "korisnik",
            Email = "korisnik@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager=false,
            IsEmployee=false,
            IsEnabled = true,
            IsDeleted=false,
            TwoFactorEnabled=false,
            AddressId = 3,
            CreatedAtUtc = DateTime.Now
            },

                new MarketUserEntity
            {
            Id = 4,
            FirstName = "uposlenik",
            LastName = "uposlenik",
            Email = "uposlenik@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager = false,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted = false,
            TwoFactorEnabled=false,
            AddressId = 1,
            CreatedAtUtc = DateTime.Now
            }
        });

    }

    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category{
               Id = 1,
               Name="Roman",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
            new Category{
               Id = 2,
               Name="Poezija",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
             new Category{
               Id = 3,
               Name="Drama",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            }
        });
    }

    private static void SeedAddresses(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>().HasData(new List<Address>
        {
            new Address{
               Id = 1,
               Line1="Maršala Tita",
               City="Mostar",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
            new Address{
               Id = 2,
               Line1="Vrbanja 1",
               City="Sarajevo",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
             new Address{
               Id = 3,
               Line1 = "Gornja Kolonija SP 100",
               City ="Jablanica",
               Country = "BiH",
               IsDeleted = false,
               CreatedAtUtc = DateTime.Now
            }
        });
    }

    private static void SeedStores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>().HasData(new List<Store>
        {
            new Store
            {
                Id = 1,
                StoreName="Central Bookstore",
                AddressId=1,
                Phone = "123-456-7890",
                Email = "test@bookverse.ba",
                OpeningHours = "Mon-Fri 9am-9pm; Sat-Sun 10am-6pm"
            },
            new Store
            {
                Id = 2,
                StoreName="Fortica Books",
                AddressId=2,
                Phone = "123-456-7890",
                Email = "test2@bookverse.ba",
                OpeningHours = "Mon-Fri 9am-9pm; Sat-Sun 10am-6pm"
            },
            new Store
            {
                Id = 3,
                StoreName="Space Bookstore",
                AddressId=3,
                Phone = "123-456-7890",
                Email = "test3@bookverse.ba",
                OpeningHours = "Mon-Fri 9am-9pm; Sat-Sun 10am-6pm"
            }
        });
    }
        private static void SeedAuthors(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(new List<Author>
        {
            new Author{
               Id = 1,
               FirstName = "Meša",
               LastName = "Selimović",
               Biography = "biografija",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
            new Author{
               Id = 2,
               FirstName = "Ivo",
               LastName = "Andrić",
               Biography = "biografija",
               Country="BiH",
               IsDeleted=false,
               CreatedAtUtc = DateTime.Now
            },
             new Author{
               Id = 3,
               FirstName = "Branko",
               LastName = "Ćopić",
               Biography = "biografija",
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
            new Books{
                Id = 1,
                ISBN = "978-86-03-02636-0",
                Title = "Derviš i smrt",
                PublisherId = 1,
                BookFormatId = 2,
                Price = 29.99m,
                Language = "Bosanski",
                Description = "Roman koji se bavi pitanjima vjere, duhovnosti i smrti, kroz priču o Dervišu koji pokušava da pronađe smisao u životu i smrti. Kroz likove i filozofske dijaloge, autor istražuje moralne dileme i ljudsku patnju.",
                PageCount = 320,
                QuantityInStockForOnlineOrders = 200,
                ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/dervis_i_smrt_logos_art.jpg",
                PublishedDate = new DateTime(1966, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
            new Books{
                Id = 2,
                ISBN = "978-86-07-00752-2",
                Title = "Na Drini ćuprija",
                PublisherId = 2,
                BookFormatId = 2,
                Price = 34.99m,
                Language = "Bosanski",
                Description = "Roman koji opisuje istoriju jednog grada i njegove mostove, kroz sudbine ljudi koji su živeli u različitim vremenima. Andrić istražuje ljudsku sudbinu, istoriju i političke i kulturne promene kroz život mosta na Drini.",
                PageCount = 412,
                QuantityInStockForOnlineOrders = 150,
                ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/d0977_na_drini_cuprija.jpg",
                PublishedDate = new DateTime(1945, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            },
            new Books{
                Id = 3,
                ISBN = "978-86-03-00942-5",
                Title = "Bašta, pepeo",
                PublisherId = 3,
                BookFormatId = 2,
                Price = 24.99m,
                Language = "Bosanski",
                Description = "Roman koji kroz priču o životu jednog mladog čoveka istražuje teme ljubavi, smrti, i socijalnih promjena. Ćopić se bavi i univerzalnim pitanjima identiteta i postojanja u svetu koji se menja.",
                PageCount = 280,
                QuantityInStockForOnlineOrders = 120,
                ImageUrl = "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/basta_pepeo.jpg",
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.Now
            }
          }
        );
    }
    private static void SeedShippingMethods(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ShippingMethods>().HasData(new List<ShippingMethods>
        {
        new ShippingMethods{
            Id=1,
            Name = "Express One",
            Description = "Domaća kurirska služba sa brzom dostavom na području cijele BiH (1–2 radna dana). Pogodno za pakete i dokumente.",
            Price = 9.50m
        },
        new ShippingMethods{
            Id=2,
            Name = "X Express",
            Description = "Brza pošta sa dostavom širom Bosne i Hercegovine u roku 24–48h. Često korištena za online trgovine.",
            Price = 8.00m
        },
        new ShippingMethods{
            Id=3,
            Name = "EuroExpress",
            Description = "Kurirska služba sa dostavom na području cijele BiH u roku 24–48h, uz mogućnost plaćanja pouzećem.",
            Price = 9.00m
        }
      });
    }
    private static void SeedOrderStatuses(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<OrderStatus>().HasData(new List<OrderStatus>
        {
        new OrderStatus{
            Id = 1,
            StatusName = OrderStatusType.Draft
        },
        new OrderStatus{
            Id = 2,
            StatusName = OrderStatusType.Packed
        },
        new OrderStatus{
            Id = 3,
            StatusName = OrderStatusType.Paid
        },
        new OrderStatus{
            Id = 4,
            StatusName = OrderStatusType.Shipped
        },
        new OrderStatus{
            Id = 5,
            StatusName = OrderStatusType.Cancelled
        }
      });
    }
    private static void SeedInventory(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<StoreInventory>().HasData(new List<StoreInventory>
        {
        new StoreInventory{
            StoreId=1,
            BookId=1,
            QuantityInStock=50,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-5",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=1,
            QuantityInStock=90,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-12",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=1,
            QuantityInStock=40,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-15",
            IsDeleted=false,
        },
         new StoreInventory{
            StoreId=1,
            BookId=2,
            QuantityInStock=200,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-21",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=2,
            QuantityInStock=210,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-22",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=2,
            QuantityInStock=240,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-23",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=1,
            BookId=3,
            QuantityInStock=70,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-31",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=3,
            QuantityInStock=90,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-32",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=3,
            QuantityInStock=80,
            LastRestocked=DateTime.Now,
            ReorderTreshold=5,
            Location="Polica A-33",
            IsDeleted=false,
        },
      });
    }

    private static void SeedCoupons(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Coupons>().HasData(new List<Coupons>
        {
        new Coupons{
            Id = 1,
            Name = "Welcome discount",
            Description= "Welcome discount with amountoff 10",
            AmountOff = 10,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(365),
            PromotionCode = "WELCOME10A"
        },
        new Coupons{
            Id = 2,
            Name = "Summer discount ",
            Description = "Summer discount with percentoff 20",
            PercentOff = 20,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(365),
            PromotionCode = "WELCOME20P"
        },
      });
    }
}