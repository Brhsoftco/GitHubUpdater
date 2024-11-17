using System;

namespace GitHubUpdater.Net.DownloadManager
{
    /// <summary>
    /// Represents a file to download regarding an update from the GitHub API
    /// </summary>
    internal class Job
    {
        /// <summary>
        /// The path to save the downloaded file to
        /// </summary>
        internal string DownloadPath { get; set; } = @"";

        /// <summary>
        /// The size of the file to download
        /// </summary>
        internal long DownloadSize { get; set; } = 0;

        /// <summary>
        /// The online location of the file to download
        /// </summary>
        internal Uri DownloadUri { get; set; } = null;
    }
}