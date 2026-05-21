using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Format = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChangeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AmountOff = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PercentOff = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PromotionCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinOrderAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaxUses = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Last4Digits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpMonth = table.Column<int>(type: "int", nullable: false),
                    ExpYear = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StripeEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StripeEventId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProcessedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripeEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TokenVersion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorCodeExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TwoFactorFailedAttempts = table.Column<int>(type: "int", nullable: false),
                    TwoFactorLockoutUntilUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetTokenExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    BookFormatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    QuantityInStockForOnlineOrders = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookFormats_BookFormatId",
                        column: x => x.BookFormatId,
                        principalTable: "BookFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingPriceAtTheTime = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    ShipToAddressId = table.Column<int>(type: "int", nullable: false),
                    ShippingMethodId = table.Column<int>(type: "int", nullable: true),
                    PickupStoreId = table.Column<int>(type: "int", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentSummaryId = table.Column<int>(type: "int", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShipToAddressId",
                        column: x => x.ShipToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentSummaries_PaymentSummaryId",
                        column: x => x.PaymentSummaryId,
                        principalTable: "PaymentSummaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingMethods_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalTable: "ShippingMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenHash = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fingerprint = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RevokedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksCategories",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksCategories", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BooksCategories_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ChangeTypeId = table.Column<int>(type: "int", nullable: false),
                    QuantityChanged = table.Column<int>(type: "int", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLog_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLog_ChangeTypes_ChangeTypeId",
                        column: x => x.ChangeTypeId,
                        principalTable: "ChangeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreInventory",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    LastRestocked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReorderTreshold = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInventory", x => new { x.StoreId, x.BookId });
                    table.ForeignKey(
                        name: "FK_StoreInventory_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreInventory_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_WishlistItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SavedForLater = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.CartId, x.BookId });
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderCoupons",
                columns: table => new
                {
                    CouponsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCoupons", x => new { x.CouponsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderCoupons_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCoupons_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtTime = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    isCurrent = table.Column<bool>(type: "bit", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingUpdates_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingUpdates_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShippingUpdates_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RefundDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StripeRefundId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_Refunds_OrderItems_OrderId_BookId",
                        columns: x => new { x.OrderId, x.BookId },
                        principalTable: "OrderItems",
                        principalColumns: new[] { "OrderId", "BookId" });
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "Line1", "Line2", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, "Mostar", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 5, 758, DateTimeKind.Utc).AddTicks(6416), false, "Maršala Tita", null, null },
                    { 2, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 5, 758, DateTimeKind.Utc).AddTicks(6438), false, "Vrbanja 1", null, null },
                    { 3, "Jablanica", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 5, 758, DateTimeKind.Utc).AddTicks(6442), false, "Meše Selimovića 8", null, null },
                    { 4, "Banja Luka", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(4039), false, "Šetalište 1. maja 5", null, null },
                    { 5, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(4043), false, "Ferhadija 22", null, null },
                    { 6, "Zenica", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(4046), false, "Bulevar Kralja Tvrtka 7", null, null },
                    { 7, "Tuzla", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(4049), false, "Franje Leđića 12", null, null },
                    { 8, "Brčko", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(4051), false, "Bijeljinska cesta 3", null, null }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Country", "CreatedAtUtc", "FirstName", "IsDeleted", "LastName", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, "Meša Selimović bio je jedan od najvećih bosanskohercegovačkih i jugoslovenskih pisaca 20. stoljeća, rođen 1910. godine u Tuzli. Završio je Filozofski fakultet u Beogradu, a veći dio života proveo je radeći kao profesor, urednik i kulturni radnik u Sarajevu. Njegovo stvaralaštvo obilježeno je dubokim filozofskim promišljanjima o slobodi, vlasti i smislu ljudskog postojanja. Svjetsku slavu stekao je romanom \"Derviš i smrt\", koji se smatra jednim od najznačajnijih djela napisanim na ovim prostorima. Drugi njegov veliki roman, \"Tvrđava\", nastavlja istraživati psihološku dubinu čovjeka u sukobu s društvom i samim sobom. Njegov stil pisanja je izuzetno misaon, prožet mudrošću i elegancijom koja i danas fascinira čitaoce širom svijeta. Dobitnik je brojnih nagrada, uključujući Njegoševu nagradu i nagradu AVNOJ-a. Umro je 1982. godine u Beogradu, ostavivši iza sebe neprolazna književna remek-djela.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2755), "Meša", false, "Selimović", null },
                    { 2, "Ivo Andrić bio je jedini književnik s prostora bivše Jugoslavije koji je dobio Nobelovu nagradu za književnost 1961. godine. Rođen je 1892. godine u Docu kod Travnika, a djetinjstvo je proveo u Višegradu, što je snažno oblikovalo njegov književni svijet. Školovao se u Sarajevu, Zagrebu, Beču i Krakovu, dok je doktorat stekao u Grazu. Osim književnošću, uspješno se bavio diplomacijom, služeći u velikim evropskim centrima poput Rima, Bukurešta i Berlina. Njegova najpoznatija djela, poput romana \"Na Drini ćuprija\" i \"Travnička hronika\", bave se sudbinom Bosne kao raskrsnice kultura i religija. Andrićev stil odlikuje se dubokom psihološkom analizom likova i smirenim, epskim pripovijedanjem. Svojim radom povezao je lokalne teme s univerzalnim ljudskim dilemama, stekavši svjetsku slavu. Umro je 1975. godine u Beogradu, ostavivši iza sebe neprocjenjivo kulturno naslijeđe.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2760), "Ivo", false, "Andrić", null },
                    { 3, "Branko Ćopić bio je jedan od najomiljenijih i najčitanijih pisaca s ovih prostora, rođen 1915. godine u Hašanima. Školovao se u Bosna i Hercegovinaaću, Banjoj Luci i Sarajevu, dok je Filozofski fakultet završio u Beogradu. Njegov književni rad obilježen je jedinstvenim spojem vedrog humora i duboke tuge za djetinjstvom i zavičajem. Tokom Drugog svjetskog rata bio je borac i ratni dopisnik, što je snažno utjecalo na teme njegovih najpoznatijih djela. Stvorio je nezaboravne likove poput Nikoletine Bursaća i dječaka iz \"Orlova rano lete\", koji su postali dio djetinjstva brojnih generacija. Bio je plodan autor romana, pripovijedaka i poezije, podjednako cijenjen među djecom i odraslima. Za svoj rad dobio je brojna priznanja, uključujući Njegoševu nagradu, te je postao član Srpske akademije nauka i umetnosti. Tragično je okončao život 1984. godine u Beogradu, ostavivši iza sebe neizbrisiv trag u jugoslavenskoj književnosti.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2763), "Branko", false, "Ćopić", null },
                    { 4, "Nura Bazdulj-Hubijar jedna je od najčitanijih savremenih bosanskohercegovačkih književnica. Rođena je 1951. godine u Mrđenovićima kod Foče, a veći dio života i radnog vijeka provela je u Travniku. Po zanimanju je ljekarka, specijalista medicinske mikrobiologije, što je profesija kojom se bavila do penzionisanja. Njen književni opus je izuzetno bogat i obuhvata romane, pjesme, drame te književnost za djecu. Dobitnica je brojnih prestižnih priznanja, uključujući nagrade za najbolje romane i radio-drame. Njeni tekstovi su prepoznatljivi po emotivnosti i neposrednosti, zbog čega su omiljeni među različitim generacijama čitalaca. Neka od njenih najpoznatijih djela su \"Ljubav je sihirbaz babo\", \"Ruža\" i \"Kad je bio juli\". Danas uživa status kultne autorice čija su djela uvrštena u školsku lektiru.\r\n", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2767), "Nura", false, "Bazdulj-Hubijar", null },
                    { 5, "Sir Arthur C. Clarke bio je kultni britanski pisac znanstvene fantastike, izumitelj i podvodni istraživač. Svjetsku slavu stekao je scenarijem za film \"2001.: Odiseja u svemiru\", koji je razvio zajedno s redateljem Stanleyjem Kubrickom. Njegov književni opus, u kojem se ističu romani poput \"Kraj djetinjstva\" i \"Susret s Ramom\", spaja strogu znanstvenu točnost s filozofskim temama. Osim po književnosti, poznat je po vizionarskom radu na konceptu geostacionarnih satelita koji su omogućili modernu telekomunikaciju. Veći dio života proveo je na Šri Lanki, gdje se aktivno bavio ronjenjem i promoviranjem znanosti. Autor je čuvenih \"Clarkeovih zakona\", od kojih treći kaže da se svaka dovoljno napredna tehnologija ne razlikuje od magije. Tijekom života primio je brojna priznanja, uključujući titulu viteza i nominaciju za Nobelovu nagradu za mir. Umro je 2008. godine, ostavivši neizbrisiv trag na modernu znanost i popularnu kulturu.", "Ujedinjeno Kraljvstvo", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2770), "Artur", false, "Klark", null },
                    { 6, "Bosanskohercegovački pisac, poeta i scenarist.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6105), "Abdulah", false, "Sidran", null },
                    { 7, "Bosanskohercegovački pisac i novinar, poznat po partizanskoj tematici.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6112), "Derviš", false, "Sušić", null },
                    { 8, "Bosanskohercegovački pisac i akademik, autor brojnih romana i priča.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6305), "Nedžad", false, "Ibrišimović", null },
                    { 9, "Bosanskohercegovački pisac i pjesnik, poznat po zbirci Sarajevo Blues.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6309), "Semezdin", false, "Mehmedinović", null },
                    { 10, "Aleksa Šantić je rođen 1868. godine u Mostaru, gdje je proveo najveći dio svog života i stvaralaštva. Bio je jedan od najvažnijih predstavnika hercegovačke i južnoslavenske lirike, poznat po pjesmama o ljubavi, zavičaju i socijalnoj nepravdi. Umro je 1924. godine u Mostaru, ostavivši iza sebe bogat poetski opus koji je postao dio klasične književnosti ovih prostora.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6312), "Aleksa", false, "Šantić", null },
                    { 11, "Amer Kapetanović je savremeni bosanskohercegovački autor i javni djelatnik poznat po svom radu u oblasti književnosti, diplomatije i društvenih nauka. Kroz svoj profesionalni i književni angažman bavi se temama kulture, identiteta i savremenih društvenih tokova u Bosni i Hercegovini i regiji. Njegov rad doprinosi promociji bosanskohercegovačke kulture i jačanju međunarodne saradnje.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6317), "Amer", false, "Kapetanović", null },
                    { 12, "Senad Švraka je bosanskohercegovački autor i istraživač koji se bavi pisanjem i stručnim radovima iz oblasti kulture i društvenih nauka. Njegov rad često obuhvata teme vezane za savremena društvena pitanja, obrazovanje i razvoj lokalne zajednice. Kroz svoje djelovanje doprinosi promociji znanja i kulturnog stvaralaštva u Bosni i Hercegovini.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6320), "Senad", false, "Švraka", null },
                    { 13, "Henry James je bio američki pisac i kritičar rođen 1843. godine u New Yorku, koji je veći dio života proveo između SAD-a i Evrope, posebno u Engleskoj. Smatra se jednim od ključnih autora realizma i preteča modernističke književnosti, poznat po psihološkoj dubini svojih likova i složenom stilu pripovijedanja. Umro je 1916. godine u Londonu, ostavivši iza sebe značajan književni opus koji uključuje romane poput Portret jedne dame i Okretaj zavrtnja.", "Sjedinjene Američke Države", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6323), "Henry", false, "James", null },
                    { 14, "Isak Samokovlija bio je bosanskohercegovački književnik i ljekar jevrejskog porijekla. Rođen je 1889. godine u Goraždu, a u svojim djelima često je opisivao život običnih ljudi u Bosni, posebno u seoskim i malim gradskim sredinama. Smatra se jednim od najvažnijih predstavnika bosanskohercegovačke književnosti 20. stoljeća.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6326), "Isak", false, "Samokovlija", null },
                    { 15, "Hamza Humo bio je bosanskohercegovački književnik, pjesnik i prozni pisac. Rođen je 1895. godine u Mostaru, a bio je jedan od istaknutih predstavnika bošnjačke moderne književnosti. Njegova djela često su obilježena lirskim izrazom i motivima Hercegovine, prirode i ljubavi.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6331), "Hamza", false, "Humo", null },
                    { 16, "Biser Alichadić (češće: Biser Alikadić) je bosanskohercegovačka književnica i pjesnikinja. Rođena je 1939. godine u Mostaru, a u književnosti je poznata po emotivnoj i introspektivnoj poeziji koja često obrađuje teme ljubavi, intime i ženske perspektive. Smatra se jednom od značajnih savremenih autorica u bosanskohercegovačkoj književnosti.", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6334), "Bisera", false, "Alikadić", null },
                    { 17, "Marie-Henri Beyle, poznatiji kao Stendhal, bio je jedan od najznačajnijih francuskih romanopisaca 19. vijeka i začetnik književnog realizma. Tokom života služio je u Napoleonovoj vojsci i proputovao veliki dio Evrope, a duga razdoblja boravka u Italiji duboko su utjecala na njegovu strast prema umjetnosti i historiji. Njegova najpoznatija djela, Crveno i crno te Parmski kartuzijanski samostan, ističu se po dubokoj psihološkoj analizi likova i kritici društvenog poretka tog vremena.", "Francuska", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6337), "Henry-Beyle", false, "Stendhal", null },
                    { 18, "Fjodor Mihajlovič Dostojevski bio je jedan od najvećih ruskih pisaca i mislilaca, čija su djela duboko istraživala ljudsku psihu, moral i religiju. Zbog učešća u revolucionarnom krugu bio je osuđen na smrt, ali mu je kazna u zadnji čas preinačena na višegodišnji prisilni rad u Sibiru. Njegovi romani, poput Zločina i kazne i Braće Karamazovih, postali su temelji moderne svjetske književnosti i egzistencijalizma.\r\n", "Rusija", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6340), "Fjodor Mihajlovič", false, "Dostojevski", null }
                });

            migrationBuilder.InsertData(
                table: "BookFormats",
                columns: new[] { "Id", "CreatedAtUtc", "Format", "IsDeleted", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(1927), "Tvrdi uvez", false, null },
                    { 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(1930), "Meki uvez", false, null },
                    { 3, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(1933), "Spiralni uvez", false, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "IsEnabled", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2631), false, true, null, "Roman" },
                    { 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2638), false, true, null, "Poezija" },
                    { 3, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2640), false, true, null, "Drama" },
                    { 4, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2643), false, true, null, "Naučna fantastika" },
                    { 5, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5922), false, true, null, "Historijski roman" },
                    { 6, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5930), false, true, null, "Priča za djecu" },
                    { 7, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5933), false, true, null, "Memoari" },
                    { 8, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5936), false, true, null, "Putopis" },
                    { 9, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5938), false, true, null, "Pripovijetke" }
                });

            migrationBuilder.InsertData(
                table: "ChangeTypes",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6940), false, null, "Ulaz" },
                    { 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6945), false, null, "Izlaz" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "AmountOff", "CreatedAtUtc", "Description", "EndDate", "IsDeleted", "MaxUses", "MinOrderAmount", "ModifiedAtUtc", "Name", "PercentOff", "PromotionCode", "StartDate" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Popust dobrodošlice, -10 KM", new DateTime(2027, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3898), false, 100, 20m, null, "Popust dobrodošlice", null, "WELCOME10A", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3896) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ljetni popust, -20%", new DateTime(2027, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3926), false, 50, 50m, null, "Ljetni popust", 20m, "WELCOME20P", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3925) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2352), false, null, "Bosanski" },
                    { 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2355), false, null, "Engleski" },
                    { 3, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2358), false, null, "Njemački" },
                    { 4, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2361), false, null, "Srpski" },
                    { 5, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2363), false, null, "Hrvatski" },
                    { 6, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2366), false, null, "Francuski" },
                    { 7, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2369), false, null, "Španski" },
                    { 8, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2371), false, null, "Italijanski" },
                    { 9, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2374), false, null, "Ruski" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "StatusName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 6 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 7 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2540), false, null, "Buybook" },
                    { 2, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2542), false, null, "Svjetlost" },
                    { 3, "Beograd", "Srbija", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2545), false, null, "Laguna" },
                    { 4, "Beograd", "Srbija", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2547), false, null, "Čarobna knjiga" },
                    { 5, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6463), false, null, "Connectum" },
                    { 6, "Zenica", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6469), false, null, "Vrijeme Zenica" },
                    { 7, "Podgorica", "Crna Gora", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6471), false, null, "Nova knjiga" },
                    { 8, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6474), false, null, "Bosanska riječ Sarajevo" },
                    { 9, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6476), false, null, "Sarajevo Publishing" }
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "CreatedAtUtc", "Description", "IsDeleted", "ModifiedAtUtc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domaća kurirska služba sa brzom dostavom na području cijele Bosna i Hercegovina (1–2 radna dana). Pogodno za pakete i dokumente.", false, null, "Express One", 9.50m },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brza pošta sa dostavom širom Bosne i Hercegovine u roku 24–48h. Često korištena za online trgovine.", false, null, "X Express", 8.00m },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurirska služba sa dostavom na području cijele Bosna i Hercegovina u roku 24–48h, uz mogućnost plaćanja pouzećem.", false, null, "EuroExpress", 9.00m }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookFormatId", "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "IsDeleted", "LanguageId", "ModifiedAtUtc", "PageCount", "Price", "PublishedDate", "PublisherId", "QuantityInStockForOnlineOrders", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2935), "Roman koji se bavi pitanjima vjere, duhovnosti i smrti, kroz priču o Dervišu koji pokušava da pronađe smisao u životu i smrti. Kroz likove i filozofske dijaloge, autor istražuje moralne dileme i ljudsku patnju.", "978-86-03-02636-0", "/images/books/dervis_i_smrt.jpg", false, 1, null, 320, 29.99m, new DateTime(1966, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200, "Derviš i smrt" },
                    { 2, 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2943), "Roman koji opisuje istoriju jednog grada i njegove mostove, kroz sudbine ljudi koji su živeli u različitim vremenima. Andrić istražuje ljudsku sudbinu, istoriju i političke i kulturne promene kroz život mosta na Drini.", "978-86-07-00752-2", "/images/books/na_drini_cuprija.jpg", false, 1, null, 412, 34.99m, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150, "Na Drini ćuprija" },
                    { 3, 2, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(2950), "Roman koji kroz priču o životu jednog mladog čoveka istražuje teme ljubavi, smrti, i socijalnih promjena. Ćopić se bavi i univerzalnim pitanjima identiteta i postojanja u svetu koji se menja.", "978-86-03-00942-5", "/images/books/basta_pepeo.jpg", false, 1, null, 280, 24.99m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 120, "Bašta, pepeo" },
                    { 4, 1, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6632), "U Novele o mutnim vremenima ušle su duže pripovjetke našeg nobelovca koje, na ovaj ili onaj način, govore o nesigurnim i nemirnim vremenima kada je ugrožen čovjekov život ili narušeno njegovo dostojanstvo. Povijesti o zloglasnoj carigradskoj tamnici (Prokleta avlija), o obijesti turskih silnika u Bosni (Priča o vezirovom slonu), o progonu Jevreja (Bife Titanik) i herojstvu malog čovjeka u II svjetskom ratu (Zeko) u središtu su Andrićevog interesovanja za pojedinačne sudbine ljudi koji su živjeli na strašnim mjestima, gledali i na svojoj koži osjećali opšte stradanje u nesrećnim okolnostima i u njima kovali i sopstvenu sudbinu. Te novele, svaka za sebe, prava su remek-djela ovog žanra, smještena u Carigrad, Travnik, Sarajevo i Beograd - gradove obremenjene istorijom i nesrećama koje su ih često pohodile.", "978-86-521-0969-2", "/images/books/novele_o_mutnim_vremenima.jpg", false, 4, null, 356, 19.5m, new DateTime(2012, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 100, "Novele o mutnim vremenima" },
                    { 5, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6646), "Roman Derviša Sušića koji istražuje teme otpora, slobode i identiteta kroz sudbine likova u turbulentnim historijskim vremenima Bosne.", "978-86-01-00512-3", "/images/books/pobune_susic_dervis.jpg", false, 1, null, 248, 22.99m, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 80, "Pobune" },
                    { 6, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6652), "Roman Nedžada Ibrišimovića koji kroz humor i satiru portretiše bosansku svakodnevicu i karaktere, sa bogatim jezičkim izrazom.", "978-9958-21-033-7", "/images/books/ugursuz_ibrisimovic.jpg", false, 1, null, 304, 26.99m, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 90, "Ugursuz" },
                    { 7, 1, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6658), "Zbirka poezije i proza Semeždina Mehmedinivića nastala za vrijeme opsade Sarajeva, poetski svjedok o ratu, gubitku i opstanku.", "978-86-7448-027-5", "/images/books/sarajevo_blues.jpg", false, 1, null, 168, 21.99m, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 75, "Sarajevo Blues" },
                    { 8, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6664), "Novela Ive Andrića smještena u istanbulski zatvor u kojoj se isprepliću sudbine zatvorenika i istražuju teme slobode, zla i ljudske prirode.", "978-86-03-01234-8", "/images/books/prokleta_avlija_andric.jpg", false, 1, null, 152, 27.99m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 130, "Prokleta avlija" },
                    { 9, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6674), "Roman Ostrvo autora Meša Selimović prati stariji bračni par koji se povlači na usamljeno ostrvo tražeći mir i smisao života. Kroz njihovu izolaciju i unutrašnje dileme, djelo istražuje teme prolaznosti, straha od smrti i suočavanja sa sopstvenim životom.", "978-86-10-00984-2", "/images/books/d0818_ostrvo.jpg", false, 1, null, 198, 17m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 130, "Ostrvo" },
                    { 10, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6680), "Roman Kad više ne bude sutra autorice Nura Bazdulj-Hubijar bavi se teškim životnim situacijama, gubicima i emotivnim borbama kroz koje prolaze njegovi likovi. Kroz snažne i potresne priče, djelo istražuje teme ljubavi, tuge i suočavanja s neizvjesnom budućnošću.", "978-9958-731-40-2", "/images/books/kad_vise_ne_bude_sutra.jpg", false, 1, null, 198, 20m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 210, "Kad više ne bude sutra" },
                    { 11, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6686), "Nastavak legendarnog SF romana koji je osvojio nagrade Hjugo, Nebjula, Lokus, Džon V. Kembel i Britansku nagradu za naučnu fantastiku.\r\nGodine 2130. vanzemaljski brod Rama proleteo je kroz Sunčev sistem. Taj prvi dokaz postojanja vanzemaljskih civilizacija predočio je ljudskom rodu mnoga zapanjujuća otkrića, ali većina njegovih tajni ostala je nerazrešena.\r\nSedamdeset godina kasnije, novi svemirski brod Ramanaca vraća se u Sunčev sistem. Ovog puta, Zemlja je spremna za kontakt. Posada najpametnijih i najsposobnijih ljudi planete sprema se za susret s vanzemaljskim brodom.", "978-86-300-0208-3", "/images/books/rama_2_klark.jpg", false, 1, null, 477, 27.90m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 180, "Rama II" },
                    { 12, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6702), "Zbirka pjesama Alekse Šantića donosi emotivnu i lirsku poeziju prožetu motivima ljubavi, rodoljublja i socijalne pravde. Njegovi stihovi, jednostavni ali snažni, odražavaju duh vremena i duboku povezanost s narodom i zavičajem.\r\n", "978-99-581-8173-3", "/images/books/pjesme_santic.jpg", false, 1, null, 103, 19m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 60, "Pjesme" },
                    { 13, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6709), "Prozni zapis jednog vremena viđen iznutra, bez namjere da bude literatura, ali s literarnom disciplinom.Fond solidarnosti nije roman o institucijama, niti o politici vremena u kojem je nastao.To je prozni zapis jednog davnog života - perioda kada se ulazilo u svijet odraslih prerano, bez jezika, bez distance i bez prava na pogrešku.Knjiga prati iskustvo mladog čovjeka koji se kreće kroz strukture koje ne razumije do kraja, ali ih prihvata kao jedinu ponuđenu realnost. Solidarnost ovdje nije ideja ni parola, nego svakodnevna praksa, često nespretna, često pogrešno shvaćena.Pisano iz današnje distance, ali bez naknadne pameti, Fond solidarnosti ostaje svjedočanstvo o formativnom vremenu jedne generacije - o iluzijama koje su bile nužne, kompromisima koji su se tek kasnije prepoznali i životu koji je morao biti proživljen da bi se mogao napustiti.", "978-9926-585-18-1", "/images/books/fond_solidarnosti.jpg", false, 1, null, 175, 25m, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 100, "Fond solidarnosti" },
                    { 14, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6715), "Za kormilom devet metarske jedrilice ALEA, tuzlanski moreplovac Senad Švraka je prokrstario Mediteran, Crveno more i Indijski okean, kao prvi Bosanac kome je to pošlo za rukom. Od prvih nesigurnih izlazaka na more, savladavanja osnova jedrenja i navigacije, do borbe sa nevremenom na Jadranu, opasnog Crvenog mora, nadmudrivanja sa piratima u Adenskom zalivu i naporne prekookeanske plovidbe koja je brod i kapetana odvela čak do Tajlanda, Senad zanimljivim i pristupačnim stilom vodi čitaoca u egzotični svijet dalekih mora. ALEA je vrhunsko štivo u kojem će svaki zaljubljenik u more i avanture, ali i svaki ljubitelj dobre priče, istinski uživati.", "978-9958-31-303-5", "/images/books/alea_senad_svraka.jpg", false, 1, null, 339, 15m, new DateTime(2017, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 134, "Alea" },
                    { 15, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6721), "Roman Bostonci Henrija Džejmsa objavljen je kao zasebna knjiga 1886. godine, pošto je prethodno bio objavljivan u periodici.\r\nUpoznajemo komplikovani svijet Amerike nakon građanskog rata, sukobljen između tradicionalnih vrijednosti i progresivnih ideja kroz perspektive tri junaka: Bejzila Rensona (konzervativni južnjak), Oliv Čenslor (njegova feministički orijentisana rođaka), Verena Terent (harizmatična vatrena govornica, zarobljena između njihovih suprotstavljenih uticaja).", "978-8663-69-418-7", "/images/books/bostonci_dzejms.jpg", false, 4, null, 430, 33m, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 120, "Bostonci" },
                    { 16, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6726), "Ovo je zbirka ponajboljih Samokovlijinih priča, sažet izbor iz njegova djela koje je kao svijetao i neprolazan trag iza sebe ostavio ovaj pisac. Maestralne Samokovlijine pripovijetke tematski su redovno smještene u svijet bosanskih Jevreja, no njihova je umjetnička vrijednost univerzalna. Po zanimanju liječnik, s dugogodišnjom terenskom praksom, Samokovlija je odlično poznavao mali svijet svojega vremena i u Sarajevu i u Bosni. O tim ljudima, o njihovoj svakodnevnici pisao je s dubokom empatijom, ali i sa smislom za siguran i precizan opis likova, ambijenata, životnih formi i običaja.", "978-9958-18-165-8", "/images/books/nosac_samuel_isak_lektira.jpg", false, 1, null, 318, 25m, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 110, "Nosač Samuel" },
                    { 17, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6732), "Grozdanin kikot je roman (pjesma, poema, skaska…) ili čak zapis o starosjedilačkom idealu prošlosti u kome je Humo pokušao da spoji i sažme idejni fantazmagorični impuls nastalim na impresivnoj unutarnjoj osnovi sa materijalističkim, tjelesnim porivom i doživljajem jasnog dodira života i prirode.", "978-9958-26-206-7", "/images/books/grozdanin_kikot_humo.jpg", false, 1, null, 105, 15m, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 145, "Grozdanin kikot" },
                    { 18, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6737), "Njen književni izraz zasniva se na konceptima moderne poezije i ne robuje klasičnoj bosanskoj književnoj tradiciji. Stih je uglavnom slobodan, a rima gotovo nezastupljena, tek u svrhu podešavanja cjelokupne melodije pjesme. Teme o kojima Bisera Alikadić najčešće piše su žena i samoća u velikom gradu. Njena poezija obiluje posebnim urbanim ugođajem, u kojima se skriva i određena kriza identiteta modernog društva kod nas s kraja sedamdesetih godina.", "978-9958-21-095-9", "/images/books/knjiga_vremena.jpg", false, 1, null, 136, 11.70m, new DateTime(1999, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 80, "Knjiga vremena" },
                    { 19, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6743), "Nura Bazdulj-Hubijar i ovaj put je uspjela napisati izuzetno interesantan roman sa neočekivanim i naglim zaokretima koji čitaoca prosto okupiraju i tjeraju da knjigu ne pušta iz ruku dok ne sazna šta će se dalje dogoditi. Ti brzi i neočekivani novi momenti u pripovijednom toku, a koji su često temeljeni na nesporazumu, daju tekstu izuzetnu živost i potvrđuju činjenicu o kompliciranosti života i njegovoj nepredvidljivosti.", "978-9958-731-35-8", "/images/books/plavi_kombi_nura_bazdulj.jpg", false, 1, null, 175, 20m, new DateTime(2022, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 90, "Plavi kombi" },
                    { 20, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6748), "Zgodan, inteligentan i ambiciozan, sin nepismenog strugara Žilijen Sorel odlučan je da se uzdigne iznad svojih skromnih provincijskih korijena. Razapet između dva moćna svijeta, crkve koju simboliše crno, i vojske koju simboliše crveno, ubrzo shvata da se uspjeh može postići samo prihvatanjem suptilnog koda po kojem društvo funkcioniše.\r\n", "978-86-521-5486-9", "/images/books/stendal_crveno_i_crno.jpg", false, 4, null, 520, 27.50m, new DateTime(2025, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 150, "Crveno i crno" },
                    { 21, 2, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(6840), "Roman Zločin i kazna izgrađen je na fabuli koju poznajemo iz kriminalističkog štiva, s tom bitnom razlikom što ovdje već na početku djela saznajemo ko je ubojica, pa i šta ga je sve navelo na zločin.Zločin i kazna nije samo roman o pojedinačnom ljudskom karakteru ni samo psihološki roman ni roman o socijalno motiviranom karakteru već je sve to ali i mnogo više od toga.\r\n", "978-86-6369-064-6", "/images/books/zlocin_i_kazna_nova_knjiga.jpg", false, 4, null, 573, 36m, new DateTime(2015, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 135, "Zločin i kazna" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "IsDeleted", "ModifiedAtUtc", "OpeningHours", "Phone", "StoreName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pj-m1@bookverse.ba", false, null, "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00", "123-456-780", "BookVerse M-1" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pj-s1@bookverse.ba", false, null, "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00", "123-567-780", "BookVerse S-1" },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pj-j1@bookverse.ba", false, null, "Ponedjeljak-Petak 9:00-21:00; Subota 10:00-16:00", "123-534-780", "BookVerse J-1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsAdmin", "IsDeleted", "IsEmployee", "IsEnabled", "IsManager", "LastName", "ModifiedAtUtc", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiresAtUtc", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled", "TwoFactorFailedAttempts", "TwoFactorLockoutUntilUtc" },
                values: new object[] { 1, 1, new DateTime(2026, 5, 20, 19, 52, 5, 874, DateTimeKind.Utc).AddTicks(7873), "admin@bookverse.com", "admin", true, false, true, true, true, "admin", null, "AQAAAAIAAYagAAAAEFPsn4QvsoQq5H2rS4nUXcH8/iY2eQHpU36CZdOr6yuSrL4wmtQTLZB4lR6Oai2JmQ==", null, null, null, null, false, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsDeleted", "IsEmployee", "IsEnabled", "IsManager", "LastName", "ModifiedAtUtc", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiresAtUtc", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled", "TwoFactorFailedAttempts", "TwoFactorLockoutUntilUtc" },
                values: new object[] { 2, 2, new DateTime(2026, 5, 20, 19, 52, 5, 986, DateTimeKind.Utc).AddTicks(4929), "manager@bookverse.com", "manager", false, true, true, true, "manager", null, "AQAAAAIAAYagAAAAELgSQgpG04Ks8pIOxHGPp8oHEHo8oKCUKu+Ny4FlJcjS7Kgft5EdyCUMBkqhWUd6qw==", null, null, null, null, false, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsDeleted", "IsEnabled", "LastName", "ModifiedAtUtc", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiresAtUtc", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled", "TwoFactorFailedAttempts", "TwoFactorLockoutUntilUtc" },
                values: new object[] { 3, 3, new DateTime(2026, 5, 20, 19, 52, 6, 113, DateTimeKind.Utc).AddTicks(7268), "customer@bookverse.com", "user", false, true, "user", null, "AQAAAAIAAYagAAAAEGr4stGantfWQHZ1lKTlBhz4r6xT4Da5H9WHvy2rQ/JvuCcE7vRj40XMmFoXbsCJsA==", null, null, null, null, false, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsDeleted", "IsEmployee", "IsEnabled", "LastName", "ModifiedAtUtc", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiresAtUtc", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled", "TwoFactorFailedAttempts", "TwoFactorLockoutUntilUtc" },
                values: new object[] { 4, 1, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(1271), "employee@bookverse.com", "employee", false, true, true, "employee", null, "AQAAAAIAAYagAAAAEPDi7iPDvyUXcvZWiPgLCCO1YYPUUIRUcwjqEMw/AlCUCEeFh6LH4G1cfH2553fv4g==", null, null, null, null, false, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsDeleted", "IsEnabled", "LastName", "ModifiedAtUtc", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiresAtUtc", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled", "TwoFactorFailedAttempts", "TwoFactorLockoutUntilUtc" },
                values: new object[,]
                {
                    { 5, 4, new DateTime(2026, 5, 20, 19, 52, 6, 362, DateTimeKind.Utc).AddTicks(802), "amer.hadzic@gmail.com", "Amer", false, true, "Hadžić", null, "AQAAAAIAAYagAAAAECh0M4nWXkisOtLmH35V/Hq2BnciV3daOaXbQvIvR1AZ8KUXSpS4hT3hTdbzyCD/WQ==", null, null, null, null, false, 0, null },
                    { 6, 5, new DateTime(2026, 5, 20, 19, 52, 6, 470, DateTimeKind.Utc).AddTicks(7871), "lejla.begovic@gmail.com", "Lejla", false, true, "Begović", null, "AQAAAAIAAYagAAAAEGaL83ZLBVFdjSxXqq4Ugql96gmXQ4wwucafx1Xw2QEJ6yXPMRUeX99C8c72bT0SxA==", null, null, null, null, false, 0, null },
                    { 7, 6, new DateTime(2026, 5, 20, 19, 52, 6, 576, DateTimeKind.Utc).AddTicks(8756), "mirza.kovacevic@gmail.com", "Mirza", false, true, "Kovačević", null, "AQAAAAIAAYagAAAAEOcqu650TZviXDN4dhOo/Qxw90IMXcvbzGMNptlhCiOPByowywtZc+7959sSGxtVIw==", null, null, null, null, false, 0, null },
                    { 8, 7, new DateTime(2026, 5, 20, 19, 52, 6, 702, DateTimeKind.Utc).AddTicks(168), "amira.sehic@gmail.com", "Amira", false, true, "Šehić", null, "AQAAAAIAAYagAAAAELqYpCvf1Kagpm+mOpwtMvlPOuw4BV/LAYsfRp95B2nPHVY0UXvMLwmA0YCYvwTsGw==", null, null, null, null, false, 0, null },
                    { 9, 8, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(5204), "damir.muratovic@gmail.com", "Damir", false, true, "Muratović", null, "AQAAAAIAAYagAAAAEBTeWhEsvHdkN+eIBgEurSxCYLTjYhzEg/vzxHu/DJ7q3uIaHVQO0ZvNU3ypGy1QsQ==", null, null, null, null, false, 0, null }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 9 },
                    { 2, 2 },
                    { 2, 8 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 4, 10 },
                    { 4, 19 },
                    { 5, 5 },
                    { 5, 11 },
                    { 6, 6 },
                    { 7, 7 },
                    { 10, 12 },
                    { 11, 13 },
                    { 12, 14 },
                    { 13, 15 },
                    { 14, 16 },
                    { 15, 17 },
                    { 16, 18 },
                    { 17, 20 },
                    { 18, 21 }
                });

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 1 },
                    { 8, 3 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 4 },
                    { 12, 2 },
                    { 13, 7 },
                    { 14, 8 },
                    { 15, 5 },
                    { 16, 9 },
                    { 17, 1 },
                    { 18, 2 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "BookId", "UserId", "Comment", "DatePosted", "IsDeleted", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, "Izuzetna knjiga koja me potpuno očarala. Meša Selimović majstorski oslikava duboke filozofske dileme i emocije likova, ostavljajući snažan utisak.", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3056), false, 5, null },
                    { 2, 2, "Dobra knjiga, ali nije me potpuno oduševila. Andrić je stvorio bogate likove i prikazao historijske procese, ali nekim dijelovima nedostaje dinamike.", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3059), false, 4, null },
                    { 3, 3, "Knjiga mi nije bila loša, ali nisam doživio neku posebnu emociju. Iako Ćopić piše o važnim temama, nisam se mogao potpuno povezati s likovima.", new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3061), false, 3, null }
                });

            migrationBuilder.InsertData(
                table: "StoreInventory",
                columns: new[] { "BookId", "StoreId", "IsDeleted", "LastRestocked", "Location", "QuantityInStock", "ReorderTreshold" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3655), "A-5", 50, 5 },
                    { 2, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3753), "A-21", 200, 5 },
                    { 3, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3762), "A-31", 70, 5 },
                    { 4, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7085), "A-41", 30, 5 },
                    { 5, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7102), "A-51", 40, 5 },
                    { 6, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7114), "A-61", 35, 5 },
                    { 7, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7125), "A-71", 50, 5 },
                    { 8, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7134), "A-81", 60, 5 },
                    { 9, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7144), "B-91", 45, 5 },
                    { 10, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7157), "B-101", 28, 5 },
                    { 11, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7172), "B-111", 50, 5 },
                    { 12, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7182), "B-121", 20, 5 },
                    { 13, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7194), "B-131", 37, 5 },
                    { 14, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7203), "B-141", 55, 5 },
                    { 15, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7218), "B-151", 24, 5 },
                    { 16, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7227), "C-161", 43, 5 },
                    { 17, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7237), "C-171", 26, 5 },
                    { 18, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7247), "C-181", 47, 5 },
                    { 19, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7256), "C-191", 33, 5 },
                    { 20, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7264), "C-201", 16, 5 },
                    { 21, 1, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7272), "C-211", 58, 5 },
                    { 1, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3746), "A-12", 90, 5 },
                    { 2, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3756), "A-22", 210, 5 },
                    { 3, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3765), "A-32", 90, 5 },
                    { 4, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7092), "A-42", 25, 5 },
                    { 5, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7106), "A-52", 35, 5 },
                    { 6, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7118), "A-62", 45, 5 },
                    { 7, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7128), "A-72", 40, 5 },
                    { 8, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7138), "A-82", 55, 5 },
                    { 9, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7150), "B-92", 38, 5 },
                    { 10, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7160), "B-102", 33, 5 },
                    { 11, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7176), "B-112", 42, 5 },
                    { 12, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7188), "B-122", 18, 5 },
                    { 13, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7197), "B-132", 29, 5 },
                    { 14, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7207), "B-142", 48, 5 },
                    { 15, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7221), "B-152", 19, 5 },
                    { 16, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7230), "C-162", 36, 5 },
                    { 17, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7240), "C-172", 34, 5 },
                    { 18, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7250), "C-182", 39, 5 },
                    { 19, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7259), "C-192", 28, 5 },
                    { 20, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7267), "C-202", 23, 5 },
                    { 21, 2, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7275), "C-212", 46, 5 },
                    { 1, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3750), "A-15", 40, 5 },
                    { 2, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3760), "A-23", 240, 5 },
                    { 3, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 244, DateTimeKind.Utc).AddTicks(3768), "A-33", 80, 5 },
                    { 4, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7096), "A-43", 20, 5 },
                    { 5, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7111), "A-53", 30, 5 },
                    { 6, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7121), "A-63", 28, 5 },
                    { 7, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7131), "A-73", 35, 5 },
                    { 8, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7141), "A-83", 45, 5 },
                    { 9, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7154), "B-93", 32, 5 },
                    { 10, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7164), "B-103", 22, 5 },
                    { 11, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7179), "B-113", 36, 5 },
                    { 12, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7191), "B-123", 25, 5 },
                    { 13, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7200), "B-133", 41, 5 },
                    { 14, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7210), "B-143", 30, 5 },
                    { 15, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7224), "B-153", 27, 5 },
                    { 16, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7233), "C-163", 31, 5 },
                    { 17, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7243), "C-173", 21, 5 },
                    { 18, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7253), "C-183", 52, 5 },
                    { 19, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7261), "C-193", 44, 5 },
                    { 20, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7270), "C-203", 19, 5 },
                    { 21, 3, false, new DateTime(2026, 5, 20, 19, 52, 6, 827, DateTimeKind.Utc).AddTicks(7278), "C-213", 37, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BooksId",
                table: "BookAuthors",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookFormatId",
                table: "Books",
                column: "BookFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksCategories_CategoriesId",
                table: "BooksCategories",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLog_BookId",
                table: "InventoryLog",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLog_ChangeTypeId",
                table: "InventoryLog",
                column: "ChangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderCoupons_OrdersId",
                table: "OrderCoupons",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentSummaryId",
                table: "Orders",
                column: "PaymentSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingMethodId",
                table: "Orders",
                column: "ShippingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipToAddressId",
                table: "Orders",
                column: "ShipToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId_TokenHash",
                table: "RefreshTokens",
                columns: new[] { "UserId", "TokenHash" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingUpdates_OrderId",
                table: "ShippingUpdates",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingUpdates_OrderStatusId",
                table: "ShippingUpdates",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingUpdates_UpdatedByUserId",
                table: "ShippingUpdates",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInventory_BookId",
                table: "StoreInventory",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AddressId",
                table: "Stores",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeEvents_StripeEventId",
                table: "StripeEvents",
                column: "StripeEventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_BookId",
                table: "WishlistItems",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BooksCategories");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "InventoryLog");

            migrationBuilder.DropTable(
                name: "OrderCoupons");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShippingUpdates");

            migrationBuilder.DropTable(
                name: "StoreInventory");

            migrationBuilder.DropTable(
                name: "StripeEvents");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ChangeTypes");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BookFormats");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "PaymentSummaries");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
