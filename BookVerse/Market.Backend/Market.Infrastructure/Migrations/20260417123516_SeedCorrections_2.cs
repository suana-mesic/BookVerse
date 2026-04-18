using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCorrections_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 100, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 100, DateTimeKind.Local).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 100, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Country", "CreatedAtUtc", "FirstName", "IsDeleted", "LastName", "ModifiedAtUtc" },
                values: new object[,]
                {
                    { 14, "Isak Samokovlija bio je bosanskohercegovački književnik i ljekar jevrejskog porijekla. Rođen je 1889. godine u Goraždu, a u svojim djelima često je opisivao život običnih ljudi u Bosni, posebno u seoskim i malim gradskim sredinama. Smatra se jednim od najvažnijih predstavnika bosanskohercegovačke književnosti 20. stoljeća.", "BiH", new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6899), "Isak", false, "Samokovlija", null },
                    { 15, "Hamza Humo bio je bosanskohercegovački književnik, pjesnik i prozni pisac. Rođen je 1895. godine u Mostaru, a bio je jedan od istaknutih predstavnika bošnjačke moderne književnosti. Njegova djela često su obilježena lirskim izrazom i motivima Hercegovine, prirode i ljubavi.", "BiH", new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6906), "Hamza", false, "Humo", null },
                    { 16, "Biser Alichadić (češće: Biser Alikadić) je bosanskohercegovačka književnica i pjesnikinja. Rođena je 1939. godine u Mostaru, a u književnosti je poznata po emotivnoj i introspektivnoj poeziji koja često obrađuje teme ljubavi, intime i ženske perspektive. Smatra se jednom od značajnih savremenih autorica u bosanskohercegovačkoj književnosti.", "BiH", new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6911), "Bisera", false, "Alikadić", null }
                });

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9672));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7615));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookFormatId", "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "IsDeleted", "Language", "ModifiedAtUtc", "PageCount", "Price", "PublishedDate", "PublisherId", "QuantityInStockForOnlineOrders", "Title" },
                values: new object[] { 16, 2, new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7678), "Ovo je zbirka ponajboljih Samokovlijinih priča, sažet izbor iz njegova djela koje je kao svijetao i neprolazan trag iza sebe ostavio ovaj pisac. Maestralne Samokovlijine pripovijetke tematski su redovno smještene u svijet bosanskih Jevreja, no njihova je umjetnička vrijednost univerzalna. Po zanimanju liječnik, s dugogodišnjom terenskom praksom, Samokovlija je odlično poznavao mali svijet svojega vremena i u Sarajevu i u Bosni. O tim ljudima, o njihovoj svakodnevnici pisao je s dubokom empatijom, ali i sa smislom za siguran i precizan opis likova, ambijenata, životnih formi i običaja.", "978-9958-18-165-8", "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/nosac_samuel_isak_lektira.jpg", false, "Bosanski", null, 318, 25m, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 110, "Nosač Samuel" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6363));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6368));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "IsEnabled", "ModifiedAtUtc", "Name" },
                values: new object[] { 11, new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(6387), false, true, null, "Pripovijetke" });

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7802));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1048), new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1096), new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(1093) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9090));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 8, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7032), false, null, "Bosanska riječ Sarajevo" },
                    { 9, "Sarajevo", "Bosna i Hercegovina", new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7036), false, null, "Sarajevo Publishing" }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 35, 13, 748, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 35, 13, 748, DateTimeKind.Utc).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 35, 13, 748, DateTimeKind.Utc).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(832));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8027));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(837));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 13, 749, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 13, 262, DateTimeKind.Local).AddTicks(6350), "AQAAAAIAAYagAAAAEKDT0X3uVHatLE2XklESgA03z6v2p6ab003s/1ZEbFa5gYZIO/u/4p9cdo3YZlsmPw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 13, 424, DateTimeKind.Local).AddTicks(363), "AQAAAAIAAYagAAAAEOObU5PVcKfo9cV8Sj6U4Hr/G3h4UkAr5PZmct7p73qxxYb79NJMNEzq4T2HFrMXQA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 13, 584, DateTimeKind.Local).AddTicks(4597), "AQAAAAIAAYagAAAAEI9UAXPbluIgfspYS8iqv6KALvFsCKYVImTB056JREeo0dHaoSCxbwV51j+POFalGQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 13, 748, DateTimeKind.Local).AddTicks(7982), "AQAAAAIAAYagAAAAEKj4zY8P7Es77Av3dPqufRxc0bkTbprI/LfhAFzSm5V3GCu6r5RjDZ2eoY7N3ei/1g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 13, 918, DateTimeKind.Local).AddTicks(1192), "AQAAAAIAAYagAAAAEFf+70+RqkdObv5OXf9F959xrvhCpbKTdm3m40vyLVHAvIUS8jAysLb0qmSXsXEWww==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 14, 64, DateTimeKind.Local).AddTicks(3854), "AQAAAAIAAYagAAAAELes42q/GCfN2xP1nhGTMyZWRWp+BJHhtN5YA8fHlFkqscc2Q7yvW2N+ImNhxxYzAw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 14, 248, DateTimeKind.Local).AddTicks(484), "AQAAAAIAAYagAAAAEG3eY29Sy0E7WN4vik0NkcV38InoTkS6p0rtuaQs/cacnk2sNNiDBuoZKj+YEOGHJw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 14, 412, DateTimeKind.Local).AddTicks(1216), "AQAAAAIAAYagAAAAEJ2Z3kHB7k8EkDvx+7S76f94Q2GkCYrDwozG4nsJADI6+NzsxOWLuRHlMv6u9VUtjQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(3582), "AQAAAAIAAYagAAAAEA9FdaWqhcYdzaNkq369u5qYhLJJJXYE3e36fmPrK5bieEtHAQ0kvp0PMozI1bqBOA==" });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[] { 14, 16 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookFormatId", "CreatedAtUtc", "Description", "ISBN", "ImageUrl", "IsDeleted", "Language", "ModifiedAtUtc", "PageCount", "Price", "PublishedDate", "PublisherId", "QuantityInStockForOnlineOrders", "Title" },
                values: new object[,]
                {
                    { 17, 2, new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7685), "Grozdanin kikot je roman (pjesma, poema, skaska…) ili čak zapis o starosjedilačkom idealu prošlosti u kome je Humo pokušao da spoji i sažme idejni fantazmagorični impuls nastalim na impresivnoj unutarnjoj osnovi sa materijalističkim, tjelesnim porivom i doživljajem jasnog dodira života i prirode.", "978-9958-26-206-7", "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/grozdanin_kikot_humo.jpg", false, "Bosanski", null, 105, 15m, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 145, "Grozdanin kikot" },
                    { 18, 2, new DateTime(2026, 4, 17, 14, 35, 14, 559, DateTimeKind.Local).AddTicks(7693), "Njen književni izraz zasniva se na konceptima moderne poezije i ne robuje klasičnoj bosanskoj književnoj tradiciji. Stih je uglavnom slobodan, a rima gotovo nezastupljena, tek u svrhu podešavanja cjelokupne melodije pjesme. Teme o kojima Bisera Alikadić najčešće piše su žena i samoća u velikom gradu. Njena poezija obiluje posebnim urbanim ugođajem, u kojima se skriva i određena kriza identiteta modernog društva kod nas s kraja sedamdesetih godina.", "978-9958-21-095-9", "https://www.knjiga.ba/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/slike/knjiga_vremena.jpg", false, "Bosanski", null, 136, 11.70m, new DateTime(1999, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 80, "Knjiga vremena" }
                });

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[] { 16, 11 });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 15, 17 },
                    { 16, 18 }
                });

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 17, 1 },
                    { 18, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 14, 16 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 15, 17 });

            migrationBuilder.DeleteData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 16, 18 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 16, 11 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BooksId", "CategoriesId" },
                keyValues: new object[] { 18, 9 });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 55, 938, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 55, 938, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 55, 938, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2922));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1970));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7104));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7111));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7144));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6559));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2693), new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2732), new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 0, 56, 333, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 0, 56, 333, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 17, 12, 0, 56, 333, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7356));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2582));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7348));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2574));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(2585));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 38, DateTimeKind.Local).AddTicks(7487), "AQAAAAIAAYagAAAAEDpDKVcD8ljrzoSHeTVQ/ixk4IDHBmVwH1w+4wU8iPtNoYi1twZcg2IoEd359CW8Gw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 137, DateTimeKind.Local).AddTicks(4856), "AQAAAAIAAYagAAAAENswOKP3ACpjy6244R7Vf9Bk5jX8oUNe0DksE89bhX23Hev8u5qhmJ85JqvklW+vSw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 235, DateTimeKind.Local).AddTicks(6853), "AQAAAAIAAYagAAAAEBc5Q6IM1Dx/AhSsyzM9T3B4Oj/hCR+M9Fru+gcmi15yp69QR9lbcLaamQWC+GCLhQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 333, DateTimeKind.Local).AddTicks(168), "AQAAAAIAAYagAAAAEPzejBavw97N9Jznk/MTgi4IC8I+S9rg194AECJabomf0NzLnCbFOw9zzMQHApH6TA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 430, DateTimeKind.Local).AddTicks(3128), "AQAAAAIAAYagAAAAEEz96WBh46uwFGDi3czVRDj2PA//IF189mLCkQu/3av237c7mG2Zq6yimERoayq0Gg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 527, DateTimeKind.Local).AddTicks(401), "AQAAAAIAAYagAAAAEAlGuBDY2P3fmPnVBZ2c7y7hbgjPwk8IeaMHpW1HPEwCNqyHzF/RRzJ8ytwcVNaxCQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 623, DateTimeKind.Local).AddTicks(8048), "AQAAAAIAAYagAAAAEI0F6NeeHkyGqnubTsav5Rta27JeO8raM5XNUXmaXxBj0K9Pz/WuJF08UVXbxXPqdg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 720, DateTimeKind.Local).AddTicks(3482), "AQAAAAIAAYagAAAAEPFbcMyx7gXerEjP8AGFPz8r92gcRTY+B18z85yUQ1RtjxGkUYuTa2cyXoXeBYsevw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 17, 14, 0, 56, 816, DateTimeKind.Local).AddTicks(5751), "AQAAAAIAAYagAAAAEDFXQ7tc0PG30CpdLtpWBa1QHC2iVbXcV4dc8+b/TwiF/y9aMyMVMkJ7hSsc87T4sQ==" });
        }
    }
}
