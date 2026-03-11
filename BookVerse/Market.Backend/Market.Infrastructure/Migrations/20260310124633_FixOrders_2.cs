using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrders_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 58, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 58, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 58, DateTimeKind.Local).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6372));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6515));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6525));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7318), new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7334), new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7331) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5496));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 12, 46, 32, 358, DateTimeKind.Utc).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 12, 46, 32, 358, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 12, 46, 32, 358, DateTimeKind.Utc).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 13, 46, 32, 157, DateTimeKind.Local).AddTicks(3061), "AQAAAAIAAYagAAAAED4X51O5sl+vjn/K0xFEpTvIucsmdVJ0TU0acAeKhZOOi54LeJiXy6ExGXIXvFhwag==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 13, 46, 32, 253, DateTimeKind.Local).AddTicks(9240), "AQAAAAIAAYagAAAAEDjQvy/dL/l84H2rCaZlPRUEkgfC/XhddTKFb3MlBm2X45c3+IFM2KWTFqm98e7Kfg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 13, 46, 32, 358, DateTimeKind.Local).AddTicks(3761), "AQAAAAIAAYagAAAAEAvdFfqUwZ0S8w/mKqhBXr39BCgH1ecX1KWe6Vq0eA5FYmyDv+hyG/OmbCf7ZGFqtg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 673, DateTimeKind.Local).AddTicks(1379));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1436));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1274));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2809), new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2805) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2838), new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2835) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 10, 11, 53, 1, 966, DateTimeKind.Utc).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 10, 12, 53, 1, 966, DateTimeKind.Local).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 771, DateTimeKind.Local).AddTicks(9875), "AQAAAAIAAYagAAAAEF8fCoVSdcS6VTIsKwA8JR4GDhSKON2c7rN82S9FtFsXLTbpTzPwU7h9UyGHdS/ufg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 869, DateTimeKind.Local).AddTicks(9153), "AQAAAAIAAYagAAAAEOslrupj9rXIFEYgC1U5XCaxccuUjQ0SAGozeSHEqAU61qw8c3z0N5I5ZDNMP0iE9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 10, 12, 53, 1, 965, DateTimeKind.Local).AddTicks(9752), "AQAAAAIAAYagAAAAEBxNQpmbIOlSufjn14E8hVyjUiQpSv8Hu+xZHcqIGgAUQ3+HIeHdgdYEzhQjNHvbeA==" });
        }
    }
}
