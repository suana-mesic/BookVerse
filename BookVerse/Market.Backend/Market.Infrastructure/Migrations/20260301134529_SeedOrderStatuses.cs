using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrderStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "StatusName" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 3 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 405, DateTimeKind.Local).AddTicks(4856));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 405, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 405, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9036));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(8842));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 27, 13, 26, 23, 822, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 27, 13, 26, 23, 822, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 27, 13, 26, 23, 822, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 27, 14, 26, 23, 534, DateTimeKind.Local).AddTicks(8777), "AQAAAAIAAYagAAAAEHyQBqRvFhURdCJFfuQrURNt7pBkD35snRtu0IZlZBeT4gwQ6tLKBZ5Lyyh1uvWcTw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 27, 14, 26, 23, 664, DateTimeKind.Local).AddTicks(4025), "AQAAAAIAAYagAAAAEPrGlZT7AK33e+ZSmxeNMQm/XMDo8cKE9q2eRd3Nm1q0a1Pydgm42JMVs3vy5KUz+Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 27, 14, 26, 23, 822, DateTimeKind.Local).AddTicks(7362), "AQAAAAIAAYagAAAAEMmBE/SLhQ3VyX/ihmGy1hUNdnL5zDi+TFID+v88lZXle2Et6jn91K7FpGU1XufzuA==" });
        }
    }
}
