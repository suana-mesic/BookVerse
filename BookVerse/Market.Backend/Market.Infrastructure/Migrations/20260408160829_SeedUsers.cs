using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 198, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 198, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 198, DateTimeKind.Local).AddTicks(9582));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6953), new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6947) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(7036), new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6989) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 8, 16, 8, 28, 588, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 8, 16, 8, 28, 588, DateTimeKind.Utc).AddTicks(6078));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 8, 16, 8, 28, 588, DateTimeKind.Utc).AddTicks(6081));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6769));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Email", "LastName", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 8, 18, 8, 28, 298, DateTimeKind.Local).AddTicks(2569), "admin@bookverse.com", "admin", "AQAAAAIAAYagAAAAEPmTMpNasxsgKQcrCmizgSzkhvfi9G2Fvjw3/234yJDcTRwHBqYRgSht4EqrAZ+VTQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Email", "FirstName", "IsManager", "LastName", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 8, 18, 8, 28, 395, DateTimeKind.Local).AddTicks(6442), "manager@bookverse.com", "manager", true, "manager", "AQAAAAIAAYagAAAAEH8YB4crBCfr8s9kTWUsvlWczV2vu4/y6SEv3Yg2T9LzdTagUPu8pMXSnATqoQ4HEw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsManager", "LastName", "PasswordHash" },
                values: new object[] { 3, new DateTime(2026, 4, 8, 18, 8, 28, 491, DateTimeKind.Local).AddTicks(7116), "korisnik@bookverse.com", "korisnik", false, "korisnik", "AQAAAAIAAYagAAAAENbTpIr/+apvfV5Rdv4A71qZxXEgjL9S4/GDomDO0jVaT0Xcu2RWTGifGmu6cEtYUw==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsDeleted", "IsEmployee", "IsEnabled", "LastName", "ModifiedAtUtc", "PasswordHash", "TwoFactorCode", "TwoFactorCodeExpiresAtUtc", "TwoFactorEnabled" },
                values: new object[] { 4, 1, new DateTime(2026, 4, 8, 18, 8, 28, 588, DateTimeKind.Local).AddTicks(4120), "uposlenik@bookverse.com", "uposlenik", false, true, true, "uposlenik", null, "AQAAAAIAAYagAAAAEPUBfEPsixcN/yatYcODvEZWOVKgs2eAsZN/d6fN/owDM8zaWBlsTcM3Pu/6IIjYhw==", null, null, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3570));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 51, 849, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4491));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5998), new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(6030), new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(6026) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 3, 16, 17, 59, 52, 144, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5825));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "Email", "LastName", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 16, 18, 59, 51, 945, DateTimeKind.Local).AddTicks(5104), "admin@gmail.com", "user", "AQAAAAIAAYagAAAAEEWzyVId0mB4rgHUR+DwtPCjjYKYIjfXKZ+XMPRn4v9n4lwsNXnPUFiL0n0HufarRw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "Email", "FirstName", "IsManager", "LastName", "PasswordHash" },
                values: new object[] { new DateTime(2026, 3, 16, 18, 59, 52, 46, DateTimeKind.Local).AddTicks(792), "string", "string", false, "string", "AQAAAAIAAYagAAAAEK0DoNoi/QVZf+q7sAFGd0kFnGcI4q1P+g81n87eNs6xIcLoxkbOpoz2Tbh7PLm2nw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddressId", "CreatedAtUtc", "Email", "FirstName", "IsManager", "LastName", "PasswordHash" },
                values: new object[] { 2, new DateTime(2026, 3, 16, 18, 59, 52, 144, DateTimeKind.Local).AddTicks(3010), "manager@gmail.com", "manager", true, "user", "AQAAAAIAAYagAAAAECDP0GBm2CLsOqlXC1IQZpzQ+uaPAdAQyyHOLZkW3uy1uoMJCXe34CFPPpG35z5ibQ==" });
        }
    }
}
