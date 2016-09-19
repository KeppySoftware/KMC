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

        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;
        public static Action NonStaticDelegate;

        public void InitializeLanguage()
        {
            res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
            cul = Program.ReturnCulture();
            // Translate system
            GroupBox1.Text = res_man.GetString("Settings", cul);
            Text = res_man.GetString("AdvSettingsTitle", cul);
            Label5.Text = res_man.GetString("AudioFreq", cul);
            Noteoff1.Text = res_man.GetString("NoteOff1", cul);
            FXDisable.Text = res_man.GetString("DisableFX", cul);
            label2.Text = res_man.GetString("NewValueTempo", cul);
            checkBox3.Text = res_man.GetString("ConstantBitrateOGG", cul);
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            InitializeLanguage();
            // W8
            if (MainWindow.Globals.PlaybackMode == true)
            {
                Label5.Enabled = false;
                FrequencyBox.Enabled = false;
                Label6.Enabled = false;
                checkBox1.Text = String.Format(res_man.GetString("OverrideTempo2", cul), MainWindow.Globals.OriginalTempo.ToString());
            }
            else
            {
                Label5.Enabled = true;
                FrequencyBox.Enabled = true;
                Label6.Enabled = true;
                checkBox1.Text = String.Format(res_man.GetString("OverrideTempo1", cul), MainWindow.Globals.OriginalTempo.ToString());
            }
            // K DONE
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            //
            FrequencyBox.Text = Convert.ToString(Settings.GetValue("audiofreq", 44100));
            BitrateBox.Text = Convert.ToString(Settings.GetValue("oggbitrate", 256));
            //
            if (Convert.ToInt32(Settings.GetValue("noteoff1", 0)) == 1)
            {
                MainWindow.Globals.NoteOff1Event = true;
                Noteoff1.Checked = true;
            }
            else
            {
                MainWindow.Globals.NoteOff1Event = false;
                Noteoff1.Checked = false;
            }
            if (Convert.ToInt32(Settings.GetValue("disablefx", 0)) == 1)
            {
                MainWindow.Globals.FXDisabled = true;
                FXDisable.Checked = true;
            }
            else
            {
                MainWindow.Globals.FXDisabled = false;
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
            //
            if (BitrateBox.Text == "")
            {
                BitrateBox.Text = "256";
            }
            //
            Settings.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.Frequency = Convert.ToInt32(this.FrequencyBox.Text);
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("audiofreq", MainWindow.Globals.Frequency, Microsoft.Win32.RegistryValueKind.DWord);
            Settings.Close();
        }

        private void BitrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.Bitrate = Convert.ToInt32(this.BitrateBox.Text);
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("oggbitrate", MainWindow.Globals.Bitrate, Microsoft.Win32.RegistryValueKind.DWord);
            Settings.Close();
        }

        private void FXDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FXDisable.Checked)
            {
                MainWindow.Globals.FXDisabled = true;
                Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("disablefx", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Settings.Close();
            }
            else
            {
                MainWindow.Globals.FXDisabled = false;
                Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("disablefx", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Settings.Close();
            }
        }

        private void Noteoff1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Noteoff1.Checked)
            {
                MainWindow.Globals.NoteOff1Event = true;
                Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("noteoff1", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Settings.Close();
            }
            else
            {
                MainWindow.Globals.NoteOff1Event = false;
                Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("noteoff1", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Settings.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MainWindow.Globals.TempoOverride = true;
                label2.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                MainWindow.Globals.TempoOverride = false;
                label2.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.FinalTempo = Convert.ToInt32(numericUpDown1.Value);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            
            if (checkBox3.Checked == true)
            {
                Settings.SetValue("overrideogg", "1", Microsoft.Win32.RegistryValueKind.DWord);
                label3.Enabled = true;
                BitrateBox.Enabled = true;
            }
            else
            {
                Settings.SetValue("overrideogg", "0", Microsoft.Win32.RegistryValueKind.DWord);
                label3.Enabled = false;
                BitrateBox.Enabled = false;
            }
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
    }
}
