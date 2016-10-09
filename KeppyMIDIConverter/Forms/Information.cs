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

        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info


        private void InitializeLanguage()
        {
            try
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture();
                // Translate system
                button2.Text = res_man.GetString("Un4seenWebsite", cul);
                button3.Text = res_man.GetString("License", cul);
                Text = res_man.GetString("InfoWindowTitle", cul);
                InfoPg.Text = res_man.GetString("InfoPageTitle", cul);
                UpdtPg.Text = res_man.GetString("UpdaterPageTitle", cul);
                label1.Text = String.Format(res_man.GetString("Credits", cul), DateTime.Now.Year.ToString(), res_man.GetString("Un4seenWebsite", cul));
                LatestVersion.Text = res_man.GetString("LatestVersionIdle", cul);
                button5.Text = res_man.GetString("CheckForUpdatesBtn", cul);
            }
            catch
            {
                MessageBox.Show("Keppy's MIDI Converter tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                // Translate system
                button2.Text = res_man.GetString("Un4seenWebsite", cul);
                button3.Text = res_man.GetString("License", cul);
                Text = res_man.GetString("InfoWindowTitle", cul);
                InfoPg.Text = res_man.GetString("InfoPageTitle", cul);
                UpdtPg.Text = res_man.GetString("UpdaterPageTitle", cul);
                label1.Text = String.Format(res_man.GetString("Credits", cul), res_man.GetString("Un4seenWebsite", cul));
                LatestVersion.Text = res_man.GetString("LatestVersionIdle", cul);
                button5.Text = res_man.GetString("CheckForUpdatesBtn", cul);
            }
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
                ThisVersion.Text = String.Format(res_man.GetString("CurrentVersion", cul), Converter.FileVersion.ToString());

                // STUFF
                if (IntPtr.Size == 8)
                {
                    Versionlabel.Text = String.Format(res_man.GetString("VersionLabel", cul), "64-bit", "SSE2");
                    SAS = "x64";
                }
                else if (IntPtr.Size == 4)
                {
                    Versionlabel.Text = String.Format(res_man.GetString("VersionLabel", cul), "32-bit", "MMX");
                    SAS = "x86";
                }

                KeppyVer.Text = "Keppy's MIDI Converter " + Application.ProductVersion + ", by KaleidonKep99";

                // OTHER STUFF
                FileVersionInfo basslibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bass.dll");
                FileVersionInfo bassmidilibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bassmidi.dll");
                FileVersionInfo bassenclibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bassenc.dll");
                FileVersionInfo bassvstlibver = FileVersionInfo.GetVersionInfo(ExecutablePath + @"\bass_vst.dll");

                // Print the file name and version number.
                String.Format(res_man.GetString("LibraryVersion", cul), basslibver.FileDescription, basslibver.FileVersion, basslibver.FilePrivatePart);
                BASSINFO.Text = String.Format(res_man.GetString("LibraryVersion", cul), "BASS", basslibver.FileVersion, basslibver.FilePrivatePart) +"\n" +
                    String.Format(res_man.GetString("LibraryVersion", cul), "BASSMIDI", bassmidilibver.FileVersion, bassmidilibver.FilePrivatePart) + "\n" +
                    String.Format(res_man.GetString("LibraryVersion", cul), "BASSenc", bassenclibver.FileVersion, bassenclibver.FilePrivatePart) + "\n" +
                    String.Format(res_man.GetString("LibraryVersion", cul), "BASS_VST", bassvstlibver.FileVersion, bassvstlibver.FilePrivatePart);

                BASSINFO2.Text = "Translated by\n" +
                    res_man.GetString("ZZZTranslators", cul) + "\n\n" + 
                     "KMC " + Application.ProductVersion + " " + SAS;
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("FatalError", cul), exception.ToString(), 1, 0);
                errordialog.ShowDialog();
            }
        }

        private void Information_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
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
                button5.Enabled = false;
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppySpartanMIDIConverter/kmcupdate.txt");
                StreamReader reader = new StreamReader(stream);
                String newestversion = reader.ReadToEnd();
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                LatestVersion.Text = "Checking for updates, please wait...";
                ThisVersion.Text = String.Format(res_man.GetString("CurrentVersion", cul), Converter.FileVersion.ToString());
                Version x = null;
                Version.TryParse(newestversion.ToString(), out x);
                Version y = null;
                Version.TryParse(Converter.FileVersion.ToString(), out y);
                if (x > y)
                {
                    tabControl1.Enabled = true;
                    button5.Enabled = true;
                    LatestVersion.Text = String.Format(res_man.GetString("UpdateFoundVer", cul), newestversion.ToString());
                    DialogResult dialogResult = MessageBox.Show(res_man.GetString("UpdatesFoundText", cul), res_man.GetString("UpdatesFoundTitle", cul), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                    button5.Enabled = true;
                    LatestVersion.Text = String.Format("{0} ({1})", res_man.GetString("NoUpdatesText", cul), y.ToString());
                    MessageBox.Show(res_man.GetString("NoUpdatesText", cul), res_man.GetString("NoUpdatesTitle", cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                tabControl1.Enabled = true;
                button5.Enabled = true;
                FileVersionInfo Converter = FileVersionInfo.GetVersionInfo("KeppyMIDIConverter.exe");
                ThisVersion.Text = String.Format(res_man.GetString("CurrentVersion", cul), Converter.FileVersion.ToString());
                LatestVersion.Text = res_man.GetString("CanNotCheckUpdates", cul);
                MessageBox.Show(String.Format(res_man.GetString("CanNotCheckUpdatesMsg", cul), ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void TrumpTrigger_Click(object sender, EventArgs e)
        {
            using (Form form = new Form())
            {
                form.Text = "I vote for Trump.";
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                form.Text = "Vote Donald Trump 2016 ~ Make America great again!";
                form.ShowIcon = false;
                form.ShowInTaskbar = false;
                form.BackgroundImage = KeppyMIDIConverter.Properties.Resources.americagreatagain;
                form.Size = new Size(506, 253);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Shown += new System.EventHandler(PlayTrumpy);
                form.ShowDialog();
            }
        }

        private void PlayTrumpy(object sender, EventArgs e)
        {
            System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.heh;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
            player.PlaySync();
            DialogResult potato = MessageBox.Show("Vote Trump 2016!\n\n~Keppy", "Very important message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (potato == DialogResult.Yes)
                MessageBox.Show(":)", "Clinton's e-mails are interesting.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (potato == DialogResult.No)
                MessageBox.Show(">:(", "Get out", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
