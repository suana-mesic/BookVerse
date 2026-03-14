using Market.Domain.Entities.Shopping;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Market.Application.Modules.Reports.Books
{
    public class GenerateBooksReportQueryHandler(IAppDbContext context)
        : IRequestHandler<GenerateBooksReportQuery, byte[]>
    {
        public async Task<byte[]> Handle(GenerateBooksReportQuery request, CancellationToken ct)
        {

            QuestPDF.Settings.License = LicenseType.Community;

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateFromLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateFrom, timeZone);
            var dateToLocal = TimeZoneInfo.ConvertTimeFromUtc(request.DateTo, timeZone);

            //dohvatimo sve zapise o narudžbama knjige request.BookId u periodu od request.DateFrom do request.DateTo
            var query = context.OrderItems
                .AsNoTracking()
                .Include(x => x.Book)
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderStatus)
                .Where(x => x.Order.CreatedAtUtc >= request.DateFrom
                         && x.Order.CreatedAtUtc <= request.DateTo
                         && (x.Order.OrderStatus.StatusName == OrderStatusType.Paid || x.Order.OrderStatus.StatusName == OrderStatusType.Completed));

            if(request.BookId.HasValue)
                query = query.Where(x => x.BookId == request.BookId);

            var items = await query
                .Include(x => x.Book)
                .ThenInclude(b => b.Authors)
                .Include(x => x.Order)
                .Select(x => new
                {
                    x.BookId,
                    Knjiga = x.Book.Title,
                    Autori = string.Join(", ", x.Book.Authors.Select(a => a.FirstName + " " + a.LastName)),
                    DatumNarudžbe = x.Order.CreatedAtUtc,
                    x.Quantity,
                    x.PriceAtTime,
                    Ukupno = x.Quantity * x.PriceAtTime
                }).ToListAsync(ct);

            var ukupnoKolicina = items.Sum(x => x.Quantity);
            var ukupanPrihod = items.Sum(x => x.Ukupno);

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text($"Izvještaj o prodaji knjiga: {dateFromLocal:dd.MM.yyyy} - {dateToLocal:dd.MM.yyyy}")
                          .SemiBold().FontSize(16).FontColor(Colors.Green.Medium);

                    page.Content().Column(col =>
                    {
                        col.Item().PaddingVertical(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(3); // Knjiga
                                c.RelativeColumn(2); // Autor
                                c.RelativeColumn(2); // Datum
                                c.ConstantColumn(40); // Kolicina
                                c.RelativeColumn(2); // Cijena
                                c.RelativeColumn(2); // Ukupno
                            });

                            table.Header(header =>
                            {
                                foreach (var naziv in new[] { "Knjiga", "Autor", "Datum", "Kol.", "Cijena", "Ukupno" })
                                {
                                    header.Cell().Background(Colors.Green.Medium).Padding(5)
                                        .Text(naziv).FontColor(Colors.White).SemiBold();
                                }
                            });

                            foreach (var item in items)
                            {
                                table.Cell().Padding(5).Text(item.Knjiga);
                                table.Cell().Padding(5).Text(item.Autori);
                                table.Cell().Padding(5).Text(item.DatumNarudžbe.ToString("dd.MM.yyyy"));
                                table.Cell().Padding(5).Text(item.Quantity.ToString());
                                table.Cell().Padding(5).Text(item.PriceAtTime.ToString("F2"));
                                table.Cell().Padding(5).Text(item.Ukupno.ToString("F2"));
                            }
                        });

                        col.Item().PaddingTop(20).BorderTop(1).PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem().Text($"Ukupno prodano: {ukupnoKolicina} kom").SemiBold();
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
