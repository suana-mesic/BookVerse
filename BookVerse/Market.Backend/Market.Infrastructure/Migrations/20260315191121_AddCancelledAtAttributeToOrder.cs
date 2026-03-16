using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCancelledAtAttributeToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 484, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 484, DateTimeKind.Local).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 484, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5233), new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5227) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5319), new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 46, 18, 935, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 46, 18, 935, DateTimeKind.Utc).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 46, 18, 935, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5076));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 46, 18, 643, DateTimeKind.Local).AddTicks(8447), "AQAAAAIAAYagAAAAEIwvZBdD3dhJ1Bq5AQN2VCWfiQRJ7a0GdjOn2i5rzv5bwZz7eywGWInKhYsIPa90pA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 46, 18, 770, DateTimeKind.Local).AddTicks(1922), "AQAAAAIAAYagAAAAEMmqG/HfmessRWM5KOd/ESyMZ0vW2QMczyGhittfRGYt5B+UUYAPSum0dsAiktWEGQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 46, 18, 935, DateTimeKind.Local).AddTicks(2158), "AQAAAAIAAYagAAAAENe5wiDsDh3qq9y10kxPzVfnhmmURxddTn0Xxus7Naw8PhQlWHe7uYsp6MlzLLF8Og==" });
        }
    }
}
