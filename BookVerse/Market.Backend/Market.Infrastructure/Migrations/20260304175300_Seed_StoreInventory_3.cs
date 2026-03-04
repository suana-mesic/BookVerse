using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_StoreInventory_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreInventory",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "IsDeleted", "LastRestocked" },
                values: new object[] { false, new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "IsDeleted", "LastRestocked" },
                values: new object[] { false, new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6182) });

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "IsDeleted", "LastRestocked" },
                values: new object[] { false, new DateTime(2026, 3, 4, 18, 52, 58, 492, DateTimeKind.Local).AddTicks(6191) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreInventory");

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

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 4, 15, 58, 44, 830, DateTimeKind.Local).AddTicks(6769));

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
    }
}
