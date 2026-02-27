using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSavedForLaterToCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAtUtc",
                table: "CartItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SavedForLater",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 201, DateTimeKind.Local).AddTicks(1111), "AQAAAAIAAYagAAAAEHjYIbxX/N6tdgu5k+ZLDyKs6hHVxcGftKDnojg6HxbyFck3Ed3OpUMVdmbJ5VDbDQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 376, DateTimeKind.Local).AddTicks(3056), "AQAAAAIAAYagAAAAEGw9mhgPHSmiAmrbbl9Q3nSoyg6TN8ph6I1dS8mMZplKlujVsOX4p+KzTYLS60+c5w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(2621), "AQAAAAIAAYagAAAAEE1Akp6T8n0sZ/pFKnDWiv20UGEBta0fo+HG5NPEJECWGqnLxb4a5NI0hza0+hv1Tg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ModifiedAtUtc",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "SavedForLater",
                table: "CartItems");

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
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 538, DateTimeKind.Local).AddTicks(8412), "AQAAAAIAAYagAAAAEBNUqJUmxdh3z0et1NDOzH3waUbpMVB9QTRyOAZk4T4uwLXwtwXCx1gxPw7SpWqN0A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 639, DateTimeKind.Local).AddTicks(2599), "AQAAAAIAAYagAAAAEGTfg8sIiUoAAwpfLJCzb+yP7Z1pqwt0CMK9+3hgqxV61gBQtsgb144JflLMS6YyfQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 13, 7, 1, 744, DateTimeKind.Local).AddTicks(5234), "AQAAAAIAAYagAAAAEBtZgAIugBXt7iKOk8fP3cMaU2u6DuLvT/0Ll5q099sWfgT4UoSsA3CX9nMDwtWLVQ==" });
        }
    }
}
