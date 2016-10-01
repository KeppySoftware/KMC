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
            using (webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                Uri URL = new Uri(String.Format("https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases/download/{0}/KeppyMIDIConverterSetup.exe", VersionToDownload));

                try
                {
                    webClient.DownloadFileAsync(URL, Path.GetTempPath() + "KeppyMIDIConverterSetup.exe");
                }
                catch
                {
                    MessageBox.Show("The converter can not connect to the GitHub servers.\n\nCheck your network connection, or contact your system administrator or network service provider.", "Keppy's Synthesizer - Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Process.Start(Path.GetTempPath() + "KeppyMIDIConverterSetup.exe");
                Application.ExitThread();

            }
            catch
            {
                MessageBox.Show("The converter can not connect to the GitHub servers.\n\nCheck your network connection, or contact your system administrator or network service provider.", "Keppy's Synthesizer - Connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
        }
    }
}
