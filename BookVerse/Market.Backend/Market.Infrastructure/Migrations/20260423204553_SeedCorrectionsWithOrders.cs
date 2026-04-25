using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCorrectionsWithOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 364, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 364, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 364, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4222));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4231));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9892));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9897));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(648));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(1232));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 906, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9467));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9569));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9766));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9781));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9038));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9956));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4056), new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4102), new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(4097) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9318));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 20, 45, 50, 906, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 20, 45, 50, 906, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 20, 45, 50, 906, DateTimeKind.Utc).AddTicks(1427));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(133));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(258));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3865));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(213));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 50, 907, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(129));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(180));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(217));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 22, 45, 51, 533, DateTimeKind.Local).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 50, 505, DateTimeKind.Local).AddTicks(3509), "AQAAAAIAAYagAAAAEOsp8+lhrAxAiqofddFxSCqG7esr5cfA51nCV2qRxY5KbCjC7+v6zEZ005YLuWEr4g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 50, 629, DateTimeKind.Local).AddTicks(3547), "AQAAAAIAAYagAAAAEEUoBS1+6dL0MCh2lbMv9pyogJIhdHBAJhtNQODt6W3tW33xsK6gkKIPKa06FJU7CA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 50, 750, DateTimeKind.Local).AddTicks(1004), "AQAAAAIAAYagAAAAEJf3KTkGatlugdxxdirnA4EhVVEapjlp0D8PhMzqpUsAkNgF5HeKkjQw8lfqilE37w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 50, 905, DateTimeKind.Local).AddTicks(8722), "AQAAAAIAAYagAAAAEI71VIeh26q/dllv/nEuYmsNmxS3HpB5miWWeau6tpxUIuGMPEbFxdchwqjIiMjCLw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 51, 27, DateTimeKind.Local).AddTicks(3020), "AQAAAAIAAYagAAAAEOQ+lYSl5mpIkzsPzfYRn6oX/YNXAfJyrTNqWex8hN+bbqfcrLmNYhM/LD6SjuJrWQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 51, 140, DateTimeKind.Local).AddTicks(4651), "AQAAAAIAAYagAAAAELSqUywRGcsjV2x4nWncCy4lxrtmjx9bnpb6Tt+MLENN14TQ8qGka0iKZ4nVyVin4Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 51, 254, DateTimeKind.Local).AddTicks(4543), "AQAAAAIAAYagAAAAEISdueSBg8s3nTTVhKsWEAcShp5Qb5GUkbkI4Os/rZDZOsk/wsG/pBOBGMTvz14neg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 51, 405, DateTimeKind.Local).AddTicks(9144), "AQAAAAIAAYagAAAAEHfBBz2RSraI2P2a140cWLMM2rXudBdpa8U2vtILptEPv1Ll2ztzl8KRuD/ssa2k3Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 22, 45, 51, 532, DateTimeKind.Local).AddTicks(7965), "AQAAAAIAAYagAAAAECGNjqEXu/lUZMX48tasBFQ/G02KS2BHPaRkuY6qdVQbq1KhPP462YIV0zlH54kYsw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 472, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 472, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 472, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2759));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2764));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2768));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3039));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3189));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3351));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2614));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4602), new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4632), new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4630) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3246));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3253));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(3257));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 10, 45, 40, 861, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 10, 45, 40, 861, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 23, 10, 45, 40, 861, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3424));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3442));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3477));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3522));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3578));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3470));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3503));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3536));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3547));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 40, 570, DateTimeKind.Local).AddTicks(8573), "AQAAAAIAAYagAAAAEP64YWgsmJbg+R4PF0LWe3vK14PJhl84+GPMVAqCOVgJYG9i1FNPInyWKYmwSqzJUg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 40, 668, DateTimeKind.Local).AddTicks(592), "AQAAAAIAAYagAAAAEI0LOHLIovo4mhsbAH2aBtWC7eCyzUMNkZiyCDhA9ozBwls2hLEaZKY2hDyR93aNhg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 40, 764, DateTimeKind.Local).AddTicks(7172), "AQAAAAIAAYagAAAAEFSKzBxRbEcS8n8Mjn0t+2C05ckmqia7w2WcJcYaU7X6NefH1E4jUAXjn6CeeJ8DuA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 40, 861, DateTimeKind.Local).AddTicks(2453), "AQAAAAIAAYagAAAAEEXhneN88IqqGrKe1Hkn69j+fAMii0D17uq9hyRX67hXK5k3GL6mqf2h73Uvoc1kcQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 40, 957, DateTimeKind.Local).AddTicks(6571), "AQAAAAIAAYagAAAAEEmCHsnw8p9jJP5+uTbBk+XiibOGOaXSFCWKO3bt0uisXlW37EpOLSbyjrcxOGy2DA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 41, 53, DateTimeKind.Local).AddTicks(8071), "AQAAAAIAAYagAAAAEORXaD5L3+X+Po4RVcItEz1uYJeqYfgPp8AeqaFh9tF9AqVMQYbsB3TVroqXfxUu9A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 41, 150, DateTimeKind.Local).AddTicks(9500), "AQAAAAIAAYagAAAAEFom2WC1AdwPsBr2uLo1Zi7Rud0xQColVzTcVHUcUbol9AJ9pBH+Q+lVE0g35wB+mw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 41, 248, DateTimeKind.Local).AddTicks(2092), "AQAAAAIAAYagAAAAEA9TImYb4zfzv5g4EFmmfDLCd9iNJvFItOVFev0doLMqrlSC6nwdUehvGFWQgQsWZA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 23, 12, 45, 41, 344, DateTimeKind.Local).AddTicks(1774), "AQAAAAIAAYagAAAAEOP4nC92RiG7h8uUIcFmz+pdJJiNxlYRQijmvEA7Ws2BTAl58C5C3BBcKD5gBTxLSg==" });
        }
    }
}
