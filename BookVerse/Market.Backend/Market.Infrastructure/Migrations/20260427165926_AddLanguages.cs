using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 23, 914, DateTimeKind.Utc).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 23, 914, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 23, 914, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1313));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(807));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1455), "/images/books/dervis_i_smrt.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1567), "/images/books/na_drini_cuprija.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1574), "/images/books/basta_pepeo.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2361), "/images/books/novele_o_mutnim_vremenima.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2371), "/images/books/pobune_susic_dervis.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2377), "/images/books/ugursuz_ibrisimovic.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2383), "/images/books/sarajevo_blues.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2388), "/images/books/prokleta_avlija_andric.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2398), "/images/books/d0818_ostrvo.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2495), "/images/books/kad_vise_ne_bude_sutra.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2501), "/images/books/rama_2_klark.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2516), "/images/books/pjesme_santic.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2522), "/images/books/fond_solidarnosti.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2527), "/images/books/alea_senad_svraka.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2532), "/images/books/bostonci_dzejms.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2538), "/images/books/nosac_samuel_isak_lektira.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2543), "/images/books/grozdanin_kikot_humo.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2548), "/images/books/knjiga_vremena.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2554), "/images/books/plavi_kombi_nura_bazdulj.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2559), "/images/books/stendal_crveno_i_crno.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "LanguageId" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2565), "/images/books/zlocin_i_kazna_nova_knjiga.jpg", 4 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1929));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2203), new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2202) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2231), new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2230) });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedAtUtc", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(988), false, null, "Bosanski" },
                    { 2, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(991), false, null, "Engleski" },
                    { 3, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(993), false, null, "Njemački" },
                    { 4, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(995), false, null, "Srpski" },
                    { 5, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(997), false, null, "Hrvatski" },
                    { 6, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(999), false, null, "Francuski" },
                    { 7, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1001), false, null, "Španski" },
                    { 8, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1003), false, null, "Italijanski" },
                    { 9, new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1004), false, null, "Ruski" }
                });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(1686));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2829));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2840));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 11, DateTimeKind.Utc).AddTicks(1373), "AQAAAAIAAYagAAAAEK77Fl81yPCbV408+75lzg5OzMcZ0fCrYl0Be/BgwnupDl0AGdIYNxLx6t6mjtGKLQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 107, DateTimeKind.Utc).AddTicks(9861), "AQAAAAIAAYagAAAAENqo2Nc2x2xDueD1TAtBfLY43IJg+7FtzEcFh1qVsCP1E3wLFP6w+itRZ1sJ1w9qlg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 204, DateTimeKind.Utc).AddTicks(7864), "AQAAAAIAAYagAAAAEMDyGzqPcUKRAgifH51ZUpev2mab3VhMBEBoMTdAqiDaMCzMNwIsMemWBZQo8AJs7A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 302, DateTimeKind.Utc).AddTicks(243), "AQAAAAIAAYagAAAAEHZraKWpn8nFlaICBUVGswenIC0W4NEWezznRqd7JtCm1PEhkgGVYy7aLVVfV7vGdQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 398, DateTimeKind.Utc).AddTicks(3207), "AQAAAAIAAYagAAAAECCar3LFh+pLtxtrMUNrlhUmU8GGZ3AqNDkVxjdz9RXhBshK6Tk/MEWqJF6HWBGNsA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 494, DateTimeKind.Utc).AddTicks(4602), "AQAAAAIAAYagAAAAEAVPBi0C71Tl1Z6TlzXgPGcSX1X71an7GQIgXQgVUn+hqQblinJKoEI58d8swGasvA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 591, DateTimeKind.Utc).AddTicks(1999), "AQAAAAIAAYagAAAAEHGSjGYuibyg66EwC/q2mOuVmgWdGLy6iHgy5ClffCGQNjbnfdo4fKZR/3MxworLOw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 691, DateTimeKind.Utc).AddTicks(1566), "AQAAAAIAAYagAAAAEFG+6dXGOfhgMJ0+2R3VySEYCykfxPSqtUGDfnHNnfmZ65F9wUcTiTnPtS/HxPBOKQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 27, 16, 59, 24, 791, DateTimeKind.Utc).AddTicks(1222), "AQAAAAIAAYagAAAAEO+UI+XAog4/r0wqTzt7POlXD/svuSg2UkiWPlushrZYkGur9qfXFr9ybQCB6e3hGg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languages_LanguageId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 225, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 225, DateTimeKind.Utc).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 225, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(5043));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3722));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2975));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "BookFormats",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3226));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3875), "https://localhost:7260/images/books/dervis_i_smrt.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3885), "https://localhost:7260/images/books/na_drini_cuprija.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3893), "https://localhost:7260/images/books/basta_pepeo.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3343), "https://localhost:7260/images/books/novele_o_mutnim_vremenima.jpg", "Srpski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3352), "https://localhost:7260/images/books/pobune_susic_dervis.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3359), "https://localhost:7260/images/books/ugursuz_ibrisimovic.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3365), "https://localhost:7260/images/books/sarajevo_blues.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3370), "https://localhost:7260/images/books/prokleta_avlija_andric.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3383), "https://localhost:7260/images/books/d0818_ostrvo.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3388), "https://localhost:7260/images/books/kad_vise_ne_bude_sutra.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3394), "https://localhost:7260/images/books/rama_2_klark.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3407), "https://localhost:7260/images/books/pjesme_santic.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3414), "https://localhost:7260/images/books/fond_solidarnosti.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3420), "https://localhost:7260/images/books/alea_senad_svraka.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3425), "https://localhost:7260/images/books/bostonci_dzejms.jpg", "Srpski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3431), "https://localhost:7260/images/books/nosac_samuel_isak_lektira.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3436), "https://localhost:7260/images/books/grozdanin_kikot_humo.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3442), "https://localhost:7260/images/books/knjiga_vremena.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3447), "https://localhost:7260/images/books/plavi_kombi_nura_bazdulj.jpg", "Bosanski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3452), "https://localhost:7260/images/books/stendal_crveno_i_crno.jpg", "Srpski" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAtUtc", "ImageUrl", "Language" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3459), "https://localhost:7260/images/books/zlocin_i_kazna_nova_knjiga.jpg", "Srpski" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2848));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2854));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3555));

            migrationBuilder.UpdateData(
                table: "ChangeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3559));

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4884), new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2027, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4918), new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3437));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(3446));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAtUtc",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4009));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4013));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "BookId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DatePosted",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3709));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3729));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3765));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 1 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3714));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3758));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3826));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 2 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3859));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 1, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4611));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 2, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 3, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(4630));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 6, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 7, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 8, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3752));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 9, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 10, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 11, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 12, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 13, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 14, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 15, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 16, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3821));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 17, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 18, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 19, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 20, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "StoreInventory",
                keyColumns: new[] { "BookId", "StoreId" },
                keyValues: new object[] { 21, 3 },
                column: "LastRestocked",
                value: new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(3861));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 336, DateTimeKind.Utc).AddTicks(151), "AQAAAAIAAYagAAAAEGHWmCdlsIjPv3iVUai9FE+q+7T7O94Pul1coH4JjIEJYJAWIBF96GexA+AJPHNIbQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 469, DateTimeKind.Utc).AddTicks(1546), "AQAAAAIAAYagAAAAENC2BttYMWxdGluAVAYEIz0y0nRNEWKDo8SYhgic6aJ+UDCMjBgbifEpwveDO3TBkQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 599, DateTimeKind.Utc).AddTicks(7883), "AQAAAAIAAYagAAAAENS+KEhqBirpE2b5X7MBZBfD5sztTqszhr7p93ea6S1KxBdq8DRif46k9RkbNttLXA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 712, DateTimeKind.Utc).AddTicks(2298), "AQAAAAIAAYagAAAAELseudIfFKQplwP0bkdutpgOUbiVOTJ8WG8AsJQMDbSoU2lFt5G4ybPr97RlY/yzBw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 829, DateTimeKind.Utc).AddTicks(270), "AQAAAAIAAYagAAAAEEiUppPoX22XKPwjQEhrP4BZ/nHJKuZP32UhbL2D3ZWvB09TEtJ5Acv44KAd4KIr1w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 5, 958, DateTimeKind.Utc).AddTicks(6695), "AQAAAAIAAYagAAAAECwP85DVurXNR0dSOf53MNzAsK3f3Nn9w3iZeSsrT4c/TEQvn9Z37kEQDB0UN/dl2w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 72, DateTimeKind.Utc).AddTicks(5878), "AQAAAAIAAYagAAAAEJoi2Houe+51tncgoeeYC5CNYFOBPfKU40yRg/Fwm2GZe7HU1w3bOPzpb6ZV8TTvmQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 213, DateTimeKind.Utc).AddTicks(9381), "AQAAAAIAAYagAAAAEAhBv1g3vRnIAm1WNJVtsTYETSyZjl7xQHtSfT7Q1aF0+idxkM+pequNiyYHIA1axQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAtUtc", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 26, 20, 51, 6, 326, DateTimeKind.Utc).AddTicks(2098), "AQAAAAIAAYagAAAAEAXt3iVhGttH5CQR1YGt//QdU38bU+PIPZmaiGI8duxAY2PMEwuXLfhC602urfjtHA==" });
        }
    }
}
