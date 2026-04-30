namespace BookVerse.Application.Common.Interfaces
{
    public interface ITranslationService
    {
       Task<string> Translate(string text, string targetLang);
       Task<string> Translate(string text, string sourceLang, string targetLang);
    }
}
