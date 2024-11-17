using System;
using System.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace GitHubUpdater.Net
{
    internal static class NetGlobals
    {
        internal static string GlobalUserAgent { get; set; } = $@"GHUpdater/{CurrentClientVersion} {OSVersionString}";

        internal static string CurrentClientVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        internal static string OSVersionString => $@"{Environment.OSVersion.Platform}_{Environment.OSVersion.Version.Major}_{Environment.OSVersion.Version.Minor}";
        internal static int Timeout { get; set; } = 0;
    }
}