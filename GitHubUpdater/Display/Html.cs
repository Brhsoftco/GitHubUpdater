using GitHubUpdater.Properties;

namespace GitHubUpdater.Display
{
    internal class Html : Displayable
    {
        internal Html()
        {
            //setup provider
            DefaultFileName = $@"{Globals.UpdateRootDir}\update.htm";
            DefaultFileContents = Resources.updateFormHtmlDocument;

            //initialise provider
            Populate();
        }
    }
}