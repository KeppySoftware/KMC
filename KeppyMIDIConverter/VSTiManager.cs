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
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyMIDIConverter
{
    public partial class VSTiManager : Form
    {
        public VSTiManager()
        {
            InitializeComponent();
        }

        public static string bitnow = null;
        public static string bitreq = null;

        private void VSTiManager_Load(object sender, EventArgs e)
        {
            if (IntPtr.Size == 8)
            {
                bitnow = "64-bit";
                bitreq = "32-bit";
            }
            else if (IntPtr.Size == 4)
            {
                bitnow = "32-bit";
                bitreq = "64-bit";
            }
            if (KeppyMIDIConverter.MainWindow.Globals.VSTMode == true)
            {
                VSTImport.Enabled = true;
                VSTUse.Checked = true;
            }
            else
            {
                VSTImport.Enabled = false;
                VSTUse.Checked = false;
            }
            if (KeppyMIDIConverter.MainWindow.Globals.VSTiDLLDesc != null)
            {
                label1.Text = KeppyMIDIConverter.MainWindow.Globals.VSTiDLLDesc;
                Unload.Enabled = true;
                Load1.Enabled = false;
            }
        }

        private void InitStartDirectory()
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                VSTiImportDialog.InitialDirectory = Settings.GetValue("lastvstfolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
            }
            catch
            {
                Settings.Close();
            }
            Settings.Close();
        }

        private void SaveDirectory(string file)
        {
            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            try
            {
                Settings.SetValue("lastvstfolder", Path.GetDirectoryName(file), RegistryValueKind.String);
                Settings.Close();
            }
            catch
            {
                Settings.Close();
            }
        }

        private void Load1_Click(object sender, EventArgs e)
        {
            InitStartDirectory();
            if (VSTiImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelCreate(44100, 2, VSTiImportDialog.FileName, BASSFlag.BASS_STREAM_DECODE);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppyMIDIConverter.MainWindow.Globals.VSTiDLL = VSTiImportDialog.FileName;
                    KeppyMIDIConverter.MainWindow.Globals.VSTiDLLDesc = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label1.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload.Enabled = true;
                    Load1.Enabled = false;
                    SaveDirectory(VSTiImportDialog.FileName);
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST instrument!\nPlease be sure to load a VST instrument and NOT a VST effect.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void Unload_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.Globals.VSTiDLL = null;
            KeppyMIDIConverter.MainWindow.Globals.VSTiDLLDesc = null;
            label1.Text = "Empty slot";
            Unload.Enabled = false;
            Load1.Enabled = true;
        }

        private void VSTUse_CheckedChanged(object sender, EventArgs e)
        {
            if (VSTUse.Checked == true)
            {
                VSTImport.Enabled = true;
                KeppyMIDIConverter.MainWindow.Globals.VSTMode = true;
            }
            else if (VSTUse.Checked == false)
            {
                VSTImport.Enabled = false;
                KeppyMIDIConverter.MainWindow.Globals.VSTMode = false;
            }
        }

        private void VSTImport_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.VSTManagerWindow frm = new KeppyMIDIConverter.VSTManagerWindow();
            frm.ShowDialog();
        }
    }
}
