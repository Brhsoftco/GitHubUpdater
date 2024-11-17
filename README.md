# GitHubUpdater
C# REST client for communicating with the GitHub API. Specifically designed for update checks relating to the latest GitHub release of the specified repo.

**It is crucial that you `tag` your releases with your version number; preferably with `v` prepended like so: `v1.0.0`.**

Initialise an update check like so:
```csharp
var version = new Version(Application.ProductVersion);
var client = new UpdateClient()
{
    Author = "<Your GitHub Username",
    RepositoryName = "<Your Repo Name>",
    CurrentInstalledVersion = version,
	DebugMode = true
};

// Start API call and update check.
// If an update is available, the client will show a form
// with release information from GitHub. Otherwise,
// a simple messagebox is displayed informing the user that
// they are up-to-date.
client.CheckIfLatest();
```
If set to true, `DebugMode` enables `Update Channel` selection; in this mode, the developer is able to check for releases that are tagged as a `Pre-release` by GitHub.

You may find this mode useful if your application permits 'Unstable' build downloads.