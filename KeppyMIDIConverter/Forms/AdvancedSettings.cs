using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace KeppyMIDIConverter
{
    public partial class AdvancedSettings : Form
    {
        public AdvancedSettings()
        {
            InitializeComponent();
        }

        Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);          
        public static Action NonStaticDelegate;

        public void InitializeLanguage()
        {
            // Translate system
            GroupBox1.Text = MainWindow.res_man.GetString("Settings", MainWindow.cul);
            Text = MainWindow.res_man.GetString("AdvSettingsTitle", MainWindow.cul);
            Label5.Text = MainWindow.res_man.GetString("AudioFreq", MainWindow.cul);
            Noteoff1.Text = MainWindow.res_man.GetString("NoteOff1", MainWindow.cul);
            FXDisable.Text = MainWindow.res_man.GetString("DisableFX", MainWindow.cul);
            label2.Text = MainWindow.res_man.GetString("NewValueTempo", MainWindow.cul);
            checkBox3.Text = MainWindow.res_man.GetString("ConstantBitrateOGG", MainWindow.cul);
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            InitializeLanguage();
            // W8
            if (MainWindow.KMCGlobals.IsKMCBusy == true && MainWindow.KMCGlobals.RenderingMode == false)
            {
                Label5.Enabled = false;
                FrequencyBox.Enabled = false;
                Label6.Enabled = false;
                checkBox1.Text = String.Format(MainWindow.res_man.GetString("OverrideTempo2", MainWindow.cul), MainWindow.KMCGlobals.OriginalTempo.ToString());
            }
            else
            {
                Label5.Enabled = true;
                FrequencyBox.Enabled = true;
                Label6.Enabled = true;
                checkBox1.Text = String.Format(MainWindow.res_man.GetString("OverrideTempo1", MainWindow.cul), MainWindow.KMCGlobals.OriginalTempo.ToString());
            }
            // K DONE
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            //
            FrequencyBox.Text = Convert.ToString(Settings.GetValue("audiofreq", 44100));
            BitrateBox.Text = Convert.ToString(Settings.GetValue("oggbitrate", 256));
            RTFPS.Value = Convert.ToDecimal(MainWindow.KMCGlobals.RTFPS);
            //
            if (Convert.ToInt32(Settings.GetValue("noteoff1", 0)) == 1)
            {
                MainWindow.KMCGlobals.NoteOff1Event = true;
                Noteoff1.Checked = true;
            }
            else
            {
                MainWindow.KMCGlobals.NoteOff1Event = false;
                Noteoff1.Checked = false;
            }
            if (Convert.ToInt32(Settings.GetValue("disablefx", 0)) == 1)
            {
                MainWindow.KMCGlobals.FXDisabled = true;
                FXDisable.Checked = true;
            }
            else
            {
                MainWindow.KMCGlobals.FXDisabled = false;
                FXDisable.Checked = false;
            }
            if (Convert.ToInt32(Settings.GetValue("overrideogg", 0)) == 1)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if (MainWindow.KMCGlobals.TempoOverride == true)
            {
                label2.Enabled = true;
                TempoVal.Enabled = true;
            }
            else
            {
                label2.Enabled = false;
                TempoVal.Enabled = false;
            }
            //
            if (BitrateBox.Text == "")
            {
                BitrateBox.Text = "256";
            }
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.Frequency = Convert.ToInt32(this.FrequencyBox.Text);
            Settings.SetValue("audiofreq", MainWindow.KMCGlobals.Frequency, Microsoft.Win32.RegistryValueKind.DWord);
        }

        private void BitrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.Bitrate = Convert.ToInt32(this.BitrateBox.Text);
            Settings.SetValue("oggbitrate", MainWindow.KMCGlobals.Bitrate, Microsoft.Win32.RegistryValueKind.DWord);
        }

        private void FXDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FXDisable.Checked)
            {
                MainWindow.KMCGlobals.FXDisabled = true;
                Settings.SetValue("disablefx", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                MainWindow.KMCGlobals.FXDisabled = false;
                Settings.SetValue("disablefx", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void Noteoff1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Noteoff1.Checked)
            {
                MainWindow.KMCGlobals.NoteOff1Event = true;
                Settings.SetValue("noteoff1", "1", Microsoft.Win32.RegistryValueKind.DWord);
            }
            else
            {
                MainWindow.KMCGlobals.NoteOff1Event = false;
                Settings.SetValue("noteoff1", "0", Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MainWindow.KMCGlobals.TempoOverride = true;
                label2.Enabled = true;
                TempoVal.Enabled = true;
            }
            else
            {
                MainWindow.KMCGlobals.TempoOverride = false;
                label2.Enabled = false;
                TempoVal.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.FinalTempo = Convert.ToInt32(TempoVal.Value);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Settings.SetValue("overrideogg", "1", Microsoft.Win32.RegistryValueKind.DWord);
                label3.Enabled = true;
                BitrateBox.Enabled = true;
                MainWindow.KMCGlobals.QualityOverride = true;
            }
            else
            {
                Settings.SetValue("overrideogg", "0", Microsoft.Win32.RegistryValueKind.DWord);
                label3.Enabled = false;
                BitrateBox.Enabled = false;
                MainWindow.KMCGlobals.QualityOverride = false;
            }
        }

        // Overrides

        protected override void OnShown(EventArgs e)
        {

            if (Properties.Settings.Default.SettLocation.X == 0 || Properties.Settings.Default.SettLocation.Y == 0)
                this.CenterToScreen();
            else
                Location = Properties.Settings.Default.SettLocation;
            base.OnShown(e);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Properties.Settings.Default.SettLocation = Location;
            Properties.Settings.Default.Save();
            Hide();
        }

        // Snap feature

        private const int SnapDist = 25;

        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
            if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
            if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
            if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
        }

        private void RTFPS_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.RTFPS = Convert.ToDouble(RTFPS.Value);
            Settings.SetValue("customfps", RTFPS.Value, Microsoft.Win32.RegistryValueKind.String);
        }
    }
}
