using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API.GHSchemas
{
    public class GHApplication : GHApiObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("tag_name")]
        public string TagName { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("draft")]
        public bool Draft { get; set; } = false;

        [JsonPropertyName("prerelease")]
        public bool Prerelease { get; set; } = false;

        [JsonPropertyName("author")]
        public GHUser Author { get; set; } = null;

        [JsonPropertyName("assets")]
        public GHAsset[] Assets { get; set; } = [];

        [JsonPropertyName("body")]
        public string Body { get; set; } = "";
    }
}