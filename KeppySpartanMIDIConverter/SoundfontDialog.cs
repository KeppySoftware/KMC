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
                if (Settings.GetValue("lastsffolder").ToString() == null)
                {
                    SoundfontImportDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog.InitialDirectory = Settings.GetValue("lastsf1folder").ToString();
                }
            }
            catch
            {

            }
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                if (Settings.GetValue("lastsffolder").ToString() == null)
                {
                    SoundfontImportDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                else
                {
                    SoundfontImportDialog.InitialDirectory = Settings.GetValue("lastsffolder").ToString();
                }
            }
            catch
            {

            }
            if (this.SoundfontImportDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in SoundfontImportDialog.FileNames)
                {
                    if (Path.GetExtension(file) == ".sf2" | Path.GetExtension(file) == ".SF2" | Path.GetExtension(file) == ".sfz" | Path.GetExtension(file) == ".SFZ" | Path.GetExtension(file) == ".sf3" | Path.GetExtension(file) == ".SF3" | Path.GetExtension(file) == ".sfpack" | Path.GetExtension(file) == ".SFPACK")
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        SFList.Items.Add(file);
                    }
                    else
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show("Invalid soundfont!\n\nPlease select a valid soundfont and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[SFList.Items.Count];
                SFList.Items.CopyTo(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0);
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.SFList.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    this.SFList.Items.RemoveAt(this.SFList.SelectedIndices[i]);
                }
                if (SFList.Items.Count == 0)
                {
                    Array.Clear(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0, KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts.Length);
                }
                else
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0);
                }
            }
            catch
            {

            }
        }

        private void SFList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            int pootis = 0;
            for (i = 0; i < s.Length; i++) 
            {
                if (Path.GetFileNameWithoutExtension(s[i]).Contains("Z-Doc"))
                {
                    DialogResult dialogResult = MessageBox.Show("Z-Doc's soundfonts are currently unstable on BASSMIDI.\n\nAre you sure you want to add this one?\n" + Path.GetFileName(s[i]), "Keppy's MIDI Converter - Z-Doc's soundfonts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SFList.Items.Add(s[i]);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
                else if (Path.GetExtension(s[i]) == ".sf2" | Path.GetExtension(s[i]) == ".SF2" | Path.GetExtension(s[i]) == ".sfz" | Path.GetExtension(s[i]) == ".SFZ" | Path.GetExtension(s[i]) == ".sf3" | Path.GetExtension(s[i]) == ".SF3" | Path.GetExtension(s[i]) == ".sfpack" | Path.GetExtension(s[i]) == ".SFPACK")
                {
                    SFList.Items.Add(s[i]);
                }
                else
                {
                    MessageBox.Show(Path.GetFileName(s[i]) + " is not a valid soundfont file!\n\nPlease drop a valid soundfont file inside the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0);
        }

        private void SFList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void SFList_KeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (char)Keys.Delete)
                {
                    for (int i = this.SFList.SelectedIndices.Count - 1; i >= 0; i--)
                    {
                        this.SFList.Items.RemoveAt(this.SFList.SelectedIndices[i]);
                    }
                    if (SFList.Items.Count == 0)
                    {
                        Array.Clear(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0, KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts.Length);
                    }
                    else
                    {
                        KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[SFList.Items.Count];
                        SFList.Items.CopyTo(KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts, 0);
                    }
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
