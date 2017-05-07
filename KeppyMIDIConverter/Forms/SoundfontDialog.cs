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
        public SoundfontDialog()
        {
            InitializeComponent();
        }

        private void InitializeLanguage()
        {
            VSTUse.Text = MainWindow.res_man.GetString("VSTUseText", MainWindow.cul);
            VSTImport.Text = MainWindow.res_man.GetString("VSTManagerButtonText", MainWindow.cul);
            label1.Text = MainWindow.res_man.GetString("SoundfontDialogMessage", MainWindow.cul);
            importSoundfontsToolStripMenuItem.Text = MainWindow.res_man.GetString("ImportSoundfontBtn", MainWindow.cul);
            removeSoundfontsToolStripMenuItem.Text = MainWindow.res_man.GetString("RemoveSoundfontBtn", MainWindow.cul);
            clearSoundfontListToolStripMenuItem.Text = MainWindow.res_man.GetString("ClearSoundfontList", MainWindow.cul);
            ImportBtn.Text = MainWindow.res_man.GetString("ImportSoundfontBtn", MainWindow.cul);
            RemoveBtn.Text = MainWindow.res_man.GetString("RemoveSoundfontBtn", MainWindow.cul);
            MvUp.Text = MainWindow.res_man.GetString("MoveUPSF", MainWindow.cul);
            MvDwn.Text = MainWindow.res_man.GetString("MoveDOWNSF", MainWindow.cul);
            Text = MainWindow.res_man.GetString("SoundfontManagerTitle", MainWindow.cul);
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
                    Array.Clear(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0, KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts.Length);
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[] { null };
                }
                else
                {
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
                }
            }
            catch { }
        }

        private void clearSoundfontListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFList.Items.Clear();
            Array.Clear(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0, KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts.Length);
            KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[0];
        }

        private void SoundfontDialog_Load(object sender, EventArgs e)
        {
            InitializeLanguage();
            SFList.ContextMenu = SFMenu;
            SoundfontImportDialog.InitialDirectory = Properties.Settings.Default.LastSFFolder;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTMode == true)
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
            else
            {
                VSTImport.Enabled = false;
                VSTUse.Enabled = false;
                VSTUse.Checked = false;
            }
        }

        private string ImportMePlease(string file)
        {
            using (var form = new Forms.BankNPresetSel(file, 0, 1))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return String.Format("p{0},{1}={2},{3}|{4}", form.BankValueReturn, form.PresetValueReturn, form.DesBankValueReturn, form.DesPresetValueReturn, file);
                }
                else
                {
                    return String.Format("p{0},{1}={2},{3}|{4}", 0, 0, 0, 0, file);
                }
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

        private void AddSoundfont()
        {
            try
            {
                int importmode = 0;
                SoundfontImportDialog.InitialDirectory = Properties.Settings.Default.LastSFFolder;
                OpenFileDialogAddCustomPaths(SoundfontImportDialog);
                if (this.SoundfontImportDialog.ShowDialog() == DialogResult.OK)
                {
                    if (ModifierKeys == Keys.Control)
                    {
                        importmode = 1;
                    }
                    foreach (String file in SoundfontImportDialog.FileNames)
                    {
                        if (Path.GetExtension(file).ToLower() == ".sf2" | Path.GetExtension(file).ToLower() == ".sf3" | Path.GetExtension(file).ToLower() == ".sfpack" | Path.GetExtension(file).ToLower() == ".sfz")
                        {
                            if (SFList.Items.Count == 1000)
                            {
                                SFList.Items.RemoveAt(1000);
                            }
                            if (Path.GetExtension(file).ToLower() == ".sfz")
                            {
                                SFList.Items.Add(ImportMePlease(file));
                            }
                            else
                            {
                                if (importmode == 1)
                                {
                                    SFList.Items.Add(ImportMePlease(file));
                                }
                                else
                                {
                                    SFList.Items.Add(file);
                                }
                            }
                            Properties.Settings.Default.LastSFFolder = Path.GetDirectoryName(file);
                            Properties.Settings.Default.Save();
                        }
                        else if (Path.GetExtension(file).ToLower() == ".sflist" | Path.GetExtension(file).ToLower() == ".txt")
                        {
                            using (StreamReader r = new StreamReader(file))
                            {
                                string line;
                                while ((line = r.ReadLine()) != null)
                                {
                                    if (line.ToLower().IndexOf('=') != -1)
                                    {
                                        SFList.Items.Add(line);
                                    }
                                    else if (line.ToLower().IndexOf('@') != -1)
                                    {
                                        // Ignore it
                                    }
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
                                        else // Absolute, let's just add it straight away
                                        {
                                            SFList.Items.Add(line);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Properties.Settings.Default.LastSFFolder = Path.GetDirectoryName(file);
                            Properties.Settings.Default.Save();
                            MessageBox.Show(MainWindow.res_man.GetString("SoundfontImportError", MainWindow.cul), MainWindow.res_man.GetString("Error", MainWindow.cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void importSoundfontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSoundfont();
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            AddSoundfont();
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
                    Array.Clear(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0, KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts.Length);
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[0];
                }
                else
                {
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                    SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
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
            KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
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
            KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
        }

        private void SFZCompliant_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(MainWindow.res_man.GetString("AboutSFZFormatText", MainWindow.cul), MainWindow.res_man.GetString("AboutSFZFormatTitle", MainWindow.cul), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("http://drealm.info/sfz/plj-sfz.xhtml");
            }
        }

        private void VSTReady_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MainWindow.res_man.GetString("AboutVSTSupportText", MainWindow.cul), MainWindow.res_man.GetString("AboutVSTSupportTitle", MainWindow.cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SFList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            int importmode = 0;
            if (ModifierKeys == Keys.Control)
            {
                importmode = 1;
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            int pootis = 0;
            for (i = 0; i < s.Length; i++) 
            {
                if (Path.GetExtension(s[i]).ToLower() == ".sf2" | Path.GetExtension(s[i]).ToLower() == ".sf3" | Path.GetExtension(s[i]).ToLower() == ".sfpack" | Path.GetExtension(s[i]).ToLower() == ".sfz")
                {
                    if (SFList.Items.Count == 1000)
                    {
                        SFList.Items.RemoveAt(1000);
                    }
                    if (Path.GetExtension(s[i]).ToLower() == ".sfz")
                    {
                        SFList.Items.Add(ImportMePlease(s[i]));
                    }
                    else
                    {
                        if (importmode == 1)
                        {
                            SFList.Items.Add(ImportMePlease(s[i]));
                        }
                        else
                        {
                            SFList.Items.Add(s[i]);
                        }
                    }
                }
                else if (Path.GetExtension(s[i]).ToLower() == ".sflist" | Path.GetExtension(s[i]).ToLower() == ".txt")
                {
                    using (StreamReader r = new StreamReader(s[i]))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            bool isabsolute = Path.IsPathRooted(line);  // Check if the path to the soundfont is absolute or relative
                            string relativepath;
                            string absolutepath;
                            if (isabsolute == false) // Not absolute, let's convert it
                            {
                                relativepath = String.Format("{0}{1}", Path.GetDirectoryName(s[i]), String.Format("\\{0}", line));
                                absolutepath = new Uri(relativepath).LocalPath;
                                SFList.Items.Add(absolutepath);
                            }
                            else // Absolute, let's just add it straight away
                            {
                                SFList.Items.Add(line);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(MainWindow.res_man.GetString("SoundfontImportError", MainWindow.cul), MainWindow.res_man.GetString("Error", MainWindow.cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
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
                        Array.Clear(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0, KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts.Length);
                        KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[] { null } ;
                    }
                    else
                    {
                        KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                        SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
                    }
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
            SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
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

        private void VSTUse_CheckedChanged(object sender, EventArgs e)
        {
            if (VSTUse.Checked == true)
            {
                VSTImport.Enabled = true;
                KeppyMIDIConverter.MainWindow.KMCGlobals.VSTMode = true;
            }
            else if (VSTUse.Checked == false)
            {
                VSTImport.Enabled = false;
                KeppyMIDIConverter.MainWindow.KMCGlobals.VSTMode = false;
            }
        }

        private void VSTImport_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.VSTManagerWindow frm = new KeppyMIDIConverter.VSTManagerWindow();
            frm.ShowDialog();
        }

    }
}
