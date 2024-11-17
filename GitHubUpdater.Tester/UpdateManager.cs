using System.Reflection;
using GitHubUpdater.Enums;

namespace GitHubUpdater.Tester
{
    internal static class UpdateManager
    {
        internal static void RunUpdateCheck(bool silentCheck = false)
        {
            var version = Assembly.GetCallingAssembly().GetName().Version;
            var updater = new UpdateClient
            {
                Author = "brh-media",
                RepositoryName = "plexdl",
                CurrentInstalledVersion = version,
                Mode = OperationModus.ChannelSelector
            };

            updater.CheckIfLatest(silentCheck);
        }
    }
}