using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCorrectionsWithDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 26, 801, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 26, 801, DateTimeKind.Utc).AddTicks(329));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 26, 801, DateTimeKind.Utc).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5468), new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5467) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5503), new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6158));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6176));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6129));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6138));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6155));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6173));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 26, 910, DateTimeKind.Utc).AddTicks(5074), "AQAAAAIAAYagAAAAEFsSvvnUcWxH8pH6rGXL1FvgM2dDiBluPXlTcmwLGIFIOhjI3BwhkTLj77/QoI8RYg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 41, DateTimeKind.Utc).AddTicks(6522), "AQAAAAIAAYagAAAAEFYFLs5oD9dM4KoNqSxbnhw7c1Jfr2r2HVOVI3HA+QaOnwcuGGVKdGEZidh11GJ3Cw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 187, DateTimeKind.Utc).AddTicks(195), "AQAAAAIAAYagAAAAELO8DGiv0FqBBXTxwUvRkbmmACv5YhcrbkT1rTEtcYKi1WaNPW9dCnbUyX3olpl1bQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 319, DateTimeKind.Utc).AddTicks(2938), "AQAAAAIAAYagAAAAEGAEQG5d58urS2tX3fqrEVswWReDLULurgmK16UFmMIxIUSTk3sWc+MijpvAOJ8GRg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 449, DateTimeKind.Utc).AddTicks(9966), "AQAAAAIAAYagAAAAEODP0+ZxLJqXFcXK/L9fSl6LHWBKRMc36RM51n1IpskqTDW4j6a9B4DPxzaLLMDAFw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 566, DateTimeKind.Utc).AddTicks(4595), "AQAAAAIAAYagAAAAEMXhGzrURVabwftY1fq8RDJ3AXxXor0yZQnwTMcowWjDv84pE2eehzWG3gf1e8EMVQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 697, DateTimeKind.Utc).AddTicks(7165), "AQAAAAIAAYagAAAAEAEv3DVLFzf8Dw2LLucJ+a9idRp65UayPS2GDrTIWlMKeJEq1FS9jmE5cmUBdSRR2w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 806, DateTimeKind.Utc).AddTicks(5045), "AQAAAAIAAYagAAAAEBcooglnvdFcDVuW22PaBv/T1u0bWB21HPo6DZP506j1+0PjCO+/aSgNY9kQX6DxwA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 10, 4, 27, 925, DateTimeKind.Utc).AddTicks(4503), "AQAAAAIAAYagAAAAEG/AU0p8NxcDlzABnCY93ifXFMhZcwpgpmvFm6PcLrQWnkkJ6HBGHh5/xmeRFp/eOA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
