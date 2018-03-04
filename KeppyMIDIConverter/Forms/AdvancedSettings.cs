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
        public static AdvancedSettings Delegate;

        public static void InitializeLanguage()
        {
            // Translate system
            Delegate.Text = Languages.Parse("AdvSettingsTitle");

            Delegate.AudioSettings.Text = Languages.Parse("AudioSettings");
            Delegate.MaxVoicesLabel.Text = Languages.Parse("MaxVoices");
            Delegate.AudioFreqLabel.Text = Languages.Parse("AudioFreq");

            Delegate.ChannelsSettings.Text = Languages.Parse("ChannelsSettings");
            Delegate.StreamSettings.Text = Languages.Parse("StreamSettings");
            Delegate.RTFPSLabel.Text = Languages.Parse("RealTimeFramerate");
            Delegate.BitrateLabel.Text = String.Format("{0}:", Languages.Parse("Bitrate"));
            Delegate.Noteoff1.Text = Languages.Parse("NoteOff1");
            Delegate.FXDisable.Text = Languages.Parse("DisableEffects");
            Delegate.OverrideTempoNow.Text = Languages.Parse("OverrideTempo");
            Delegate.ConstantBitrate.Text = String.Format("{0}:", Languages.Parse("ConstantBitrate"));
            Delegate.OKBtn.Text = Languages.Parse("OKBtn");
        }

        public AdvancedSettings()
        {
            InitializeComponent();
            Delegate = this;
            InitializeLanguage();
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            try
            {
                // W8
                if (MainWindow.KMCStatus.IsKMCBusy == true && MainWindow.KMCStatus.RenderingMode == false)
                {
                    AudioFreqLabel.Enabled = false;
                    FrequencyBox.Enabled = false;
                    Label6.Enabled = false;
                }
                else
                {
                    AudioFreqLabel.Enabled = true;
                    FrequencyBox.Enabled = true;
                    Label6.Enabled = true;
                }
                // K DONE
                MaxVoices.Value = Properties.Settings.Default.Voices.LimitToRange(0, (Int32)MaxVoices.Maximum);
                OverrideTempoNow.Text = String.Format(Languages.Parse("OverrideTempo"), MainWindow.KMCGlobals.OriginalTempo.ToString());
                FrequencyBox.Text = Convert.ToString(Properties.Settings.Default.AudioFreq);
                BitrateBox.Text = Convert.ToString(Properties.Settings.Default.Bitrate);
                RTFPS.Value = Convert.ToDecimal(Properties.Settings.Default.RealTimeFPS);
                //
                if (Properties.Settings.Default.NoteOff1 == true)
                    Noteoff1.Checked = true;
                else
                    Noteoff1.Checked = false;

                if (Properties.Settings.Default.DisableEffects == true)
                    FXDisable.Checked = true;
                else
                    FXDisable.Checked = false;

                if (Properties.Settings.Default.OverrideBitrate == true)
                    ConstantBitrate.Checked = true;
                else
                    ConstantBitrate.Checked = false;

                if (Properties.Settings.Default.OverrideTempo == true)
                {
                    OverrideTempoNow.Checked = true;
                    TempoValue.Enabled = true;
                }
                else
                {
                    OverrideTempoNow.Checked = false;
                    TempoValue.Enabled = false;
                    TempoValue.Value = 40;
                }
            }
            catch (Exception ex)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("FatalError"), ex.ToString(), 1, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioFreq = Convert.ToInt32(this.FrequencyBox.Text);
            Properties.Settings.Default.Save();
        }

        private void BitrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Bitrate = Convert.ToInt32(this.BitrateBox.Text);
            Properties.Settings.Default.Save();
        }

        private void FXDisable_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DisableEffects = FXDisable.Checked;
            Properties.Settings.Default.Save();
        }

        private void Noteoff1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoteOff1 = Noteoff1.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (OverrideTempoNow.Checked == true)
            {
                Properties.Settings.Default.OverrideTempo = true;
                TempoValue.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.OverrideTempo = false;
                TempoValue.Enabled = false;
                TempoValue.Value = 40;
                MainWindow.KMCGlobals.TempoScale = 1 / ((120 - TempoValue.Value) / 80.0f);
                BASSControl.SetTempo(false, false);
            }
            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (ConstantBitrate.Checked == true)
            {
                Properties.Settings.Default.OverrideBitrate = true;
                Properties.Settings.Default.Save();
                BitrateLabel.Enabled = true;
                BitrateBox.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.OverrideBitrate = false;
                Properties.Settings.Default.Save();
                BitrateLabel.Enabled = false;
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

        private void RTFPS_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RealTimeFPS = Convert.ToDouble(RTFPS.Value);
            Properties.Settings.Default.Save();
        }

        private void TempoValue_Scroll(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.TempoScale = 1 / ((120 - TempoValue.Value) / 80.0f);
            BASSControl.SetTempo(false, false);
        }

        private void CheckTempo_Tick(object sender, EventArgs e)
        {
            TempoCurrent.Text = String.Format("{0}bpm", Convert.ToDouble(60000000 / (MainWindow.KMCGlobals.MIDITempo * MainWindow.KMCGlobals.TempoScale)).ToString("0.0"));
        }

        private void MaxVoices_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Voices = (int)MaxVoices.Value;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), ex.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void ChannelsSettings_Click(object sender, EventArgs e)
        {
            new ChannelsSettings().ShowDialog();
        }
    }
}
