using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Orders");

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
    }
}
