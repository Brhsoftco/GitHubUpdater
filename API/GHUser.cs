using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API
{
    public class GHUser
    {
        [JsonPropertyName("login")]
        public string login { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("avatar_url")]
        public string avatar_url { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string gravatar_id { get; set; }
    }
}