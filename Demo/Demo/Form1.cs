﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GitHubUpdater;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GitHubUpdater.UpdateClient client = new GitHubUpdater.UpdateClient() { Author = "GLgele", RepositoryName = "EmployeesDIR-Cs", CurrentInstalledVersion = new Version(1,0,0,0) };
            client.CheckIfLatest();
        }
    }
}
