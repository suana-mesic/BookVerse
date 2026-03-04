using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_StoreInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 50, 895, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 50, 895, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 50, 895, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9944));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9104));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9343));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 48, 51, 263, DateTimeKind.Utc).AddTicks(211));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 48, 51, 263, DateTimeKind.Utc).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 48, 51, 263, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.InsertData(
                table: "StoreInventory",
                columns: new[] { "BookId", "StoreId", "LastRestocked", "Location", "QuantityInStock", "ReorderTreshold" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(744), "Polica A-5", 50, 5 },
                    { 2, 1, new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(760), "Polica A-10", 70, 5 },
                    { 3, 1, new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(766), "Polica A-7", 60, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 48, 51, 3, DateTimeKind.Local).AddTicks(7654), "AQAAAAIAAYagAAAAEO63Qdc0MfEzrsUgjznc9UBRmSK55Xv6PqCzN603B1xMYsoUcJHNXeGsvnm2sikS0Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 48, 51, 140, DateTimeKind.Local).AddTicks(8903), "AQAAAAIAAYagAAAAEBX1JgoqJqWO/8XGNS+i0+gj/4E7iWIEzRBpMHsXsu9qj8ZaMeDcIO28OZd7g3YEBg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 48, 51, 262, DateTimeKind.Local).AddTicks(8080), "AQAAAAIAAYagAAAAEBUQWSWtXpps3CoAj0UldN+93K0MHZQ9eQ5pw1Sva6PNxl0Q6fFXrEBwNPqVVb14Hg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 425, DateTimeKind.Local).AddTicks(4240), "AQAAAAIAAYagAAAAEGm7jfZheLinT6oxC33y2nlv6/cQKWQl7Pg5oJzBubdBeQdA63fzajY4jDtlkLXnWQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 600, DateTimeKind.Local).AddTicks(7256), "AQAAAAIAAYagAAAAEOYtGe8WL9BCAdrfkAcjMjJhlrZFJlp2YeUmQIP7ymrC/EBOJvruJwXBjOfH6KB9dA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(4619), "AQAAAAIAAYagAAAAEP8e6ITvs5hBYCHK0Qm3K6MqiVwqgPudMyd5cuGrpDTYRsoNAIKNC5dKbgvCXQr9AQ==" });
        }
    }
}
