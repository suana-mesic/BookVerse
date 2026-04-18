namespace Market.Application.Common.Interfaces
{
    public interface ITranslationService
    {
       Task<string> Translate(string text, string targetLang);
    }
}
