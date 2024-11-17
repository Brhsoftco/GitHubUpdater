using GitHubUpdater.Properties;

namespace GitHubUpdater.Display
{
    internal class Stylesheet : Displayable
    {
        internal Stylesheet()
        {
            //setup provider
            DefaultFileName = $@"{Globals.UpdateRootDir}\style.css";
            DefaultFileContents = Resources.updateFormHtmlStyle;

            //initialise provider
            Populate();
        }
    }
}