using System.Text.Json;
using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API.GHSchemas
{
    public class GHApiObject
    {
        [JsonPropertyName("status")]
        public string StatusCode { get; set; } = "";

        [JsonPropertyName("message")]
        public string Message { get; set; } = "";

        public string ToJson(bool prettyPrint = true)
            => JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = prettyPrint
            });

        public static T FromJson<T>(string json)
            => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
    }
}