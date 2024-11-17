using System;
using System.Collections.Generic;

namespace GitHubUpdater.API
{
    internal class Application
    {
        internal string url { get; set; }
        internal string assets_url { get; set; }
        internal string upload_url { get; set; }
        internal string html_url { get; set; }
        internal int id { get; set; }
        internal string node_id { get; set; }
        internal string tag_name { get; set; }
        internal string target_commitish { get; set; }
        internal string name { get; set; }
        internal bool draft { get; set; }
        internal User author { get; set; }
        internal bool prerelease { get; set; }
        internal DateTime created_at { get; set; }
        internal DateTime published_at { get; set; }
        internal List<Assets> assets { get; set; }
        internal string tarball_url { get; set; }
        internal string zipball_url { get; set; }
        internal string body { get; set; }
    }
}