using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixOrdersEntity_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 430, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(765));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2037));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1709));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3482), new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3559), new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1086));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 12, 16, 24, 4, 731, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.InsertData(
                table: "StoreInventory",
                columns: new[] { "BookId", "StoreId", "IsDeleted", "LastRestocked", "Location", "QuantityInStock", "ReorderTreshold" },
                values: new object[,]
                {
                    { 2, 1, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3159), "Polica A-21", 200, 5 },
                    { 3, 1, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3175), "Polica A-31", 70, 5 },
                    { 2, 2, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3163), "Polica A-22", 210, 5 },
                    { 3, 2, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3180), "Polica A-32", 90, 5 },
                    { 2, 3, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3170), "Polica A-23", 240, 5 },
                    { 3, 3, false, new DateTime(2026, 3, 12, 17, 24, 4, 731, DateTimeKind.Local).AddTicks(3190), "Polica A-33", 80, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 527, DateTimeKind.Local).AddTicks(6204), "AQAAAAIAAYagAAAAEKm8wb4KvFGsxLEy8Ik8rnpWZdcYncBXsKLTHDo65vvBZau/W+zOaybhNJYY/XppPg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 624, DateTimeKind.Local).AddTicks(5902), "AQAAAAIAAYagAAAAEAl1woeHwV5Aw/TMLY4ZA7ACaagy7E96lITEG+qzTBO3g4tc9CprBT1iLIQD9zqtow==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 12, 17, 24, 4, 730, DateTimeKind.Local).AddTicks(9299), "AQAAAAIAAYagAAAAEAvLScq2Xi6P4XbSNMQA/5pKlQTcmAqJq4LID36IWrEVbo8eyfvINx8tXNykuQlltg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 });

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
        }
    }
}
