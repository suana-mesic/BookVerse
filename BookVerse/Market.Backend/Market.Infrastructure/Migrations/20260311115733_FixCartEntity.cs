using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCartEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ModifiedAtUtc",
                table: "Carts");

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

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 495, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 495, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 495, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1941));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3352), new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3338) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3394), new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3387) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1266));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 57, 31, 888, DateTimeKind.Utc).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 57, 31, 888, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 57, 31, 888, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 57, 31, 888, DateTimeKind.Local).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 57, 31, 604, DateTimeKind.Local).AddTicks(8605), "AQAAAAIAAYagAAAAEMOgrotW2t6z5ccYWf93g+azjOp9RmKAUelyTtUTmWCMKhrK3VeheupwaQ6JuTFrkw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 57, 31, 728, DateTimeKind.Local).AddTicks(7127), "AQAAAAIAAYagAAAAEA+uJGZ8nqQ4DqOmAH3wN3goHqUoG78i1BX4H8ETX5p7w1jAkt+uYZ6RVoOMfCUNXQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 57, 31, 887, DateTimeKind.Local).AddTicks(9430), "AQAAAAIAAYagAAAAEJxph6CK+tANE1/7bO+mZAFIGs2bQM/irStQvM7+Lp1cYiH4WiQucIDEfOtyeRbzvw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAtUtc",
                table: "Carts",
                type: "datetime2",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 71, DateTimeKind.Local).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 71, DateTimeKind.Local).AddTicks(1733));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 71, DateTimeKind.Local).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(3751));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5521), new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5557), new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5552) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 28, 16, 480, DateTimeKind.Utc).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 28, 16, 480, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 11, 11, 28, 16, 480, DateTimeKind.Utc).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 28, 16, 217, DateTimeKind.Local).AddTicks(1887), "AQAAAAIAAYagAAAAEMKy5eyyhWmsvJlpDTNhQrJO1tyVj4eEaZQcW99gj1mjFmwG6gZwudHnDT33TYIvaQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 28, 16, 356, DateTimeKind.Local).AddTicks(4370), "AQAAAAIAAYagAAAAEF0WdmpSP0tNeDI1lPOcAZv+eUeM3uVRgu2yhymiB1wqawKVYnfzk71VeRuVfyx1Ug==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 11, 12, 28, 16, 480, DateTimeKind.Local).AddTicks(2537), "AQAAAAIAAYagAAAAEB8iLhH4cAUF0DDooakvWZeHJuvsLZcq3UevMPso0467Z5WC6BuvKwDf3PsJ4GFRBw==" });
        }
    }
}
