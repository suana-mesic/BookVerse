namespace BookVerse.Application.Common.Interfaces
{
    public interface ITranslationService
    {
        // CancellationToken is optional with a default value so existing callers do not
        // need to change. New code (like list handlers) should pass the request's token
        // so that pending HTTP calls can be cancelled when the client disconnects.
        Task<string> Translate(string text, string targetLang, CancellationToken ct = default);
        Task<string> Translate(string text, string sourceLang, string targetLang, CancellationToken ct = default);
    }
}
