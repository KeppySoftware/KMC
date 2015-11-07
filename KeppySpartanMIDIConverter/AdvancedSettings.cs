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
            if (this.FrequencyBox.Text == "")
            {
                this.FrequencyBox.Text = "48000";
            }
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
            }
            else
            {
                MainWindow.Globals.ChorusAFX = false;
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
            }
            else
            {
                MainWindow.Globals.CompressorAFX = false;
            }
        }

        private void CompressorFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.CompressorAFXValue = Convert.ToInt32(this.CompressorFXNum.Value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DistortionFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DistortionFX.Checked)
            {
                MainWindow.Globals.DistortionAFX = true;
            }
            else
            {
                MainWindow.Globals.DistortionAFX = false;
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
            }
            else
            {
                MainWindow.Globals.EchoAFX = false;
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
            }
            else
            {
                MainWindow.Globals.FlangerAFX = false;
            }
        }

        private void FlangerFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.FlangerAFXValue = Convert.ToInt32(this.FlangerFXNum.Value);
        }

        private void FrequencyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.Frequency = Convert.ToInt32(this.FrequencyBox.Text);
        }

        private void FXDisable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.FXDisable.Checked)
            {
                MainWindow.Globals.FXDisabled = true;
            }
            else
            {
                MainWindow.Globals.FXDisabled = false;
            }
        }

        private void GargleFX_CheckedChanged(object sender, EventArgs e)
        {
            if (this.GargleFX.Checked)
            {
                MainWindow.Globals.GargleAFX = true;
            }
            else
            {
                MainWindow.Globals.GargleAFX = false;
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
            }
            else
            {
                MainWindow.Globals.NoteOff1Event = false;
            }
        }

        private void ReverbFX2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ReverbFX2.Checked)
            {
                MainWindow.Globals.ReverbAFX = true;
            }
            else
            {
                MainWindow.Globals.ReverbAFX = false;
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
            }
            else
            {
                MainWindow.Globals.SittingAFX = false;
            }
        }

        private void SittingFXNum_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Globals.SittingAFXValue = Convert.ToInt32(this.SittingFXNum.Value);
        }

    }
}
