using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API.GHSchemas
{
    public class GHUser : GHApiObject
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string GravatarId { get; set; }
    }
}