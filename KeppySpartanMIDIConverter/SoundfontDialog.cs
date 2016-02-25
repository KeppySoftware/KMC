using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
                    if (Path.GetFileNameWithoutExtension(file).Contains("Z-Doc") == true & Path.GetExtension(file) == ".sf2" | Path.GetExtension(file) == ".SF2" | Path.GetExtension(file) == ".sfz" | Path.GetExtension(file) == ".SFZ" | Path.GetExtension(file) == ".sf3" | Path.GetExtension(file) == ".SF3" | Path.GetExtension(file) == ".sfpack" | Path.GetExtension(file) == ".SFPACK")
                    {
                        DialogResult dialogResult = MessageBox.Show("Z-Doc's soundfonts are currently unstable on BASSMIDI.\n\nAre you sure you want to add this one?\n" + Path.GetFileName(file), "Keppy's MIDI Converter - Z-Doc's soundfonts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SFList.Items.Add(file);
                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                    else if (Path.GetExtension(file) == ".sf2" | Path.GetExtension(file) == ".SF2" | Path.GetExtension(file) == ".sfz" | Path.GetExtension(file) == ".SFZ" | Path.GetExtension(file) == ".sf3" | Path.GetExtension(file) == ".SF3" | Path.GetExtension(file) == ".sfpack" | Path.GetExtension(file) == ".SFPACK")
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        SFList.Items.Add(file);
                    }
                    else if (Path.GetExtension(file) == ".dls" | Path.GetExtension(file) == ".DLS")
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show("BASSMIDI does NOT support the downloadable sounds (DLS) format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Path.GetExtension(file) == ".exe" | Path.GetExtension(file) == ".EXE" | Path.GetExtension(file) == ".dll" | Path.GetExtension(file) == ".DLL")
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show("Are you really trying to add executables to the soundfonts list?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show("Invalid soundfont!\n\nPlease select a valid soundfont and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[] { null };
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

        private void MvUp_Click(object sender, EventArgs e)
        {
            if (SFList.SelectedItems.Count > 0)
            {
                object selected = SFList.SelectedItem;
                int indx = SFList.Items.IndexOf(selected);
                int totl = SFList.Items.Count;
                if (indx == 0)
                {
                    SFList.Items.Remove(selected);
                    SFList.Items.Insert(totl - 1, selected);
                    SFList.SetSelected(totl - 1, true);
                }
                else
                {
                    SFList.Items.Remove(selected);
                    SFList.Items.Insert(indx - 1, selected);
                    SFList.SetSelected(indx - 1, true);
                }
            }
        }

        private void MvDwn_Click(object sender, EventArgs e)
        {
            if (SFList.SelectedItems.Count > 0)
            {
                object selected = SFList.SelectedItem;
                int indx = SFList.Items.IndexOf(selected);
                int totl = SFList.Items.Count;
                if (indx == totl - 1)
                {
                    SFList.Items.Remove(selected);
                    SFList.Items.Insert(0, selected);
                    SFList.SetSelected(0, true);
                }
                else
                {
                    SFList.Items.Remove(selected);
                    SFList.Items.Insert(indx + 1, selected);
                    SFList.SetSelected(indx + 1, true);
                }
            }
        }

        private void SFZCompliant_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This program is compliant to the \"SFZ 1.0 format\", and partially with the \"SFZ 2.0 format\".\n\nDo you want to visit the \"Unofficial SFZ format information\" website?", "About the SFZ format", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("http://drealm.info/sfz/plj-sfz.xhtml");
            }
            else if (dialogResult == DialogResult.No)
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
                if (Path.GetFileNameWithoutExtension(s[i]).Contains("Z-Doc") & Path.GetExtension(s[i]) == ".sf2" | Path.GetExtension(s[i]) == ".SF2" | Path.GetExtension(s[i]) == ".sfz" | Path.GetExtension(s[i]) == ".SFZ" | Path.GetExtension(s[i]) == ".sf3" | Path.GetExtension(s[i]) == ".SF3" | Path.GetExtension(s[i]) == ".sfpack" | Path.GetExtension(s[i]) == ".SFPACK")
                {
                    DialogResult dialogResult = MessageBox.Show("Z-Doc's soundfonts are currently unstable on BASSMIDI.\n\nAre you sure you want to add this one?\n" + Path.GetFileName(s[i]), "Keppy's MIDI Converter - Z-Doc's soundfonts", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SFList.Items.Add(s[i]);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        
                    }
                }
                else if (Path.GetExtension(s[i]) == ".sf2" | Path.GetExtension(s[i]) == ".SF2" | Path.GetExtension(s[i]) == ".sfz" | Path.GetExtension(s[i]) == ".SFZ" | Path.GetExtension(s[i]) == ".sf3" | Path.GetExtension(s[i]) == ".SF3" | Path.GetExtension(s[i]) == ".sfpack" | Path.GetExtension(s[i]) == ".SFPACK")
                {
                    SFList.Items.Add(s[i]);
                }
                else if (Path.GetExtension(s[i]) == ".dls" | Path.GetExtension(s[i]) == ".DLS")
                {
                    MessageBox.Show("BASSMIDI does NOT support the downloadable sounds (DLS) format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Path.GetExtension(s[i]) == ".exe" | Path.GetExtension(s[i]) == ".EXE" | Path.GetExtension(s[i]) == ".dll" | Path.GetExtension(s[i]) == ".DLL")
                {
                    MessageBox.Show("Are you really trying to add executables to the soundfonts list?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        KeppySpartanMIDIConverter.MainWindow.Globals.Soundfonts = new string[] { null } ;
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

        private void SFListCheck_Tick(object sender, EventArgs e)
        {
            if (SFList.Items.Count <= 1)
            {
                MvUp.Enabled = false;
                MvDwn.Enabled = false;
            }
            else
            {
                MvUp.Enabled = true;
                MvDwn.Enabled = true;
            }
        }
    }
}
