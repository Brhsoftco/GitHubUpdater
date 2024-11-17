using System.Reflection;

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
                RepositoryName = "SL5Console-releases",
                CurrentInstalledVersion = version,
                DebugMode = true
            };

            updater.CheckIfLatest(silentCheck);
        }
    }
}