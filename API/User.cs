namespace GitHubUpdater.API
{
    internal class User
    {
        internal string login { get; set; }
        internal int id { get; set; }
        internal string node_id { get; set; }
        internal string avatar_url { get; set; }
        internal string gravatar_id { get; set; }
        internal string url { get; set; }
        internal string html_url { get; set; }
        internal string followers_url { get; set; }
        internal string following_url { get; set; }
        internal string gists_url { get; set; }
        internal string starred_url { get; set; }
        internal string subscriptions_url { get; set; }
        internal string organizations_url { get; set; }
        internal string repos_url { get; set; }
        internal string events_url { get; set; }
        internal string received_events_url { get; set; }
        internal string type { get; set; }
        internal bool site_admin { get; set; }
    }
}