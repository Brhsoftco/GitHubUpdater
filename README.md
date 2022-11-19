# GitHubUpdater
C# REST client for communicating with the GitHub API. Specifically designed for update checks relating to the latest GitHub release of the specified repo.

Initialise an update check like so:
```csharp
var version = new Version(Application.ProductVersion);
var client = new UpdateClient()
{
    Author = "<Your GitHub Username",
    RepositoryName = "<Your Repo Name>",
    CurrentInstalledVersion = version,
    BaseUrl = "http://api.github.com/"
};

// Default BaseUrl is "http://api.github.com/". 
// You don't have to give it a value unless you have special requirements

// Start API call and update check.
// If an update is available, the client will show a form
// with release information from GitHub. Otherwise,
// a simple messagebox is displayed informing the user that
// they are up-to-date.
client.CheckIfLatest();
```
