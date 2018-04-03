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
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;

namespace KeppyMIDIConverter
{
    public partial class SoundfontDialog : Form
    {
        public static SoundfontDialog Delegate;

        public SoundfontDialog()
        {
            InitializeComponent();
            Delegate = this;
            InitializeLanguage();
        }

        public static void InitializeLanguage()
        {
            Delegate.PreloadDefaultSF.Text = Languages.Parse("PreloadDefaultSF");
            Delegate.VSTUse.Text = Languages.Parse("VSTUseText");
            Delegate.VSTImport.Text = Languages.Parse("VSTManagerButtonText");
            Delegate.label1.Text = Languages.Parse("SoundfontDialogMessage");
            Delegate.importSoundfontsToolStripMenuItem.Text = Languages.Parse("ImportSoundfontBtn");
            Delegate.removeSoundfontsToolStripMenuItem.Text = Languages.Parse("RemoveSoundfontBtn");
            Delegate.clearSoundfontListToolStripMenuItem.Text = Languages.Parse("ClearSoundfontList");
            Delegate.ImportBtn.Text = Languages.Parse("ImportSoundfontBtn");
            Delegate.RemoveBtn.Text = Languages.Parse("RemoveSoundfontBtn");
            Delegate.MvUp.Text = Languages.Parse("MoveUpSF");
            Delegate.MvDwn.Text = Languages.Parse("MoveDownSF");
            Delegate.Text = Languages.Parse("SoundfontManagerTitle");
        }

        private void SoundfontDialog_Load(object sender, EventArgs e)
        {
            SFList.ContextMenu = SFMenu;
            SoundfontImportDialog.InitialDirectory = Properties.Settings.Default.LastSoundFontFolder;

            PreloadDefaultSF.Checked = Properties.Settings.Default.PreloadDefaultSF;

            if (Properties.Settings.Default.LoudMaxEnabled)
                MainWindow.KMCStatus.VSTMode = true;

            if (MainWindow.KMCStatus.VSTMode == true)
            {
                VSTImport.Enabled = true;
                VSTUse.Checked = true;
            }
            else
            {
                VSTImport.Enabled = false;
                VSTUse.Checked = false;
            }
        }

        private void removeSoundfontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.SFList.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    this.SFList.Items.RemoveAt(this.SFList.SelectedIndices[i]);
                }
                if (SFList.Items.Count == 0)
                {
                    Array.Clear(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0, KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts.Length);
                    KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[] { null };
                }
                else
                {
                    KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
                }
            }
            catch { }
        }

        private void clearSoundfontListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFList.Items.Clear();
            Array.Clear(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0, KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts.Length);
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[0];
        }

        private string ImportMePlease(string file)
        {
            using (var form = new BankNPresetSel(file, true))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                    return String.Format("p{0},{1}={2},{3}|{4}", form.DesBankValueReturn, form.DesPresetValueReturn, form.SrcBankValueReturn, form.SrcPresetValueReturn, file);
                else
                    return String.Format("p{0},{1}={2},{3}|{4}", 0, 0, 0, 0, file);
            }
        }

        public static void OpenFileDialogAddCustomPaths(FileDialog dialog) // This function doesn't work on Windows XP
        {
            try
            {
                // Import the soundfont favorites file from Keppy's Synthesizer
                using (StreamReader r = new StreamReader(System.Environment.GetEnvironmentVariable("USERPROFILE").ToString() + "\\Keppy's Synthesizer\\keppymididrv.favlist"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        dialog.CustomPlaces.Add(line);
                    }
                }
            }
            catch
            {
                // Trigger nothing
            }
        }

        private void AddSoundFont()
        {
            try
            {
                Boolean ImportPresetFromSF2 = (ModifierKeys == Keys.Control);
                SoundfontImportDialog.InitialDirectory = Properties.Settings.Default.LastSoundFontFolder;
                OpenFileDialogAddCustomPaths(SoundfontImportDialog);
                if (this.SoundfontImportDialog.ShowDialog() == DialogResult.OK)
                {
                    AddSoundFontsToList(SoundfontImportDialog.FileNames, ImportPresetFromSF2);
                    KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddSoundFontsToList(String[] SFs, Boolean ImportPresetFromSF2)
        {
            foreach (String file in SFs)
            {
                if (Path.GetExtension(file).ToLower() == ".sf2" | Path.GetExtension(file).ToLower() == ".sf3" | Path.GetExtension(file).ToLower() == ".sfpack" | Path.GetExtension(file).ToLower() == ".sfz")
                {
                    if (SFList.Items.Count == 1000) SFList.Items.RemoveAt(1000);

                    if (Path.GetExtension(file).ToLower() == ".sfz")
                        SFList.Items.Add(ImportMePlease(file));
                    else
                    {
                        if (ImportPresetFromSF2)
                            SFList.Items.Add(ImportMePlease(file));
                        else
                            SFList.Items.Add(file);
                    }

                    Properties.Settings.Default.LastSoundFontFolder = Path.GetDirectoryName(file);
                    Properties.Settings.Default.Save();
                }
                else if (Path.GetExtension(file).ToLower() == ".sflist" | Path.GetExtension(file).ToLower() == ".txt")
                {
                    using (StreamReader r = new StreamReader(file))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            if (line.ToLower().IndexOf('=') != -1) SFList.Items.Add(line);
                            else if (line.ToLower().IndexOf('@') != -1) { } // Ignore it
                            else
                            {
                                bool isabsolute = Path.IsPathRooted(line);  // Check if the path to the soundfont is absolute or relative
                                string relativepath;
                                string absolutepath;
                                if (isabsolute == false) // Not absolute, let's convert it
                                {
                                    relativepath = String.Format("{0}{1}", Path.GetDirectoryName(file), String.Format("\\{0}", line));
                                    absolutepath = new Uri(relativepath).LocalPath;
                                    SFList.Items.Add(absolutepath);
                                }
                                else SFList.Items.Add(line); // Absolute, let's just add it straight away
                            }
                        }
                    }
                }
                else
                {
                    Properties.Settings.Default.LastSoundFontFolder = Path.GetDirectoryName(file);
                    Properties.Settings.Default.Save();
                    MessageBox.Show(Languages.Parse("SoundfontImportError"), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
        }

        private void importSoundfontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSoundFont();
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            AddSoundFont();
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
                    Array.Clear(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0, KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts.Length);
                    KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[0];
                }
                else
                {
                    KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
                }
            }
            catch { }
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
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
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
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
        }

        private void SFZCompliant_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Languages.Parse("AboutSFZFormatText"), Languages.Parse("AboutSFZFormatTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("http://drealm.info/sfz/plj-sfz.xhtml");
            }
        }

        private void VSTReady_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Languages.Parse("AboutVSTSupportText"), Languages.Parse("AboutVSTSupportTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SFList_DragDrop(object sender, DragEventArgs e)
        {
            bool ImportPresetFromSF2 = (ModifierKeys == Keys.Control);

            AddSoundFontsToList((string[])e.Data.GetData(DataFormats.FileDrop, false), ImportPresetFromSF2);
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
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
                        Array.Clear(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0, KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts.Length);
                        KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[] { null } ;
                    }
                    else
                    {
                        KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
                        SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
                    }
                }
            }
            catch { }
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

        private void VSTUse_CheckedChanged(object sender, EventArgs e)
        {
            VSTImport.Enabled = VSTUse.Checked;
            KeppyMIDIConverter.MainWindow.KMCStatus.VSTMode = VSTUse.Checked;

            if (VSTUse.Checked != true)
            {
                Properties.Settings.Default.LoudMaxEnabled = false;
                Properties.Settings.Default.Save();
            }
        }

        private void PreloadDefaultSF_CheckedChanged(object sender, EventArgs e)
        {
            if (PreloadDefaultSF.Checked != true)
            {
                Properties.Settings.Default.PreloadDefaultSF = false;
                Properties.Settings.Default.Save();
            }
        }

        private void VSTImport_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.VSTManagerWindow frm = new KeppyMIDIConverter.VSTManagerWindow();
            frm.ShowDialog();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.SoundFontChain.SoundFonts, 0);
            this.Close();
        }
    }
}
