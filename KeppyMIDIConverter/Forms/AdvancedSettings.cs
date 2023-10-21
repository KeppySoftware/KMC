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
            Delegate.SincInter.Text = Languages.Parse("SincInter");

            Delegate.MIDIEventsSettings.Text = Languages.Parse("MIDIEventsSettings");
            Delegate.IgnoreNotes1.Text = Languages.Parse("IgnoreNotes1");
            Delegate.HighestVel.Text = Languages.Parse("HighestVel");
            Delegate.LowestVel.Text = Languages.Parse("LowestVel");
            Delegate.Limit88.Text = Languages.Parse("Limit88");
            Delegate.Noteoff1.Text = Languages.Parse("NoteOff1");

            Delegate.StreamSettings.Text = Languages.Parse("StreamSettings");
            Delegate.ChannelsSettings.Text = Languages.Parse("ChannelsSettings");
            Delegate.RTFPSLabel.Text = Languages.Parse("RealTimeFramerate");
            Delegate.BitrateLabel.Text = String.Format("{0}:", Languages.Parse("Bitrate"));
            Delegate.FXDisable.Text = Languages.Parse("DisableEffects");
            Delegate.OverrideTempoNow.Text = Languages.Parse("OverrideTempo");
            Delegate.ConstantBitrate.Text = String.Format("{0}:", Languages.Parse("ConstantBitrate"));
            Delegate.OKBtn.Text = Languages.Parse("OKBtn");

            Delegate.NoRampIn.Text = Languages.Parse("NoteRampIn");
            Delegate.LinAttMod.Text = Languages.Parse("LinAttMod");
            Delegate.LinDecVol.Text = Languages.Parse("LinDecVol");
        }

        public AdvancedSettings()
        {
            InitializeComponent();
            Delegate = this;
            InitializeLanguage();

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
                SincInter.Checked = Properties.Settings.Default.SincInter;
                BitrateBox.Text = Convert.ToString(Properties.Settings.Default.Bitrate);
                RTFPS.Value = Convert.ToDecimal(Properties.Settings.Default.RealTimeFPS);
                IgnoreNotes1.Checked = Properties.Settings.Default.IgnoreNotes1;
                LoVel.Value = Properties.Settings.Default.IgnoreNotesLow;
                HiVel.Value = Properties.Settings.Default.IgnoreNotesHigh;
                Limit88.Checked = Properties.Settings.Default.Limit88;
                Noteoff1.Checked = Properties.Settings.Default.NoteOff1;
                FXDisable.Checked = Properties.Settings.Default.DisableEffects;
                ConstantBitrate.Checked = Properties.Settings.Default.OverrideBitrate;
                TempoValue.Enabled = OverrideTempoNow.Checked = Properties.Settings.Default.OverrideTempo;

                // NEW
                NoRampIn.Checked = Properties.Settings.Default.NoRampIn;
                LinAttMod.Checked = Properties.Settings.Default.LinAttMod;
                LinDecVol.Checked = Properties.Settings.Default.LinDecVol;
                //
            }
            catch (Exception ex)
            {
                ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("FatalError"), ex.ToString(), 1, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
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

        private void Limit88_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Limit88 = Limit88.Checked;
            Properties.Settings.Default.Save();
        }

        private void IgnoreNotes1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreNotes1 = IgnoreNotes1.Checked;
            Properties.Settings.Default.Save();
        }

        private void RTFPS_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RealTimeFPS = Convert.ToDouble(RTFPS.Value);
            Properties.Settings.Default.Save();
        }

        private void SincInter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SincInter = SincInter.Checked;
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
            Properties.Settings.Default.Voices = (int)MaxVoices.Value;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OverrideTempo = OverrideTempoNow.Checked;
            TempoValue.Enabled = OverrideTempoNow.Checked;
            TempoCurrent.Enabled = OverrideTempoNow.Checked;

            if (!Properties.Settings.Default.OverrideTempo)
                TempoValue.Value = 40;

            MainWindow.KMCGlobals.TempoScale = 1 / ((120 - TempoValue.Value) / 80.0f);
            BASSControl.SetTempo(false, false);

            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OverrideBitrate = ConstantBitrate.Checked;
            Properties.Settings.Default.Save();
            BitrateLabel.Enabled = ConstantBitrate.Checked;
            BitrateBox.Enabled = ConstantBitrate.Checked;
        }

        private void ChannelsSettings_Click(object sender, EventArgs e)
        {
            new ChannelsSettings().ShowDialog();
        }

        private void LoVel_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreNotesLow = (int)LoVel.Value;
            Properties.Settings.Default.Save();
        }

        private void HiVel_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreNotesHigh = (int)HiVel.Value;
            Properties.Settings.Default.Save();
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {

        }

        private void NoRampIn_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoRampIn = NoRampIn.Checked;
            Properties.Settings.Default.Save();
        }

        private void LinAttMod_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LinAttMod = LinAttMod.Checked;
            Properties.Settings.Default.Save();
        }

        private void LinDecVol_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LinDecVol = LinDecVol.Checked;
            Properties.Settings.Default.Save();
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
