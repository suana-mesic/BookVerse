using BookVerse.Domain.Entities.Shopping;
using BookVerse.Domain.Entities.UserReviews;

namespace BookVerse.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);

    private const string BookImagesBaseUrl = "/images/books/";


    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedAddresses(modelBuilder);
        SeedUsers(modelBuilder);
        seedBookFormats(modelBuilder);
        SeedLanguages(modelBuilder);
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
        SeedMoreAddresses(modelBuilder);
        SeedMoreUsers(modelBuilder);
        SeedMoreCategories(modelBuilder);
        SeedMoreAuthors(modelBuilder);
        SeedMorePublishers(modelBuilder);
        SeedMoreBooks(modelBuilder);
        SeedChangeTypes(modelBuilder);
        SeedMoreInventory(modelBuilder);
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
                CreatedAtUtc = DateTime.UtcNow
            },
        new Publisher
        {
            Id = 2,
            Name = "Svjetlost",
            City = "Sarajevo",
            Country = "Bosna i Hercegovina",
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        },
         new Publisher
         {
             Id = 3,
             Name = "Laguna",
             City = "Beograd",
             Country = "Srbija",
             IsDeleted = false,
             CreatedAtUtc = DateTime.UtcNow
         },
        new Publisher
        {
            Id = 4,
            Name = "Čarobna knjiga",
            City = "Beograd",
            Country = "Srbija",
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        });
    }

    private static void SeedLanguages(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "Bosanski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 2, Name = "Engleski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 3, Name = "Njemački", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 4, Name = "Srpski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 5, Name = "Hrvatski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 6, Name = "Francuski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 7, Name = "Španski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 8, Name = "Italijanski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Language { Id = 9, Name = "Ruski", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow }
        );
    }

    private static void seedBookFormats(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookFormat>().HasData(
            new BookFormat
            {
                Id = 1,
                Format = "Tvrdi uvez",
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
            },
        new BookFormat
        {
            Id = 2,
            Format = "Meki uvez",
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        },
        new BookFormat
        {
            Id = 3,
            Format = "Spiralni uvez",
            IsDeleted = false,
            CreatedAtUtc = DateTime.UtcNow
        });
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<BookVerseUserEntity>();

        modelBuilder.Entity<BookVerseUserEntity>().HasData(new List<BookVerseUserEntity>
        {
                new BookVerseUserEntity
            {
            Id = 1,
            FirstName = "admin",
            LastName = "admin",
            Email = "admin@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = true,
            IsManager = true,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted=false,
            AddressId =1,
            TwoFactorEnabled=false,
            CreatedAtUtc = DateTime.UtcNow
            },
               new BookVerseUserEntity
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
            CreatedAtUtc = DateTime.UtcNow
            },
              new BookVerseUserEntity
            {
            Id = 3,
            FirstName = "user",
            LastName = "user",
            Email = "customer@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager=false,
            IsEmployee=false,
            IsEnabled = true,
            IsDeleted=false,
            TwoFactorEnabled=false,
            AddressId = 3,
            CreatedAtUtc = DateTime.UtcNow
            },
                new BookVerseUserEntity
            {
            Id = 4,
            FirstName = "employee",
            LastName = "employee",
            Email = "employee@bookverse.com",
            PasswordHash = hasher.HashPassword(null!, "string"),
            IsAdmin = false,
            IsManager = false,
            IsEmployee = true,
            IsEnabled = true,
            IsDeleted = false,
            TwoFactorEnabled=false,
            AddressId = 1,
            CreatedAtUtc = DateTime.UtcNow
            },
        });

    }

    private static void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category{
               Id = 1,
               Name="Roman",
               IsEnabled = true,
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Category{
               Id = 2,
               Name="Poezija",
               IsEnabled = true,
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
             new Category{
               Id = 3,
               Name="Drama",
               IsEnabled = true,
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Category{
               Id = 4,
               Name="Naučna fantastika",
               IsEnabled = true,
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
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
               Country="Bosna i Hercegovina",
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Address{
               Id = 2,
               Line1="Vrbanja 1",
               City="Sarajevo",
               Country="Bosna i Hercegovina",
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
             new Address{
               Id = 3,
               Line1 = "Meše Selimovića 8",
               City ="Jablanica",
               Country = "Bosna i Hercegovina",
               IsDeleted = false,
               CreatedAtUtc = DateTime.UtcNow
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
                StoreName="BookVerse M-1",
                AddressId=1,
                Phone = "123-456-780",
                Email = "pj-m1@bookverse.ba",
                OpeningHours = "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00"
            },
            new Store
            {
                Id = 2,
                StoreName="BookVerse S-1",
                AddressId=2,
                Phone = "123-567-780",
                Email = "pj-s1@bookverse.ba",
                OpeningHours = "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00"
            },
            new Store
            {
                Id = 3,
                StoreName="BookVerse J-1",
                AddressId=3,
                Phone = "123-534-780",
                Email = "pj-j1@bookverse.ba",
                OpeningHours = "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00"
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
               Biography = "Meša Selimović bio je jedan od najvećih bosanskohercegovačkih i jugoslovenskih pisaca 20. stoljeća, rođen 1910. godine u Tuzli. Završio je Filozofski fakultet u Beogradu, a veći dio života proveo je radeći kao profesor, urednik i kulturni radnik u Sarajevu. Njegovo stvaralaštvo obilježeno je dubokim filozofskim promišljanjima o slobodi, vlasti i smislu ljudskog postojanja. Svjetsku slavu stekao je romanom \"Derviš i smrt\", koji se smatra jednim od najznačajnijih djela napisanim na ovim prostorima. Drugi njegov veliki roman, \"Tvrđava\", nastavlja istraživati psihološku dubinu čovjeka u sukobu s društvom i samim sobom. Njegov stil pisanja je izuzetno misaon, prožet mudrošću i elegancijom koja i danas fascinira čitaoce širom svijeta. Dobitnik je brojnih nagrada, uključujući Njegoševu nagradu i nagradu AVNOJ-a. Umro je 1982. godine u Beogradu, ostavivši iza sebe neprolazna književna remek-djela.",
               Country="Bosna i Hercegovina",
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Author{
               Id = 2,
               FirstName = "Ivo",
               LastName = "Andrić",
               Biography = "Ivo Andrić bio je jedini književnik s prostora bivše Jugoslavije koji je dobio Nobelovu nagradu za književnost 1961. godine. Rođen je 1892. godine u Docu kod Travnika, a djetinjstvo je proveo u Višegradu, što je snažno oblikovalo njegov književni svijet. Školovao se u Sarajevu, Zagrebu, Beču i Krakovu, dok je doktorat stekao u Grazu. Osim književnošću, uspješno se bavio diplomacijom, služeći u velikim evropskim centrima poput Rima, Bukurešta i Berlina. Njegova najpoznatija djela, poput romana \"Na Drini ćuprija\" i \"Travnička hronika\", bave se sudbinom Bosne kao raskrsnice kultura i religija. Andrićev stil odlikuje se dubokom psihološkom analizom likova i smirenim, epskim pripovijedanjem. Svojim radom povezao je lokalne teme s univerzalnim ljudskim dilemama, stekavši svjetsku slavu. Umro je 1975. godine u Beogradu, ostavivši iza sebe neprocjenjivo kulturno naslijeđe.",
               Country="Bosna i Hercegovina",
               IsDeleted=false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Author{
               Id = 3,
               FirstName = "Branko",
               LastName = "Ćopić",
               Biography = "Branko Ćopić bio je jedan od najomiljenijih i najčitanijih pisaca s ovih prostora, rođen 1915. godine u Hašanima. Školovao se u Bosna i Hercegovinaaću, Banjoj Luci i Sarajevu, dok je Filozofski fakultet završio u Beogradu. Njegov književni rad obilježen je jedinstvenim spojem vedrog humora i duboke tuge za djetinjstvom i zavičajem. Tokom Drugog svjetskog rata bio je borac i ratni dopisnik, što je snažno utjecalo na teme njegovih najpoznatijih djela. Stvorio je nezaboravne likove poput Nikoletine Bursaća i dječaka iz \"Orlova rano lete\", koji su postali dio djetinjstva brojnih generacija. Bio je plodan autor romana, pripovijedaka i poezije, podjednako cijenjen među djecom i odraslima. Za svoj rad dobio je brojna priznanja, uključujući Njegoševu nagradu, te je postao član Srpske akademije nauka i umetnosti. Tragično je okončao život 1984. godine u Beogradu, ostavivši iza sebe neizbrisiv trag u jugoslavenskoj književnosti.",
               Country = "Bosna i Hercegovina",
               IsDeleted = false,
               CreatedAtUtc = DateTime.UtcNow
            },
            new Author{
               Id = 4,
               FirstName = "Nura",
               LastName = "Bazdulj-Hubijar",
               Biography = "Nura Bazdulj-Hubijar jedna je od najčitanijih savremenih bosanskohercegovačkih književnica. Rođena je 1951. godine u Mrđenovićima kod Foče, a veći dio života i radnog vijeka provela je u Travniku. Po zanimanju je ljekarka, specijalista medicinske mikrobiologije, što je profesija kojom se bavila do penzionisanja. Njen književni opus je izuzetno bogat i obuhvata romane, pjesme, drame te književnost za djecu. Dobitnica je brojnih prestižnih priznanja, uključujući nagrade za najbolje romane i radio-drame. Njeni tekstovi su prepoznatljivi po emotivnosti i neposrednosti, zbog čega su omiljeni među različitim generacijama čitalaca. Neka od njenih najpoznatijih djela su \"Ljubav je sihirbaz babo\", \"Ruža\" i \"Kad je bio juli\". Danas uživa status kultne autorice čija su djela uvrštena u školsku lektiru.\r\n",
               Country = "Bosna i Hercegovina",
               IsDeleted = false,
               CreatedAtUtc = DateTime.UtcNow
            },
              new Author{
               Id = 5,
               FirstName = "Artur",
               LastName = "Klark",
               Biography = "Sir Arthur C. Clarke bio je kultni britanski pisac znanstvene fantastike, izumitelj i podvodni istraživač. Svjetsku slavu stekao je scenarijem za film \"2001.: Odiseja u svemiru\", koji je razvio zajedno s redateljem Stanleyjem Kubrickom. Njegov književni opus, u kojem se ističu romani poput \"Kraj djetinjstva\" i \"Susret s Ramom\", spaja strogu znanstvenu točnost s filozofskim temama. Osim po književnosti, poznat je po vizionarskom radu na konceptu geostacionarnih satelita koji su omogućili modernu telekomunikaciju. Veći dio života proveo je na Šri Lanki, gdje se aktivno bavio ronjenjem i promoviranjem znanosti. Autor je čuvenih \"Clarkeovih zakona\", od kojih treći kaže da se svaka dovoljno napredna tehnologija ne razlikuje od magije. Tijekom života primio je brojna priznanja, uključujući titulu viteza i nominaciju za Nobelovu nagradu za mir. Umro je 2008. godine, ostavivši neizbrisiv trag na modernu znanost i popularnu kulturu.",
               Country = "Ujedinjeno Kraljvstvo",
               IsDeleted = false,
               CreatedAtUtc = DateTime.UtcNow
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
                LanguageId = 1,
                Description = "Roman koji se bavi pitanjima vjere, duhovnosti i smrti, kroz priču o Dervišu koji pokušava da pronađe smisao u životu i smrti. Kroz likove i filozofske dijaloge, autor istražuje moralne dileme i ljudsku patnju.",
                PageCount = 320,
                QuantityInStockForOnlineOrders = 200,
                ImageUrl = BookImagesBaseUrl + "dervis_i_smrt.jpg",
                PublishedDate = new DateTime(1966, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
            },
            new Books{
                Id = 2,
                ISBN = "978-86-07-00752-2",
                Title = "Na Drini ćuprija",
                PublisherId = 2,
                BookFormatId = 2,
                Price = 34.99m,
                LanguageId = 1,
                Description = "Roman koji opisuje istoriju jednog grada i njegove mostove, kroz sudbine ljudi koji su živeli u različitim vremenima. Andrić istražuje ljudsku sudbinu, istoriju i političke i kulturne promene kroz život mosta na Drini.",
                PageCount = 412,
                QuantityInStockForOnlineOrders = 150,
                ImageUrl = BookImagesBaseUrl + "na_drini_cuprija.jpg",
                PublishedDate = new DateTime(1945, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
            },
            new Books{
                Id = 3,
                ISBN = "978-86-03-00942-5",
                Title = "Bašta, pepeo",
                PublisherId = 3,
                BookFormatId = 2,
                Price = 24.99m,
                LanguageId = 1,
                Description = "Roman koji kroz priču o životu jednog mladog čoveka istražuje teme ljubavi, smrti, i socijalnih promjena. Ćopić se bavi i univerzalnim pitanjima identiteta i postojanja u svetu koji se menja.",
                PageCount = 280,
                QuantityInStockForOnlineOrders = 120,
                ImageUrl = BookImagesBaseUrl + "basta_pepeo.jpg",
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow
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
            Description = "Domaća kurirska služba sa brzom dostavom na području cijele Bosna i Hercegovina (1–2 radna dana). Pogodno za pakete i dokumente.",
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
            Description = "Kurirska služba sa dostavom na području cijele Bosna i Hercegovina u roku 24–48h, uz mogućnost plaćanja pouzećem.",
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
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-5",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=1,
            QuantityInStock=90,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-12",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=1,
            QuantityInStock=40,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-15",
            IsDeleted=false,
        },
         new StoreInventory{
            StoreId=1,
            BookId=2,
            QuantityInStock=200,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-21",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=2,
            QuantityInStock=210,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-22",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=2,
            QuantityInStock=240,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-23",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=1,
            BookId=3,
            QuantityInStock=70,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-31",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=2,
            BookId=3,
            QuantityInStock=90,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-32",
            IsDeleted=false,
        },
        new StoreInventory{
            StoreId=3,
            BookId=3,
            QuantityInStock=80,
            LastRestocked=DateTime.UtcNow,
            ReorderTreshold=5,
            Location="A-33",
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
            Name = "Popust dobrodošlice",
            Description= "Popust dobrodošlice, -10 KM",
            AmountOff = 10,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(365),
            PromotionCode = "WELCOME10A"
        },
        new Coupons{
            Id = 2,
            Name = "Ljetni popust",
            Description = "Ljetni popust, -20%",
            PercentOff = 20,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow.AddDays(365),
            PromotionCode = "WELCOME20P"
        },
      });
    }

    private static void SeedMoreAddresses(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().HasData(new List<Address>
        {
            new Address { Id = 4, Line1 = "Šetalište 1. maja 5", City = "Banja Luka", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Address { Id = 5, Line1 = "Ferhadija 22", City = "Sarajevo", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Address { Id = 6, Line1 = "Bulevar Kralja Tvrtka 7", City = "Zenica", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Address { Id = 7, Line1 = "Franje Leđića 12", City = "Tuzla", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Address { Id = 8, Line1 = "Bijeljinska cesta 3", City = "Brčko", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMoreUsers(ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<BookVerseUserEntity>();
        modelBuilder.Entity<BookVerseUserEntity>().HasData(new List<BookVerseUserEntity>
        {
            new BookVerseUserEntity { Id = 5, FirstName = "Amer", LastName = "Hadžić", Email = "amer.hadzic@gmail.com", PasswordHash = hasher.HashPassword(null!, "string"), IsAdmin = false, IsManager = false, IsEmployee = false, IsEnabled = true, IsDeleted = false, AddressId = 4, TwoFactorEnabled = false, CreatedAtUtc = DateTime.UtcNow },
            new BookVerseUserEntity { Id = 6, FirstName = "Lejla", LastName = "Begović", Email = "lejla.begovic@gmail.com", PasswordHash = hasher.HashPassword(null!, "string"), IsAdmin = false, IsManager = false, IsEmployee = false, IsEnabled = true, IsDeleted = false, AddressId = 5, TwoFactorEnabled = false, CreatedAtUtc = DateTime.UtcNow },
            new BookVerseUserEntity { Id = 7, FirstName = "Mirza", LastName = "Kovačević", Email = "mirza.kovacevic@gmail.com", PasswordHash = hasher.HashPassword(null!, "string"), IsAdmin = false, IsManager = false, IsEmployee = false, IsEnabled = true, IsDeleted = false, AddressId = 6, TwoFactorEnabled = false, CreatedAtUtc = DateTime.UtcNow },
            new BookVerseUserEntity { Id = 8, FirstName = "Amira", LastName = "Šehić", Email = "amira.sehic@gmail.com", PasswordHash = hasher.HashPassword(null!, "string"), IsAdmin = false, IsManager = false, IsEmployee = false, IsEnabled = true, IsDeleted = false, AddressId = 7, TwoFactorEnabled = false, CreatedAtUtc = DateTime.UtcNow },
            new BookVerseUserEntity { Id = 9, FirstName = "Damir", LastName = "Muratović", Email = "damir.muratovic@gmail.com", PasswordHash = hasher.HashPassword(null!, "string"), IsAdmin = false, IsManager = false, IsEmployee = false, IsEnabled = true, IsDeleted = false, AddressId = 8, TwoFactorEnabled = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMoreCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category { Id = 5, Name = "Historijski roman", IsEnabled = true, IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Category { Id = 6, Name = "Priča za djecu", IsEnabled = true, IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Category { Id = 7, Name = "Memoari", IsEnabled = true, IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Category { Id = 8, Name = "Putopis", IsEnabled = true, IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Category { Id = 9, Name = "Pripovijetke", IsEnabled = true, IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMoreAuthors(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(new List<Author>
        {
            new Author { Id = 6, FirstName = "Abdulah", LastName = "Sidran", Biography = "Bosanskohercegovački pisac, poeta i scenarist.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Author { Id = 7, FirstName = "Derviš", LastName = "Sušić", Biography = "Bosanskohercegovački pisac i novinar, poznat po partizanskoj tematici.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Author { Id = 8, FirstName = "Nedžad", LastName = "Ibrišimović", Biography = "Bosanskohercegovački pisac i akademik, autor brojnih romana i priča.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Author { Id = 9, FirstName = "Semezdin", LastName = "Mehmedinović", Biography = "Bosanskohercegovački pisac i pjesnik, poznat po zbirci Sarajevo Blues.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
             new Author { Id = 10, FirstName = "Aleksa", LastName = "Šantić", Biography = "Aleksa Šantić je rođen 1868. godine u Mostaru, gdje je proveo najveći dio svog života i stvaralaštva. Bio je jedan od najvažnijih predstavnika hercegovačke i južnoslavenske lirike, poznat po pjesmama o ljubavi, zavičaju i socijalnoj nepravdi. Umro je 1924. godine u Mostaru, ostavivši iza sebe bogat poetski opus koji je postao dio klasične književnosti ovih prostora.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
             new Author { Id = 11, FirstName = "Amer", LastName = "Kapetanović", Biography = "Amer Kapetanović je savremeni bosanskohercegovački autor i javni djelatnik poznat po svom radu u oblasti književnosti, diplomatije i društvenih nauka. Kroz svoj profesionalni i književni angažman bavi se temama kulture, identiteta i savremenih društvenih tokova u Bosni i Hercegovini i regiji. Njegov rad doprinosi promociji bosanskohercegovačke kulture i jačanju međunarodne saradnje.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
             new Author { Id = 12, FirstName = "Senad", LastName = "Švraka", Biography = "Senad Švraka je bosanskohercegovački autor i istraživač koji se bavi pisanjem i stručnim radovima iz oblasti kulture i društvenih nauka. Njegov rad često obuhvata teme vezane za savremena društvena pitanja, obrazovanje i razvoj lokalne zajednice. Kroz svoje djelovanje doprinosi promociji znanja i kulturnog stvaralaštva u Bosni i Hercegovini.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
             new Author { Id = 13, FirstName = "Henry", LastName = "James", Biography = "Henry James je bio američki pisac i kritičar rođen 1843. godine u New Yorku, koji je veći dio života proveo između SAD-a i Evrope, posebno u Engleskoj. Smatra se jednim od ključnih autora realizma i preteča modernističke književnosti, poznat po psihološkoj dubini svojih likova i složenom stilu pripovijedanja. Umro je 1916. godine u Londonu, ostavivši iza sebe značajan književni opus koji uključuje romane poput Portret jedne dame i Okretaj zavrtnja.", Country = "Sjedinjene Američke Države", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
              new Author { Id = 14, FirstName = "Isak", LastName = "Samokovlija", Biography = "Isak Samokovlija bio je bosanskohercegovački književnik i ljekar jevrejskog porijekla. Rođen je 1889. godine u Goraždu, a u svojim djelima često je opisivao život običnih ljudi u Bosni, posebno u seoskim i malim gradskim sredinama. Smatra se jednim od najvažnijih predstavnika bosanskohercegovačke književnosti 20. stoljeća.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
              new Author { Id = 15, FirstName = "Hamza", LastName = "Humo", Biography = "Hamza Humo bio je bosanskohercegovački književnik, pjesnik i prozni pisac. Rođen je 1895. godine u Mostaru, a bio je jedan od istaknutih predstavnika bošnjačke moderne književnosti. Njegova djela često su obilježena lirskim izrazom i motivima Hercegovine, prirode i ljubavi.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
              new Author { Id = 16, FirstName = "Bisera", LastName = "Alikadić", Biography = "Biser Alichadić (češće: Biser Alikadić) je bosanskohercegovačka književnica i pjesnikinja. Rođena je 1939. godine u Mostaru, a u književnosti je poznata po emotivnoj i introspektivnoj poeziji koja često obrađuje teme ljubavi, intime i ženske perspektive. Smatra se jednom od značajnih savremenih autorica u bosanskohercegovačkoj književnosti.", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
              new Author { Id = 17, FirstName = "Henry-Beyle", LastName = "Stendhal", Biography = "Marie-Henri Beyle, poznatiji kao Stendhal, bio je jedan od najznačajnijih francuskih romanopisaca 19. vijeka i začetnik književnog realizma. Tokom života služio je u Napoleonovoj vojsci i proputovao veliki dio Evrope, a duga razdoblja boravka u Italiji duboko su utjecala na njegovu strast prema umjetnosti i historiji. Njegova najpoznatija djela, Crveno i crno te Parmski kartuzijanski samostan, ističu se po dubokoj psihološkoj analizi likova i kritici društvenog poretka tog vremena.", Country = "Francuska", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
              new Author { Id = 18, FirstName = "Fjodor Mihajlovič", LastName = "Dostojevski", Biography = "Fjodor Mihajlovič Dostojevski bio je jedan od najvećih ruskih pisaca i mislilaca, čija su djela duboko istraživala ljudsku psihu, moral i religiju. Zbog učešća u revolucionarnom krugu bio je osuđen na smrt, ali mu je kazna u zadnji čas preinačena na višegodišnji prisilni rad u Sibiru. Njegovi romani, poput Zločina i kazne i Braće Karamazovih, postali su temelji moderne svjetske književnosti i egzistencijalizma.\r\n", Country = "Rusija", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMorePublishers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>().HasData(new List<Publisher>
        {
            new Publisher { Id = 5, Name = "Connectum", City = "Sarajevo", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Publisher { Id = 6, Name = "Vrijeme Zenica", City = "Zenica", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Publisher { Id = 7, Name = "Nova knjiga", City = "Podgorica", Country = "Crna Gora", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Publisher { Id = 8, Name = "Bosanska riječ Sarajevo", City = "Sarajevo", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new Publisher { Id = 9, Name = "Sarajevo Publishing", City = "Sarajevo", Country = "Bosna i Hercegovina", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMoreBooks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>().HasData(new List<Books>
        {
            new Books
            {
                Id = 4,
                ISBN = "978-86-521-0969-2",
                Title = "Novele o mutnim vremenima",
                PublisherId = 1,
                BookFormatId = 1,
                Price = 19.5m,
                LanguageId = 4,
                Description = "U Novele o mutnim vremenima ušle su duže pripovjetke našeg nobelovca koje, na ovaj ili onaj način, govore o nesigurnim i nemirnim vremenima kada je ugrožen čovjekov život ili narušeno njegovo dostojanstvo. Povijesti o zloglasnoj carigradskoj tamnici (Prokleta avlija), o obijesti turskih silnika u Bosni (Priča o vezirovom slonu), o progonu Jevreja (Bife Titanik) i herojstvu malog čovjeka u II svjetskom ratu (Zeko) u središtu su Andrićevog interesovanja za pojedinačne sudbine ljudi koji su živjeli na strašnim mjestima, gledali i na svojoj koži osjećali opšte stradanje u nesrećnim okolnostima i u njima kovali i sopstvenu sudbinu. Te novele, svaka za sebe, prava su remek-djela ovog žanra, smještena u Carigrad, Travnik, Sarajevo i Beograd - gradove obremenjene istorijom i nesrećama koje su ih često pohodile.",
                PageCount = 356,
                QuantityInStockForOnlineOrders = 100,
                PublishedDate = new DateTime(2012, 11, 30),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "novele_o_mutnim_vremenima.jpg"
            },
            new Books
            {
                Id = 5,
                ISBN = "978-86-01-00512-3",
                Title = "Pobune",
                PublisherId = 2,
                BookFormatId = 2,
                Price = 22.99m,
                LanguageId = 1,
                Description = "Roman Derviša Sušića koji istražuje teme otpora, slobode i identiteta kroz sudbine likova u turbulentnim historijskim vremenima Bosne.",
                PageCount = 248,
                QuantityInStockForOnlineOrders = 80,
                PublishedDate = new DateTime(1960, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "pobune_susic_dervis.jpg"
            },
            new Books
            {
                Id = 6,
                ISBN = "978-9958-21-033-7",
                Title = "Ugursuz",
                PublisherId = 4,
                BookFormatId = 2,
                Price = 26.99m,
                LanguageId = 1,
                Description = "Roman Nedžada Ibrišimovića koji kroz humor i satiru portretiše bosansku svakodnevicu i karaktere, sa bogatim jezičkim izrazom.",
                PageCount = 304,
                QuantityInStockForOnlineOrders = 90,
                PublishedDate = new DateTime(1997, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "ugursuz_ibrisimovic.jpg"
            },
            new Books
            {
                Id = 7,
                ISBN = "978-86-7448-027-5",
                Title = "Sarajevo Blues",
                PublisherId = 1,
                BookFormatId = 1,
                Price = 21.99m,
                LanguageId = 1,
                Description = "Zbirka poezije i proza Semeždina Mehmedinivića nastala za vrijeme opsade Sarajeva, poetski svjedok o ratu, gubitku i opstanku.",
                PageCount = 168,
                QuantityInStockForOnlineOrders = 75,
                PublishedDate = new DateTime(1992, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "sarajevo_blues.jpg"
            },
            new Books
            {
                Id = 8,
                ISBN = "978-86-03-01234-8",
                Title = "Prokleta avlija",
                PublisherId = 3,
                BookFormatId = 2,
                Price = 27.99m,
                LanguageId = 1,
                Description = "Novela Ive Andrića smještena u istanbulski zatvor u kojoj se isprepliću sudbine zatvorenika i istražuju teme slobode, zla i ljudske prirode.",
                PageCount = 152,
                QuantityInStockForOnlineOrders = 130,
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "prokleta_avlija_andric.jpg"
            },
             new Books
            {
                Id = 9,
                ISBN = "978-86-10-00984-2",
                Title = "Ostrvo",
                PublisherId = 3,
                BookFormatId = 2,
                Price = 17m,
                LanguageId = 1,
                Description = "Roman Ostrvo autora Meša Selimović prati stariji bračni par koji se povlači na usamljeno ostrvo tražeći mir i smisao života. Kroz njihovu izolaciju i unutrašnje dileme, djelo istražuje teme prolaznosti, straha od smrti i suočavanja sa sopstvenim životom.",
                PageCount = 198,
                QuantityInStockForOnlineOrders = 130,
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "d0818_ostrvo.jpg"
            },
              new Books
            {
                Id = 10,
                ISBN = "978-9958-731-40-2",
                Title = "Kad više ne bude sutra",
                PublisherId = 1,
                BookFormatId = 2,
                Price = 20m,
                LanguageId = 1,
                Description = "Roman Kad više ne bude sutra autorice Nura Bazdulj-Hubijar bavi se teškim životnim situacijama, gubicima i emotivnim borbama kroz koje prolaze njegovi likovi. Kroz snažne i potresne priče, djelo istražuje teme ljubavi, tuge i suočavanja s neizvjesnom budućnošću.",
                PageCount = 198,
                QuantityInStockForOnlineOrders = 210,
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "kad_vise_ne_bude_sutra.jpg"
            },
               new Books
            {
                Id = 11,
                ISBN = "978-86-300-0208-3",
                Title = "Rama II",
                PublisherId = 4,
                BookFormatId = 2,
                Price = 27.90m,
                LanguageId = 1,
                Description = "Nastavak legendarnog SF romana koji je osvojio nagrade Hjugo, Nebjula, Lokus, Džon V. Kembel i Britansku nagradu za naučnu fantastiku.\r\nGodine 2130. vanzemaljski brod Rama proleteo je kroz Sunčev sistem. Taj prvi dokaz postojanja vanzemaljskih civilizacija predočio je ljudskom rodu mnoga zapanjujuća otkrića, ali većina njegovih tajni ostala je nerazrešena.\r\nSedamdeset godina kasnije, novi svemirski brod Ramanaca vraća se u Sunčev sistem. Ovog puta, Zemlja je spremna za kontakt. Posada najpametnijih i najsposobnijih ljudi planete sprema se za susret s vanzemaljskim brodom.",
                PageCount = 477,
                QuantityInStockForOnlineOrders = 180,
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "rama_2_klark.jpg"
            },
                 new Books
            {
                Id = 12,
                ISBN = "978-99-581-8173-3",
                Title = "Pjesme",
                PublisherId = 6,
                BookFormatId = 2,
                Price = 19m,
                LanguageId = 1,
                Description = "Zbirka pjesama Alekse Šantića donosi emotivnu i lirsku poeziju prožetu motivima ljubavi, rodoljublja i socijalne pravde. Njegovi stihovi, jednostavni ali snažni, odražavaju duh vremena i duboku povezanost s narodom i zavičajem.\r\n",
                PageCount = 103,
                QuantityInStockForOnlineOrders = 60,
                PublishedDate = new DateTime(1954, 1, 1),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "pjesme_santic.jpg"
            },
                  new Books
            {
                Id = 13,
                ISBN = "978-9926-585-18-1",
                Title = "Fond solidarnosti",
                PublisherId = 6,
                BookFormatId = 2,
                Price = 25m,
                LanguageId = 1,
                Description = "Prozni zapis jednog vremena viđen iznutra, bez namjere da bude literatura, ali s literarnom disciplinom.Fond solidarnosti nije roman o institucijama, niti o politici vremena u kojem je nastao.To je prozni zapis jednog davnog života - perioda kada se ulazilo u svijet odraslih prerano, bez jezika, bez distance i bez prava na pogrešku.Knjiga prati iskustvo mladog čovjeka koji se kreće kroz strukture koje ne razumije do kraja, ali ih prihvata kao jedinu ponuđenu realnost. Solidarnost ovdje nije ideja ni parola, nego svakodnevna praksa, često nespretna, često pogrešno shvaćena.Pisano iz današnje distance, ali bez naknadne pameti, Fond solidarnosti ostaje svjedočanstvo o formativnom vremenu jedne generacije - o iluzijama koje su bile nužne, kompromisima koji su se tek kasnije prepoznali i životu koji je morao biti proživljen da bi se mogao napustiti.",
                PageCount = 175,
                QuantityInStockForOnlineOrders = 100,
                PublishedDate = new DateTime(2025, 9, 8),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "fond_solidarnosti.jpg"
            },
                    new Books
            {
                Id = 14,
                ISBN = "978-9958-31-303-5",
                Title = "Alea",
                PublisherId = 4,
                BookFormatId = 2,
                Price = 15m,
                LanguageId = 1,
                Description = "Za kormilom devet metarske jedrilice ALEA, tuzlanski moreplovac Senad Švraka je prokrstario Mediteran, Crveno more i Indijski okean, kao prvi Bosanac kome je to pošlo za rukom. Od prvih nesigurnih izlazaka na more, savladavanja osnova jedrenja i navigacije, do borbe sa nevremenom na Jadranu, opasnog Crvenog mora, nadmudrivanja sa piratima u Adenskom zalivu i naporne prekookeanske plovidbe koja je brod i kapetana odvela čak do Tajlanda, Senad zanimljivim i pristupačnim stilom vodi čitaoca u egzotični svijet dalekih mora. ALEA je vrhunsko štivo u kojem će svaki zaljubljenik u more i avanture, ali i svaki ljubitelj dobre priče, istinski uživati.",
                PageCount = 339,
                QuantityInStockForOnlineOrders = 134,
                PublishedDate = new DateTime(2017, 4, 6),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "alea_senad_svraka.jpg"
            },
                 new Books
            {
                Id = 15,
                ISBN = "978-8663-69-418-7",
                Title = "Bostonci",
                PublisherId = 7,
                BookFormatId = 2,
                Price = 33m,
                LanguageId = 4,
                Description = "Roman Bostonci Henrija Džejmsa objavljen je kao zasebna knjiga 1886. godine, pošto je prethodno bio objavljivan u periodici.\r\nUpoznajemo komplikovani svijet Amerike nakon građanskog rata, sukobljen između tradicionalnih vrijednosti i progresivnih ideja kroz perspektive tri junaka: Bejzila Rensona (konzervativni južnjak), Oliv Čenslor (njegova feministički orijentisana rođaka), Verena Terent (harizmatična vatrena govornica, zarobljena između njihovih suprotstavljenih uticaja).",
                PageCount = 430,
                QuantityInStockForOnlineOrders = 120,
                PublishedDate = new DateTime(2024, 7, 10),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "bostonci_dzejms.jpg"
            },
                new Books
            {
                Id = 16,
                ISBN = "978-9958-18-165-8",
                Title = "Nosač Samuel",
                PublisherId = 6,
                BookFormatId = 2,
                Price = 25m,
                LanguageId = 1,
                Description = "Ovo je zbirka ponajboljih Samokovlijinih priča, sažet izbor iz njegova djela koje je kao svijetao i neprolazan trag iza sebe ostavio ovaj pisac. Maestralne Samokovlijine pripovijetke tematski su redovno smještene u svijet bosanskih Jevreja, no njihova je umjetnička vrijednost univerzalna. Po zanimanju liječnik, s dugogodišnjom terenskom praksom, Samokovlija je odlično poznavao mali svijet svojega vremena i u Sarajevu i u Bosni. O tim ljudima, o njihovoj svakodnevnici pisao je s dubokom empatijom, ali i sa smislom za siguran i precizan opis likova, ambijenata, životnih formi i običaja.",
                PageCount = 318,
                QuantityInStockForOnlineOrders = 110,
                PublishedDate = new DateTime(2025, 7, 10),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "nosac_samuel_isak_lektira.jpg"
            },
             new Books
            {
                Id = 17,
                ISBN = "978-9958-26-206-7",
                Title = "Grozdanin kikot",
                PublisherId = 8,
                BookFormatId = 2,
                Price = 15m,
                LanguageId = 1,
                Description = "Grozdanin kikot je roman (pjesma, poema, skaska…) ili čak zapis o starosjedilačkom idealu prošlosti u kome je Humo pokušao da spoji i sažme idejni fantazmagorični impuls nastalim na impresivnoj unutarnjoj osnovi sa materijalističkim, tjelesnim porivom i doživljajem jasnog dodira života i prirode.",
                PageCount = 105,
                QuantityInStockForOnlineOrders = 145,
                PublishedDate = new DateTime(2021,4 , 13),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "grozdanin_kikot_humo.jpg"
            },
                new Books
            {
                Id = 18,
                ISBN = "978-9958-21-095-9",
                Title = "Knjiga vremena",
                PublisherId = 9,
                BookFormatId = 2,
                Price = 11.70m,
                LanguageId = 1,
                Description = "Njen književni izraz zasniva se na konceptima moderne poezije i ne robuje klasičnoj bosanskoj književnoj tradiciji. Stih je uglavnom slobodan, a rima gotovo nezastupljena, tek u svrhu podešavanja cjelokupne melodije pjesme. Teme o kojima Bisera Alikadić najčešće piše su žena i samoća u velikom gradu. Njena poezija obiluje posebnim urbanim ugođajem, u kojima se skriva i određena kriza identiteta modernog društva kod nas s kraja sedamdesetih godina.",
                PageCount = 136,
                QuantityInStockForOnlineOrders = 80,
                PublishedDate = new DateTime(1999, 5 , 18),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "knjiga_vremena.jpg"
            },
               new Books
            {
                Id = 19,
                ISBN = "978-9958-731-35-8",
                Title = "Plavi kombi",
                PublisherId = 9,
                BookFormatId = 2,
                Price = 20m,
                LanguageId = 1,
                Description = "Nura Bazdulj-Hubijar i ovaj put je uspjela napisati izuzetno interesantan roman sa neočekivanim i naglim zaokretima koji čitaoca prosto okupiraju i tjeraju da knjigu ne pušta iz ruku dok ne sazna šta će se dalje dogoditi. Ti brzi i neočekivani novi momenti u pripovijednom toku, a koji su često temeljeni na nesporazumu, daju tekstu izuzetnu živost i potvrđuju činjenicu o kompliciranosti života i njegovoj nepredvidljivosti.",
                PageCount = 175,
                QuantityInStockForOnlineOrders = 90,
                PublishedDate = new DateTime(2022, 6 , 19),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "plavi_kombi_nura_bazdulj.jpg"
            },
                 new Books
            {
                Id = 20,
                ISBN = "978-86-521-5486-9",
                Title = "Crveno i crno",
                PublisherId = 3,
                BookFormatId = 2,
                Price = 27.50m,
                LanguageId = 4,
                Description = "Zgodan, inteligentan i ambiciozan, sin nepismenog strugara Žilijen Sorel odlučan je da se uzdigne iznad svojih skromnih provincijskih korijena. Razapet između dva moćna svijeta, crkve koju simboliše crno, i vojske koju simboliše crveno, ubrzo shvata da se uspjeh može postići samo prihvatanjem suptilnog koda po kojem društvo funkcioniše.\r\n",
                PageCount = 520,
                QuantityInStockForOnlineOrders = 150,
                PublishedDate = new DateTime(2025, 8 , 21),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "stendal_crveno_i_crno.jpg"
            },
               new Books
            {
                Id = 21,
                ISBN = "978-86-6369-064-6",
                Title = "Zločin i kazna",
                PublisherId = 7,
                BookFormatId = 2,
                Price = 36m,
                LanguageId = 4,
                Description = "Roman Zločin i kazna izgrađen je na fabuli koju poznajemo iz kriminalističkog štiva, s tom bitnom razlikom što ovdje već na početku djela saznajemo ko je ubojica, pa i šta ga je sve navelo na zločin.Zločin i kazna nije samo roman o pojedinačnom ljudskom karakteru ni samo psihološki roman ni roman o socijalno motiviranom karakteru već je sve to ali i mnogo više od toga.\r\n",
                PageCount = 573,
                QuantityInStockForOnlineOrders = 135,
                PublishedDate = new DateTime(2015, 9 , 14),
                IsDeleted = false,
                CreatedAtUtc = DateTime.UtcNow,
                ImageUrl = BookImagesBaseUrl + "zlocin_i_kazna_nova_knjiga.jpg"
            },
        });
    }

    private static void SeedChangeTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChangeTypes>().HasData(new List<ChangeTypes>
        {
            new ChangeTypes { Id = 1, Name = "Ulaz", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
            new ChangeTypes { Id = 2, Name = "Izlaz", IsDeleted = false, CreatedAtUtc = DateTime.UtcNow },
        });
    }

    private static void SeedMoreInventory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoreInventory>().HasData(new List<StoreInventory>
        {
            new StoreInventory { StoreId = 1, BookId = 4, QuantityInStock = 30, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-41", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 4, QuantityInStock = 25, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-42", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 4, QuantityInStock = 20, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-43", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 5, QuantityInStock = 40, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-51", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 5, QuantityInStock = 35, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-52", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 5, QuantityInStock = 30, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-53", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 6, QuantityInStock = 35, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-61", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 6, QuantityInStock = 45, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-62", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 6, QuantityInStock = 28, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-63", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 7, QuantityInStock = 50, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-71", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 7, QuantityInStock = 40, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-72", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 7, QuantityInStock = 35, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-73", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 8, QuantityInStock = 60, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-81", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 8, QuantityInStock = 55, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-82", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 8, QuantityInStock = 45, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "A-83", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 9, QuantityInStock = 45, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-91", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 9, QuantityInStock = 38, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-92", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 9, QuantityInStock = 32, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-93", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 10, QuantityInStock = 28, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-101", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 10, QuantityInStock = 33, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-102", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 10, QuantityInStock = 22, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-103", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 11, QuantityInStock = 50, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-111", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 11, QuantityInStock = 42, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-112", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 11, QuantityInStock = 36, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-113", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 12, QuantityInStock = 20, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-121", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 12, QuantityInStock = 18, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-122", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 12, QuantityInStock = 25, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-123", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 13, QuantityInStock = 37, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-131", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 13, QuantityInStock = 29, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-132", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 13, QuantityInStock = 41, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-133", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 14, QuantityInStock = 55, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-141", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 14, QuantityInStock = 48, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-142", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 14, QuantityInStock = 30, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-143", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 15, QuantityInStock = 24, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-151", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 15, QuantityInStock = 19, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-152", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 15, QuantityInStock = 27, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "B-153", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 16, QuantityInStock = 43, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-161", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 16, QuantityInStock = 36, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-162", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 16, QuantityInStock = 31, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-163", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 17, QuantityInStock = 26, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-171", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 17, QuantityInStock = 34, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-172", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 17, QuantityInStock = 21, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-173", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 18, QuantityInStock = 47, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-181", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 18, QuantityInStock = 39, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-182", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 18, QuantityInStock = 52, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-183", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 19, QuantityInStock = 33, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-191", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 19, QuantityInStock = 28, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-192", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 19, QuantityInStock = 44, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-193", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 20, QuantityInStock = 16, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-201", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 20, QuantityInStock = 23, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-202", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 20, QuantityInStock = 19, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-203", IsDeleted = false },
            new StoreInventory { StoreId = 1, BookId = 21, QuantityInStock = 58, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-211", IsDeleted = false },
            new StoreInventory { StoreId = 2, BookId = 21, QuantityInStock = 46, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-212", IsDeleted = false },
            new StoreInventory { StoreId = 3, BookId = 21, QuantityInStock = 37, LastRestocked = DateTime.UtcNow, ReorderTreshold = 5, Location = "C-213", IsDeleted = false },
        });
    }
}