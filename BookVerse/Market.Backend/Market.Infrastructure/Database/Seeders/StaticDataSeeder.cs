using System.Collections.Generic;

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
}