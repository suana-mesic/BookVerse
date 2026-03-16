using Market.Domain.Entities.Shopping;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Market.Application.Modules.Reports.Orders
{
    public class GenerateOrdersReportQueryHandler(IAppDbContext context)
    : IRequestHandler<GenerateOrdersReportQuery, byte[]>
    {
        public async Task<byte[]> Handle(GenerateOrdersReportQuery request, CancellationToken ct)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateFromLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateFrom, timeZone);
            var dateToLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateTo, timeZone);

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

            if (request.OrderId.HasValue)
                query = query.Where(x => x.Id == request.OrderId);

            var orders = await query.Select(x => new
            {
                x.Id,
                Kupac = x.User.FirstName + " " + x.User.LastName,
                x.CreatedAtUtc,
                x.TotalPrice,
                Status = x.OrderStatus.StatusName
            }).ToListAsync(ct);

            var ukupanPrihod = orders.Sum(x => x.TotalPrice);
            var ukupanBroj = orders.Count;

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text($"Izvještaj narudžbi: {dateFromLocal:dd.MM.yyyy} - {dateToLocal:dd.MM.yyyy}")
                      .SemiBold().FontSize(16).FontColor(Colors.Blue.Medium);

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.ConstantColumn(50); // ID
                                c.RelativeColumn(2); // Kupac
                                c.RelativeColumn(2); // Datum
                                c.RelativeColumn(1); // Iznos
                                c.RelativeColumn(1); // Status
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                    .Text("ID").FontColor(Colors.White).SemiBold();
                                header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                    .Text("Kupac").FontColor(Colors.White).SemiBold();
                                header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                    .Text("Datum").FontColor(Colors.White).SemiBold();
                                header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                    .Text("Iznos (KM)").FontColor(Colors.White).SemiBold();
                                header.Cell().Background(Colors.Blue.Medium).Padding(5)
                                    .Text("Status").FontColor(Colors.White).SemiBold();
                            });

                            // Redovi
                            foreach (var order in orders)
                            {
                                table.Cell().Padding(5).Text(order.Id.ToString());
                                table.Cell().Padding(5).Text(order.Kupac);
                                table.Cell().Padding(5).Text(order.CreatedAtUtc.ToString("dd.MM.yyyy"));
                                table.Cell().Padding(5).Text(order.TotalPrice.ToString("F2"));
                                table.Cell().Padding(5).Text(order.Status);
                            }

                        });
                        // Summary na kraju
                        col.Item().PaddingTop(20).BorderTop(1).PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text($"Ukupno narudžbi: {ukupanBroj}").SemiBold();
                            row.RelativeItem().AlignRight().Text($"Ukupni prihod: {ukupanPrihod:F2} KM").SemiBold();
                        });

                    });
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Stranica ");
                        x.CurrentPageNumber();
                        x.Span(" od ");
                        x.TotalPages();
                    });
                });
            });
            return pdf.GeneratePdf();
        }
    }
}
