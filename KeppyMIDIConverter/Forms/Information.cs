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
using System.Globalization;
using System.Resources;
using System.IO;

namespace KeppyMIDIConverter
{
    public partial class Informations : Form
    {
        public Informations()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        private void InitializeLanguage()
        {
            button2.Text = MainWindow.res_man.GetString("Un4seenWebsite", MainWindow.cul);
            button3.Text = MainWindow.res_man.GetString("License", MainWindow.cul);
            Text = String.Format("{0} (Build date: {1})", MainWindow.res_man.GetString("InfoWindowTitle", MainWindow.cul), GetLinkerTime(Assembly.GetExecutingAssembly(), TimeZoneInfo.Utc));
            InfoPg.Text = MainWindow.res_man.GetString("InfoPageTitle", MainWindow.cul);
            UpdtPg.Text = MainWindow.res_man.GetString("UpdaterPageTitle", MainWindow.cul);
            label1.Text = String.Format(MainWindow.res_man.GetString("Credits", MainWindow.cul), DateTime.Now.Year.ToString(), MainWindow.res_man.GetString("Un4seenWebsite", MainWindow.cul));
            LatestVersion.Text = MainWindow.res_man.GetString("LatestVersionIdle", MainWindow.cul);
            CFU.Text = MainWindow.res_man.GetString("CheckForUpdatesBtn", MainWindow.cul);
            DonateBtn.Text = MainWindow.res_man.GetString("Donate", MainWindow.cul);
        }

        public static string ExecutablePath = KeppyMIDIConverter.MainWindow.KMCGlobals.ExecutablePath;

        private void Informations_Load(object sender, EventArgs e)
        {
            try
            {
                // Auto-update stuff
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string SAS = null;
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo(assembly.Location);
                ThisVersion.Text = String.Format(MainWindow.res_man.GetString("CurrentVersion", MainWindow.cul), Converter.FileVersion.ToString());

                // STUFF
                if (IntPtr.Size == 8)
                {
                    Versionlabel.Text = String.Format(MainWindow.res_man.GetString("VersionLabel", MainWindow.cul), "64-bit", "SSE2");
                    SAS = "x64";
                }
                else if (IntPtr.Size == 4)
                {
                    Versionlabel.Text = String.Format(MainWindow.res_man.GetString("VersionLabel", MainWindow.cul), "32-bit", "MMX");
                    SAS = "x86";
                }

                KeppyVer.Text = "Keppy's MIDI Converter " + Application.ProductVersion + ", by KaleidonKep99";

                // OTHER STUFF
                FileVersionInfo basslibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bass.dll");
                FileVersionInfo bassmidilibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bassmidi.dll");
                FileVersionInfo bassenclibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bassenc.dll");
                FileVersionInfo bassvstlibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bass_vst.dll");

                // Print the file name and version number.
                String.Format(MainWindow.res_man.GetString("LibraryVersion", MainWindow.cul), basslibver.FileDescription, basslibver.FileVersion, basslibver.FilePrivatePart);
                BASSINFO.Text = String.Format(MainWindow.res_man.GetString("LibraryVersion", MainWindow.cul), "BASS", basslibver.FileVersion, basslibver.FilePrivatePart) +"\n" +
                    String.Format(MainWindow.res_man.GetString("LibraryVersion", MainWindow.cul), "BASSMIDI", bassmidilibver.FileVersion, bassmidilibver.FilePrivatePart) + "\n" +
                    String.Format(MainWindow.res_man.GetString("LibraryVersion", MainWindow.cul), "BASSenc", bassenclibver.FileVersion, bassenclibver.FilePrivatePart) + "\n" +
                    String.Format(MainWindow.res_man.GetString("LibraryVersion", MainWindow.cul), "BASS_VST", bassvstlibver.FileVersion, bassvstlibver.FilePrivatePart);

                BASSINFO2.Text = "Translated by\n" +
                    MainWindow.res_man.GetString("ZZZTranslators", MainWindow.cul) + "\n\n" + 
                     "KMC " + Application.ProductVersion + " " + SAS;
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("FatalError", MainWindow.cul), exception.ToString(), 1, 0);
                errordialog.ShowDialog();
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
            string license = "..\\license.rtf";
            string license2 = "license.rtf";
            if (File.Exists(license) == true && File.Exists(license2) == true)
            {
                System.Diagnostics.Process.Start("wordpad.exe", license);
            }
            else if (File.Exists(license) == true && File.Exists(license2) == false)
            {
                System.Diagnostics.Process.Start("wordpad.exe", license);
            }
            else if (File.Exists(license) == false && File.Exists(license2) == true)
            {
                System.Diagnostics.Process.Start("wordpad.exe", license2);
            }
            else if (File.Exists(license) == false && File.Exists(license2) == false)
            {
                MessageBox.Show("I can't seem to find the license anywhere...", "Oops, that's embarassing!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                CFU.Enabled = false;
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppyMIDIConverter/kmcupdate.txt");
                StreamReader reader = new StreamReader(stream);
                String newestversion = reader.ReadToEnd();
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                LatestVersion.Text = "Checking for updates, please wait...";
                ThisVersion.Text = String.Format(MainWindow.res_man.GetString("CurrentVersion", MainWindow.cul), Converter.FileVersion.ToString());
                Version x = null;
                Version.TryParse(newestversion.ToString(), out x);
                Version y = null;
                Version.TryParse(Converter.FileVersion.ToString(), out y);
                if (ModifierKeys == Keys.Shift)
                {
                    UpdateDownloader frm = new UpdateDownloader(newestversion);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
                else
                {
                    if (x > y)
                    {
                        tabControl1.Enabled = true;
                        CFU.Enabled = true;
                        LatestVersion.Text = String.Format(MainWindow.res_man.GetString("UpdateFoundVer", MainWindow.cul), newestversion.ToString());
                        DialogResult dialogResult = MessageBox.Show(MainWindow.res_man.GetString("UpdatesFoundText", MainWindow.cul), MainWindow.res_man.GetString("UpdatesFoundTitle", MainWindow.cul), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (dialogResult == DialogResult.Yes)
                        {
                            UpdateDownloader frm = new UpdateDownloader(newestversion);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        tabControl1.Enabled = true;
                        CFU.Enabled = true;
                        LatestVersion.Text = String.Format("{0} ({1})", MainWindow.res_man.GetString("NoUpdatesText", MainWindow.cul), y.ToString());
                        MessageBox.Show(MainWindow.res_man.GetString("NoUpdatesText", MainWindow.cul), MainWindow.res_man.GetString("NoUpdatesTitle", MainWindow.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                tabControl1.Enabled = true;
                CFU.Enabled = true;
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                ThisVersion.Text = String.Format(MainWindow.res_man.GetString("CurrentVersion", MainWindow.cul), Converter.FileVersion.ToString());
                LatestVersion.Text = MainWindow.res_man.GetString("CanNotCheckUpdates", MainWindow.cul);
                MessageBox.Show(String.Format(MainWindow.res_man.GetString("CanNotCheckUpdatesMsg", MainWindow.cul), ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DonateBtn_Click(object sender, EventArgs e)
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
