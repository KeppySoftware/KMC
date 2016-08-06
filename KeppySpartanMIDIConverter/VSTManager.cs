using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass.AddOn.Midi;

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

        private void VSTManagerWindow_Load(object sender, EventArgs e)
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
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc != null)
            {
                label1.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc;
                Unload.Enabled = true;
                Load1.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc2 != null)
            {
                label2.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc2;
                Unload2.Enabled = true;
                Load2.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc3 != null)
            {
                label3.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc3;
                Unload3.Enabled = true;
                Load3.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc4 != null)
            {
                label4.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc4;
                Unload4.Enabled = true;
                Load4.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc5 != null)
            {
                label5.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc5;
                Unload5.Enabled = true;
                Load5.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc6 != null)
            {
                label6.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc6;
                Unload6.Enabled = true;
                Load6.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc7 != null)
            {
                label1.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc7;
                Unload7.Enabled = true;
                Load7.Enabled = false;
            }
            if (KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc8 != null)
            {
                label8.Text = KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc8;
                Unload8.Enabled = true;
                Load8.Enabled = false;
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label1.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload.Enabled = true;
                    Load1.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load2_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL2 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc2 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label2.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload2.Enabled = true;
                    Load2.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load3_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL3 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc3 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label3.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload3.Enabled = true;
                    Load3.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load4_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL4 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc4 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label4.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload4.Enabled = true;
                    Load4.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load5_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL5 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc5 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label5.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload5.Enabled = true;
                    Load5.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load6_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL6 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc6 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label6.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload6.Enabled = true;
                    Load6.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load7_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL7 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc7 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label7.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload7.Enabled = true;
                    Load7.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Load8_Click(object sender, EventArgs e)
        {
            if (VSTImportDialog.ShowDialog() == DialogResult.OK)
            {
                Un4seen.Bass.Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                int Test = Bass.BASS_StreamCreateDummy(44100, 2, BASSFlag.BASS_STREAM_DECODE, IntPtr.Zero);
                int VSTTester = BassVst.BASS_VST_ChannelSetDSP(Test, VSTImportDialog.FileName, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(VSTTester, vstInfo))
                {
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL8 = VSTImportDialog.FileName;
                    KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc8 = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    label8.Text = vstInfo.productName + " by " + vstInfo.vendorName + " (Version: " + vstInfo.vendorVersion + ")";
                    Bass.BASS_Free();
                    Unload8.Enabled = true;
                    Load8.Enabled = false;
                }
                else
                {
                    Bass.BASS_Free();
                    MessageBox.Show("This is not a VST effect!\nPlease be sure to load a VST effect and NOT a VST instrument.\n\nAlso, if you're trying to use a " + bitreq + " VST, you need to use the " + bitreq + " version of Keppy's MIDI Converter too.\nThe " + bitnow + " version of Keppy's MIDI Converter does NOT support " + bitreq + " VSTs or viceversa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }  
        }

        private void Unload_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc = null;
            label1.Text = "Empty slot 1";
            Unload.Enabled = false;
            Load1.Enabled = true;
        }

        private void Unload2_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL2 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc2 = null;
            label2.Text = "Empty slot 2";
            Unload2.Enabled = false;
            Load2.Enabled = true;
        }

        private void Unload3_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL3 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc3 = null;
            label3.Text = "Empty slot 3";
            Unload3.Enabled = false;
            Load3.Enabled = true;
        }

        private void Unload4_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL4 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc4 = null;
            label4.Text = "Empty slot 4";
            Unload4.Enabled = false;
            Load4.Enabled = true;
        }

        private void Unload5_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL5 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc5 = null;
            label5.Text = "Empty slot 5";
            Unload5.Enabled = false;
            Load5.Enabled = true;
        }

        private void Unload6_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL6 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc6 = null;
            label6.Text = "Empty slot 6";
            Unload6.Enabled = false;
            Load6.Enabled = true;
        }

        private void Unload7_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL7 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc7 = null;
            label7.Text = "Empty slot 7";
            Unload7.Enabled = false;
            Load7.Enabled = true;
        }

        private void Unload8_Click(object sender, EventArgs e)
        {
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLL8 = null;
            KeppySpartanMIDIConverter.MainWindow.Globals.VSTDLLDesc8 = null;
            label8.Text = "Empty slot 8";
            Unload8.Enabled = false;
            Load8.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Unload.PerformClick();
            Unload2.PerformClick();
            Unload3.PerformClick();
            Unload4.PerformClick();
            Unload5.PerformClick();
            Unload6.PerformClick();
            Unload7.PerformClick();
            Unload8.PerformClick();
        }
    }
}
