using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsDeletedFromCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
