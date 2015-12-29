using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeppySpartanMIDIConverter
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
                groupBox3.Enabled = false;
            }
            else
            {
                Label5.Enabled = true;
                FrequencyBox.Enabled = true;
                Label6.Enabled = true;
                groupBox3.Enabled = true;
            }
            // K DONE
            Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects");
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            //
            FrequencyBox.Text = Convert.ToString(Settings.GetValue("audiofreq"));
            //
            if (Convert.ToInt32(Effects.GetValue("reverb")) == 1)
            {
                MainWindow.Globals.ReverbAFX = true;
                ReverbFX2.Checked = false;
            }
            else
            {
                MainWindow.Globals.ReverbAFX = false;
                ReverbFX2.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("chorus")) == 1)
            {
                MainWindow.Globals.ChorusAFX = true;
                ChorusFX2.Checked = true;
            }
            else
            {
                MainWindow.Globals.ChorusAFX = false;
                ChorusFX2.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("flanger")) == 1)
            {
                MainWindow.Globals.FlangerAFX = true;
                FlangerFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.FlangerAFX = false;
                FlangerFX.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("compressor")) == 1)
            {
                MainWindow.Globals.CompressorAFX = true;
                CompressorFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.CompressorAFX = false;
                CompressorFX.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("gargle")) == 1)
            {
                MainWindow.Globals.GargleAFX = true;
                GargleFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.GargleAFX = false;
                GargleFX.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("distortion")) == 1)
            {
                MainWindow.Globals.DistortionAFX = true;
                DistortionFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.DistortionAFX = false;
                DistortionFX.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("echo")) == 1)
            {
                MainWindow.Globals.EchoAFX = true;
                EchoFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.EchoAFX = false;
                EchoFX.Checked = false;
            }
            if (Convert.ToInt32(Effects.GetValue("sittingroom")) == 1)
            {
                MainWindow.Globals.SittingAFX = true;
                SittingFX.Checked = true;
            }
            else
            {
                MainWindow.Globals.SittingAFX = false;
                SittingFX.Checked = false;
            }
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
            //
            Effects.Close();
            Settings.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ChorusFX2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChorusFX2.Checked)
            {
                MainWindow.Globals.ChorusAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("chorus", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.ChorusAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("chorus", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void ChorusFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.ChorusAFXValue = Convert.ToInt32(this.ChorusFXNum.Value);
        }

        private void CompressorFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CompressorFX.Checked)
            {
                MainWindow.Globals.CompressorAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("compressor", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.CompressorAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("compressor", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void CompressorFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.CompressorAFXValue = Convert.ToInt32(this.CompressorFXNum.Value);
        }

        private void DistortionFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DistortionFX.Checked)
            {
                MainWindow.Globals.DistortionAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("distortion", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.DistortionAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("distortion", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void DistortionFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.DistortionAFXValue = Convert.ToInt32(this.DistortionFXNum.Value);
        }

        private void EchoFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.EchoFX.Checked)
            {
                MainWindow.Globals.EchoAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("echo", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.EchoAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("echo", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void EchoFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.EchoAFXValue = Convert.ToInt32(this.EchoFXNum.Value);
        }

        private void FlangerFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FlangerFX.Checked)
            {
                MainWindow.Globals.FlangerAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("flanger", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.FlangerAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("flanger", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void FlangerFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.FlangerAFXValue = Convert.ToInt32(this.FlangerFXNum.Value);
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.Frequency = Convert.ToInt32(this.FrequencyBox.Text);
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("audiofreq", MainWindow.Globals.Frequency, Microsoft.Win32.RegistryValueKind.DWord);
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

        private void GargleFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.GargleFX.Checked)
            {
                MainWindow.Globals.GargleAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("gargle", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.GargleAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("gargle", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void GargleFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.GargleAFXValue = Convert.ToInt32(this.GargleFXNum.Value);
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

        private void ReverbFX2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ReverbFX2.Checked)
            {
                MainWindow.Globals.ReverbAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("reverb", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.ReverbAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("reverb", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void ReverbFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.ReverbAFXValue = Convert.ToInt32(this.ReverbFXNum.Value);
        }

        private void SittingFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SittingFX.Checked)
            {
                MainWindow.Globals.SittingAFX = true;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("sittingroom", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
            else
            {
                MainWindow.Globals.SittingAFX = false;
                Microsoft.Win32.RegistryKey Effects = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                Effects.SetValue("sittingroom", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Effects.Close();
            }
        }

        private void SittingFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.SittingAFXValue = Convert.ToInt32(this.SittingFXNum.Value);
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
    }
}
