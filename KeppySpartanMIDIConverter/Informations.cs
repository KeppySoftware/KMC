using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
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

        private void Informations_Load(object sender, EventArgs e)
        {
            // Auto-update stuff
            FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
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
            FileVersionInfo basslibver = FileVersionInfo.GetVersionInfo("bass.dll");
            FileVersionInfo bassmidilibver = FileVersionInfo.GetVersionInfo("bassmidi.dll");
            FileVersionInfo bassenclibver = FileVersionInfo.GetVersionInfo("bassenc.dll");
            FileVersionInfo bassnetlibver = FileVersionInfo.GetVersionInfo("Bass.Net.dll");

            // Print the file name and version number.
            BASSINFO.Text = basslibver.FileDescription + " version: " + basslibver.FileVersion + "." + basslibver.FilePrivatePart + "\n" +
                bassmidilibver.FileDescription + " version: " + bassmidilibver.FileVersion + "." + bassmidilibver.FilePrivatePart + "\n" +
                bassenclibver.FileDescription + " version: " + bassenclibver.FileVersion + "." + bassenclibver.FilePrivatePart + "\n" +
                bassnetlibver.FileDescription + " version: " + bassnetlibver.FileVersion + "." + bassnetlibver.FilePrivatePart;
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
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppy-s-MIDI-Driver/master/output/keppydriverupdate.txt");
                StreamReader reader = new StreamReader(stream);
                String newestversion = reader.ReadToEnd();
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                ThisVersion.Text = "The current version of the converter, installed on your system, is: " + Converter.FileVersion.ToString();
                LatestVersion.Text = "The latest version online, in the GitHub repository, is: " + newestversion.ToString();
                int x = 0;
                Int32.TryParse(newestversion.ToString(), out x);
                int y = 0;
                Int32.TryParse(Converter.FileVersion.ToString(), out y);
                if (x > y)
                {
                    MessageBox.Show("New update found, press OK to open the release page.", "New update found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Process.Start("http://goo.gl/BHgazb");
                }
                else
                {
                    MessageBox.Show("This release is already updated.", "No updates found.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                ThisVersion.Text = "The current version of the converter, installed on your system, is: " + Converter.FileVersion.ToString();
                LatestVersion.Text = "Can not check for updates. You're offline, or maybe the website is temporarily down.";
                MessageBox.Show("Can not check for updates!\n\nSpecific .NET error:\n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
