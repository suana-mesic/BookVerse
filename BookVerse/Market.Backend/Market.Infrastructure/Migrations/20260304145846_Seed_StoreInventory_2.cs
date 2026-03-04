using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_StoreInventory_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2026, 3, 4, 15, 58, 44, 482, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 482, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 482, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5801));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 58, 44, 830, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 58, 44, 830, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 14, 58, 44, 830, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.InsertData(
                table: "StoreInventory",
                columns: new[] { "BookId", "StoreId", "LastRestocked", "Location", "QuantityInStock", "ReorderTreshold" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(6763), "Polica A-12", 90, 5 },
                    { 1, 3, new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(6769), "Polica A-15", 40, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 58, 44, 606, DateTimeKind.Local).AddTicks(5126), "AQAAAAIAAYagAAAAEFfBBwWzjUORYBoEjxE2pKTpYfRQp28gM/hDoB3sdzRi7lOW3V1u9AAmp77FuyXh/A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 58, 44, 718, DateTimeKind.Local).AddTicks(9527), "AQAAAAIAAYagAAAAEG75YWckdCYd6wjTI/1tVKMGRNjF6p99y2JUk/RStkxWQco5apn5pykB0mzbZ4A7XQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(4294), "AQAAAAIAAYagAAAAEAvACbaBuEKJ1A7cvs6S1NJ0ur7dzM52yoxO1t0ZwW5Aw+09GamAH306tMIibsqIyg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 });

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

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 15, 48, 51, 263, DateTimeKind.Local).AddTicks(744));

            migrationBuilder.InsertData(
                table: "StoreInventory",
                columns: new[] { "BookId", "StoreId", "LastRestocked", "Location", "QuantityInStock", "ReorderTreshold" },
                values: new object[,]
                {
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
    }
}
