namespace BookVerse.Application.Modules.Translate
{
    public class GetLibreTranslateQuery
    {
        public string Q { get; set; }
        public string Source { get; set; } = "auto";
        public string Target { get; set; }
        public string Format { get; set; } = "text";
    }
}
