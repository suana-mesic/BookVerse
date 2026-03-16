using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderStatuses_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusName",
                value: 4);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusName",
                value: 5);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 365, DateTimeKind.Local).AddTicks(2835));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 365, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 365, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(8931));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9559));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(2461), new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(2451) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(2507), new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(2501) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusName",
                value: 5);

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusName",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 42, 41, 837, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 42, 41, 837, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 15, 11, 42, 41, 837, DateTimeKind.Utc).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1742));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 15, 12, 42, 41, 837, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 42, 41, 515, DateTimeKind.Local).AddTicks(7953), "AQAAAAIAAYagAAAAEA/xeW/41X5Z+HY/ImaTmJmILJZhZhTOg7zsh9gutmVqq0IteKe+Wrn2qTwFPSXiHg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 42, 41, 666, DateTimeKind.Local).AddTicks(8172), "AQAAAAIAAYagAAAAEDonMsMQpHVjvIWrgGGZsBwRj7vFTzng+lhkSAzKi9Fx3P9HRn1xOm8JqoZMN//FkQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 15, 12, 42, 41, 836, DateTimeKind.Local).AddTicks(7599), "AQAAAAIAAYagAAAAEDMRlW6SI4gQW7+9A5j/pJNKX4DoH1pM8BwLUALezcIWEycBiPn3OsnxEr7RsxxFjg==" });
        }
    }
}
