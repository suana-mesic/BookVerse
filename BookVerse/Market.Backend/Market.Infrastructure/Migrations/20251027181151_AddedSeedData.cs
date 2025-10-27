using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2025, 10, 27, 19, 11, 50, 354, DateTimeKind.Local).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2025, 10, 27, 19, 11, 50, 354, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreatedAtUtc", "IsDeleted", "Line1", "Line2", "ModifiedAtUtc" },
                values: new object[] { 3, "Jablanica", "BiH", new DateTime(2025, 10, 27, 19, 11, 50, 354, DateTimeKind.Local).AddTicks(1830), false, "Gornja Kolonija SP 100", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 27, 19, 11, 50, 450, DateTimeKind.Local).AddTicks(9193), "AQAAAAIAAYagAAAAEMYEyN+DhRoc4qjHJEjwyCt9JvSl9yEm2eQp59z1kcqQeVVKoZeCniWZNefuMtb+1w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 27, 19, 11, 50, 549, DateTimeKind.Local).AddTicks(9603), "AQAAAAIAAYagAAAAEPjfPp0QbKjo+i8vcOAlq9Cz8LjgpAvHU5pfwxyidh1N2bNP/AbTJ9zXiLsLJmVUQQ==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsAdmin", "IsDeleted", "IsEmployee", "IsEnabled", "IsManager", "LastName", "ModifiedAtUtc", "PasswordHash", "TokenVersion" },
                values: new object[] { 3, 2, new DateTime(2025, 10, 27, 19, 11, 50, 647, DateTimeKind.Local).AddTicks(2750), "string@gmail.com", "manager@market.local", false, false, true, true, true, "string", null, "AQAAAAIAAYagAAAAEOv4zTUubxggjpkWCnM6N5H/J+xURyOJhxs+iO006IluzFq1MLBAggXIcuSUFhK7Ag==", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2025, 10, 27, 18, 52, 41, 178, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2025, 10, 27, 18, 52, 41, 178, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 52, 41, 291, DateTimeKind.Local).AddTicks(7819), "AQAAAAIAAYagAAAAEEMp+EUIp8wIvFz6c9qfC0ojT8Huj1Z7zdmrUZ+mKkILn+ehPLG4Nf7OSN/IpKhMCQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2025, 10, 27, 18, 52, 41, 400, DateTimeKind.Local).AddTicks(1761), "AQAAAAIAAYagAAAAEJXPoiAUCN+MDocXpBDSsoVXhF2FyZtYMvjmOSyqFIvcQ3LQjqO4DTu50O0D55BAsg==" });
        }
    }
}
