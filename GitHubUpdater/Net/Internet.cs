﻿using System.Runtime.InteropServices;

namespace GitHubUpdater.Net
{
    internal static class Internet
    {
        /// <summary>
        /// Win32 API hook on 'wininet.dll'
        /// </summary>
        /// <param name="description"></param>
        /// <param name="reservedValue"></param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int description, int reservedValue);

        /// <summary>
        /// Uses the Win32 API to check whether Windows has a valid internet connection
        /// </summary>
        /// <returns></returns>
        internal static bool IsConnected =>
            InternetGetConnectedState(out _, 0);
    }
}