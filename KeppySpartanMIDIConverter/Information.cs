using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace KeppySpartanMIDIConverter
{
    public partial class Informations : Form
    {
        public Informations()
        {
            InitializeComponent();
        }

        public partial class ExePath
        {
            public static string ExecutablePath = KeppySpartanMIDIConverter.MainWindow.Globals.ExecutablePath;
        }

        private void Informations_Load(object sender, EventArgs e)
        {
            try
            {
                // Auto-update stuff
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo(assembly.Location);
                ThisVersion.Text = "The current version of the converter, installed on your system, is: " + Converter.FileVersion.ToString();
                // STUFF
                if (IntPtr.Size == 8)
                {
                    Versionlabel.Text = "Compiled for 64-bit systems, optimized for SSE2 ready CPUs.";
                }
                else if (IntPtr.Size == 4)
                {
                    Versionlabel.Text = "Compiled for 32-bit systems, optimized for MMX ready CPUs.";
                }
                KeppyVer.Text = "Keppy's MIDI Converter " + Application.ProductVersion + ", by Keppy Studios";

                // OTHER STUFF
                FileVersionInfo basslibver = FileVersionInfo.GetVersionInfo(ExePath.ExecutablePath + @"\bass.dll");
                FileVersionInfo bassmidilibver = FileVersionInfo.GetVersionInfo(ExePath.ExecutablePath + @"\bassmidi.dll");
                FileVersionInfo bassvstlibver = FileVersionInfo.GetVersionInfo(ExePath.ExecutablePath + @"\bass_vst.dll");
                FileVersionInfo bassenclibver = FileVersionInfo.GetVersionInfo(ExePath.ExecutablePath + @"\bassenc.dll");
                FileVersionInfo bassnetlibver = FileVersionInfo.GetVersionInfo(ExePath.ExecutablePath + @"\Bass.Net.dll");

                // Print the file name and version number.
                BASSINFO.Text = basslibver.FileDescription + " version: " + basslibver.FileVersion + "." + basslibver.FilePrivatePart + "\n" +
                    bassmidilibver.FileDescription + " version: " + bassmidilibver.FileVersion + "." + bassmidilibver.FilePrivatePart + "\n" +
                    bassenclibver.FileDescription + " version: " + bassenclibver.FileVersion + "." + bassenclibver.FilePrivatePart + "\n" +
                    bassnetlibver.FileDescription + " version: " + bassnetlibver.FileVersion + "." + bassnetlibver.FilePrivatePart;

                BASSINFO2.Text = bassvstlibver.FileDescription + " version: " + bassvstlibver.FileVersion + "." + bassvstlibver.FilePrivatePart + "\n\n\n" +
                     "KMC " + Application.ProductVersion;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.un4seen.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad.exe", "license.rtf");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://keppystudios.com/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KaleidonKep99/Keppys-MIDI-Converter");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.Enabled = false;
                button5.Enabled = false;
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppySpartanMIDIConverter/kmcupdate.txt");
                StreamReader reader = new StreamReader(stream);
                String newestversion = reader.ReadToEnd();
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                LatestVersion.Text = "Checking for updates, please wait...";
                ThisVersion.Text = "The current version of the converter, installed on your system, is: " + Converter.FileVersion.ToString();
                Version x = null;
                Version.TryParse(newestversion.ToString(), out x);
                Version y = null;
                Version.TryParse(Converter.FileVersion.ToString(), out y);
                if (x > y)
                {
                    tabControl1.Enabled = true;
                    button5.Enabled = true;
                    LatestVersion.Text = "New updates found! Version " + newestversion.ToString() + " is online!";
                    MessageBox.Show("New update found, press OK to open the release page.", "New update found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Process.Start("https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases");
                }
                else if (x <= y)
                {
                    tabControl1.Enabled = true;
                    button5.Enabled = true;
                    LatestVersion.Text = "There are no updates available right now. Try checking later.";
                    MessageBox.Show("This release is already updated.", "No updates found.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tabControl1.Enabled = true;
                    button5.Enabled = true;
                    LatestVersion.Text = "There are no updates available right now. Try checking later.";
                    MessageBox.Show("This release is already updated.", "No updates found.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                tabControl1.Enabled = true;
                button5.Enabled = true;
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                ThisVersion.Text = "The current version of the converter, installed on your system, is: " + Converter.FileVersion.ToString();
                LatestVersion.Text = "Can not check for updates! You're offline, or maybe the website is temporarily down.";
                MessageBox.Show("Can not check for updates!\n\nSpecific .NET error:\n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string url = "";

            string business = "prapapappo1999@gmail.com";
            string description = "Donation";
            string country = "US";
            string currency = "USD";

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            Process.Start(url);
        }
    }
}
