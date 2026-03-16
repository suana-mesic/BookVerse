using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedAtPropertyInReviewsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5998), new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(6030), new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "DatePosted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4935), null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "DatePosted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4938), null });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "DatePosted", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4941), null });

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 16, 18, 59, 51, 945, DateTimeKind.Local).AddTicks(5104), "AQAAAAIAAYagAAAAEEWzyVId0mB4rgHUR+DwtPCjjYKYIjfXKZ+XMPRn4v9n4lwsNXnPUFiL0n0HufarRw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 16, 18, 59, 52, 46, DateTimeKind.Local).AddTicks(792), "AQAAAAIAAYagAAAAEK0DoNoi/QVZf+q7sAFGd0kFnGcI4q1P+g81n87eNs6xIcLoxkbOpoz2Tbh7PLm2nw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(3010), "AQAAAAIAAYagAAAAECDP0GBm2CLsOqlXC1IQZpzQ+uaPAdAQyyHOLZkW3uy1uoMJCXe34CFPPpG35z5ibQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reviews");

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
    }
}
