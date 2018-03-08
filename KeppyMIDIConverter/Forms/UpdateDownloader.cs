using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;

namespace KeppyMIDIConverter
{
    public partial class UpdateDownloader : Form
    {
        WebClient webClient;
        String VersionToDownload;

        public UpdateDownloader(String text)
        {
            InitializeComponent();
            VersionToDownload = text;
        }

        private void UpdateDownloader_Load(object sender, EventArgs e)
        {
            String PathExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!PathExe.Contains("C:\\Program Files"))
            {
                Process.Start(String.Format("https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases/tag/{0}", VersionToDownload));
                Close();
            }
            else
            {
                using (webClient = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    Uri URL = new Uri(String.Format("https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases/download/{0}/KeppyMIDIConverterSetup.exe", VersionToDownload));

                    try
                    {
                        webClient.DownloadFileAsync(URL, String.Format("{0}{1}", Path.GetTempPath(), "KeppyMIDIConverterSetup.exe"));
                    }
                    catch
                    {
                        MessageBox.Show(Languages.Parse("ConnectionErrorDesc"), String.Format("{0} {1} - {2}", Program.Who, Program.Title, Languages.Parse("ConnectionErrorTitle")), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                try
                {
                    Process.Start(Path.GetTempPath() + "KeppyMIDIConverterSetup.exe");
                    Application.ExitThread();
                }
                catch
                {
                    MessageBox.Show(Languages.Parse("CorruptedSetupDesc"), String.Format("{0} {1} - {2}", Program.Who, Program.Title, Languages.Parse("CorruptedSetupTitle")), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                MessageBox.Show(Languages.Parse("ConnectionErrorDesc"), String.Format("{0} {1} - {2}", Program.Who, Program.Title, Languages.Parse("ConnectionErrorTitle")), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }
    }
}
