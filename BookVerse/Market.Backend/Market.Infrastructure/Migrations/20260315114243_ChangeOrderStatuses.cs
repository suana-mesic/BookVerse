using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3482), new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3559), new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3501) });

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
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3163));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 527, DateTimeKind.Local).AddTicks(6204), "AQAAAAIAAYagAAAAEKm8wb4KvFGsxLEy8Ik8rnpWZdcYncBXsKLTHDo65vvBZau/W+zOaybhNJYY/XppPg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 624, DateTimeKind.Local).AddTicks(5902), "AQAAAAIAAYagAAAAEAl1woeHwV5Aw/TMLY4ZA7ACaagy7E96lITEG+qzTBO3g4tc9CprBT1iLIQD9zqtow==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 730, DateTimeKind.Local).AddTicks(9299), "AQAAAAIAAYagAAAAEAvLScq2Xi6P4XbSNMQA/5pKlQTcmAqJq4LID36IWrEVbo8eyfvINx8tXNykuQlltg==" });
        }
    }
}
