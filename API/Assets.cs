using System;

namespace GitHubUpdater.API
{
    internal class Assets
    {
        internal string url { get; set; }
        internal int id { get; set; }
        internal string node_id { get; set; }
        internal string name { get; set; }
        internal string label { get; set; }
        internal User uploader { get; set; }
        internal string content_type { get; set; }
        internal string state { get; set; }
        internal int size { get; set; }
        internal int download_count { get; set; }
        internal DateTime created_at { get; set; }
        internal DateTime updated_at { get; set; }
        internal string browser_download_url { get; set; }
    }
}