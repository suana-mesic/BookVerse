using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoupons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "AmountOff", "CreatedAtUtc", "Description", "EndDate", "IsDeleted", "ModifiedAtUtc", "Name", "PercentOff", "PromotionCode", "StartDate" },
                values: new object[,]
                {
                    { 1, 10m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome discount with amountoff 10", new DateTime(2027, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2809), false, null, "Welcome discount", null, "WELCOME10A", new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2805) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer discount with percentoff 20", new DateTime(2027, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2838), false, null, "Summer discount ", 20m, "WELCOME20P", new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2835) }
                });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 771, DateTimeKind.Local).AddTicks(9875), "AQAAAAIAAYagAAAAEF8fCoVSdcS6VTIsKwA8JR4GDhSKON2c7rN82S9FtFsXLTbpTzPwU7h9UyGHdS/ufg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 869, DateTimeKind.Local).AddTicks(9153), "AQAAAAIAAYagAAAAEOslrupj9rXIFEYgC1U5XCaxccuUjQ0SAGozeSHEqAU61qw8c3z0N5I5ZDNMP0iE9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 965, DateTimeKind.Local).AddTicks(9752), "AQAAAAIAAYagAAAAEBxNQpmbIOlSufjn14E8hVyjUiQpSv8Hu+xZHcqIGgAUQ3+HIeHdgdYEzhQjNHvbeA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 149, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 149, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 149, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9537));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 40, 32, 451, DateTimeKind.Utc).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 40, 32, 451, DateTimeKind.Utc).AddTicks(638));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 40, 32, 451, DateTimeKind.Utc).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 40, 32, 451, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 40, 32, 250, DateTimeKind.Local).AddTicks(5197), "AQAAAAIAAYagAAAAEM2pQqSoeWWman8JA33znLXkI5Cn9JZls/b4xdt1EgsePHZrIX9WZ52eKRUBF4rKRQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 40, 32, 354, DateTimeKind.Local).AddTicks(2916), "AQAAAAIAAYagAAAAEBO/8iAw126mh0xBsfipbeoAg4DwSXPKp2EQpBkLTz5gINJ5CVVupJyLD11ksQ5IkA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 40, 32, 450, DateTimeKind.Local).AddTicks(8436), "AQAAAAIAAYagAAAAEIJ7aF6SJgfyYPNC3QkeUFXoyAlU9rpMTDz3tYm5pEljl02U7yViPWXdikHTktIarg==" });
        }
    }
}
