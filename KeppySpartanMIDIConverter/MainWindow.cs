using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
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
            public static AdvancedSettings frm = new AdvancedSettings();
            public static Un4seen.Bass.Misc.DSP_PeakLevelMeter _plm;
            public static bool AutoShutDownEnabled = false;
            public static bool ChorusAFX = false;
            public static bool CompressorAFX = false;
            public static bool DistortionAFX = false;
            public static bool EchoAFX = false;
            public static bool FXDisabled = false;
            public static bool FlangerAFX = false;
            public static bool GargleAFX = false;
            public static bool NoteOff1Event = false;
            public static bool PlaybackMode = false;
            public static bool ReverbAFX = false;
            public static bool SittingAFX = false;
            public static bool TempoOverride = false;
            public static int ActiveVoicesInt = 0;
            public static int AverageCPU;
            public static int CancellationPendingValue = 0;
            public static int ChorusAFXValue = 1;
            public static int ChorusDelay = 0;
            public static int ChorusDepth = 0;
            public static int ChorusFeedback = 0;
            public static int ChorusLevel = 0;
            public static int ChorusOnOr = 0;
            public static int ChorusRate = 0;
            public static int CompressorAFXValue = 1;
            public static int CurrentEncoder;
            public static int CurrentMode;
            public static int CurrentStatusMaximumInt;
            public static int CurrentStatusValueInt;
            public static int DistortionAFXValue = 1;
            public static int EchoAFXValue = 1;
            public static int FlangerAFXValue = 1;
            public static int FinalTempo;
            public static int Frequency = 0xbb80;
            public static int DefaultSoundfont;
            public static int GargleAFXValue = 1;
            public static int LimitVoicesInt = 0x186a0;
            public static int ReverbAFXValue = 1;
            public static int ReverbDelay = 0;
            public static int ReverbHiCut = 20;
            public static int ReverbLevel = 0;
            public static int ReverbLoCut = 20;
            public static int ReverbOnOr = 0;
            public static int ReverbTime = 0;
            public static int SittingAFXValue = 1;
            public static int SoundFont;
            public static int Time = 0;
            public static int Volume;
            public static int _Encoder;
            public static int _recHandle;
            public static string BenchmarkTime;
            public static string CurrentPeak = "Root mean square: -.- dB | Average: -.- dB | Peak: -.- dB";
            public static string CurrentStatusTextString;
            public static string DisabledOr;
            public static string ExportWhereYay;
            public static string MIDILastDirectory;
            public static string SFLastDirectory;
            public static string ExportLastDirectory;
            public static string MIDIName;
            public static string NewWindowName = null;
            public static string PreviousItemCodec = "WAV 32-bit (float)";
            public static string SFLittleName;
            public static string SFName;
            public static string WAVName;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
                BassNet.Registration("kaleidonkep99@outlook.com", "2X203132524822");
                if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 0)
                {
                    MessageBox.Show("The converter requires Windows XP or newer to run.\nWindows 2000 and older are NOT supported.\n\nPress OK to quit.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    Application.ExitThread();
                }
                else
                {
                    Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                    Globals._plm.CalcRMS = true;
                    try
                    {
                        using (RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter"))
                            if (Key != null)
                            {
                                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                                RegistryKey Effects = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                                try
                                {      
                                    VoiceLimit.Value = Convert.ToInt32(Settings.GetValue("voices"));
                                    trackBar1.Value = Convert.ToInt32(Settings.GetValue("volume"));
                                    Globals.Volume = Convert.ToInt32(Settings.GetValue("volume"));
                                    Globals.Frequency = Convert.ToInt32(Settings.GetValue("audiofreq"));
                                    // BOOLEANSSSSSSSSS
                                    if (Effects.GetValue("reverb") == "1")
                                    {
                                        Globals.ReverbAFX = true;
                                    }
                                    else
                                    {
                                        Globals.ReverbAFX = false;
                                    }
                                    if (Effects.GetValue("chorus") == "1")
                                    {
                                        Globals.ChorusAFX = true;
                                    }
                                    else
                                    {
                                        Globals.ChorusAFX = false;
                                    }
                                    if (Effects.GetValue("flanger") == "1")
                                    {
                                        Globals.FlangerAFX = true;
                                    }
                                    else
                                    {
                                        Globals.FlangerAFX = false;
                                    }
                                    if (Effects.GetValue("compressor") == "1")
                                    {
                                        Globals.CompressorAFX = true;
                                    }
                                    else
                                    {
                                        Globals.CompressorAFX = false;
                                    }
                                    if (Effects.GetValue("gargle") == "1")
                                    {
                                        Globals.GargleAFX = true;
                                    }
                                    else
                                    {
                                        Globals.GargleAFX = false;
                                    }
                                    if (Effects.GetValue("distortion") == "1")
                                    {
                                        Globals.DistortionAFX = true;
                                    }
                                    else
                                    {
                                        Globals.DistortionAFX = false;
                                    }
                                    if (Effects.GetValue("echo") == "1")
                                    {
                                        Globals.EchoAFX = true;
                                    }
                                    else
                                    {
                                        Globals.EchoAFX = false;
                                    }
                                    if (Effects.GetValue("sittingroom") == "1")
                                    {
                                        Globals.SittingAFX = true;
                                    }
                                    else
                                    {
                                        Globals.SittingAFX = false;
                                    }
                                    if (Effects.GetValue("sittingroom") == "1")
                                    {
                                        Globals.SittingAFX = true;
                                    }
                                    else
                                    {
                                        Globals.SittingAFX = false;
                                    }
                                    if (Settings.GetValue("noteoff1") == "1")
                                    {
                                        Globals.NoteOff1Event = true;
                                    }
                                    else
                                    {
                                        Globals.NoteOff1Event = false;
                                    }
                                    if (Settings.GetValue("disablefx") == "1")
                                    {
                                        Globals.FXDisabled = true;
                                    }
                                    else
                                    {
                                        Globals.FXDisabled = false;
                                    }
                                    Globals.MIDILastDirectory = Settings.GetValue("lastmidifolder").ToString();
                                    Globals.SFLastDirectory = Settings.GetValue("lastsffolder").ToString();
                                    Globals.ExportLastDirectory = Settings.GetValue("lastexportfolder").ToString();
                                    Settings.Close();
                                    Effects.Close();
                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.ToString(), "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Settings.Close();
                                    Effects.Close();
                                }
                            }
                            else if (Key == null)
                            {
                                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
                                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects");
                                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                                RegistryKey Effects = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Effects", true);
                                VoiceLimit.Value = 100000;
                                Settings.SetValue("voices", "100000", RegistryValueKind.DWord);
                                Settings.SetValue("lastmidifolder", "", RegistryValueKind.String);
                                Settings.SetValue("lastsffolder", "", RegistryValueKind.String);
                                Settings.SetValue("lastexportfolder", "", RegistryValueKind.String);
                                Settings.SetValue("noteoff1", "0", RegistryValueKind.DWord);
                                Settings.SetValue("disablefx", "0", RegistryValueKind.DWord);
                                Settings.SetValue("maxcpu", "0", RegistryValueKind.DWord);
                                Settings.SetValue("audiofreq", "44100", RegistryValueKind.DWord);
                                Settings.SetValue("volume", "10000", RegistryValueKind.DWord);
                                Effects.SetValue("reverb", "0", RegistryValueKind.DWord);
                                Effects.SetValue("chorus", "0", RegistryValueKind.DWord);
                                Effects.SetValue("flanger", "0", RegistryValueKind.DWord);
                                Effects.SetValue("compressor", "0", RegistryValueKind.DWord);
                                Effects.SetValue("gargle", "0", RegistryValueKind.DWord);
                                Effects.SetValue("distortion", "0", RegistryValueKind.DWord);
                                Effects.SetValue("echo", "0", RegistryValueKind.DWord);
                                Effects.SetValue("sittingroom", "0", RegistryValueKind.DWord);
                                Settings.Close();
                                Effects.Close();
                            }
                        Console.WriteLine("Settings loaded.");
                    }
                    catch (Exception exception2)
                    {
                        MessageBox.Show("Error!", exception2.InnerException.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Globals.AutoShutDownEnabled = false;
            }
        }

        private void abortRenderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.CancellationPendingValue = 1;
            Globals.AutoShutDownEnabled = false;
            this.startRenderingWAVToolStripMenuItem.Enabled = true;
            this.startRenderingOGGToolStripMenuItem.Enabled = true;
            this.playInRealtimeBetaToolStripMenuItem.Enabled = true;
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

        private void clearMIDIsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void ConverterOGG_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Globals.SFName == null)
                {
                    throw new Exception("No soundfont selected!");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list!");
                }
                try
                {
                    int font = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = "empty";
                            string path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy 1).ogg";
                            Un4seen.Bass.Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 0);
                            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, 32);
                            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
                            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_FX | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
                            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 95);
							Globals.NewWindowName = "Keppy's MIDI Converter | Exporting \"" + Path.GetFileNameWithoutExtension(str) + "\"...";
                            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                            Globals._plm.CalcRMS = true;
                            BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[] { new BASS_MIDI_FONT(font, -1, 0) };
                            BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, 1);
                            BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
                            int num3 = 0;
                            if (File.Exists(Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg"))
                            {
                                do
                                {
                                    num3++;
                                    encpath = "oggenc2 -q 10 - -o \"" + Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy " + num3.ToString() + ").ogg\"";
                                    path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy " + num3.ToString() + ").ogg";
                                }
                                while (File.Exists(path));
                                Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, encpath, BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                            }
                            else
                            {
                                Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, "oggenc2 - -o \"" + Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + ".ogg\"", BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
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
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                            }
                            else
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_MIDI_NOTEOFF1);
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
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    if (MainWindow.Globals.TempoOverride == true)
                                    {
                                        BassMidi.BASS_MIDI_StreamEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_NOTE, Globals.FinalTempo);
                                    }
                                    else
                                    {
                                        // NULL
                                    }
                                    float FloatVolume = ((float)Globals.Volume) / 10000;
                                    BassMidi.BASS_MIDI_FontSetVolume(font, FloatVolume);
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
                                    float[] buffer = new float[length / 4];
                                    Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                                    if (num12 < 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas converted. (Cannot estimate size for OGG files)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "%";
                                    }
                                    else if (num12 > 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas converted. (Cannot estimate size for OGG files)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(num12 / 100f)).ToString("0.0") + "x~ more slower)";
                                    }
                                    Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                                    Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                                    Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                                    Globals.CurrentPeak = String.Format("Root mean square: {0:#00.0} dB | Average: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                                    Console.WriteLine("Current position: " + str5.ToString() + " - " + str4.ToString());
                                }
                                else if (Globals.CancellationPendingValue == 1)
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
                                    KeepLooping = false;
                                    break;
                                }
                            }
                            if (Globals.CancellationPendingValue == 1)
                            {
                                KeepLooping = false;
                                if (KeepLooping == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (Globals.CancellationPendingValue == 1)
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Conversion aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                simpleSound.Play();
                            }
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Globals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            else
                            {
                                if (Environment.OSVersion.Version.Major == 5)
                                {
                                    MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                    simpleSound.Play();
                                }
                            }
                        }
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

        private void ConverterWAV_DoWork(object sender, DoWorkEventArgs e)
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
                    int font = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                    bool KeepLooping = true;
                    while (KeepLooping) 
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            string path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy 1).wav";
                            Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 0);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, 32);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
                            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_FX | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
                            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                            Un4seen.Bass.Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 0);
                            Globals.NewWindowName = "Keppy's MIDI Converter | Exporting \"" + Path.GetFileNameWithoutExtension(str) + "\"...";
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
                                    encpath = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy " + num3.ToString() + ").wav";
                                    path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy " + num3.ToString() + ").wav";
                                }
                                while (File.Exists(path));
                                Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, encpath, BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
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
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                            }
                            else
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_MIDI_NOTEOFF1);
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
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    if (MainWindow.Globals.TempoOverride == true)
                                    {
                                        BassMidi.BASS_MIDI_StreamEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_NOTE, Globals.FinalTempo);
                                    }
                                    else
                                    {
                                        // NULL
                                    }
                                    float FloatVolume = ((float)Globals.Volume) / 10000;
                                    BassMidi.BASS_MIDI_FontSetVolume(font, FloatVolume);
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
                                    float[] buffer = new float[length / 4];
                                    Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                                    if (num12 < 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas converted. (Cannot estimate size for OGG files)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "%";
                                    }
                                    else if (num12 > 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas converted. (Cannot estimate size for OGG files)\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(num12 / 100f)).ToString("0.0") + "x~ more slower)";
                                    }
                                    Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                                    Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                                    Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                                    Globals.CurrentPeak = String.Format("Root mean square: {0:#00.0} dB | Average: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                                }
                                else if (Globals.CancellationPendingValue == 1)
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
                                    KeepLooping = false;
                                    break;
                                } 
                            }
                            if (Globals.CancellationPendingValue == 1)
                            {
                                KeepLooping = false;
                                if (KeepLooping == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (Globals.CancellationPendingValue == 1)
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Conversion aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                simpleSound.Play();
                            } 
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Globals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            else
                            {
                                if (Environment.OSVersion.Version.Major == 5)
                                {
                                    MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                    simpleSound.Play();
                                }
                            }
                        }
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

        private void RealTimePlayBackBeta_DoWork(object sender, DoWorkEventArgs e)
        {
            Globals.PlaybackMode = true;
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
                    int font = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            string path = Globals.ExportWhereYay + @"\" + fileNameWithoutExtension + " (Copy 1).wav";
                            Un4seen.Bass.Bass.BASS_Init(-1, Globals.Frequency, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, 150);                     
                            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
                            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_MUSIC_FLOAT | BASSFlag.BASS_MUSIC_FX | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
                            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                            Un4seen.Bass.Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 85);
                            Globals.NewWindowName = "Keppy's MIDI Converter | Playing \"" + Path.GetFileNameWithoutExtension(str) + "\"...";
                            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                            Globals._plm.CalcRMS = true;
                            BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[] { new BASS_MIDI_FONT(font, -1, 0) };
                            BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, 1);
                            BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
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
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                            }
                            else
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_MIDI_NOTEOFF1);
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
                            int lengthing = Convert.ToInt32(Un4seen.Bass.Bass.BASS_ChannelSeconds2Bytes(Globals._recHandle, 10.0));
                            Bass.BASS_ChannelUpdate(Globals._recHandle, lengthing);
                            Bass.BASS_ChannelPlay(Globals._recHandle, false);
                            lengthing = 0;
                            while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    if (MainWindow.Globals.TempoOverride == true)
                                    {
                                        BassMidi.BASS_MIDI_StreamEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_NOTE, Globals.FinalTempo);
                                    }
                                    else
                                    {
                                        // NULL
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
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                                    }
                                    else
                                    {
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_DEFAULT, BASSFlag.BASS_MIDI_NOTEOFF1);
                                    }
                                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, Convert.ToInt32(Globals.Volume));
                                    Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                                    int length = Convert.ToInt32(Un4seen.Bass.Bass.BASS_ChannelSeconds2Bytes(Globals._recHandle, 10.0));
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
                                    float[] buffer = new float[length / 4];
                                    Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                                    if (num12 < 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas played.\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "%";
                                    }
                                    else if (num12 > 100f)
                                    {
                                        Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas played.\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nBASS CPU usage: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(num12 / 100f)).ToString("0.0") + "x~ more slower)";
                                    }
                                    Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                                    Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                                    Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                                    Globals.CurrentPeak = String.Format("Root mean square: {0:#00.0} dB | Average: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                                    Bass.BASS_ChannelUpdate(Globals._recHandle, length);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                    Bass.BASS_StreamFree(Globals._recHandle);
                                    BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                                    Bass.BASS_Free();
                                    Globals.CurrentStatusTextString = "Conversion aborted.";
                                    Globals.ActiveVoicesInt = 0;
                                    Globals.NewWindowName = "Keppy's MIDI Converter";
                                    MessageBox.Show("Playback aborted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Globals.CurrentStatusTextString = null;
                                    KeepLooping = false;
                                    break;
                                }
                            }
                            if (Globals.CancellationPendingValue == 1)
                            {
                                KeepLooping = false;
                                if (KeepLooping == false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (Globals.CancellationPendingValue == 1)
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Playback aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Playback finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                simpleSound.Play();
                            }
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            BassMidi.BASS_MIDI_FontFree(Globals.SoundFont);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Playback finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer("convfin.wav");
                                simpleSound.Play();
                            }
                        }
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
            if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show("The converter is still exporting MIDIs!\n\nAre you sure you want to exit?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) Process.GetCurrentProcess().Kill();

            // Confirm user wants to close
            if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show("The converter is still exporting MIDIs!\n\nAre you sure you want to exit?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.GetCurrentProcess().Kill();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void importMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in this.MIDIImport.FileNames)
                {
                    this.MIDIList.Items.Add(str);
                }
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.MIDILastDirectory = Path.GetDirectoryName(MIDIImport.FileName);
                Settings.SetValue("lastmidifolder", Globals.MIDILastDirectory);
                MIDIImport.InitialDirectory = Globals.MIDILastDirectory;
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
                BassMidi.BASS_MIDI_FontUnload(Globals.DefaultSoundfont, -1, -1);
                Globals.SFName = this.SoundfontImportDialog.FileName;
                if ((Path.GetExtension(Globals.SFName) == ".sf2") | (Path.GetExtension(Globals.SFName) == ".sfz") | (Path.GetExtension(Globals.SFName) == ".SF2") | (Path.GetExtension(Globals.SFName) == ".SFZ"))
                {
                    try
                    {
                        Globals.SFName = this.SoundfontImportDialog.FileName;
                        Globals.SFLittleName = Path.GetFileName(Globals.SFName);
                        Globals.DefaultSoundfont = BassMidi.BASS_MIDI_FontInit(Globals.SFName);
                        BASS_MIDI_FONTINFO info = new BASS_MIDI_FONTINFO();
                        BassMidi.BASS_MIDI_FontGetInfo(Globals.DefaultSoundfont, info);
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
                    RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                    Globals.SFLastDirectory = Path.GetDirectoryName(SoundfontImportDialog.FileName);
                    Settings.SetValue("lastsffolder", Globals.SFLastDirectory);
                    SoundfontImportDialog.InitialDirectory = Globals.SFLastDirectory;
                }
                else
                {
                    MessageBox.Show("Invalid soundfont!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                    Globals.SFLastDirectory = Path.GetDirectoryName(SoundfontImportDialog.FileName);
                    Settings.SetValue("lastsffolder", Globals.SFLastDirectory);
                    SoundfontImportDialog.InitialDirectory = Globals.SFLastDirectory;
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

        // Links

        private void officialBlackMIDIWikiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://officialblackmidi.wikia.com/wiki/Official_Black_MIDI_Wikia");
        }

        private void wikipediasPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://en.wikipedia.org/wiki/Black_MIDI");
        }

        private void kaleidonKep99sYouTubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCJeqODojIv4TdeHcBfHJRnA");
        }

        private void keppyStudiosWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://kaleidonkep99.altervista.org/");
        }

        // No more links

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
            MIDIImport.InitialDirectory = Globals.MIDILastDirectory;
            SoundfontImportDialog.InitialDirectory = Globals.SFLastDirectory;
            ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            if (!Globals.AutoShutDownEnabled)
            {
                Globals.AutoShutDownEnabled = false;
                disabledToolStripMenuItem.Checked = true;
            }
            try
            {
                if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    this.Text = "Keppy's MIDI Converter";
                    this.loadingpic.Visible = false;
                    if (Environment.OSVersion.Version.Major == 5)
                    {
                        
                    }
                    else
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    }
                    this.CurrentStatusText.Text = "Idle.\nAdd some MIDIs to start the conversion or the preview!";
                    this.UsedVoices.Text = @"Voices: 0/" + Globals.LimitVoicesInt.ToString();
                    this.CurrentStatus.Value = 0;
                    this.CurrentStatus.Maximum = 0;
                    this.DefMenu.Enabled = true;
                    this.loadingpic.Visible = false;
                    this.SettingsBox.Enabled = true;
                    this.importMIDIsToolStripMenuItem.Enabled = true;
                    this.removeSelectedMIDIsToolStripMenuItem.Enabled = true;
                    this.clearMIDIsListToolStripMenuItem.Enabled = true;
                    this.startRenderingWAVToolStripMenuItem.Enabled = true;
                    this.startRenderingOGGToolStripMenuItem.Enabled = true;
                    this.playInRealtimeBetaToolStripMenuItem.Enabled = true;
                    this.abortRenderingToolStripMenuItem.Enabled = false;
                    this.trackBar1.Enabled = true;
                    this.loadSoundfontToolStripMenuItem.Enabled = true;
                    this.unloadSoundfontToolStripMenuItem.Enabled = true;
                    this.labelRMS.Text = Globals.CurrentPeak;
                }
                else if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    if (Globals.CurrentStatusTextString == null)
                    {
                        if (Environment.OSVersion.Version.Major == 5)
                        {

                        }
                        else
                        {
                            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                        }
                        if (Globals.PlaybackMode == true)
                        {

                        }
                        else
                        {
                            this.SettingsBox.Enabled = false;
                            this.trackBar1.Enabled = false;
                        }
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        this.CurrentStatusText.Text = "Preparing for export/benchmark.\nPlease wait...";
                        this.UsedVoices.Text = "Voices: " + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.DefMenu.Enabled = false;
                        this.loadingpic.Visible = true;
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.loadSoundfontToolStripMenuItem.Enabled = false;
                        this.unloadSoundfontToolStripMenuItem.Enabled = false;
                        this.labelRMS.Text = Globals.CurrentPeak;
                    }
                    else
                    {
                        if (Environment.OSVersion.Version.Major == 5)
                        {

                        }
                        else
                        {
                           TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                           TaskbarManager.Instance.SetProgressValue(Globals.CurrentStatusValueInt, Globals.CurrentStatusMaximumInt);
                        }
                        if (Globals.PlaybackMode == true)
                        {

                        }
                        else
                        {
                            this.SettingsBox.Enabled = false;
                            this.trackBar1.Enabled = false;
                        }
                        this.CurrentStatusText.Text = Globals.CurrentStatusTextString;
                        this.UsedVoices.Text = "Voices: " + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        this.DefMenu.Enabled = false;
                        this.loadingpic.Visible = true;
                        this.CurrentStatus.Value = Globals.CurrentStatusValueInt;
                        this.CurrentStatus.Maximum = Globals.CurrentStatusMaximumInt;
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
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
            }
            catch
            {
            }
        }

        private void startRenderingWAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            string dummyFileName = "Save Here";
            this.ExportWhere.FileName = dummyFileName;
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                this.ConverterWAV.RunWorkerAsync();
            }
        }

        private void startRenderingOGGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            string dummyFileName = "Save Here";
            this.ExportWhere.FileName = dummyFileName;
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                this.ConverterOGG.RunWorkerAsync();
            }
        }

        private void playInRealtimeBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            this.RealTimePlayBack.RunWorkerAsync();
        }

        private void unloadSoundfontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BassMidi.BASS_MIDI_FontUnload(Globals.DefaultSoundfont, -1, -1);
            Globals.SFName = null;
            Globals.SFLittleName = null;
            this.label2.Text = "Font unloaded.\nLoad a soundfont first\nto see its informations here.";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("volume", trackBar1.Value.ToString(), Microsoft.Win32.RegistryValueKind.DWord);
                Globals.Volume = Convert.ToInt32(this.trackBar1.Value);
                Settings.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VoiceLimit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("voices", VoiceLimit.Value.ToString(), Microsoft.Win32.RegistryValueKind.DWord);
                Globals.LimitVoicesInt = Convert.ToInt32(VoiceLimit.Value.ToString());
                Settings.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdvSettingsButton_Click(object sender, EventArgs e)
        {
            Globals.frm.ShowDialog();
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = true;
            disabledToolStripMenuItem.Checked = false;
            Globals.AutoShutDownEnabled = true;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = true;
            Globals.AutoShutDownEnabled = false;
        }
    }
}
