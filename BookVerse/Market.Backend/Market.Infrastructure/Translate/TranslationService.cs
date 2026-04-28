using Market.Application.Common.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Market.Infrastructure.Translate
{
    public class TranslationService : ITranslationService
    {
        private readonly HttpClient _http;

        public TranslationService(HttpClient http)
        {
            _http = http;
        }

        public Task<string> Translate(string text, string targetLang)
            => Translate(text, "bs", targetLang);

        public async Task<string> Translate(string text, string sourceLang, string targetLang)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            try
            {
                var encoded = Uri.EscapeDataString(text);
                var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={sourceLang}&tl={targetLang}&dt=t&q={encoded}";

                var response = await _http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return text;

                var json = await response.Content.ReadAsStringAsync();
                var parsed = JsonSerializer.Deserialize<JsonElement>(json);

                var translated = parsed[0].EnumerateArray()
                    .Select(segment => segment[0].GetString() ?? "")
                    .Aggregate(string.Concat);

                return string.IsNullOrWhiteSpace(translated) ? text : translated;
            }
            catch
            {
                return text;
            }
        }
    }
}
