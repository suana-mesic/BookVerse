namespace Market.Application.Modules.Reports.Orders
{
    public class GenerateOrdersReportQuery:IRequest<byte[]>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? UserId { get; set; }
        public string Language { get; set; } = "bs";
    }
}
