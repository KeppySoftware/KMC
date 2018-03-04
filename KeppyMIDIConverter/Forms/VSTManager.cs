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
            Text = Languages.Parse("VSTManager");
            Desc1.Text = Languages.Parse("EmptySlot") + " 1";
            Desc2.Text = Languages.Parse("EmptySlot") + " 2";
            Desc3.Text = Languages.Parse("EmptySlot") + " 3";
            Desc4.Text = Languages.Parse("EmptySlot") + " 4";
            Desc5.Text = Languages.Parse("EmptySlot") + " 5";
            Desc6.Text = Languages.Parse("EmptySlot") + " 6";
            Desc7.Text = Languages.Parse("EmptySlot") + " 7";
            Desc8.Text = Languages.Parse("EmptySlot") + " 8";
            Load1.Text = Languages.Parse("LoadVST");
            Load2.Text = Languages.Parse("LoadVST");
            Load3.Text = Languages.Parse("LoadVST");
            Load4.Text = Languages.Parse("LoadVST");
            Load5.Text = Languages.Parse("LoadVST");
            Load6.Text = Languages.Parse("LoadVST");
            Load7.Text = Languages.Parse("LoadVST");
            Load8.Text = Languages.Parse("LoadVST");
            Unload1.Text = Languages.Parse("UnloadVST");
            Unload2.Text = Languages.Parse("UnloadVST");
            Unload3.Text = Languages.Parse("UnloadVST");
            Unload4.Text = Languages.Parse("UnloadVST");
            Unload5.Text = Languages.Parse("UnloadVST");
            Unload6.Text = Languages.Parse("UnloadVST");
            Unload7.Text = Languages.Parse("UnloadVST");
            Unload8.Text = Languages.Parse("UnloadVST");
            UnloadAllVSTs.Text = Languages.Parse("UnloadAllVSTs");
            Desc.Text = Languages.Parse("VSTHowDoTheyWork");
            UnloadAllVSTs.Text = Languages.Parse("UnloadAllVSTs");
            OKBtn.Text = Languages.Parse("OKBtn");
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

            for (int i = 0; i <= 7; i++)
            {
                if (KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[i] != null)
                {
                    Desc1.Text = KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[i];

                    if (i == 0)
                    {
                        Unload1.Enabled = true;
                        Load1.Enabled = false;
                    }
                    else if (i == 1)
                    {
                        Unload2.Enabled = true;
                        Load2.Enabled = false;
                    }
                    else if (i == 2)
                    {
                        Unload3.Enabled = true;
                        Load3.Enabled = false;
                    }
                    else if (i == 3)
                    {
                        Unload4.Enabled = true;
                        Load4.Enabled = false;
                    }
                    else if (i == 4)
                    {
                        Unload5.Enabled = true;
                        Load5.Enabled = false;
                    }
                    else if (i == 5)
                    {
                        Unload6.Enabled = true;
                        Load6.Enabled = false;
                    }
                    else if (i == 6)
                    {
                        Unload7.Enabled = true;
                        Load7.Enabled = false;
                    }
                    else if (i == 7)
                    {
                        Unload8.Enabled = true;
                        Load8.Enabled = false;
                    }
                }
            }

            LoudMaxCheck.ForeColor = Properties.Settings.Default.LoudMaxEnabled ? Color.Green : Color.DarkRed;
            LoudMaxCheck.Text = Properties.Settings.Default.LoudMaxEnabled ? "LoudMax on" : "LoudMax off";
            LoudMaxCheck.Checked = Properties.Settings.Default.LoudMaxEnabled;
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
            LoadVST(ref MainWindow.VSTs.VSTDLLs[0], ref MainWindow.VSTs.VSTDLLDescs[0], Desc1, Unload1, Load1, 1);
        }

        private void Load2_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[1], ref MainWindow.VSTs.VSTDLLDescs[1], Desc2, Unload2, Load2, 2);
        }

        private void Load3_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[2], ref MainWindow.VSTs.VSTDLLDescs[2], Desc3, Unload3, Load3, 3);
        }

        private void Load4_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[3], ref MainWindow.VSTs.VSTDLLDescs[3], Desc4, Unload4, Load4, 4);
        }

        private void Load5_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[4], ref MainWindow.VSTs.VSTDLLDescs[4], Desc5, Unload5, Load5, 5);
        }

        private void Load6_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[5], ref MainWindow.VSTs.VSTDLLDescs[5], Desc6, Unload6, Load6, 6);
        }

        private void Load7_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[6], ref MainWindow.VSTs.VSTDLLDescs[6], Desc7, Unload7, Load7, 7);
        }

        private void Load8_Click(object sender, EventArgs e)
        {
            LoadVST(ref MainWindow.VSTs.VSTDLLs[7], ref MainWindow.VSTs.VSTDLLDescs[7], Desc8, Unload8, Load8, 8);
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
                        if (Properties.Settings.Default.VSTiDisclaimer)
                        {
                            DialogResult dialogResult = MessageBox.Show(Languages.Parse("LegalWarningVSTi"), String.Format("{0}{1} - {2}", Program.Who, Program.Title, Languages.Parse("Warning")), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Properties.Settings.Default.VSTiDisclaimer = false;
                                Properties.Settings.Default.Save();
                                status = 2;
                                MessageBox.Show(Languages.Parse("VSTiModeOnLegal"), String.Format("{0}{1} - {2}", Program.Who, Program.Title, Languages.Parse("Warning")), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                Properties.Settings.Default.VSTiDisclaimer = true;
                                Properties.Settings.Default.Save();
                                return;
                            }
                        }
                        else
                        {
                            status = 2;
                            MessageBox.Show(Languages.Parse("VSTiModeOn"), String.Format("{0}{1} - {2}", Program.Who, Program.Title, Languages.Parse("Warning")), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
                        VSTDLLDesc = String.Format("{0} - ({1})", VSTImportDialog.FileName, Languages.Parse("NotVerified"));
                        Desc.Text = String.Format("{0} - ({1})", VSTImportDialog.FileName, Languages.Parse("NotVerified"));
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
                            String Lab = String.Format(Languages.Parse("VSTNameAndVersion"), MainWindow.KMCGlobals.vstIInfo.productName, MainWindow.KMCGlobals.vstIInfo.vendorName, MainWindow.KMCGlobals.vstIInfo.vendorVersion);
                            VSTDLL = VSTImportDialog.FileName;
                            VSTDLLDesc = Lab;
                            Desc.Text = Lab;
                            Unload.Enabled = true;
                            Load.Enabled = false;
                            SaveDirectory(VSTImportDialog.FileName);
                            BassVst.BASS_VST_ChannelFree(VSTiTester);
                            Bass.BASS_Free();
                        }
                        else
                        {
                            MessageBox.Show(String.Format(Languages.Parse("InvalidVSTLoaded"), Path.GetFileNameWithoutExtension(VSTImportDialog.FileName), bitreq, bitnow), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                            VSTDLLDesc = String.Format(Languages.Parse("VSTNameAndVersion"), VSTInfo.productName, VSTInfo.vendorName, VSTInfo.vendorVersion);
                            Desc.Text = String.Format(Languages.Parse("VSTNameAndVersion"), VSTInfo.productName, VSTInfo.vendorName, VSTInfo.vendorVersion);
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
                            MessageBox.Show(String.Format(Languages.Parse("InvalidVSTLoaded"), Path.GetFileNameWithoutExtension(VSTImportDialog.FileName), bitreq, bitnow), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            BassVst.BASS_VST_ChannelRemoveDSP(Test, VSTTester);
                            Bass.BASS_StreamFree(Test);
                            Bass.BASS_Free();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), ex.ToString(), 0, 1);
                errordialog.ShowDialog();
            }
        }

        private void Unload_Click(object sender, EventArgs e)
        {
            MainWindow.KMCGlobals.vstIInfo = new BASS_VST_INFO();
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[0] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[0] = null;
            Desc1.Text = Languages.Parse("EmptySlot") + " 1";
            Unload1.Enabled = false;
            Load1.Enabled = true;
        }

        private void Unload2_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[1] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[1] = null;
            Desc2.Text = Languages.Parse("EmptySlot") + " 2";
            Unload2.Enabled = false;
            Load2.Enabled = true;
        }

        private void Unload3_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[2] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[2] = null;
            Desc3.Text = Languages.Parse("EmptySlot") + " 3";
            Unload3.Enabled = false;
            Load3.Enabled = true;
        }

        private void Unload4_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[3] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[3] = null;
            Desc4.Text = Languages.Parse("EmptySlot") + " 4";
            Unload4.Enabled = false;
            Load4.Enabled = true;
        }

        private void Unload5_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[4] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[4] = null;
            Desc5.Text = Languages.Parse("EmptySlot") + " 5";
            Unload5.Enabled = false;
            Load5.Enabled = true;
        }

        private void Unload6_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[5] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[5] = null;
            Desc6.Text = Languages.Parse("EmptySlot") + " 6";
            Unload6.Enabled = false;
            Load6.Enabled = true;
        }

        private void Unload7_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[6] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[6] = null;
            Desc7.Text = Languages.Parse("EmptySlot") + " 7";
            Unload7.Enabled = false;
            Load7.Enabled = true;
        }

        private void Unload8_Click(object sender, EventArgs e)
        {
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLs[7] = null;
            KeppyMIDIConverter.MainWindow.VSTs.VSTDLLDescs[7] = null;
            Desc8.Text = Languages.Parse("EmptySlot") + " 8";
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
            Properties.Settings.Default.LoudMaxEnabled = LoudMaxCheck.Checked;
            LoudMaxCheck.ForeColor = Properties.Settings.Default.LoudMaxEnabled ? Color.Green : Color.DarkRed;
            LoudMaxCheck.Text = Properties.Settings.Default.LoudMaxEnabled ? "LoudMax on" : "LoudMax off";
            LoudMaxCheck.Checked = Properties.Settings.Default.LoudMaxEnabled;
            Properties.Settings.Default.Save();
        }
    }
}
