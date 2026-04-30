using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookVerse.API.Converters
{
    public class UtcDateTimeConverter : JsonConverter<DateTime>
    {
        // JSON converter that ensures all DateTime objects are treated as UTC.
        // Fixes an EF Core issue where DateTime values returned from the database have Kind = Unspecified,
        // causing incorrect time display on the frontend (missing 'Z' suffix in JSON).
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
       => DateTime.SpecifyKind(reader.GetDateTime(), DateTimeKind.Utc);

        // When writing JSON, sets Kind = Utc before serialization,
        // ensuring the JSON output always contains the 'Z' suffix (e.g., "2024-01-15T14:30:00Z").
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Utc));
    }
}
