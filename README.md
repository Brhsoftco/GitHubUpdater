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
	
	//this is the default value; see below for more options
	Mode = OperationModus.Normal
};

// Start API call and update check.
// If an update is available, the client will show a form
// with release information from GitHub. Otherwise,
// a simple messagebox is displayed informing the user that
// they are up-to-date.
client.CheckIfLatest();
```
You can set `Mode` to one of three options:
- `OperationModus.DebugMode` allows for logging API outputs, enabling the channel selector and always showing the `Update Available` form
- `OperationModus.ChannelSelector` enables pulling from either only `Pre-release` builds or only `Stable` builds via the use of a selection form; otherwise, the behaviour is the same as `Normal`
- `OperationModus.Normal` only pulls from the `Stable` channel and will only show the `Update Available` form if a later version is available