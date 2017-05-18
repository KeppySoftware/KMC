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
using System.Globalization;
using System.Resources;

namespace KeppyMIDIConverter
{
    public partial class VSTManagerWindow : Form
    {
        public VSTManagerWindow()
        {
            InitializeComponent();
        }

        public static string bitnow = null;
        public static string bitreq = null;

        private void InitializeLanguage()
        {
            Text = MainWindow.res_man.GetString("VSTManager", MainWindow.cul);
            Desc1.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 1";
            Desc2.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 2";
            Desc3.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 3";
            Desc4.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 4";
            Desc5.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 5";
            Desc6.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 6";
            Desc7.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 7";
            Desc8.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 8";
            Load1.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load2.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load3.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load4.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load5.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load6.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load7.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Load8.Text = MainWindow.res_man.GetString("LoadVST", MainWindow.cul);
            Unload1.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload2.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload3.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload4.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload5.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload6.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload7.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            Unload8.Text = MainWindow.res_man.GetString("UnloadVST", MainWindow.cul);
            UnloadAllVSTs.Text = MainWindow.res_man.GetString("UnloadAllVSTs", MainWindow.cul);
            Desc.Text = MainWindow.res_man.GetString("VSTHowDoTheyWork", MainWindow.cul);
        }

        private void VSTManagerWindow_Load(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(633, 468);
            InitializeLanguage();
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
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc != null)
            {
                Desc1.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc;
                Unload1.Enabled = true;
                Load1.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc2 != null)
            {
                Desc2.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc2;
                Unload2.Enabled = true;
                Load2.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc3 != null)
            {
                Desc3.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc3;
                Unload3.Enabled = true;
                Load3.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc4 != null)
            {
                Desc4.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc4;
                Unload4.Enabled = true;
                Load4.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc5 != null)
            {
                Desc5.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc5;
                Unload5.Enabled = true;
                Load5.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc6 != null)
            {
                Desc6.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc6;
                Unload6.Enabled = true;
                Load6.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc7 != null)
            {
                Desc1.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc7;
                Unload7.Enabled = true;
                Load7.Enabled = false;
            }
            if (KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc8 != null)
            {
                Desc8.Text = KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc8;
                Unload8.Enabled = true;
                Load8.Enabled = false;
            }
            if (MainWindow.KMCGlobals.IsLoudMaxEnabled)
            {
                LoudMaxCheck.ForeColor = Color.Green;
                LoudMaxCheck.Text = "LoudMax on";
                LoudMaxCheck.Checked = true;
            }
            else
            {
                LoudMaxCheck.ForeColor = Color.DarkRed;
                LoudMaxCheck.Text = "LoudMax off";
                LoudMaxCheck.Checked = false;
            }
        }

        private void InitStartDirectory()
        {
            VSTImportDialog.InitialDirectory = Properties.Settings.Default.LastVSTFolder;
        }

        private void SaveDirectory(string file)
        {
            Properties.Settings.Default.LastVSTFolder = Path.GetDirectoryName(file);
            Properties.Settings.Default.Save();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL, ref MainWindow.KMCGlobals.VSTDLLDesc, Desc1, Unload1, Load1, 1);
        }

        private void Load2_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL2, ref MainWindow.KMCGlobals.VSTDLLDesc2, Desc2, Unload2, Load2, 2);
        }

        private void Load3_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL3, ref MainWindow.KMCGlobals.VSTDLLDesc3, Desc3, Unload3, Load3, 3);
        }

        private void Load4_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL4, ref MainWindow.KMCGlobals.VSTDLLDesc4, Desc4, Unload4, Load4, 4);
        }

        private void Load5_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL5, ref MainWindow.KMCGlobals.VSTDLLDesc5, Desc5, Unload5, Load5, 5);
        }

        private void Load6_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL6, ref MainWindow.KMCGlobals.VSTDLLDesc6, Desc6, Unload6, Load6, 6);
        }

        private void Load7_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL7, ref MainWindow.KMCGlobals.VSTDLLDesc7, Desc7, Unload7, Load7, 7);
        }

        private void Load8_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.KMCGlobals.VSTDLL8, ref MainWindow.KMCGlobals.VSTDLLDesc8, Desc8, Unload8, Load8, 8);
        }

        private void LoadVST(ref String VSTDLL, ref String VSTDLLDesc, Label Desc, Button Unload, Button Load, Int32 NumVST)
        {
            try
            {
                int status = 0;

                if (ModifierKeys == Keys.Shift) status = 1;
                else if (ModifierKeys == Keys.Control)
                {
                    if (NumVST == 1)
                    {
                        status = 2;
                        MessageBox.Show("VSTi mode activated.", "Keppy's MIDI Converter - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else status = 0;
                }

                InitStartDirectory();
                if (VSTImportDialog.ShowDialog() == DialogResult.OK)
                {
                    BASS_VST_INFO VSTInfo = new BASS_VST_INFO();
                    if (status == 1)
                    {
                        VSTDLL = VSTImportDialog.FileName;
                        VSTDLLDesc = VSTImportDialog.FileName + " (Not verified)";
                        Desc.Text = VSTImportDialog.FileName + " (Not verified)";
                        Bass.BASS_Free();
                        Unload.Enabled = true;
                        Load.Enabled = false;
                        SaveDirectory(VSTImportDialog.FileName);
                    }
                    else if (status == 2)
                    {
                        Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                        int VSTiTester = BassVst.BASS_VST_ChannelCreate(44100, 2, VSTImportDialog.FileName, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
                        MainWindow.KMCGlobals.vstIInfo = new BASS_VST_INFO();
                        bool Success = BassVst.BASS_VST_GetInfo(VSTiTester, MainWindow.KMCGlobals.vstIInfo);
                        if (Success)
                        {
                            String Lab = String.Format("{0} by {1} (Version number: {2}", MainWindow.KMCGlobals.vstIInfo.productName, MainWindow.KMCGlobals.vstIInfo.vendorName, MainWindow.KMCGlobals.vstIInfo.vendorVersion);
                            VSTDLL = VSTImportDialog.FileName;
                            VSTDLLDesc = MainWindow.KMCGlobals.vstIInfo.productName + " by " + MainWindow.KMCGlobals.vstIInfo.vendorName + " (Version: " + MainWindow.KMCGlobals.vstIInfo.vendorVersion + ")";
                            Desc.Text = MainWindow.KMCGlobals.vstIInfo.productName + " by " + MainWindow.KMCGlobals.vstIInfo.vendorName + " (Version: " + MainWindow.KMCGlobals.vstIInfo.vendorVersion + ")";
                            Unload.Enabled = true;
                            Load.Enabled = false;
                            SaveDirectory(VSTImportDialog.FileName);
                            BassVst.BASS_VST_ChannelFree(VSTiTester);
                            Bass.BASS_Free();
                        }
                        else
                        {
                            MessageBox.Show(String.Format(MainWindow.res_man.GetString("InvalidVSTLoaded", MainWindow.cul), Path.GetFileNameWithoutExtension(VSTImportDialog.FileName), bitreq, bitnow), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            BassVst.BASS_VST_ChannelFree(VSTiTester);
                            Bass.BASS_Free();
                        }
                    }
                    else
                    {
                        Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                        int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                        int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                        bool Success = BassVst.BASS_VST_GetInfo(VSTTester, VSTInfo);
                        if (Success)
                        {
                            VSTDLL = VSTImportDialog.FileName;
                            VSTDLLDesc = VSTInfo.productName + " by " + VSTInfo.vendorName + " (Version: " + VSTInfo.vendorVersion + ")";
                            Desc.Text = VSTInfo.productName + " by " + VSTInfo.vendorName + " (Version: " + VSTInfo.vendorVersion + ")";
                            Bass.BASS_Free();
                            Unload.Enabled = true;
                            Load.Enabled = false;
                            SaveDirectory(VSTImportDialog.FileName);
                            BassVst.BASS_VST_ChannelRemoveDSP(Test, VSTTester);
                            Bass.BASS_StreamFree(Test);
                            Bass.BASS_Free();
                        }
                        else
                        {
                            MessageBox.Show(String.Format(MainWindow.res_man.GetString("InvalidVSTLoaded", MainWindow.cul), Path.GetFileNameWithoutExtension(VSTImportDialog.FileName), bitreq, bitnow), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            BassVst.BASS_VST_ChannelRemoveDSP(Test, VSTTester);
                            Bass.BASS_StreamFree(Test);
                            Bass.BASS_Free();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", MainWindow.cul), ex.ToString(), 0, 1);
                errordialog.ShowDialog();
            }
        }

        private void Unload_Click(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.vstIInfo = new BASS_VST_INFO();
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc = null;
            Desc1.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 1";
            Unload1.Enabled = false;
            Load1.Enabled = true;
        }

        private void Unload2_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL2 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc2 = null;
            Desc2.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 2";
            Unload2.Enabled = false;
            Load2.Enabled = true;
        }

        private void Unload3_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL3 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc3 = null;
            Desc3.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 3";
            Unload3.Enabled = false;
            Load3.Enabled = true;
        }

        private void Unload4_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL4 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc4 = null;
            Desc4.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 4";
            Unload4.Enabled = false;
            Load4.Enabled = true;
        }

        private void Unload5_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL5 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc5 = null;
            Desc5.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 5";
            Unload5.Enabled = false;
            Load5.Enabled = true;
        }

        private void Unload6_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL6 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc6 = null;
            Desc6.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 6";
            Unload6.Enabled = false;
            Load6.Enabled = true;
        }

        private void Unload7_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL7 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc7 = null;
            Desc7.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 7";
            Unload7.Enabled = false;
            Load7.Enabled = true;
        }

        private void Unload8_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLL8 = null;
            KeppyMIDIConverter.MainWindow.KMCGlobals.VSTDLLDesc8 = null;
            Desc8.Text = MainWindow.res_man.GetString("EmptySlot", MainWindow.cul) + " 8";
            Unload8.Enabled = false;
            Load8.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Unload1.PerformClick();
            Unload2.PerformClick();
            Unload3.PerformClick();
            Unload4.PerformClick();
            Unload5.PerformClick();
            Unload6.PerformClick();
            Unload7.PerformClick();
            Unload8.PerformClick();
        }

        private void LoudMaxCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LoudMaxCheck.Checked)
            {
                Properties.Settings.Default.LoudMaxEnabled = true;
                Properties.Settings.Default.Save();
                LoudMaxCheck.ForeColor = Color.Green;
                LoudMaxCheck.Text = "LoudMax on";
            }
            else
            {
                Properties.Settings.Default.LoudMaxEnabled = false;
                Properties.Settings.Default.Save();
                LoudMaxCheck.ForeColor = Color.DarkRed;
                LoudMaxCheck.Text = "LoudMax off";
            }
        }
    }
}
