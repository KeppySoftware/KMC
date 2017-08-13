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

        public static Action NonStaticDelegate;

        public void InitializeLanguage()
        {
            // Translate system
            GroupBox1.Text = MainWindow.res_man.GetString("Settings", MainWindow.cul);
            Text = MainWindow.res_man.GetString("AdvSettingsTitle", MainWindow.cul);
            Label5.Text = MainWindow.res_man.GetString("AudioFreq", MainWindow.cul);
            Noteoff1.Text = MainWindow.res_man.GetString("NoteOff1", MainWindow.cul);
            FXDisable.Text = MainWindow.res_man.GetString("DisableFX", MainWindow.cul);
            TempoCurrent.Text = MainWindow.res_man.GetString("NewValueTempo", MainWindow.cul);
            checkBox3.Text = MainWindow.res_man.GetString("ConstantBitrateOGG", MainWindow.cul);
        }

        private void AdvancedSettings_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeLanguage();
                // W8
                if (MainWindow.KMCGlobals.IsKMCBusy == true && MainWindow.KMCGlobals.RenderingMode == false)
                {
                    Label5.Enabled = false;
                    FrequencyBox.Enabled = false;
                    Label6.Enabled = false;
                }
                else
                {
                    Label5.Enabled = true;
                    FrequencyBox.Enabled = true;
                    Label6.Enabled = true;
                }
                // K DONE
                OverrideTempoNow.Text = String.Format(MainWindow.res_man.GetString("OverrideTempo1", MainWindow.cul), MainWindow.KMCGlobals.OriginalTempo.ToString());
                FrequencyBox.Text = Convert.ToString(Properties.Settings.Default.AudioFreq);
                BitrateBox.Text = Convert.ToString(Properties.Settings.Default.OGGBitrate);
                RTFPS.Value = Convert.ToDecimal(MainWindow.KMCGlobals.RTFPS);
                //
                if (Properties.Settings.Default.NoteOff1 == true)
                {
                    MainWindow.KMCGlobals.NoteOff1Event = true;
                    Noteoff1.Checked = true;
                }
                else
                {
                    MainWindow.KMCGlobals.NoteOff1Event = false;
                    Noteoff1.Checked = false;
                }
                if (Properties.Settings.Default.DisableFX == true)
                {
                    MainWindow.KMCGlobals.FXDisabled = true;
                    FXDisable.Checked = true;
                }
                else
                {
                    MainWindow.KMCGlobals.FXDisabled = false;
                    FXDisable.Checked = false;
                }
                if (Properties.Settings.Default.OverrideOGG == true)
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                if (Properties.Settings.Default.TempoOverride == true)
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
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("FatalError", MainWindow.cul), ex.ToString(), 1, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.Frequency = Convert.ToInt32(this.FrequencyBox.Text);
            Properties.Settings.Default.AudioFreq = MainWindow.KMCGlobals.Frequency;
            Properties.Settings.Default.Save();
        }

        private void BitrateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.Bitrate = Convert.ToInt32(this.BitrateBox.Text);
            Properties.Settings.Default.OGGBitrate = MainWindow.KMCGlobals.Bitrate;
            Properties.Settings.Default.Save();
        }

        private void FXDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FXDisable.Checked)
            {
                MainWindow.KMCGlobals.FXDisabled = true;
                Properties.Settings.Default.DisableFX = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                MainWindow.KMCGlobals.FXDisabled = false;
                Properties.Settings.Default.DisableFX = false;
                Properties.Settings.Default.Save();
            }
        }

        private void Noteoff1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Noteoff1.Checked)
            {
                MainWindow.KMCGlobals.NoteOff1Event = true;
                Properties.Settings.Default.NoteOff1 = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                MainWindow.KMCGlobals.NoteOff1Event = false;
                Properties.Settings.Default.NoteOff1 = false;
                Properties.Settings.Default.Save();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (OverrideTempoNow.Checked == true)
            {
                Properties.Settings.Default.TempoOverride = true;
                TempoValue.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.TempoOverride = false;
                TempoValue.Enabled = false;
                TempoValue.Value = 40;
                MainWindow.KMCGlobals.TempoScale = 1 / ((120 - TempoValue.Value) / 80.0f);
                MainWindow.SetTempo(false);
            }
            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Properties.Settings.Default.OverrideOGG = true;
                Properties.Settings.Default.Save();
                label3.Enabled = true;
                BitrateBox.Enabled = true;
                MainWindow.KMCGlobals.QualityOverride = true;
            }
            else
            {
                Properties.Settings.Default.OverrideOGG = false;
                Properties.Settings.Default.Save();
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
            Properties.Settings.Default.RTFPS = MainWindow.KMCGlobals.RTFPS;
            Properties.Settings.Default.Save();
        }

        private void TempoValue_Scroll(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.TempoScale = 1 / ((120 - TempoValue.Value) / 80.0f);
            MainWindow.SetTempo(false);
        }

        private void CheckTempo_Tick(object sender, EventArgs e)
        {
            TempoCurrent.Text = String.Format("{0}bpm", Convert.ToDouble(60000000 / (MainWindow.KMCGlobals.MIDITempo * MainWindow.KMCGlobals.TempoScale)).ToString("0.0"));
        }
    }
}
