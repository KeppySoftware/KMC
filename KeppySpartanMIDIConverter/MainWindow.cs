using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Taskbar;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Midi;

namespace KeppySpartanMIDIConverter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static int _Encoder;
            public static int _recHandle;
            public static int ActiveVoicesInt = 0;
            public static int AverageCPU;
            public static string BenchmarkTime;
            public static int CancellationPendingValue = 0;
            public static bool ChorusAFX = false;
            public static int ChorusAFXValue = 1;
            public static int ChorusDelay = 0;
            public static int ChorusDepth = 0;
            public static int ChorusFeedback = 0;
            public static int ChorusLevel = 0;
            public static int ChorusOnOr = 0;
            public static int ChorusRate = 0;
            public static bool CompressorAFX = false;
            public static int CompressorAFXValue = 1;
            public static int CurrentEncoder;
            public static int CurrentMode;
            public static int CurrentStatusMaximumInt;
            public static string CurrentStatusTextString;
            public static int CurrentStatusValueInt;
            public static string DisabledOr;
            public static bool DistortionAFX = false;
            public static int DistortionAFXValue = 1;
            public static bool EchoAFX = false;
            public static int EchoAFXValue = 1;
            public static string ExportWhereYay;
            public static string FinalTempo;
            public static bool FlangerAFX = false;
            public static int FlangerAFXValue = 1;
            public static int Frequency = 0xbb80;
            public static bool FXDisabled = false;
            public static bool GargleAFX = false;
            public static int GargleAFXValue = 1;
            public static int LimitVoicesInt = 0x186a0;
            public static string MIDIName;
            public static string MP3Bitrate;
            public static string NewWindowName = null;
            public static string CurrentPeak = "RMS: 0.0 dB | AVG: 0.0 dB | Peak: 0.0 dB";
            public static bool NoteOff1Event = false;
            public static string PreviousItemCodec = "WAV 32-bit (float)";
            public static bool ReverbAFX = false;
            public static int ReverbAFXValue = 1;
            public static int ReverbDelay = 0;
            public static int ReverbHiCut = 20;
            public static int ReverbLevel = 0;
            public static int ReverbLoCut = 20;
            public static int ReverbOnOr = 0;
            public static int ReverbTime = 0;
            public static string SFLittleName;
            public static string SFName;
            public static bool SittingAFX = false;
            public static int SittingAFXValue = 1;
            public static int SoundFont;
            public static int Time = 0;
            public static string WAVName;
            public static Un4seen.Bass.Misc.DSP_PeakLevelMeter _plm;
            public static AdvancedSettings frm = new AdvancedSettings();
        }

        private void abortBenchmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CancellationPendingValue = 1;
            startBenchmarkToolStripMenuItem.Enabled = true;
            abortBenchmarkToolStripMenuItem.Enabled = false;
        }

        private void abortRenderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CancellationPendingValue = 1;
            this.startRenderingToolStripMenuItem.Enabled = true;
            this.abortRenderingToolStripMenuItem.Enabled = false;
        }

        private void addMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in this.MIDIImport.FileNames)
                {
                    this.MIDIList.Items.Add(str);
                }
            }
        }

        private void Benchmarker_DoWork(object sender, DoWorkEventArgs e)
        {
            string str = null;
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                if (Globals.SFName == null)
                {
                    throw new Exception("No soundfont selected.");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list.");
                }
                try
                {
                    int newvalue = Convert.ToInt32(this.VoiceLimit.Value.ToString());
                    int font = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                    Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, newvalue);
                    foreach (string str2 in this.MIDIList.Items)
                    {
                        Path.GetFileNameWithoutExtension(str2);
                        Un4seen.Bass.Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER | BASSInit.BASS_DEVICE_LATENCY, IntPtr.Zero);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 10);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, 8);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                        Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str2, 0L, 0L, BASSFlag.BASS_MUSIC_DECODE | BASSFlag.BASS_AAC_FRAME960 | BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_FX, Globals.Frequency);
                        Globals.NewWindowName = "Keppy's MIDI Converter | Benchmarking " + Path.GetFileNameWithoutExtension(str2) + "...";
                        Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                        Globals._plm.CalcRMS = true;
                        BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[] { new BASS_MIDI_FONT(font, -1, 0) };
                        BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, 1);
                        BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
                        Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, null, BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                        while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                        {
                            int length = Convert.ToInt32(Un4seen.Bass.Bass.BASS_ChannelSeconds2Bytes(Globals._recHandle, 0.02));
                            long pos = Un4seen.Bass.Bass.BASS_ChannelGetLength(Globals._recHandle);
                            long num5 = Un4seen.Bass.Bass.BASS_ChannelGetPosition(Globals._recHandle);
                            float single1 = ((float)pos) / 1048576f;
                            float num6 = ((float)num5) / 1048576f;
                            double num7 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, pos);
                            double num8 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, num5);
                            double totalSeconds = stopwatch.Elapsed.TotalSeconds;
                            TimeSpan span = TimeSpan.FromSeconds(num7);
                            TimeSpan span2 = TimeSpan.FromSeconds(num8);
                            TimeSpan span3 = TimeSpan.FromSeconds(totalSeconds);
                            string text1 = span.Hours.ToString().PadLeft(2, '0') + ":" + span.Minutes.ToString().PadLeft(2, '0') + ":" + span.Seconds.ToString().PadLeft(2, '0');
                            string text2 = span2.Hours.ToString().PadLeft(2, '0') + ":" + span2.Minutes.ToString().PadLeft(2, '0') + ":" + span2.Seconds.ToString().PadLeft(2, '0');
                            str = span3.Hours.ToString().PadLeft(2, '0') + ":" + span3.Minutes.ToString().PadLeft(2, '0') + ":" + span3.Seconds.ToString().PadLeft(2, '0');
                            float num10 = 0f;
                            float num11 = 0f;
                            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref num10);
                            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_CPU, ref num11);
                            int[] buffer = new int[length / 4];
                            Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                            Globals.CurrentStatusTextString = num6.ToString("0.0") + "MBs converted.\nBenchmark total time: " + str + "\nBASS CPU usage: " + Convert.ToInt32(num11).ToString() + "% (" + Convert.ToInt32((float)(num11 / 100f)).ToString() + "x~ more slower)";
                            Globals.ActiveVoicesInt = Convert.ToInt32(num10);
                            Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                            Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num5 / 0x100000L));
                            Globals.CurrentPeak = String.Format("RMS: {0:#00.0} dB | AVG: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                            if (Globals.CancellationPendingValue == 1)
                            {
                                stopwatch.Stop();
                                Globals.CurrentStatusTextString = "Benchmark aborted.";
                                Globals.NewWindowName = "Keppy's MIDI Converter";
                                Globals.ActiveVoicesInt = 0;
                                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                Bass.BASS_StreamFree(Globals._recHandle);
                                BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                                Bass.BASS_Free();
                                MessageBox.Show("Benchmark aborted.\n\nTotal time was: " + str, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Globals.CurrentStatusTextString = null;
                                break;
                            }
                            if (Globals.CancellationPendingValue == 2)
                            {
                                stopwatch.Stop();
                                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                Bass.BASS_StreamFree(Globals._recHandle);
                                BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                                Bass.BASS_Free();
                                Globals.NewWindowName = "Keppy's MIDI Converter";
                                Globals.CurrentStatusTextString = "Closing...";
                                break;
                            }
                        }
                    }
                    if (Globals.CancellationPendingValue == 1)
                    {
                        Globals.CancellationPendingValue = 0;
                    }
                    else if (Globals.CancellationPendingValue == 2)
                    {
                        Globals.CancellationPendingValue = 0;
                    }
                    else
                    {
                        stopwatch.Stop();
                        BassEnc.BASS_Encode_Stop(Globals._Encoder);
                        Bass.BASS_StreamFree(Globals._recHandle);
                        BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                        Bass.BASS_Free();
                        Globals.NewWindowName = "Keppy's MIDI Converter";
                        MessageBox.Show("Benchmark finished.\n\nYou ''converted'' all the MIDIs in: " + str, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception exception)
                {
                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                    Bass.BASS_StreamFree(Globals._recHandle);
                    BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                    Bass.BASS_Free();
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    MessageBox.Show(exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);   
            }
        }

        private void benchmarkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CurrentMode = 1;
            this.conversionModeToolStripMenuItem.Enabled = true;
            this.benchmarkModeToolStripMenuItem.Enabled = false;
        }

        private void clearMIDIsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void conversionModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CurrentMode = 0;
            this.conversionModeToolStripMenuItem.Enabled = false;
            this.benchmarkModeToolStripMenuItem.Enabled = true;
        }

        private void Converter_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Globals.SFName == null)
                {
                    throw new Exception("No soundfont selected.");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list.");
                }
                try
                {
                    int newvalue = Convert.ToInt32(this.VoiceLimit.Value.ToString());
                    int font = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                    Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, newvalue);
                    foreach (string str in this.MIDIList.Items)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                        string path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (1).wav";
                        Un4seen.Bass.Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER | BASSInit.BASS_DEVICE_LATENCY, IntPtr.Zero);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 10);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, 8);
                        Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                        Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_MUSIC_DECODE | BASSFlag.BASS_AAC_FRAME960 | BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_FX, Globals.Frequency);
                        Globals.NewWindowName = "Keppy's MIDI Converter | Exporting " + Path.GetFileNameWithoutExtension(str) + "...";
                        Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                        Globals._plm.CalcRMS = true;
                        BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[] { new BASS_MIDI_FONT(font, -1, 0) };
                        BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, 1);
                        BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
                        int num3 = 0;
                        if (File.Exists(Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".wav"))
                        {
                            do
                            {
                                num3++;
                                path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (" + num3.ToString() + ").wav";
                            }
                            while (File.Exists(path));
                            Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, path, BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                        }
                        else
                        {
                            Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + ".wav", BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                        }
                        if (Globals.FXDisabled)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
                        }
                        else
                        {
                            Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_MIDI_NOFX);
                        }
                        if (Globals.NoteOff1Event)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_FX_FREESOURCE, BASSFlag.BASS_FX_FREESOURCE);
                        }
                        else
                        {
                            Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_FX_FREESOURCE);
                        }
                        if (Globals.ReverbAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_REVERB, Globals.ReverbAFXValue);
                        }
                        if (Globals.ChorusAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_CHORUS, Globals.ChorusAFXValue);
                        }
                        if (Globals.CompressorAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_COMPRESSOR, Globals.CompressorAFXValue);
                        }
                        if (Globals.DistortionAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_DISTORTION, Globals.DistortionAFXValue);
                        }
                        if (Globals.FlangerAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_FLANGER, Globals.FlangerAFXValue);
                        }
                        if (Globals.EchoAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_ECHO, Globals.EchoAFXValue);
                        }
                        if (Globals.SittingAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_I3DL2REVERB, Globals.SittingAFXValue);
                        }
                        if (Globals.GargleAFX)
                        {
                            Un4seen.Bass.Bass.BASS_ChannelSetFX(Globals._recHandle, BASSFXType.BASS_FX_DX8_GARGLE, Globals.GargleAFXValue);
                        }
                        while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                        {
                            int length = Convert.ToInt32(Un4seen.Bass.Bass.BASS_ChannelSeconds2Bytes(Globals._recHandle, 0.02));
                            long pos = Un4seen.Bass.Bass.BASS_ChannelGetLength(Globals._recHandle);
                            long num6 = Un4seen.Bass.Bass.BASS_ChannelGetPosition(Globals._recHandle);
                            float num7 = ((float)pos) / 1048576f;
                            float num8 = ((float)num6) / 1048576f;
                            double num9 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, pos);
                            double num10 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, num6);
                            TimeSpan span = TimeSpan.FromSeconds(num9);
                            TimeSpan span2 = TimeSpan.FromSeconds(num10);
                            string str4 = span.Hours.ToString().PadLeft(2, '0') + ":" + span.Minutes.ToString().PadLeft(2, '0') + ":" + span.Seconds.ToString().PadLeft(2, '0');
                            string str5 = span2.Hours.ToString().PadLeft(2, '0') + ":" + span2.Minutes.ToString().PadLeft(2, '0') + ":" + span2.Seconds.ToString().PadLeft(2, '0');
                            float num11 = 0f;
                            float num12 = 0f;
                            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref num11);
                            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_CPU, ref num12);
                            int[] buffer = new int[length / 4];
                            Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                            if (num12 < 100f)
                            {
                                Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs converted. (Estimated final WAV size: " + num7.ToString("0.0") + "MB)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "%";
                            }
                            else if (num12 > 100f)
                            {
                                Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs converted. (Estimated final WAV size: " + num7.ToString("0.0") + "MB)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "% (" + Convert.ToInt32((float)(num12 / 100f)).ToString() + "x~ more slower)";
                            }
                            Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                            Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                            Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                            Globals.CurrentPeak = String.Format("RMS: {0:#00.0} dB | AVG: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                            if (Globals.CancellationPendingValue == 1)
                            {
                                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                Bass.BASS_StreamFree(Globals._recHandle);
                                BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                                Bass.BASS_Free();
                                Globals.CurrentStatusTextString = "Conversion aborted.";
                                Globals.ActiveVoicesInt = 0;
                                Globals.NewWindowName = "Keppy's MIDI Converter";
                                MessageBox.Show("Conversion aborted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Globals.CurrentStatusTextString = null;
                                break;
                            }
                        }
                    }
                    if (Globals.CancellationPendingValue == 1)
                    {
                        Globals.CancellationPendingValue = 0;
                        Globals.NewWindowName = "Keppy's MIDI Converter";
                    }
                    else
                    {
                        BassEnc.BASS_Encode_Stop(Globals._Encoder);
                        Bass.BASS_StreamFree(Globals._recHandle);
                        BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                        Bass.BASS_Free();
                        Globals.NewWindowName = "Keppy's MIDI Converter";
                        Globals.ActiveVoicesInt = 0;
                        MessageBox.Show("Files have been converted succesfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (Exception exception)
                {
                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                    Bass.BASS_StreamFree(Globals._recHandle);
                    BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                    Bass.BASS_Free();
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    MessageBox.Show(exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception exception2)
            {
                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                Bass.BASS_StreamFree(Globals._recHandle);
                BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                Bass.BASS_Free();
                Globals.NewWindowName = "Keppy's MIDI Converter";
                MessageBox.Show(exception2.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CancellationPendingValue = 2;
            base.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BassNet.Registration("kaleidonkep99@outlook.com", "2X203132524822");
        }

        private void importMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in this.MIDIImport.FileNames)
                {
                    this.MIDIList.Items.Add(str);
                }
            }
        }

        private void informationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Informations().ShowDialog();
        }

        private void loadSoundfontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SoundfontImportDialog.ShowDialog() == DialogResult.OK)
            {
                Globals.SFName = this.SoundfontImportDialog.FileName;
                if ((Path.GetExtension(Globals.SFName) == ".sf2") | (Path.GetExtension(Globals.SFName) == ".sfz") | (Path.GetExtension(Globals.SFName) == ".SF2") | (Path.GetExtension(Globals.SFName) == ".SFZ"))
                {
                    try
                    {
                        Globals.SFName = this.SoundfontImportDialog.FileName;
                        Globals.SFLittleName = Path.GetFileName(Globals.SFName);
                        int handle = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                        BASS_MIDI_FONTINFO info = new BASS_MIDI_FONTINFO();
                        BassMidi.BASS_MIDI_FontGetInfo(handle, info);
                        if ((Path.GetExtension(Globals.SFName) == "*.sfz") | (Path.GetExtension(Globals.SFName) == ".SFZ") && (info.ToString() == "Name=, Copyright=, Comment="))
                        {
                            this.label2.Text = "Can not take additional soundfont infos from SFZ files:\nName: " + Globals.SFLittleName;
                        }
                        else if ((Path.GetExtension(Globals.SFName) != "*.sf2") | (Path.GetExtension(Globals.SFName) == ".SF2") && (info.ToString() == "Name=, Copyright=, Comment="))
                        {
                            this.label2.Text = "Missing additional info about the soundfont:\nName: " + Globals.SFLittleName;
                        }
                        else if (info.presets.ToString() == "1")
                        {
                            string[] strArray = new string[] { "Name: ", info.name.ToString(), " (", Globals.SFLittleName, ", ", info.presets.ToString(), " preset)\nSize: ", (((float)info.samsize) / 1048576f).ToString("0.00"), "MB" };
                            this.label2.Text = string.Concat(strArray);
                        }
                        else
                        {
                            string[] strArray2 = new string[] { "Name: ", info.name.ToString(), " (", Globals.SFLittleName, ", ", info.presets.ToString(), " presets)\nSize: ", (((float)info.samsize) / 1048576f).ToString("0.00"), "MB" };
                            this.label2.Text = string.Concat(strArray2);
                        }
                    }
                    catch
                    {
                        string message = "Unhandled exception.";
                        try
                        {
                            Environment.FailFast(message);
                        }
                        finally
                        {
                            Console.WriteLine("");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid soundfont!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIList.SelectedItems.Count >= 2)
            {
                MessageBox.Show(this, "You can only move one item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.MoveItem(1);
            }
        }

        public void MoveItem(int direction)
        {
            if ((this.MIDIList.SelectedItem != null) && (this.MIDIList.SelectedIndex >= 0))
            {
                int index = this.MIDIList.SelectedIndex + direction;
                if ((index >= 0) && (index < this.MIDIList.Items.Count))
                {
                    object selectedItem = this.MIDIList.SelectedItem;
                    this.MIDIList.Items.Remove(selectedItem);
                    this.MIDIList.Items.Insert(index, selectedItem);
                    this.MIDIList.SetSelected(index, true);
                }
            }
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIList.SelectedItems.Count >= 2)
            {
                MessageBox.Show(this, "You can only move one item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.MoveItem(-1);
            }
        }

        private void officialBlackMIDIWikiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://officialblackmidi.wikia.com/wiki/Official_Black_MIDI_Wikia");
        }

        private void removeMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.MIDIList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                this.MIDIList.Items.RemoveAt(this.MIDIList.SelectedIndices[i]);
            }
        }

        private void removeSelectedMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.MIDIList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                this.MIDIList.Items.RemoveAt(this.MIDIList.SelectedIndices[i]);
            }
        }

        private void RenderingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    this.CurrentStatusText.Text = "Idle.\nAdd some MIDIs to start the conversion or the benchmark!";
                    this.UsedVoices.Text = "Voices:\n0\\" + Globals.LimitVoicesInt.ToString();
                    this.CurrentStatus.Value = 0;
                    this.CurrentStatus.Maximum = 0;
                    this.loadSoundfontToolStripMenuItem.Enabled = true;
                    this.unloadSoundfontToolStripMenuItem.Enabled = true;
                    this.labelRMS.Text = Globals.CurrentPeak;
                }
                else if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (Globals.CurrentStatusTextString == null)
                    {
                        this.CurrentStatusText.Text = "Preparing for export/benchmark.\nPlease wait...";
                        this.UsedVoices.Text = "Voices:\n" + Globals.ActiveVoicesInt.ToString() + @"\" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.abortRenderingToolStripMenuItem.Enabled = false;
                        this.loadSoundfontToolStripMenuItem.Enabled = false;
                        this.unloadSoundfontToolStripMenuItem.Enabled = false;
                        this.labelRMS.Text = Globals.CurrentPeak;
                    }
                    else
                    {
                        this.CurrentStatusText.Text = Globals.CurrentStatusTextString;
                        this.UsedVoices.Text = "Voices:\n" + Globals.ActiveVoicesInt.ToString() + @"\" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        TaskbarManager.Instance.SetProgressValue(Globals.CurrentStatusValueInt, Globals.CurrentStatusMaximumInt);
                        this.CurrentStatus.Value = Globals.CurrentStatusValueInt;
                        this.CurrentStatus.Maximum = Globals.CurrentStatusMaximumInt;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.loadSoundfontToolStripMenuItem.Enabled = false;
                        this.unloadSoundfontToolStripMenuItem.Enabled = false;
                        this.labelRMS.Text = Globals.CurrentPeak;
                    }
                    if (Globals.NewWindowName == null)
                    {
                        this.Text = "Keppy's MIDI Converter";
                    }
                    else
                    {
                        this.Text = Globals.NewWindowName;
                    }
                }
                if (this.Converter.IsBusy || this.Benchmarker.IsBusy)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    this.importMIDIsToolStripMenuItem.Enabled = false;
                    this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                    this.clearMIDIsListToolStripMenuItem.Enabled = false;
                    this.startRenderingToolStripMenuItem.Enabled = false;
                    this.startBenchmarkToolStripMenuItem.Enabled = false;
                    if (this.CurrentStatusText.Text == "Preparing for export/benchmark.\nPlease wait...")
                    {
                        this.abortRenderingToolStripMenuItem.Enabled = false;
                        this.abortBenchmarkToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.abortBenchmarkToolStripMenuItem.Enabled = true;
                    }
                    this.modesToolStripMenuItem.Enabled = false;
                    this.loadSoundfontToolStripMenuItem.Enabled = false;
                    this.unloadSoundfontToolStripMenuItem.Enabled = false;
                    this.VoiceLimit.Enabled = false;
                    this.AdvSettingsButton.Enabled = false;
                    this.DefMenu.Enabled = false;
                    this.loadingpic.Visible = true;
                    this.labelRMS.Text = Globals.CurrentPeak;
                }
                else if (!this.Converter.IsBusy || !this.Benchmarker.IsBusy)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    TaskbarManager.Instance.SetProgressValue(0, 0);
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    this.importMIDIsToolStripMenuItem.Enabled = true;
                    this.removeSelectedMIDIsToolStripMenuItem.Enabled = true;
                    this.clearMIDIsListToolStripMenuItem.Enabled = true;
                    this.startRenderingToolStripMenuItem.Enabled = true;
                    this.abortRenderingToolStripMenuItem.Enabled = false;
                    this.startBenchmarkToolStripMenuItem.Enabled = true;
                    this.abortBenchmarkToolStripMenuItem.Enabled = false;
                    this.modesToolStripMenuItem.Enabled = true;
                    this.loadSoundfontToolStripMenuItem.Enabled = true;
                    this.unloadSoundfontToolStripMenuItem.Enabled = true;
                    this.VoiceLimit.Enabled = true;
                    this.AdvSettingsButton.Enabled = true;
                    this.DefMenu.Enabled = true;
                    this.loadingpic.Visible = false;
                }
            }
            catch
            {
            }
            if (Globals.CurrentMode == 0)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                TaskbarManager.Instance.SetProgressValue(Globals.CurrentStatusValueInt, Globals.CurrentStatusMaximumInt);
                this.startRenderingToolStripMenuItem.Visible = true;
                this.abortRenderingToolStripMenuItem.Visible = true;
                this.startBenchmarkToolStripMenuItem.Visible = false;
                this.abortBenchmarkToolStripMenuItem.Visible = false;
            }
            else
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                TaskbarManager.Instance.SetProgressValue(Globals.CurrentStatusValueInt, Globals.CurrentStatusMaximumInt);
                this.startRenderingToolStripMenuItem.Visible = false;
                this.abortRenderingToolStripMenuItem.Visible = false;
                this.startBenchmarkToolStripMenuItem.Visible = true;
                this.abortBenchmarkToolStripMenuItem.Visible = true;
            }
        }

        private void startBenchmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            this.Benchmarker.RunWorkerAsync();
        }

        private void startRenderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            string dummyFileName = "Save Here";
            this.ExportWhere.FileName = dummyFileName;
            this.ExportWhere.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                this.Converter.RunWorkerAsync();
            }
        }

        private void unloadSoundfontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.SFName = null;
            Globals.SFLittleName = null;
            this.label2.Text = "Load a soundfont first\nto see its informations here.";
        }

        private void VoiceLimit_ValueChanged(object sender, EventArgs e)
        {
            Globals.LimitVoicesInt = Convert.ToInt32(this.VoiceLimit.Value);
        }

        private void AdvSettingsButton_Click(object sender, EventArgs e)
        {
            Globals.frm.ShowDialog();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            BassNet.Registration("yourbassnetemailhere", "yourbassnetcodehere");
            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
            Globals._plm.CalcRMS = true;
        }
    }
}
