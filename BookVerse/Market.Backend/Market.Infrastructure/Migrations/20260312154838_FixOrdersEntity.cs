using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrdersEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingMethodId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PickupStoreId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 36, 807, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 36, 807, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 36, 807, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6939));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8687), new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8715), new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8712) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 15, 48, 37, 99, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 15, 48, 37, 99, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 15, 48, 37, 99, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 16, 48, 36, 905, DateTimeKind.Local).AddTicks(8047), "AQAAAAIAAYagAAAAEM2V/9x38QM/ya6YBJYRTu5Vaq2rIp/u2XBVOqwq13OW249xP7HxgKcVDiucAqPezw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 16, 48, 37, 2, DateTimeKind.Local).AddTicks(5599), "AQAAAAIAAYagAAAAEEjMcYJRmDWKU4JmLdv566Ebe/Hx+F3iSVIal6GFxOZ3TbFOtoTGerAKs4PkswwNUw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 16, 48, 37, 99, DateTimeKind.Local).AddTicks(5519), "AQAAAAIAAYagAAAAEPg/ixYVpV25zZUiE08sULU0iwiGH3qSIALYFpng3QdQgQNEH9qHdOepCxwu19WzIQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PickupStoreId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingMethodId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingMethods_ShippingMethodId",
                table: "Orders",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
