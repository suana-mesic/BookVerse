using System.Text.Json;
using System.Text.Json.Serialization;

namespace Market.API.Converters
{
    public class UtcDateTimeConverter : JsonConverter<DateTime>
    {
        // JSON konverter koji osigurava da se svi DateTime objekti tretiraju kao UTC.
        // Rješava problem EF Core-a koji iz baze vraća DateTime sa Kind = Unspecified,
        // što uzrokuje pogrešan prikaz vremena na frontendu (nedostaje 'Z' sufiks u JSON-u).
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
       => DateTime.SpecifyKind(reader.GetDateTime(), DateTimeKind.Utc);

        // Pri pisanju JSON-a, postavlja Kind = Utc prije serijalizacije,
        // što rezultira da JSON output uvijek sadrži 'Z' sufiks (npr. "2024-01-15T14:30:00Z").
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(DateTime.SpecifyKind(value, DateTimeKind.Utc));
    }
}
