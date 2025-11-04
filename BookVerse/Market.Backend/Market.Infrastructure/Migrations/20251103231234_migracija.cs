using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migracija : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    TokenVersion = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    BookFormatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Fingerprint = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "Line1", "Line2", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, "Mostar", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 5, DateTimeKind.Local).AddTicks(8289), false, "Maršala Tita", null, null },
                    { 2, "Sarajevo", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 5, DateTimeKind.Local).AddTicks(8342), false, "Vrbanja 1", null, null },
                    { 3, "Jablanica", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 5, DateTimeKind.Local).AddTicks(8345), false, "Gornja Kolonija SP 100", null, null }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Country", "CreatedAtUtc", "FirstName", "IsDeleted", "LastName", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, "biografija", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7788), "Meša", false, "Selimović", null },
                    { 2, "biografija", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7795), "Ivo", false, "Andrić", null },
                    { 3, "biografija", "BiH", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7798), "Branko", false, "Ćopić", null }
                });

            migrationBuilder.InsertData(
                table: "BookFormats",
                columns: new[] { "Id", "CreatedAtUtc", "Format", "IsDeleted", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7297), "Tvrdi uvez", false, null },
                    { 2, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7303), "Tvrdi papirni uvez", false, null },
                    { 3, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7306), "Spiralni uvez", false, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, "Sarajevo", "Bosna i Hercegovina", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7516), false, null, "Buybook" },
                    { 2, "Sarajevo", "Bosna i Hercegovina", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7596), false, null, "Svjetlost" },
                    { 3, "Beograd", "Srbija", new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7599), false, null, "Laguna" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookFormatId", "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "IsDeleted", "Language", "ModifiedAtUtc", "PageCount", "Price", "PublishedDate", "PublisherId", "QuantityInStockForOnlineOrders", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7704), "A story about a young man, Holden Caulfield, and his experiences in New York City after being expelled from prep school.", "978-0-316-76948-0", "https://example.com/images/catcher_in_the_rye.jpg", false, "English", null, 277, 19.99m, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 150, "The Catcher in the Rye" },
                    { 2, 1, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7718), "A fantasy novel by J.R.R. Tolkien, following the adventures of Bilbo Baggins in Middle-earth.", "978-0-618-00221-3", "https://example.com/images/the_hobbit.jpg", false, "English", null, 310, 25.99m, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 120, "The Hobbit" },
                    { 3, 2, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(7727), "A spiritual guidebook written by a spiritual teacher, exploring hidden knowledge and insights, offering guidance on life, peace, and inner wisdom.", "978-1-84293-719-6", "https://example.com/images/the_secret_of_secrets.jpg", false, "English", null, 400, 19.99m, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150, "The Secret of Secrets" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsAdmin", "IsDeleted", "IsEmployee", "IsEnabled", "IsManager", "LastName", "ModifiedAtUtc", "PasswordHash", "TokenVersion" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 4, 0, 12, 34, 73, DateTimeKind.Local).AddTicks(2737), "admin@gmail.com", "Admin", true, false, true, true, false, "User", null, "AQAAAAIAAYagAAAAEAAemFy62S/L2obApiz1yhH4n9ja6QU5HC3VLaIdNjMw6L1a8yNqjkF9LGbT/9BLTQ==", 0 },
                    { 2, 2, new DateTime(2025, 11, 4, 0, 12, 34, 140, DateTimeKind.Local).AddTicks(5415), "string@gmail.com", "string", false, false, true, true, false, "string", null, "AQAAAAIAAYagAAAAEPZHZ+kSMERX5+gElIsWKh5NYVwlBO3yLQNns7PNMVpWuFHKNhlYJqWukXVXRVzFsQ==", 0 },
                    { 3, 2, new DateTime(2025, 11, 4, 0, 12, 34, 206, DateTimeKind.Local).AddTicks(6578), "string@gmail.com", "manager@market.local", false, false, true, true, true, "string", null, "AQAAAAIAAYagAAAAECqAZ6LuaNSvxyvwUsb67mlw1cjwvVthBGu9jO/bVsPO51Kzf4mCFcSSKRkY0UQ+PQ==", 0 }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 }
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
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookFormats");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
