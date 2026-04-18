using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCorrections_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 14, 10 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 16, 11 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 45, 484, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 45, 484, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 45, 484, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9621));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6012));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "Language", "PageCount", "Price", "PublishedDate", "Title" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6550), "U Novele o mutnim vremenima ušle su duže pripovjetke našeg nobelovca koje, na ovaj ili onaj način, govore o nesigurnim i nemirnim vremenima kada je ugrožen čovjekov život ili narušeno njegovo dostojanstvo. Povijesti o zloglasnoj carigradskoj tamnici (Prokleta avlija), o obijesti turskih silnika u Bosni (Priča o vezirovom slonu), o progonu Jevreja (Bife Titanik) i herojstvu malog čovjeka u II svjetskom ratu (Zeko) u središtu su Andrićevog interesovanja za pojedinačne sudbine ljudi koji su živjeli na strašnim mjestima, gledali i na svojoj koži osjećali opšte stradanje u nesrećnim okolnostima i u njima kovali i sopstvenu sudbinu. Te novele, svaka za sebe, prava su remek-djela ovog žanra, smještena u Carigrad, Travnik, Sarajevo i Beograd - gradove obremenjene istorijom i nesrećama koje su ih često pohodile.", "978-86-521-0969-2", "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/novele_o_mutnim_vremenima.jpg", "Srpski", 356, 19.5m, new DateTime(2012, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novele o mutnim vremenima" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6699));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6737));

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 12, 2 },
                    { 13, 7 },
                    { 14, 8 },
                    { 16, 9 },
                    { 18, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5791), "Priča za djecu" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5797), "Memoari" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5801), "Putopis" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(5806), "Pripovijetke" });

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9361), new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9358) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9392), new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9389) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 53, 46, 58, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 53, 46, 58, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 53, 46, 58, DateTimeKind.Utc).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7196));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7345));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7277));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7320));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7236));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7325));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 45, 597, DateTimeKind.Local).AddTicks(8), "AQAAAAIAAYagAAAAENCytbaDekVYyLRziTWNG1L8/cg4VUVRLQ5jhq6PJe1j447ccrto0aGa1tKLUGPSOA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 45, 719, DateTimeKind.Local).AddTicks(2312), "AQAAAAIAAYagAAAAEIOolJEo9yASFGVih7MgjEZjRfG6o2PG1sedeJzIUpeIIg0WAzplIR16J4aYSiImxQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 45, 897, DateTimeKind.Local).AddTicks(403), "AQAAAAIAAYagAAAAEPDB4jli0NOftHrqea0SoEUF29PVJUhWy8UpLMaFRk229KhfCxrZXGpu8DQh0an0JQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 58, DateTimeKind.Local).AddTicks(6820), "AQAAAAIAAYagAAAAELMSf4HuE5IIQw2A93/bYeQNhsjO4licV1z5rAhN+rqbCveIU1qmoASH5QVyU/QH9Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 218, DateTimeKind.Local).AddTicks(3387), "AQAAAAIAAYagAAAAEFxAKWLsleChAG10UgFUZ/aBAnym84gigQ73dxwo1H+qYhxActpjYnhiomK/HrJ7bQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 385, DateTimeKind.Local).AddTicks(3049), "AQAAAAIAAYagAAAAEMDejT5xyxfipJT5um5avNqhUUrPnzXV/z9zOWxiwp4yJODoC97OACRs3CBiDSebpw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 551, DateTimeKind.Local).AddTicks(7972), "AQAAAAIAAYagAAAAEECU23HQR8K7wdf6OMPgInQcpxHSOIpPlhS6HI6DPCwzMEfeCyNevL+uLspo03Ge4w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 720, DateTimeKind.Local).AddTicks(328), "AQAAAAIAAYagAAAAEKEuI1Hz4x/5WBLOnsYB6uZPbbZ52uzYyOf0YaXgxHaG1xS3XxDYWPT/DMPdFNGS9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 53, 46, 887, DateTimeKind.Local).AddTicks(4982), "AQAAAAIAAYagAAAAEO/z+AfRLtUvkldxx6YRr/wQIw2P+S7OEo9QdbiVh9C1J/6CmcDm5LcqAz83pQlFRg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 13, 7 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 14, 8 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 16, 9 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 24, 612, DateTimeKind.Local).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 24, 612, DateTimeKind.Local).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 24, 612, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(590));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9541));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "Language", "PageCount", "Price", "PublishedDate", "Title" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3825), "Remek djelo svjetske književnosti i jedna od najčitanijih knjiga u svijetu, Da Vinčijev kod je nevjerovatna knjiga, puna zanosa, napete avanture, naučnih zagonetki i obrta, triler koji nas na potpuno nepredvidljiv način uvlači sve dublje u priču do nevjerovatnog raspleta.\r\n", "978-86-819-6280-0", "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/na_drini_cuprija_andric.jpg", "Bosanski", 336, 21m, new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Na Drini ćuprija" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3864));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 12, 9 },
                    { 13, 8 },
                    { 18, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9261));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9265));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2607));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2618), "Naučna fantastika" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2624), "Priča za djecu" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2627), "Memoari" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "Name" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2631), "Poezija" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "IsEnabled", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 10, new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2636), false, true, null, "Putopis" },
                    { 11, new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(2640), false, true, null, "Pripovijetke" }
                });

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(442), new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(439) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(474), new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(472) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9158));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3534));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 44, 25, 273, DateTimeKind.Utc).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 44, 25, 273, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 18, 11, 44, 25, 273, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4527));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 25, 274, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4469));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4554));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 24, 761, DateTimeKind.Local).AddTicks(9050), "AQAAAAIAAYagAAAAEBg9Avnua1rXgUFnIGEDlZ14dOmRIRDNCtRJjTNevWwQH8mbnK5rqiZyZJdLLZkkJA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 24, 938, DateTimeKind.Local).AddTicks(9129), "AQAAAAIAAYagAAAAEGfvVliEovyjPR5J7HUBvNPT/vMzoPB5HcHdQyb+bXgN4gS4l7/0QKAxnAUTEcnMvw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 110, DateTimeKind.Local).AddTicks(5707), "AQAAAAIAAYagAAAAEFJJq4z5tLNagDcKacdGKqObyFlYvirKsgN7OttNHPipamebxyLsB+Fysq11N0dGaQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 273, DateTimeKind.Local).AddTicks(8028), "AQAAAAIAAYagAAAAEI5eRtWpJb8tfFpoTmeaJGVYdPudbqCnRHkDNkXlzeh2uz1xqR3vixCZCU0UPPq/Tw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 452, DateTimeKind.Local).AddTicks(723), "AQAAAAIAAYagAAAAEK35FFw8UjvGLw8P2BIfASqZU15qDF44DDwlNXU3nlkED5VHdfwnipS+PicB+oC4jw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 634, DateTimeKind.Local).AddTicks(4014), "AQAAAAIAAYagAAAAEAqarYDd7Oo1SUAq8U8R9mbskPHawbdTXC1AfDzzxwH/eclLRro0xZPXTClHY0Itjg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 801, DateTimeKind.Local).AddTicks(8799), "AQAAAAIAAYagAAAAEJMF4O0Xai++FVjSVAh8BFwEH+PyyqNgaeW8qbzCfh09GXSJbS9CiyAowtgoFyT22g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 25, 971, DateTimeKind.Local).AddTicks(3856), "AQAAAAIAAYagAAAAEAPvmgpyVJOFRB7X08bg2f0+r+DYRJk4K5Te8Q5Am7vLvjSLAdaa9xE3BVpx2mHnig==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 18, 13, 44, 26, 85, DateTimeKind.Local).AddTicks(876), "AQAAAAIAAYagAAAAENDD2cISg4B6ptY2ETj5D27izLuJMxiDZ3HmKPMVwwZSJtjfRGNAmOpOJc2jNu3NYg==" });

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 14, 10 },
                    { 16, 11 }
                });
        }
    }
}
