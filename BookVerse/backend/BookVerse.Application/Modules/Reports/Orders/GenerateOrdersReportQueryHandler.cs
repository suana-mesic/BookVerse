using BookVerse.Domain.Entities.Shopping;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace BookVerse.Application.Modules.Reports.Orders
{
    public class GenerateOrdersReportQueryHandler(IAppDbContext context)
    : IRequestHandler<GenerateOrdersReportQuery, byte[]>
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _translations = new()
        {
            ["bs"] = new()
            {
                ["reportTitle"] = "Izvještaj narudžbi",
                ["id"] = "ID",
                ["customer"] = "Kupac",
                ["allCustomers"] = "Svi kupci",
                ["date"] = "Datum",
                ["amount"] = "Iznos (KM)",
                ["status"] = "Status",
                ["totalOrders"] = "Ukupno narudžbi",
                ["totalRevenue"] = "Ukupni prihod",
                ["page"] = "Stranica",
                ["of"] = "od",
                ["Paid"] = "Plaćeno",
                ["Packed"] = "Spakovano",
                ["Shipped"] = "Isporučeno",
                ["currency"] = "KM",
            },
            ["en"] = new()
            {
                ["reportTitle"] = "Orders Report",
                ["id"] = "ID",
                ["customer"] = "Customer",
                ["allCustomers"] = "All customers",
                ["date"] = "Date",
                ["amount"] = "Amount (BAM)",
                ["status"] = "Status",
                ["totalOrders"] = "Total orders",
                ["totalRevenue"] = "Total revenue",
                ["page"] = "Page",
                ["of"] = "of",
                ["Paid"] = "Paid",
                ["Packed"] = "Packed",
                ["Shipped"] = "Shipped",
                ["currency"] = "BAM",
            },
        };

        private string translatePdf(string lang, string key)
        {
            var l = _translations.ContainsKey(lang) ? lang : "bs";
            return _translations[l].TryGetValue(key, out var val) ? val : key;
        }

        public async Task<byte[]> Handle(GenerateOrdersReportQuery request, CancellationToken ct)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var lang = string.IsNullOrWhiteSpace(request.Language) ? "bs" : request.Language;
            var culture = lang == "en" ? new CultureInfo("en-US") : new CultureInfo("bs-BA");
            var dateFormat = lang == "en" ? "MM/dd/yyyy" : "dd.MM.yyyy";

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateFromLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateFrom, timeZone);
            var dateToLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateTo, timeZone).Date.AddDays(-1);

            var query = context.Orders
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.OrderStatus)
                .Where(x => 
                x.CreatedAtUtc >= request.DateFrom &&
                x.CreatedAtUtc <= request.DateTo &&
                (x.OrderStatus.StatusName == OrderStatusType.Paid || x.OrderStatus.StatusName == OrderStatusType.Packed ||
                  x.OrderStatus.StatusName == OrderStatusType.Shipped));

            if (request.UserId.HasValue)
                query = query.Where(x => x.UserId == request.UserId);

            var orders = await query.Select(x => new
            {
                x.Id,
                x.CreatedAtUtc,
                x.TotalPrice,
                Status = x.OrderStatus.StatusName
            }).ToListAsync(ct);

            var totalRevenue = orders.Sum(x => x.TotalPrice);
            var totalCount = orders.Count;

            string customerName = translatePdf(lang, "allCustomers");
            if (request.UserId.HasValue)
            {
                var name = await context.Users
                    .AsNoTracking()
                    .Where(u => u.Id == request.UserId.Value)
                    .Select(u => u.FirstName + " " + u.LastName)
                    .FirstOrDefaultAsync(ct);
                if (!string.IsNullOrWhiteSpace(name))
                    customerName = name;
            }

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Column(h =>
                    {
                        h.Item().Text($"{translatePdf(lang, "reportTitle")}: {dateFromLocal.ToString(dateFormat, culture)} - {dateToLocal.ToString(dateFormat, culture)}")
                          .SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);
                        h.Item().PaddingTop(4).Text($"{translatePdf(lang, "customer")}: {customerName}")
                          .FontSize(12).FontColor(Colors.Grey.Darken2);
                    });

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.ConstantColumn(50);
                                c.RelativeColumn(2);
                                c.RelativeColumn(1);
                                c.RelativeColumn(1);
                            });

                            table.Header(header =>
                            {
                                foreach (var col in new[] { translatePdf(lang,"id"), translatePdf(lang,"date"), translatePdf(lang,"amount"), translatePdf(lang,"status") })
                                    header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                        .Text(col).FontColor(Colors.White).SemiBold();
                            });

                            foreach (var order in orders)
                            {
                                table.Cell().Padding(5).Text(order.Id.ToString());
                                table.Cell().Padding(5).Text(order.CreatedAtUtc.ToString(dateFormat, culture));
                                table.Cell().Padding(5).Text(order.TotalPrice.ToString("N2", culture));
                                table.Cell().Padding(5).Text(translatePdf(lang, order.Status.ToString()));
                            }
                        });

                        col.Item().PaddingTop(20).BorderTop(1).PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text($"{translatePdf(lang, "totalOrders")}: {totalCount}").SemiBold();
                            row.RelativeItem().AlignRight().Text($"{translatePdf(lang, "totalRevenue")}: {totalRevenue.ToString("N2", culture)} {translatePdf(lang, "currency")}").SemiBold();
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
