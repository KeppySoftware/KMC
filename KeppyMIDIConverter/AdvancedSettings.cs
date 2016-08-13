using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class AdvancedSettings : Form
    {
        public AdvancedSettings()
        {
            InitializeComponent();
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            // W8
            if (MainWindow.Globals.PlaybackMode == true)
            {
                Label5.Enabled = false;
                FrequencyBox.Enabled = false;
                Label6.Enabled = false;
                checkBox1.Text = "Override tempo (Original: " + MainWindow.Globals.OriginalTempo.ToString() + "bpm)";
            }
            else
            {
                Label5.Enabled = true;
                FrequencyBox.Enabled = true;
                Label6.Enabled = true;
                checkBox1.Text = "Override tempo (Playback mode only)";
            }
            // K DONE
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            //
            FrequencyBox.Text = Convert.ToString(Settings.GetValue("audiofreq"));
            BitrateBox.Text = Convert.ToString(Settings.GetValue("oggbitrate"));
            //
            if (Convert.ToInt32(Settings.GetValue("noteoff1")) == 1)
            {
                MainWindow.Globals.NoteOff1Event = true;
                Noteoff1.Checked = true;
            }
            else
            {
                MainWindow.Globals.NoteOff1Event = false;
                Noteoff1.Checked = false;
            }
            if (Convert.ToInt32(Settings.GetValue("disablefx")) == 1)
            {
                MainWindow.Globals.FXDisabled = true;
                FXDisable.Checked = true;
            }
            else
            {
                MainWindow.Globals.FXDisabled = false;
                FXDisable.Checked = false;
            }
            if (Convert.ToInt32(Settings.GetValue("overrideogg")) == 1)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Guide.Active = true;
            }
            else
            {
                Guide.Active = false;
            }
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
    }
}
