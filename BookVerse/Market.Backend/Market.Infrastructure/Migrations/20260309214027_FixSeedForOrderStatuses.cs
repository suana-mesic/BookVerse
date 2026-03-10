using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedForOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 453, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 453, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 453, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(7725));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(5715));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6439));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 9, 21, 40, 25, 916, DateTimeKind.Utc).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 9, 21, 40, 25, 916, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 9, 21, 40, 25, 916, DateTimeKind.Utc).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 40, 25, 606, DateTimeKind.Local).AddTicks(3653), "AQAAAAIAAYagAAAAEJaKBBirVGvQjYsM38pmCzckblwItfgkiV23mV2yrJkCqrIfAAINB5wlQ1gCa/BeRQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 40, 25, 783, DateTimeKind.Local).AddTicks(8239), "AQAAAAIAAYagAAAAEOiN8ebHHlmPBtEdM3S/vBcZP/sk64xrsQveX03jrrFNq/J9/v4t92XXWACO+JyccA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 9, 22, 40, 25, 916, DateTimeKind.Local).AddTicks(2503), "AQAAAAIAAYagAAAAEK23urVsvVu5dYCUNZJOtdxcuf96ldqgpoIEM1+artxxfw2x1OlGW8zm/hPX4MsYcg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 114, DateTimeKind.Local).AddTicks(9153));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 114, DateTimeKind.Local).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 114, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9464));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 18, 24, 45, 413, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 18, 24, 45, 413, DateTimeKind.Utc).AddTicks(9604));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 18, 24, 45, 413, DateTimeKind.Utc).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 414, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 414, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 19, 24, 45, 414, DateTimeKind.Local).AddTicks(364));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 19, 24, 45, 212, DateTimeKind.Local).AddTicks(3158), "AQAAAAIAAYagAAAAEC4pUyEVw4Jlp4I7s1dm91IGWwz5rblGjrcyxGGU53xeMybqorCGzWYqDNhl7bPdZQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 19, 24, 45, 313, DateTimeKind.Local).AddTicks(6865), "AQAAAAIAAYagAAAAEJRULaYrUj+R2a+7KV85cAIq4Ex1CgyRbVqPU6LgyixreaMYMv4V66ptoDoJkHzxnA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 19, 24, 45, 413, DateTimeKind.Local).AddTicks(7774), "AQAAAAIAAYagAAAAEIbyQ8Ec1jS4ZKeGUbWEqzx3SCmlZjGjlg6BtotcfSKW+3uKcG8WnZuz+MAHo7V2+g==" });
        }
    }
}
