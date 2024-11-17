using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.WaitWindow
{
    /// <summary>
    /// Provides data for the WaitWindow events.
    /// </summary>
    internal class GHUWaitWindowEventArgs : EventArgs
    {
        /// <summary>
        /// Initialises a new instance of the WaitWindowEventArgs class.
        /// </summary>
        /// <param name="gui">The associated WaitWindow instance.</param>
        /// <param name="args">A list of arguments to be passed.</param>
        internal GHUWaitWindowEventArgs(GHUWaitWindow gui, List<object> args)
        {
            Window = gui;
            Arguments = args;
        }

        internal GHUWaitWindow Window { get; }

        internal List<object> Arguments { get; }

        internal object Result { get; set; }
    }
}