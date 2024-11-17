using GitHubUpdater.API.GHSchemas;
using GitHubUpdater.Enums;
using System;

namespace GitHubUpdater.API
{
    /// <summary>
    /// Data class for API data received from GitHub
    /// </summary>
    public class UpdateResponse
    {
        /// <summary>
        /// Null-checks that determine whether the response contains valid data that can be parsed (all must succeed)
        /// </summary>
        public bool Valid
            => CurrentVersion != null
               && UpdatedVersion != null
               && UpdateData != null;

        /// <summary>
        /// The update channel that this request was issued on (e.g. Development/Stable)
        /// </summary>
        public UpdateChannel Channel { get; set; } = UpdateChannel.Unknown;

        /// <summary>
        /// Current version of the application
        /// </summary>
        public Version CurrentVersion { get; set; } = null;

        /// <summary>
        /// UpdatedVersion of the application (parsed from the release tag-name by removing 'v' from the start)
        /// </summary>
        public Version UpdatedVersion =>
            UpdateData != null
            ? !string.IsNullOrWhiteSpace(UpdateData.TagName)
                ? new Version(UpdateData.TagName.TrimStart('v').ToValidVersionString())
                : null
            : null;

        /// <summary>
        /// The DateTime this object was generated
        /// </summary>
        public DateTime Generated { get; set; } = DateTime.Now;

        /// <summary>
        /// The raw API data itself
        /// </summary>
        public GHApplication UpdateData { get; set; } = null;

        /// <summary>
        /// Executes RunVersionCheck() to determine the result (simplifies checks)
        /// </summary>
        public bool UpToDate => RunVersionCheck() == VersionStatus.Bumped || RunVersionCheck() == VersionStatus.UpToDate;

        /// <summary>
        /// Compares 'UpdatedVersion' and 'CurrentVersion' to identify the difference (outdated or up-to-date, etc.)
        /// </summary>
        /// <returns></returns>
        public VersionStatus RunVersionCheck()
        {
            var updated = UpdatedVersion;
            var status = VersionStatus.Undetermined;

            //add a build and revision of '0' (v[M].[m].[0.0]) if one isn't defined, by creating a new temporary version object
            if (updated.Build == -1)
                updated = new Version($"{UpdateData.TagName.TrimStart('v')}.0.0");

            //add a revision of '0' if one isn't defined, by creating a new temporary version object
            if (updated.Revision == -1)
                updated = new Version($"{UpdateData.TagName.TrimStart('v')}.0");

            try
            {
                //null-checks
                if (Valid)
                {
                    //execute version check
                    var comparison = CurrentVersion.CompareTo(updated);

                    status = comparison switch
                    {
                        //outdated
                        < 0 => VersionStatus.Outdated,
                        //up-to-date
                        0 => VersionStatus.UpToDate,
                        _ => VersionStatus.Bumped
                    };
                }
            }
            catch
            {
                //ignore
            }

            //finalise and return the result
            return status;
        }
    }
}