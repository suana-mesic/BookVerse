using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLast4DigitsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Last4Digits",
                table: "PaymentSummaries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 513, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 513, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 513, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4415), new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4445), new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 29, 47, 809, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 29, 47, 809, DateTimeKind.Utc).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 29, 47, 809, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4269));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 29, 47, 611, DateTimeKind.Local).AddTicks(3840), "AQAAAAIAAYagAAAAEM0pAcPGxKqZxvJW1AJxzzGmbR0wiYJ9h4cl+4SMrPomCefpf2aZeEVBeIV05q8fCw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 29, 47, 710, DateTimeKind.Local).AddTicks(5232), "AQAAAAIAAYagAAAAEGI+GODH0yVu0Djlt+ttrC9ORHz/wWsWZFSHn77mqgV6IulKV7mmgyNseEku6qtsTQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 29, 47, 809, DateTimeKind.Local).AddTicks(202), "AQAAAAIAAYagAAAAEE4FSbH6BzftC2W95BSgVxQt4N+RlLAmobklTKvVXGWU/Cfaq4d2SQjO9Vsp94w1vA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Last4Digits",
                table: "PaymentSummaries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 19, 992, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 19, 992, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 19, 992, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1823));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3249), new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3245) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3282), new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(1314));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 11, 20, 293, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 11, 20, 293, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 19, 11, 20, 293, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 20, 11, 20, 293, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 11, 20, 93, DateTimeKind.Local).AddTicks(7252), "AQAAAAIAAYagAAAAEL2kBq6kAd9148RCR8StqYBPOH+2oH5Fx5Obx25Iohpbf3Y/oJFpqZagmYQJUrKsrQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 11, 20, 194, DateTimeKind.Local).AddTicks(7342), "AQAAAAIAAYagAAAAEEb9Yv3LA2s2VZXrBGmsRwA2vaThUwV9KUlTzQpsvPZOK6vVUbfKZBQmYpm9H+n29g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 20, 11, 20, 292, DateTimeKind.Local).AddTicks(9609), "AQAAAAIAAYagAAAAEBbnCt4nIgR69DKAqKbi+CRKjxb0PYMAFq5qU2p6dg8iQAjNaN/6zS6NlSPOfTKFug==" });
        }
    }
}
