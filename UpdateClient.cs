using Newtonsoft.Json;
using RestSharp;
using System;
using System.Windows.Forms;
using GitHubUpdater.WaitWindow;
using Application = GitHubUpdater.API.Application;

// ReSharper disable LocalizableElement

namespace GitHubUpdater
{
    public class UpdateClient
    {
        public string Author { get; set; } = "";
        public string RepositoryName { get; set; } = "";
        public string ApiUrl => $"repos/{Author}/{RepositoryName}/releases/latest";
        private static string BaseUrl => "http://api.github.com/";
        public bool WaitWindowWorker => true;
        public Version CurrentInstalledVersion { get; set; }

        public void ShowUpdateForm(Application data)
        {
            var frm = new Update { UpdateData = data };
            frm.ShowDialog();
        }

        public void CheckIfLatest()
        {
            if (CurrentInstalledVersion == null)
            {
                MessageBox.Show(@"Couldn't determine the currently installed version because it was null.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var data = GetLatestRelease();
                var vNow = CurrentInstalledVersion;
                var vNew = new Version(data.tag_name.TrimStart('v'));
                var vCompare = vNow.CompareTo(vNew);
                if (vCompare < 0)
                {
                    ShowUpdateForm(data);
                }
                else
                {
                    MessageBox.Show($"You're running the latest version!\n\nYour version: {vNow}" +
                                    $"\nLatest release: {vNew}", @"Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void ShowUpdateForm()
        {
            var data = GetLatestRelease();
            ShowUpdateForm(data);
        }

        public Application GetLatestRelease()
        {
            Application data = null;

            try
            {
                var api = GetUpdateInfo();
                data = JsonConvert.DeserializeObject<Application>(api);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update error\r\n\r\n{ex}");
            }

            return data;
        }

        protected RestClient GetRestClient()
            => new RestClient(BaseUrl);

        private string GetUpdateInfo()
        {
            if (WaitWindowWorker)
                return (string)GHUWaitWindow.Show(GetUpdateInfoWorker, @"Contacting GitHub");
            return ApiContact();
        }

        protected virtual string GetBaseUrl()
        {
            return BaseUrl;
        }

        private void GetUpdateInfoWorker(object sender, GHUWaitWindowEventArgs e)
        {
            e.Result = ApiContact();
        }

        private string ApiContact()
        {
            var client = GetRestClient();
            var request = new RestRequest { Resource = ApiUrl };
            var response = client.Execute(request);
            return response.Content;
        }
    }
}