using System;
using System.Text.Json.Serialization;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.API.GHSchemas
{
    public class GHAsset : GHApiObject
    {
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("uploader")]
        public GHUser Uploader { get; set; } = null;

        [JsonPropertyName("size")]
        public int Size { get; set; } = 0;

        [JsonPropertyName("download_count")]
        public int DownloadCount { get; set; } = 0;

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [JsonPropertyName("browser_download_url")]
        public string BrowserDownloadUrl { get; set; } = "";
    }
}