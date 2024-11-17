using System;
using System.IO;

namespace GitHubUpdater.Display
{
    internal class Displayable
    {
        internal string StoredContent { get; set; }
        internal bool AutoLoad { get; set; } = true;
        internal bool AutoExport { get; set; } = true;
        internal string DefaultFileName { get; set; } = "";
        internal string DefaultFileContents { get; set; } = "";

        internal string PopulateFromDefault(bool bypassAutoExport = false)
        {
            try
            {
                //validation
                if (string.IsNullOrWhiteSpace(DefaultFileName)
                    || string.IsNullOrWhiteSpace(DefaultFileContents))
                {
                    return null;
                }

                //set accordingly
                StoredContent = DefaultFileContents;

                //export?
                if (!AutoExport || bypassAutoExport)
                    return DefaultFileContents;
                if (!File.Exists(DefaultFileName))
                    File.WriteAllText(DefaultFileName, StoredContent);
                return DefaultFileContents;
            }
            catch (Exception ex)
            {
                //log issue
                ex.ExportError();
            }

            //default
            return null;
        }

        internal string PopulateFromFile()
        {
            try
            {
                //validation
                if (string.IsNullOrWhiteSpace(DefaultFileName)
                    || string.IsNullOrWhiteSpace(DefaultFileContents))
                {
                    return null;
                }

                //checks
                if (File.Exists(DefaultFileName))
                {
                    var readout = File.ReadAllText(DefaultFileName);
                    if (!string.IsNullOrWhiteSpace(readout))
                    {
                        //apply changes
                        StoredContent = readout;

                        //success
                        return readout;
                    }
                }
            }
            catch (Exception ex)
            {
                //log issue
                ex.ExportError();
            }

            //default
            return null;
        }

        internal string Populate()
        {
            if (!AutoLoad)
                return PopulateFromDefault();
            var filePopulate = PopulateFromFile();
            return !string.IsNullOrWhiteSpace(filePopulate)
                ? filePopulate
                : PopulateFromDefault();

        }
    }
}