using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoFactorToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwoFactorCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TwoFactorCodeExpiresAtUtc",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 437, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 438, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 438, DateTimeKind.Local).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6098));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6788));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 12, 7, 1, 744, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 12, 7, 1, 744, DateTimeKind.Utc).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 12, 7, 1, 744, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 538, DateTimeKind.Local).AddTicks(8412), "AQAAAAIAAYagAAAAEBNUqJUmxdh3z0et1NDOzH3waUbpMVB9QTRyOAZk4T4uwLXwtwXCx1gxPw7SpWqN0A==", null, null, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 639, DateTimeKind.Local).AddTicks(2599), "AQAAAAIAAYagAAAAEGTfg8sIiUoAAwpfLJCzb+yP7Z1pqwt0CMK9+3hgqxV61gBQtsgb144JflLMS6YyfQ==", null, null, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(5234), "AQAAAAIAAYagAAAAEBtZgAIugBXt7iKOk8fP3cMaU2u6DuLvT/0Ll5q099sWfgT4UoSsA3CX9nMDwtWLVQ==", null, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoFactorCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorCodeExpiresAtUtc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 25, 770, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 25, 770, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 25, 770, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2355));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 25, 13, 47, 26, 64, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 25, 13, 47, 26, 64, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 25, 13, 47, 26, 64, DateTimeKind.Utc).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 47, 25, 868, DateTimeKind.Local).AddTicks(3817), "AQAAAAIAAYagAAAAEGX89OuCkxXlwDLG4OvD4zwHfHkxZwVmCUvClJNYcpGxDWgyVeG9lS8VfNigPPXd5w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 47, 25, 967, DateTimeKind.Local).AddTicks(1321), "AQAAAAIAAYagAAAAEJY8bsnHYigHR3YGP75A944uyv2pN8cN+s9YNggLTZNzEQ4dSl3JaC0nTUdodszhyA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 25, 14, 47, 26, 64, DateTimeKind.Local).AddTicks(1035), "AQAAAAIAAYagAAAAEM5Gka8xykulw8g/RZHQRCzfN/Ug6hxH/b6e9sr94QzMV+jQ1frowqqlelJgKmFiQQ==" });
        }
    }
}
