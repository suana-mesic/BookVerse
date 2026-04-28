using Market.Domain.Entities.Shopping;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Market.Application.Modules.Reports.Books
{
    public class GenerateBooksReportQueryHandler(IAppDbContext context)
        : IRequestHandler<GenerateBooksReportQuery, byte[]>
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _translations = new()
        {
            ["bs"] = new()
            {
                ["reportTitle"] = "Izvještaj o prodaji knjiga",
                ["book"] = "Knjiga",
                ["allBooks"] = "Sve knjige",
                ["orderId"] = "ID narudžbe",
                ["date"] = "Datum",
                ["qty"] = "Kol.",
                ["price"] = "Cijena",
                ["total"] = "Ukupno",
                ["totalQty"] = "Ukupno prodano",
                ["totalRevenue"] = "Ukupni prihod",
                ["unit"] = "kom",
                ["page"] = "Stranica",
                ["of"] = "od",
            },
            ["en"] = new()
            {
                ["reportTitle"] = "Book Sales Report",
                ["book"] = "Book",
                ["allBooks"] = "All books",
                ["orderId"] = "Order ID",
                ["date"] = "Date",
                ["qty"] = "Qty.",
                ["price"] = "Price",
                ["total"] = "Total",
                ["totalQty"] = "Total sold",
                ["totalRevenue"] = "Total revenue",
                ["unit"] = "pcs",
                ["page"] = "Page",
                ["of"] = "of",
            },
        };

        private string translatePdf(string lang, string key)
        {
            var l = _translations.ContainsKey(lang) ? lang : "bs";
            return _translations[l].TryGetValue(key, out var val) ? val : key;
        }

        public async Task<byte[]> Handle(GenerateBooksReportQuery request, CancellationToken ct)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var lang = string.IsNullOrWhiteSpace(request.Language) ? "bs" : request.Language;

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateFromLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateFrom, timeZone);
            var dateToLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateTo, timeZone).Date.AddDays(-1);

            var query = context.OrderItems
                .AsNoTracking()
                .Include(x => x.Book)
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderStatus)
                .Where(x => x.Order.CreatedAtUtc >= request.DateFrom
                         && x.Order.CreatedAtUtc <= request.DateTo
                         && (x.Order.OrderStatus.StatusName == OrderStatusType.Paid || x.Order.OrderStatus.StatusName == OrderStatusType.Packed ||x.Order.OrderStatus.StatusName == OrderStatusType.Shipped));

            if(request.BookId.HasValue)
                query = query.Where(x => x.BookId == request.BookId);

            var items = await query
                .Include(x => x.Order)
                .Select(x => new
                {
                    x.OrderId,
                    DatumNarudžbe = x.Order.CreatedAtUtc,
                    x.Quantity,
                    x.PriceAtTime,
                    Ukupno = x.Quantity * x.PriceAtTime
                }).ToListAsync(ct);

            string bookTitle = translatePdf(lang, "allBooks");
            if (request.BookId.HasValue)
            {
                var title = await context.Books
                    .AsNoTracking()
                    .Where(b => b.Id == request.BookId.Value)
                    .Select(b => b.Title)
                    .FirstOrDefaultAsync(ct);
                if (!string.IsNullOrWhiteSpace(title))
                    bookTitle = title;
            }

            var ukupnoKolicina = items.Sum(x => x.Quantity);
            var ukupanPrihod = items.Sum(x => x.Ukupno);

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Column(h =>
                    {
                        h.Item().Text($"{translatePdf(lang, "reportTitle")}: {dateFromLocal:dd.MM.yyyy} - {dateToLocal:dd.MM.yyyy}")
                              .SemiBold().FontSize(16).FontColor(Colors.Green.Medium);
                        h.Item().PaddingTop(4).Text($"{translatePdf(lang, "book")}: {bookTitle}")
                              .FontSize(12).FontColor(Colors.Grey.Darken2);
                    });

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                                c.ConstantColumn(40);
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                foreach (var naziv in new[] { translatePdf(lang,"orderId"), translatePdf(lang,"date"), translatePdf(lang,"qty"), translatePdf(lang,"price"), translatePdf(lang,"total") })
                                    header.Cell().Background(Colors.Green.Medium).Padding(5)
                                        .Text(naziv).FontColor(Colors.White).SemiBold();
                            });

                            foreach (var item in items)
                            {
                                table.Cell().Padding(5).Text(item.OrderId.ToString());
                                table.Cell().Padding(5).Text(item.DatumNarudžbe.ToString("dd.MM.yyyy"));
                                table.Cell().Padding(5).Text(item.Quantity.ToString());
                                table.Cell().Padding(5).Text(item.PriceAtTime.ToString("F2"));
                                table.Cell().Padding(5).Text(item.Ukupno.ToString("F2"));
                            }
                        });

                        col.Item().PaddingTop(20).BorderTop(1).PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text($"{translatePdf(lang, "totalQty")}: {ukupnoKolicina} {translatePdf(lang, "unit")}").SemiBold();
                            row.RelativeItem().AlignRight().Text($"{translatePdf(lang, "totalRevenue")}: {ukupanPrihod:F2} KM").SemiBold();
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span($"{translatePdf(lang, "page")} ");
                        x.CurrentPageNumber();
                        x.Span($" {translatePdf(lang, "of")} ");
                        x.TotalPages();
                    });
                });
            });

            return pdf.GeneratePdf();
        }
    }
}
