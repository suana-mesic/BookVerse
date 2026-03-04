using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Location_In_StoreInventory_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "StoreInventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 260, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5506));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6442));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 4, 13, 25, 28, 739, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 425, DateTimeKind.Local).AddTicks(4240), "AQAAAAIAAYagAAAAEGm7jfZheLinT6oxC33y2nlv6/cQKWQl7Pg5oJzBubdBeQdA63fzajY4jDtlkLXnWQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 600, DateTimeKind.Local).AddTicks(7256), "AQAAAAIAAYagAAAAEOYtGe8WL9BCAdrfkAcjMjJhlrZFJlp2YeUmQIP7ymrC/EBOJvruJwXBjOfH6KB9dA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 4, 14, 25, 28, 739, DateTimeKind.Local).AddTicks(4619), "AQAAAAIAAYagAAAAEP8e6ITvs5hBYCHK0Qm3K6MqiVwqgPudMyd5cuGrpDTYRsoNAIKNC5dKbgvCXQr9AQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "StoreInventory");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 160, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 160, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 160, DateTimeKind.Local).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9786));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(128));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 464, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 1, 13, 45, 27, 464, DateTimeKind.Utc).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 1, 13, 45, 27, 464, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 1, 13, 45, 27, 464, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 1, 14, 45, 27, 261, DateTimeKind.Local).AddTicks(508), "AQAAAAIAAYagAAAAEL2abRhsuD8zTYcR+BZMn+pk3EYL2Z7jbsA+dsAtYexi9ss5GrA0Gn/dtuLlk6KwBA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 1, 14, 45, 27, 361, DateTimeKind.Local).AddTicks(5078), "AQAAAAIAAYagAAAAEJUEIlnJzv+YPq2uP9q5nwFjlP7nsvMUhUvfEVErPznODOMjCW5LxQv893CTy/9HHA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 1, 14, 45, 27, 463, DateTimeKind.Local).AddTicks(8515), "AQAAAAIAAYagAAAAEI/Vik7ITR3j7m780+MxrTmWko4buKAPSOJdkS9mSA/JgHJTN7Ynk3G2U8w3Q/gY9Q==" });
        }
    }
}
