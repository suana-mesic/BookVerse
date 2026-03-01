using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Shipping_Methods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "Id", "CreatedAtUtc", "Description", "IsDeleted", "ModifiedAtUtc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domaća kurirska služba sa brzom dostavom na području cijele BiH (1–2 radna dana). Pogodno za pakete i dokumente.", false, null, "Express One", 9.50m },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brza pošta sa dostavom širom Bosne i Hercegovine u roku 24–48h. Često korištena za online trgovine.", false, null, "X Express", 8.00m },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kurirska služba sa dostavom na području cijele BiH u roku 24–48h, uz mogućnost plaćanja pouzećem.", false, null, "EuroExpress", 9.00m }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 50, DateTimeKind.Local).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 2, 26, 15, 9, 27, 538, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 201, DateTimeKind.Local).AddTicks(1111), "AQAAAAIAAYagAAAAEHjYIbxX/N6tdgu5k+ZLDyKs6hHVxcGftKDnojg6HxbyFck3Ed3OpUMVdmbJ5VDbDQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 376, DateTimeKind.Local).AddTicks(3056), "AQAAAAIAAYagAAAAEGw9mhgPHSmiAmrbbl9Q3nSoyg6TN8ph6I1dS8mMZplKlujVsOX4p+KzTYLS60+c5w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 26, 16, 9, 27, 538, DateTimeKind.Local).AddTicks(2621), "AQAAAAIAAYagAAAAEE1Akp6T8n0sZ/pFKnDWiv20UGEBta0fo+HG5NPEJECWGqnLxb4a5NI0hza0+hv1Tg==" });
        }
    }
}
