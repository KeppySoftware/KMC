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

namespace KeppyMIDIConverter
{
    public partial class SoundfontDialog : Form
    {
        public SoundfontDialog()
        {
            InitializeComponent();
        }

        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        private void InitializeLanguage()
        {
            try
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture();
                // Translate system
                VSTUse.Text = res_man.GetString("VSTUseText", cul);
                VSTImport.Text = res_man.GetString("VSTManagerButtonText", cul);
                label1.Text = res_man.GetString("SoundfontDialogMessage", cul);
                importSoundfontsToolStripMenuItem.Text = res_man.GetString("ImportSoundfontBtn", cul);
                removeSoundfontsToolStripMenuItem.Text = res_man.GetString("RemoveSoundfontBtn", cul);
                clearSoundfontListToolStripMenuItem.Text = res_man.GetString("ClearSoundfontList", cul);
                ImportBtn.Text = res_man.GetString("ImportSoundfontBtn", cul);
                RemoveBtn.Text = res_man.GetString("RemoveSoundfontBtn", cul);
                MvUp.Text = res_man.GetString("MoveUPSF", cul);
                MvDwn.Text = res_man.GetString("MoveDOWNSF", cul);
                Text = res_man.GetString("SoundfontManagerTitle", cul);
            }
            catch
            {
                MessageBox.Show("Keppy's MIDI Converter tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                // Translate system
                VSTUse.Text = res_man.GetString("VSTUseText", cul);
                VSTImport.Text = res_man.GetString("VSTManagerButtonText", cul);
                label1.Text = res_man.GetString("SoundfontDialogMessage", cul);
                importSoundfontsToolStripMenuItem.Text = res_man.GetString("ImportSoundfontBtn", cul);
                removeSoundfontsToolStripMenuItem.Text = res_man.GetString("RemoveSoundfontBtn", cul);
                clearSoundfontListToolStripMenuItem.Text = res_man.GetString("ClearSoundfontList", cul);
                ImportBtn.Text = res_man.GetString("ImportSoundfontBtn", cul);
                RemoveBtn.Text = res_man.GetString("RemoveSoundfontBtn", cul);
                MvUp.Text = res_man.GetString("MoveUPSF", cul);
                MvDwn.Text = res_man.GetString("MoveDOWNSF", cul);
                Text = res_man.GetString("SoundfontManagerTitle", cul);
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
                    Array.Clear(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0, KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts.Length);
                    KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[] { null };
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

        private void clearSoundfontListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFList.Items.Clear();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private void SoundfontDialog_Load(object sender, EventArgs e)
        {
            InitializeLanguage();
            SFList.ContextMenu = SFMenu;
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            SoundfontImportDialog.InitialDirectory = Settings.GetValue("lastsffolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
            Settings.Close();
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

        // NOT SUPPORTED ON XP
        public static void OpenFileDialogAddCustomPaths(FileDialog dialog)
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
        // NOT SUPPORTED ON XP

        private void importSoundfontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int importmode = 0;
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            SoundfontImportDialog.InitialDirectory = Settings.GetValue("lastsffolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
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
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                    }
                    else if (Path.GetExtension(file).ToLower() == ".sflist")
                    {
                        using (StreamReader r = new StreamReader(file))
                        {
                            string line;
                            while ((line = r.ReadLine()) != null)
                            {
                                SFList.Items.Add(line); // Read the external list and add the items to the list
                            }
                        }
                    }
                    else
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show(res_man.GetString("SoundfontImportError", cul), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
            }
            Settings.Close();
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            int importmode = 0;
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            SoundfontImportDialog.InitialDirectory = Settings.GetValue("lastsffolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
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
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                    }
                    else if (Path.GetExtension(file).ToLower() == ".sflist")
                    {
                        using (StreamReader r = new StreamReader(file))
                        {
                            string line;
                            while ((line = r.ReadLine()) != null)
                            {
                                SFList.Items.Add(line); // Read the external list and add the items to the list
                            }
                        }
                    }
                    else
                    {
                        Settings.SetValue("lastsffolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                        MessageBox.Show(res_man.GetString("SoundfontImportError", cul), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts = new string[SFList.Items.Count];
                SFList.Items.CopyTo(KeppyMIDIConverter.MainWindow.KMCGlobals.Soundfonts, 0);
            }
            Settings.Close();
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
            DialogResult dialogResult = MessageBox.Show(res_man.GetString("AboutSFZFormatText", cul), res_man.GetString("AboutSFZFormatTitle", cul), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("http://drealm.info/sfz/plj-sfz.xhtml");
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void VSTReady_Click(object sender, EventArgs e)
        {
            MessageBox.Show(res_man.GetString("AboutVSTSupportText", cul), res_man.GetString("AboutVSTSupportTitle", cul), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else if (Path.GetExtension(s[i]).ToLower() == ".sflist")
                {
                    using (StreamReader r = new StreamReader(s[i]))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            SFList.Items.Add(line); // Read the external list and add the items to the list
                        }
                    }
                }
                else
                {
                    MessageBox.Show(res_man.GetString("SoundfontImportError", cul), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
