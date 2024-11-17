using System;
using System.IO;

namespace GitHubUpdater.Display
{
    internal class Displayable
    {
        internal string StoredText { get; set; }
        internal bool AutoLoad { get; set; } = true;
        internal bool AutoExport { get; set; } = true;
        internal string DefaultFileName { get; set; } = "";
        internal string DefaultFileContents { get; set; } = "";

        internal bool PopulateFromDefault(bool bypassAutoExport = false)
        {
            try
            {
                //validation
                if (string.IsNullOrWhiteSpace(DefaultFileName)
                    || string.IsNullOrWhiteSpace(DefaultFileContents))
                {
                    return false;
                }

                //set accordingly
                StoredText = DefaultFileContents;

                //export?
                if (!AutoExport || bypassAutoExport)
                    return true;
                if (!File.Exists(DefaultFileName))
                    File.WriteAllText(DefaultFileName, StoredText);
                return true;
            }
            catch (Exception ex)
            {
                //log issue
                ex.ExportError();
            }

            //default
            return false;
        }

        internal bool PopulateFromFile()
        {
            try
            {
                //validation
                if (string.IsNullOrWhiteSpace(DefaultFileName)
                    || string.IsNullOrWhiteSpace(DefaultFileContents))
                {
                    return false;
                }

                //checks
                if (File.Exists(DefaultFileName))
                {
                    var readout = File.ReadAllText(DefaultFileName);
                    if (!string.IsNullOrWhiteSpace(readout))
                    {
                        //apply changes
                        StoredText = readout;

                        //success
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //log issue
                ex.ExportError();
            }

            //default
            return false;
        }

        internal bool Populate()
            => AutoLoad ? PopulateFromFile() : PopulateFromDefault();
    }
}