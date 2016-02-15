using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KeppyMIDIConverter
{
    public partial class SoundfontDialog : Form
    {
        public SoundfontDialog()
        {
            InitializeComponent();
        }

        public static class BankPresetValue
        {
            public static int bank1val = 0;
            public static int bank2val = 0;
            public static int bank3val = 0;
            public static int preset1val = 0;
            public static int preset2val = 0;
            public static int preset3val = 0;
        }

        private void SoundfontDialog_Load(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                if (Settings.GetValue("lastsf1folder").ToString() == null)
                {
                    SoundfontImportDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog1.InitialDirectory = Settings.GetValue("lastsf1folder").ToString();
                }
                if (Settings.GetValue("lastsf2folder").ToString() == null)
                {
                    SoundfontImportDialog2.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog1.InitialDirectory = Settings.GetValue("lastsf2folder").ToString();
                }
                if (Settings.GetValue("lastsf3folder").ToString() == null)
                {
                    SoundfontImportDialog3.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog1.InitialDirectory = Settings.GetValue("lastsf3folder").ToString();
                }
            }
            catch
            {

            }
        }

        private void ImportBtn1_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                if (Settings.GetValue("lastsf1folder").ToString() == null)
                {
                    SoundfontImportDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog1.InitialDirectory = Settings.GetValue("lastsf1folder").ToString();
                }
            }
            catch
            {

            }
            if (this.SoundfontImportDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(SoundfontImportDialog1.FileName) == ".sf2" | Path.GetExtension(SoundfontImportDialog1.FileName) == ".SF2")
                {
                    Settings.SetValue("lastsf1folder", Path.GetDirectoryName(SoundfontImportDialog1.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName1 = SoundfontImportDialog1.FileName;
                    SFPathText1.Text = SoundfontImportDialog1.FileName;
                    LoadBP1.Enabled = true;
                    LoadBP1.Checked = false;
                    Bank1.Enabled = false;
                    Preset1.Enabled = false;
                    Bank1.Minimum = -1;
                    Preset1.Minimum = -1;
                    Bank1.Value = -1;
                    Preset1.Value = -1;
                    BankPresetValue.bank1val = -1;
                    BankPresetValue.preset1val = -1;
                    Unload1.Enabled = true;
                }
                else if (Path.GetExtension(SoundfontImportDialog1.FileName) == ".sfz" | Path.GetExtension(SoundfontImportDialog1.FileName) == ".SFZ")
                {
                    Settings.SetValue("lastsf1folder", Path.GetDirectoryName(SoundfontImportDialog1.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName1 = SoundfontImportDialog1.FileName;
                    SFPathText1.Text = SoundfontImportDialog1.FileName;
                    LoadBP1.Enabled = false;
                    LoadBP1.Checked = false;
                    Bank1.Enabled = true;
                    Preset1.Enabled = true;
                    Bank1.Minimum = 0;
                    Preset1.Minimum = 0;
                    Bank1.Value = 0;
                    Preset1.Value = 0;
                    BankPresetValue.bank1val = -1;
                    BankPresetValue.preset1val = -1;
                    Unload2.Enabled = true;
                }
                else
                {
                    Settings.SetValue("lastsf1folder", Path.GetDirectoryName(SoundfontImportDialog1.FileName).ToString(), RegistryValueKind.String);
                    MessageBox.Show("Invalid soundfont!\n\nPlease select a valid soundfont and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName1 = null;
                    SFPathText1.Text = null;
                    Bank1.Enabled = false;
                    Preset1.Enabled = false;
                    Unload1.Enabled = false;
                }
            }
        }

        private void ImportBtn2_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                if (Settings.GetValue("lastsf2folder").ToString() == null)
                {
                    SoundfontImportDialog2.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog2.InitialDirectory = Settings.GetValue("lastsf2folder").ToString();
                }
            }
            catch
            {

            }
            if (this.SoundfontImportDialog2.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(SoundfontImportDialog2.FileName) == ".sf2" | Path.GetExtension(SoundfontImportDialog2.FileName) == ".SF2")
                {
                    Settings.SetValue("lastsf2folder", Path.GetDirectoryName(SoundfontImportDialog2.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName2 = SoundfontImportDialog2.FileName;
                    SFPathText2.Text = SoundfontImportDialog2.FileName;
                    LoadBP2.Enabled = true;
                    LoadBP2.Checked = false;
                    Bank2.Enabled = false;
                    Preset2.Enabled = false;
                    Bank2.Minimum = -1;
                    Preset2.Minimum = -1;
                    Bank2.Value = -1;
                    Preset2.Value = -1;
                    BankPresetValue.bank2val = -1;
                    BankPresetValue.preset2val = -1;
                    Unload2.Enabled = true;
                }
                else if (Path.GetExtension(SoundfontImportDialog2.FileName) == ".sfz" | Path.GetExtension(SoundfontImportDialog2.FileName) == ".SFZ")
                {
                    Settings.SetValue("lastsf2folder", Path.GetDirectoryName(SoundfontImportDialog2.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName2 = SoundfontImportDialog2.FileName;
                    SFPathText2.Text = SoundfontImportDialog1.FileName;
                    LoadBP2.Enabled = false;
                    LoadBP2.Checked = false;
                    Bank2.Enabled = true;
                    Preset2.Enabled = true;
                    Bank2.Minimum = 0;
                    Preset2.Minimum = 0;
                    Bank2.Value = 0;
                    Preset2.Value = 0;
                    BankPresetValue.bank2val = 0;
                    BankPresetValue.preset2val = 0;
                    Unload2.Enabled = true;
                }
                else
                {
                    Settings.SetValue("lastsf2folder", Path.GetDirectoryName(SoundfontImportDialog2.FileName).ToString(), RegistryValueKind.String);
                    MessageBox.Show("Invalid soundfont!\n\nPlease select a valid soundfont and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName2 = null;
                    SFPathText2.Text = null;
                    Bank2.Enabled = false;
                    Preset2.Enabled = false;
                    Unload2.Enabled = false;
                }
            }
        }

        private void ImportBtn3_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                if (Settings.GetValue("lastsf3folder").ToString() == null)
                {
                    SoundfontImportDialog3.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog3.InitialDirectory = Settings.GetValue("lastsf3folder").ToString();
                }
            }
            catch
            {

            }
            if (this.SoundfontImportDialog3.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(SoundfontImportDialog3.FileName) == ".sf2" | Path.GetExtension(SoundfontImportDialog3.FileName) == ".SF2")
                {
                    Settings.SetValue("lastsf3folder", Path.GetDirectoryName(SoundfontImportDialog3.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName3 = SoundfontImportDialog3.FileName;
                    SFPathText3.Text = SoundfontImportDialog3.FileName;
                    LoadBP3.Enabled = true;
                    LoadBP3.Checked = false;
                    Bank3.Enabled = false;
                    Preset3.Enabled = false;
                    Bank3.Minimum = -1;
                    Preset3.Minimum = -1;
                    Bank3.Value = -1;
                    Preset3.Value = -1;
                    BankPresetValue.bank3val = -1;
                    BankPresetValue.preset3val = -1;
                    Unload3.Enabled = true;

                }
                else if (Path.GetExtension(SoundfontImportDialog3.FileName) == ".sfz" | Path.GetExtension(SoundfontImportDialog3.FileName) == ".SFZ")
                {
                    Settings.SetValue("lastsf3folder", Path.GetDirectoryName(SoundfontImportDialog3.FileName).ToString(), RegistryValueKind.String);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName3 = SoundfontImportDialog3.FileName;
                    SFPathText3.Text = SoundfontImportDialog3.FileName;
                    LoadBP3.Enabled = false;
                    LoadBP3.Checked = false;
                    Bank3.Enabled = true;
                    Preset3.Enabled = true;
                    Bank3.Minimum = 0;
                    Preset3.Minimum = 0;
                    Bank3.Value = 0;
                    Preset3.Value = 0;
                    BankPresetValue.bank3val = 0;
                    BankPresetValue.preset3val = 0;
                    Unload3.Enabled = true;
                }
                else
                {
                    Settings.SetValue("lastsf3folder", Path.GetDirectoryName(SoundfontImportDialog3.FileName).ToString(), RegistryValueKind.String);
                    MessageBox.Show("Invalid soundfont!\n\nPlease select a valid soundfont and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    KeppySpartanMIDIConverter.MainWindow.Globals.SFName3 = null;
                    SFPathText3.Text = null;
                    Bank3.Enabled = false;
                    Preset3.Enabled = false;
                    Unload3.Enabled = false;
                }
            }
        }

        private void Bank1_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.bank1val = Convert.ToInt32(Bank1.Value);
        }

        private void Bank2_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.bank2val = Convert.ToInt32(Bank2.Value);
        }

        private void Bank3_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.bank3val = Convert.ToInt32(Bank3.Value);
        }

        private void Preset1_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.preset1val = Convert.ToInt32(Preset1.Value);
        }

        private void Preset2_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.preset2val = Convert.ToInt32(Preset2.Value);
        }

        private void Preset3_ValueChanged(object sender, EventArgs e)
        {
            BankPresetValue.preset3val = Convert.ToInt32(Preset3.Value);
        }


        private void LoadBP1_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadBP1.Checked == true)
            {
                Bank1.Enabled = true;
                Preset1.Enabled = true;
                Bank1.Minimum = 0;
                Preset1.Minimum = 0;
            }
            else
            {
                Bank1.Enabled = false;
                Preset1.Enabled = false;
                Bank1.Minimum = -1;
                Preset1.Minimum = -1;
                Bank1.Value = -1;
                Preset1.Value = -1;
            }
        }

        private void LoadBP2_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadBP2.Checked == true)
            {
                Bank2.Enabled = true;
                Preset2.Enabled = true;
                Bank2.Minimum = 0;
                Preset2.Minimum = 0;
            }
            else
            {
                Bank2.Enabled = false;
                Preset2.Enabled = false;
                Bank2.Minimum = -1;
                Preset2.Minimum = -1;
                Bank2.Value = -1;
                Preset2.Value = -1;
            }
        }

        private void LoadBP3_CheckedChanged(object sender, EventArgs e)
        {

            if (LoadBP3.Checked == true)
            {
                Bank3.Enabled = true;
                Preset3.Enabled = true;
                Bank3.Minimum = 0;
                Preset3.Minimum = 0;
            }
            else
            {
                Bank3.Enabled = false;
                Preset3.Enabled = false;
                Bank3.Minimum = -1;
                Preset3.Minimum = -1;
                Bank3.Value = -1;
                Preset3.Value = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Unload1_Click(object sender, EventArgs e)
        {
            SFPathText1.Text = null;
            Bank1.Minimum = 0;
            Preset1.Minimum = 0;
            Bank1.Value = 127;
            Preset1.Value = 127;
            Bank1.Enabled = false;
            Preset1.Enabled = false;
            KeppySpartanMIDIConverter.MainWindow.Globals.SFName1 = null;
            LoadBP1.Enabled = false;
            LoadBP1.Checked = false;
            Unload1.Enabled = false;
        }

        private void Unload2_Click(object sender, EventArgs e)
        {
            SFPathText2.Text = null;
            Bank2.Minimum = 0;
            Preset2.Minimum = 0;
            Bank2.Value = 127;
            Preset2.Value = 127;
            Bank2.Enabled = false;
            Preset2.Enabled = false;
            KeppySpartanMIDIConverter.MainWindow.Globals.SFName2 = null;
            LoadBP2.Enabled = false;
            LoadBP2.Checked = false;
            Unload2.Enabled = false;
        }

        private void Unload3_Click(object sender, EventArgs e)
        {
            SFPathText3.Text = null;
            Bank3.Minimum = 0;
            Preset3.Minimum = 0;
            Bank3.Value = 127;
            Preset3.Value = 127;
            Bank3.Enabled = false;
            Preset3.Enabled = false;
            KeppySpartanMIDIConverter.MainWindow.Globals.SFName3 = null;
            LoadBP3.Enabled = false;
            LoadBP3.Checked = false;
            Unload3.Enabled = false;
        }

        private void Unload2IfCheckFailed()
        {
            SFPathText2.Text = null;
            Bank2.Minimum = 0;
            Preset2.Minimum = 0;
            Bank2.Value = 127;
            Preset2.Value = 127;
            Bank2.Enabled = false;
            Preset2.Enabled = false;
            KeppySpartanMIDIConverter.MainWindow.Globals.SFName2 = null;
            LoadBP2.Enabled = false;
            LoadBP2.Checked = false;
            Unload2.Enabled = false;
        }

        private void Unload3IfCheckFailed()
        {
            SFPathText3.Text = null;
            Bank3.Minimum = 0;
            Preset3.Minimum = 0;
            Bank3.Value = 127;
            Preset3.Value = 127;
            Bank3.Enabled = false;
            Preset3.Enabled = false;
            KeppySpartanMIDIConverter.MainWindow.Globals.SFName3 = null;
            LoadBP3.Enabled = false;
            LoadBP3.Checked = false;
            Unload3.Enabled = false;
        }

        private void SFLoadCheck_Tick(object sender, EventArgs e)
        {
            if (SFPathText1.Text == "")
            {
                ImportBtn2.Enabled = false;
                Unload2IfCheckFailed();
            }
            else
            {
                ImportBtn2.Enabled = true;      
            }
            if (SFPathText2.Text == "")
            {
                ImportBtn3.Enabled = false;
                Unload3IfCheckFailed();
            }
            else
            {
                ImportBtn3.Enabled = true;
            }

        }
    }
}
