using System;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming

namespace GitHubUpdater.WaitWindow.UI
{
    /// <summary>
    /// The dialogue displayed by a WaitWindow instance.
    /// </summary>
    internal partial class GHUWaitWindowGui : Form
    {
        public GHUWaitWindowGui(GHUWaitWindow parent)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            _parent = parent;
        }

        private readonly GHUWaitWindow _parent;

        private delegate T FunctionInvoker<out T>();

        internal object Result;
        internal Exception Error;

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //   Create Delegate
            var threadController = new FunctionInvoker<object>(DoWork);

            //   Execute on secondary thread.
            threadController.BeginInvoke(WorkComplete, threadController);
        }

        internal object DoWork()
        {
            //	Invoke the worker method and return any results.
            var e = new GHUWaitWindowEventArgs(_parent, _parent.Args);
            _parent.WorkerMethod?.Invoke(this, e);
            return e.Result;
        }

        private void WorkComplete(IAsyncResult results)
        {
            if (!IsDisposed)
            {
                if (InvokeRequired)
                {
                    Invoke(new GHUWaitWindow.MethodInvoker<IAsyncResult>(WorkComplete), results);
                }
                else
                {
                    //	Capture the result
                    try
                    {
                        Result = ((FunctionInvoker<object>)results.AsyncState).EndInvoke(results);
                    }
                    catch (Exception ex)
                    {
                        //	Grab the Exception for rethrowing after the WaitWindow has closed.
                        Error = ex;
                    }
                    Close();
                }
            }
        }

        internal void SetMessage(string message)
        {
            MessageLabel.Text = message;
        }

        internal void Cancel()
        {
            Invoke(new MethodInvoker(Close), null);
        }
    }
}