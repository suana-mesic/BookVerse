using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_StoreInventory_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 197, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 197, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 197, DateTimeKind.Local).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4777));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(5265));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 17, 52, 58, 492, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 17, 52, 58, 492, DateTimeKind.Utc).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 17, 52, 58, 492, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6182));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 18, 52, 58, 294, DateTimeKind.Local).AddTicks(4947), "AQAAAAIAAYagAAAAECj9kDIwIuQ71bfi+u+rwbm74QRI13moVDOMcNg74mOTq8DFWtUpnS9zPRBmovwKVg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 18, 52, 58, 392, DateTimeKind.Local).AddTicks(7715), "AQAAAAIAAYagAAAAECO29ETte3qWaYD/8PBkKqe7zLsdgd0B4wdhamJtLbCegGvC3EMdSWQJHedYiRCM2Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(2931), "AQAAAAIAAYagAAAAELYpGblodK350d0UMHK30RIOnT8NyHs/mNSZYiy7IMsH8TQCd3LAsLNkk2N1L9ohBA==" });
        }
    }
}
