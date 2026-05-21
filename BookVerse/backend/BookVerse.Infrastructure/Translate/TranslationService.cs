using BookVerse.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BookVerse.Infrastructure.Translate
{
    // Wrapper around the unofficial Google translate endpoint. Each call is guarded by:
    //   - HttpClient.Timeout (set when the client is registered in DI) so a slow Google
    //     reply cannot make the whole listing hang.
    //   - A CancellationToken from the caller so the request is dropped if the user
    //     disconnects or the parent operation is cancelled.
    //   - IMemoryCache so we never translate the same string twice in the cache window;
    //     this is what stops a page listing from sending 100+ HTTP calls each time.
    //   - try/catch + ILogger so a Google error is recorded instead of being silently
    //     swallowed by "catch { return text; }".
    public class TranslationService : ITranslationService
    {
        private readonly HttpClient _http;
        private readonly IMemoryCache _cache;
        private readonly ILogger<TranslationService> _logger;

        // Translations rarely change, so a relatively long cache window is fine. Sliding
        // expiration means popular strings stay in cache as long as something uses them.
        private static readonly TimeSpan CacheDuration = TimeSpan.FromHours(6);

        public TranslationService(
            HttpClient http,
            IMemoryCache cache,
            ILogger<TranslationService> logger)
        {
            _http = http;
            _cache = cache;
            _logger = logger;
        }

        // Default source language is Bosnian because the data in the DB is stored in bs.
        public Task<string> Translate(string text, string targetLang, CancellationToken ct = default)
            => Translate(text, "bs", targetLang, ct);

        public async Task<string> Translate(string text, string sourceLang, string targetLang, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // No need to call Google when the source and target are the same.
            if (string.Equals(sourceLang, targetLang, StringComparison.OrdinalIgnoreCase))
                return text;

            // Key includes both languages so a "bs->en" cached value does not get
            // returned for an "en->de" lookup of the same string.
            var cacheKey = $"translate:{sourceLang}:{targetLang}:{text}";

            if (_cache.TryGetValue<string>(cacheKey, out var cached) && cached is not null)
                return cached;

            try
            {
                var encoded = Uri.EscapeDataString(text);
                var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLang}&tl={targetLang}&dt=t&q={encoded}";

                // Pass the CancellationToken so HttpClient stops waiting if the parent
                // operation is cancelled. The overall HTTP timeout is enforced by
                // HttpClient.Timeout, configured when the client is registered.
                using var response = await _http.GetAsync(url, ct);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning(
                        "Google translate returned non-success status {StatusCode} for {Source}->{Target} text length {Length}",
                        response.StatusCode, sourceLang, targetLang, text.Length);
                    return text;
                }

                var json = await response.Content.ReadAsStringAsync(ct);
                var parsed = JsonSerializer.Deserialize<JsonElement>(json);

                var translated = parsed[0].EnumerateArray()
                    .Select(segment => segment[0].GetString() ?? "")
                    .Aggregate(string.Concat);

                var result = string.IsNullOrWhiteSpace(translated) ? text : translated;

                // Cache the result so the same string never goes to Google again in this window.
                _cache.Set(cacheKey, result, CacheDuration);

                return result;
            }
            catch (OperationCanceledException)
            {
                // Bubble cancellation up so MediatR/EF can react to a cancelled request.
                throw;
            }
            catch (Exception ex)
            {
                // The old code did "catch { return text; }" which hid every problem -
                // bad TLS, blocked IP, parse errors. We still fall back to the original
                // text so the page does not break, but we now log the reason.
                _logger.LogWarning(ex,
                    "Translation failed for {Source}->{Target} text length {Length}; returning original text",
                    sourceLang, targetLang, text.Length);
                return text;
            }
        }
    }
}
