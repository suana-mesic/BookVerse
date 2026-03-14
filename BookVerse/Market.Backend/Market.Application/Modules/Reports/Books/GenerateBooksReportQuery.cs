namespace Market.Application.Modules.Reports.Books
{
    public class GenerateBooksReportQuery: IRequest<byte[]>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ? BookId { get; set; }
    }
}
