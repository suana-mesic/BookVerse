using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrdersEntity_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentSummaries_PaymentSummaryId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentSummaryId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 407, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 407, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 407, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9843), new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9838) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9871), new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9867) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 5, 23, 701, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 5, 23, 701, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 5, 23, 701, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(9715));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 5, 23, 503, DateTimeKind.Local).AddTicks(8639), "AQAAAAIAAYagAAAAECxc2OGs9V8EKgxHkOhxipYsOqOzACi58X7w/dr3XwCDCmou+mPGmu/d6YpHoG3VzA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 5, 23, 603, DateTimeKind.Local).AddTicks(2059), "AQAAAAIAAYagAAAAENV5Q/GMwm6XPYXVv1BQ0jlyOjk7Gx5QvihXNUqpo58frIQq0e1L1rXCkjgaFMCNWg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 5, 23, 701, DateTimeKind.Local).AddTicks(6844), "AQAAAAIAAYagAAAAEDDl2o/SaKnqAE7g5AfIkE88KsmQd/HtMXlo48Aisy1DNNzKhkXz2UlwcoFQdzONPA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentSummaries_PaymentSummaryId",
                table: "Orders",
                column: "PaymentSummaryId",
                principalTable: "PaymentSummaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentSummaries_PaymentSummaryId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentSummaryId",
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
                name: "FK_Orders_PaymentSummaries_PaymentSummaryId",
                table: "Orders",
                column: "PaymentSummaryId",
                principalTable: "PaymentSummaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
