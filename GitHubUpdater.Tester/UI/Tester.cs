using System;
using System.Windows.Forms;

namespace GitHubUpdater.Tester.UI
{
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Close();

        private void BtnStart_Click(object sender, EventArgs e)
            => UpdateManager.RunUpdateCheck();
    }
}