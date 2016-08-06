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
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass.AddOn.Midi;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KeppySpartanMIDIConverter
{
    public partial class MainWindow : Form
    {
        public MainWindow(String[] args)
        {          
            InitializeComponent();
            //To store all the soundfonts that where opened with the application
            List<String> soundfonts = null;
            //Parse through arguments
            foreach (String s in args)
            {
                //Find out is the current argument is a file path/name
                if (File.Exists(s))
                {
                    //Find out it the current file is a MIDI
                    if (s.EndsWith(".mid") | s.EndsWith(".midi") | s.EndsWith(".kar") | s.EndsWith(".rmi") | s.EndsWith(".MID") | s.EndsWith(".MIDI") | s.EndsWith(".KAR") | s.EndsWith(".RMI"))
                    {
                        //Add MIDI to midi list
                        this.MIDIList.Items.Add(s);
                    }
                    //If the file isnt a MIDI, check if its a soundfont
                    if (s.EndsWith(".sf2") | s.EndsWith(".sf3") | s.EndsWith(".sfpack") | s.EndsWith(".sfz") | s.EndsWith(".SF2") | s.EndsWith(".SF3") | s.EndsWith(".SFPACK") | s.EndsWith(".SFZ"))
                    {
                        //There are soundfonts beeing added to the application so create the list
                        if (soundfonts == null)
                        {
                            soundfonts = new List<String>();
                        }
                        soundfonts.Add(s);
                    }
                }
            }
            //Check if there are soundfonts
            if(soundfonts != null)
            {
                //
                Globals.Soundfonts = new string[soundfonts.Count];
                soundfonts.CopyTo(Globals.Soundfonts, 0);
                foreach(String s in soundfonts)
                {
                    Globals.frm2.SFList.Items.Add(s);
                }
            }
        }

        Timer t1 = new Timer();
        Timer t2 = new Timer();

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool enabled);

        public static class Globals
        {
            public static AdvancedSettings frm = new AdvancedSettings();
            public static DSPPROC _myDSP;
            public static KeppyMIDIConverter.SoundfontDialog frm2 = new KeppyMIDIConverter.SoundfontDialog();
            public static Un4seen.Bass.Misc.DSP_PeakLevelMeter _plm;
            public static bool AutoClearMIDIListEnabled = false;
            public static bool AutoShutDownEnabled = false;
            public static bool FXDisabled = true;
            public static bool NoteOff1Event = false;
            public static bool OldTimeThingy = false;
            public static bool PlaybackMode = false;
            public static bool QualityOverride = false;
            public static bool RenderingMode = false;
            public static bool TempoOverride = false;
            public static bool VSTMode = false;
            public static int ActiveVoicesInt = 0;
            public static int AverageCPU;
            public static int Bitrate = 128;
            public static int CancellationPendingValue = 0;
            public static int CurrentEncoder;
            public static int CurrentMode;
            public static int CurrentStatusMaximumInt;
            public static int CurrentStatusValueInt;
            public static int DefaultSoundfont;
            public static int FinalTempo = 120;
            public static int Frequency = 0xbb80;
            public static int LimitVoicesInt = 0x186a0;
            public static int OriginalTempo;
            public static int SoundFont;
            public static int Time = 0;
            public static int Volume;
            public static int _Encoder;
            public static int _recHandle;
            public static int _Mixer;
            public static int _VSTHandle;
            public static int _VSTHandle2;
            public static int _VSTHandle3;
            public static int _VSTHandle4;
            public static int _VSTHandle5;
            public static int _VSTHandle6;
            public static int _VSTHandle7;
            public static int _VSTHandle8;
            public static string BenchmarkTime;
            public static string CurrentPeak = "Root mean square: N/A dB | Average: N/A dB | Peak: N/A dB";
            public static string CurrentStatusTextString;
            public static string DisabledOr;
            public static string ExportLastDirectory;
            public static string ExportWhereYay;
            public static string MIDILastDirectory;
            public static string MIDIName;
            public static string NewWindowName = null;
            public static string VSTDLL = null;
            public static string VSTDLL2 = null;
            public static string VSTDLL3 = null;
            public static string VSTDLL4 = null;
            public static string VSTDLL5 = null;
            public static string VSTDLL6 = null;
            public static string VSTDLL7 = null;
            public static string VSTDLL8 = null;
            public static string VSTDLLDesc = null;
            public static string VSTDLLDesc2 = null;
            public static string VSTDLLDesc3 = null;
            public static string VSTDLLDesc4 = null;
            public static string VSTDLLDesc5 = null;
            public static string VSTDLLDesc6 = null;
            public static string VSTDLLDesc7 = null;
            public static string VSTDLLDesc8 = null;
            public static string WAVName;
            public static string[] Soundfonts = { null };

            // Other
            public static string ExecutablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
                BassNet.Registration("kaleidonkep99@outlook.com", "2X203132524822");
                // Fade in ;)
                t1.Interval = 10;  //we'll increase the opacity every 10ms
                t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
                t1.Start(); 
                // Fade in ;)
                if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 0)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Windows 2000 is not supported", "The converter requires Windows XP or newer to run.\nWindows 2000 and older are NOT supported.\n\nPress OK to quit.", 1, 0);
                    errordialog.ShowDialog();
                    this.Hide();
                    Application.ExitThread();
                }
                else
                {
                    try
                    {
                        Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                        Globals._plm.CalcRMS = true;
                    }
                    catch (Exception exception2)
                    {
                        Opacity = 1.00;
                        KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception2.ToString(), 1, 0);
                        errordialog.ShowDialog();
                    }
                    try
                    {
                        using (RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter"))
                            if (Key != null)
                            {
                                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                                try
                                {      
                                    // Generic settings
                                    VoiceLimit.Value = Convert.ToInt32(Settings.GetValue("voices"));
                                    VolumeBar.Value = Convert.ToInt32(Settings.GetValue("volume"));
                                    Globals.Volume = Convert.ToInt32(Settings.GetValue("volume"));
                                    Globals.Frequency = Convert.ToInt32(Settings.GetValue("audiofreq"));
                                    Globals.Bitrate = Convert.ToInt32(Settings.GetValue("oggbitrate"));
                                    // Audio events
                                    if (Convert.ToInt32(Settings.GetValue("audioevents", 1)) == 1)
                                    {
                                        enabledToolStripMenuItem4.Checked = true;
                                        disabledToolStripMenuItem4.Checked = false;
                                        Settings.SetValue("audioevents", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        enabledToolStripMenuItem4.Checked = false;
                                        disabledToolStripMenuItem4.Checked = true;
                                        Settings.SetValue("audioevents", "0", RegistryValueKind.DWord);
                                    }
                                    // Autoupdate lel
                                    if (Convert.ToInt32(Settings.GetValue("autoupdatecheck", 1)) == 1)
                                    {
                                        enabledToolStripMenuItem3.Checked = true;
                                        disabledToolStripMenuItem3.Checked = false;
                                        Settings.SetValue("autoupdatecheck", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        enabledToolStripMenuItem3.Checked = false;
                                        disabledToolStripMenuItem3.Checked = true;
                                        Settings.SetValue("autoupdatecheck", "0", RegistryValueKind.DWord);
                                    }
                                    // Old time thingy for TheGhastModding lel
                                    if (Convert.ToInt32(Settings.GetValue("oldtimethingy", 0)) == 1)
                                    {
                                        enabledToolStripMenuItem2.Checked = true;
                                        disabledToolStripMenuItem2.Checked = false;
                                        Globals.OldTimeThingy = true;
                                        Settings.SetValue("oldtimethingy", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        enabledToolStripMenuItem2.Checked = false;
                                        disabledToolStripMenuItem2.Checked = true;
                                        Globals.OldTimeThingy = false;
                                        Settings.SetValue("oldtimethingy", "0", RegistryValueKind.DWord);
                                    }
                                    // Note off setting
                                    if (Convert.ToInt32(Settings.GetValue("noteoff1", 0)) == 1)
                                    {
                                        Globals.NoteOff1Event = true;
                                        Settings.SetValue("noteoff1", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        Globals.NoteOff1Event = false;
                                        Settings.SetValue("noteoff1", "0", RegistryValueKind.DWord);
                                    }
                                    // BASS default sound effects (Reverb and chorus)
                                    if (Convert.ToInt32(Settings.GetValue("disablefx", 0)) == 1)
                                    {
                                        Globals.FXDisabled = true;
                                        Settings.SetValue("disablefx", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        Globals.FXDisabled = false;
                                        Settings.SetValue("disablefx", "0", RegistryValueKind.DWord);
                                    }
                                    // OGG bitrate override
                                    if (Convert.ToInt32(Settings.GetValue("overrideogg", 0)) == 1)
                                    {
                                        Globals.QualityOverride = true;
                                        Settings.SetValue("overrideogg", "1", RegistryValueKind.DWord);
                                    }
                                    else
                                    {
                                        Globals.QualityOverride = false;
                                        Settings.SetValue("overrideogg", "0", RegistryValueKind.DWord);
                                    }
                                    Globals.MIDILastDirectory = Settings.GetValue("lastmidifolder", "").ToString();
                                    Globals.ExportLastDirectory = Settings.GetValue("lastexportfolder", "").ToString();
                                    Settings.Close();
                                }
                                catch (Exception exception)
                                {
                                    MessageBox.Show(exception.Message.ToString(), "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Fatal error", exception.Message.ToString(), 1, 0);
                                    errordialog.ShowDialog();
                                    Settings.Close();
                                }
                            }
                            else if (Key == null)
                            {
                                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings");
                                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                                VoiceLimit.Value = 100000;
                                Settings.SetValue("voices", "100000", RegistryValueKind.DWord);
                                Settings.SetValue("lastmidifolder", "", RegistryValueKind.String);
                                Settings.SetValue("lastsffolder", "", RegistryValueKind.String);
                                Settings.SetValue("lastexportfolder", "", RegistryValueKind.String);
                                Settings.SetValue("audioevents", "1", RegistryValueKind.DWord);
                                Settings.SetValue("autoupdatecheck", "1", RegistryValueKind.DWord);
                                Settings.SetValue("oldtimethingy", "0", RegistryValueKind.DWord);
                                Settings.SetValue("noteoff1", "0", RegistryValueKind.DWord);
                                Settings.SetValue("disablefx", "0", RegistryValueKind.DWord);
                                Settings.SetValue("maxcpu", "0", RegistryValueKind.DWord);
                                Settings.SetValue("audiofreq", "44100", RegistryValueKind.DWord);
                                Settings.SetValue("volume", "10000", RegistryValueKind.DWord);
                                Settings.Close();
                            }
                        Console.WriteLine("Settings loaded.");
                    }
                    catch (Exception exception2)
                    {
                        KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception2.ToString(), 0, 0);
                        errordialog.ShowDialog();
                    }
                    Globals.AutoShutDownEnabled = false;
                    Globals.AutoClearMIDIListEnabled = false;
            }
        }

        private void startRenderingWAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.RenderingMode = true;
            this.loadingpic.Visible = true;
            string dummyFileName = "Save Here";
            this.ExportWhere.FileName = dummyFileName;
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            Globals.CurrentStatusTextString = null;
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.CurrentStatusTextString = null;
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                this.ConverterWAV.RunWorkerAsync();
            }
            else
            {
                Globals.RenderingMode = false;
                this.loadingpic.Visible = false;
            }
        }


        private void startRenderingOGGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.RenderingMode = true;
            this.loadingpic.Visible = true;
            string dummyFileName = "Save Here";
            this.ExportWhere.FileName = dummyFileName;
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.CurrentStatusTextString = null;
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                this.ConverterOGG.RunWorkerAsync();
            }
            else
            {
                Globals.RenderingMode = false;
                this.loadingpic.Visible = false;
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

        private void BASSInitSystem()
        {
            Bass.BASS_StreamFree(Globals._recHandle);
            Bass.BASS_Free();
            Un4seen.Bass.Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
        }

        private void BASSVSTInit()
        {
            if (Globals.VSTMode == true)
            {
                Globals._VSTHandle = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL, BASSVSTDsp.BASS_VST_DEFAULT, 8);
                Globals._VSTHandle2 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL2, BASSVSTDsp.BASS_VST_DEFAULT, 7);
                Globals._VSTHandle3 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL3, BASSVSTDsp.BASS_VST_DEFAULT, 6);
                Globals._VSTHandle4 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL4, BASSVSTDsp.BASS_VST_DEFAULT, 5);
                Globals._VSTHandle5 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL5, BASSVSTDsp.BASS_VST_DEFAULT, 4);
                Globals._VSTHandle6 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL6, BASSVSTDsp.BASS_VST_DEFAULT, 3);
                Globals._VSTHandle7 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL7, BASSVSTDsp.BASS_VST_DEFAULT, 2);
                Globals._VSTHandle8 = BassVst.BASS_VST_ChannelSetDSP(Globals._recHandle, Globals.VSTDLL8, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle2, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle2, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle3, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle3, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle4, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle4, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle5, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle5, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle6, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle6, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle7, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle7, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle8, vstInfo) && vstInfo.hasEditor)
                {
                    Form f = new Form();
                    f.Width = vstInfo.editorWidth + 4;
                    f.Height = vstInfo.editorHeight + 34;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.Text = "Change VST DSP settings: " + vstInfo.effectName;
                    f.Closing += new CancelEventHandler(f_Closing);
                    BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle8, f.Handle);
                    var dialogResult2 = f.ShowDialog();
                }
            }
        }

        private void BASSStreamSystem(String str)
        {
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", false);
            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Globals.LimitVoicesInt);
            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 0);
            if (Path.GetFileNameWithoutExtension(str).Length >= 49)
            {
                Globals.NewWindowName = "Keppy's MIDI Converter | Exporting \"" + Path.GetFileNameWithoutExtension(str).Truncate(49) + "...\"...";
            }
            else
            {
                Globals.NewWindowName = "Keppy's MIDI Converter | Exporting \"" + Path.GetFileNameWithoutExtension(str) + "\"...";
            }
            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
            Globals._plm.CalcRMS = true;
            BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[Globals.Soundfonts.Length];
            int sfnum = 0;
            foreach (string s in Globals.Soundfonts)
            {
                fonts[sfnum].font = BassMidi.BASS_MIDI_FontInit(s);
                fonts[sfnum].preset = -1;
                fonts[sfnum].bank = 0;
                BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, sfnum + 1);
                sfnum += 1;
            }
            BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
        }

        private void BASSEffectSettings()
        {
            if (Globals.FXDisabled == true)
            {
                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
            }
            else
            {
                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOFX);
            }
            if (Globals.NoteOff1Event == true)
            {
                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
            }
            else
            {
                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOTEOFF1);
            }
        }

        private void BASSEncoderInit(Int32 format, String str)
        {
            string path;
            string audiopath = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg";
            int num3 = 1;
            if (format == 0)
            {
                if (File.Exists(Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".wav"))
                {
                    do
                    {
                        path = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").wav";
                        ++num3;
                    } while (File.Exists(path));
                    BassEnc.BASS_Encode_Stop(Globals._recHandle);
                    Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, path, BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                }
                else
                {
                    BassEnc.BASS_Encode_Stop(Globals._recHandle);
                    Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".wav", BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                }
            }
            else if (format == 1)
            {
                if (File.Exists(audiopath))
                {
                    do
                    {
                        if (Globals.QualityOverride == true)
                        {
                            path = "kmcogg -m" + Globals.Bitrate.ToString() + " -M" + Globals.Bitrate.ToString() + " - -o \"" + Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg\"";
                            audiopath = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg";
                        }
                        else
                        {
                            path = "kmcogg - -o \"" + Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg\"";
                            audiopath = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg";
                        }
                        ++num3;
                    } while (File.Exists(audiopath));
                    foreach (Process proc in Process.GetProcessesByName("kmcogg"))
                    {
                        proc.Kill();
                    }
                    BassEnc.BASS_Encode_Stop(Globals._recHandle);
                    Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, path, BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                }
                else
                {
                    if (Globals.QualityOverride == true)
                    {
                        foreach (Process proc in Process.GetProcessesByName("kmcogg"))
                        {
                            proc.Kill();
                        }
                        BassEnc.BASS_Encode_Stop(Globals._recHandle);
                        Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, "kmcogg -m" + Globals.Bitrate.ToString() + " -M" + Globals.Bitrate.ToString() + " - -o \"" + Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg\"", BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                    }
                    else
                    {
                        foreach (Process proc in Process.GetProcessesByName("kmcogg"))
                        {
                            proc.Kill();
                        }
                        BassEnc.BASS_Encode_Stop(Globals._recHandle);
                        Globals._Encoder = BassEnc.BASS_Encode_Start(Globals._recHandle, "kmcogg - -o \"" + Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg\"", BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                    }
                }
            }
        }

        private void BASSEncodingEngine(DateTime starttime)
        {
            TimeSpan timespent = DateTime.Now - starttime;
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
            Globals.ActiveVoicesInt = Convert.ToInt32(num11);
            Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
            Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
            int secondsremaining = (int)(timespent.TotalSeconds / (int)num6 * ((int)pos - (int)num6));
            TimeSpan span3 = TimeSpan.FromSeconds(secondsremaining);
            string str6 = span3.Hours.ToString().PadLeft(2, '0') + ":" + span3.Minutes.ToString().PadLeft(2, '0') + ":" + span3.Seconds.ToString().PadLeft(2, '0');
            string str7 = timespent.Hours.ToString().PadLeft(2, '0') + ":" + timespent.Minutes.ToString().PadLeft(2, '0') + ":" + timespent.Seconds.ToString().PadLeft(2, '0');
            float percentage = num8 / num7;
            float percentagefinal;
            if (percentage * 100 < 0)
                percentagefinal = 0.0f;
            else if (percentage * 100 > 100)
                percentagefinal = 1.0f;
            else
                percentagefinal = percentage;
            float[] buffer = new float[length / 4];
            if (MainWindow.Globals.TempoOverride == true)
            {
                BassMidi.BASS_MIDI_StreamEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_NOTE, Globals.FinalTempo);
            }
            else
            {
                // NULL
            }

            if (Globals.VSTMode == true)
            {
                int r = Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
                r = Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._VSTHandle, buffer, length);
            }
            else
            {
                Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);
            }

            if (num12 < 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nApproximate time left: " + str6.ToString() + " - Time elapsed: " + str7.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(100f / num12)).ToString("0.0") + "x~ more faster)";
                else
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(100f / num12)).ToString("0.0") + "x~ more faster)";
            }
            else if (num12 == 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nApproximate time left: " + str6.ToString() + " - Time elapsed: " + str7.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "%";
                else
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "%";
            }
            else if (num12 > 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nApproximate time left: " + str6.ToString() + " - Time elapsed: " + str7.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(num12 / 100f)).ToString("0.0") + "x~ more slower)";
                else
                    Globals.CurrentStatusTextString = num8.ToString("0.00") + "MBs of RAW samples converted. (" + percentagefinal.ToString("0.0%") + ")\nCurrent position: " + str5.ToString() + " - " + str4.ToString() + "\nRendering time: " + Convert.ToInt32(num12).ToString() + "% (" + ((float)(num12 / 100f)).ToString("0.0") + "x~ more slower)";
            }
            Globals.CurrentPeak = String.Format("Root mean square: {0:#00.0} dB | Average: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
            Console.WriteLine("Current position: " + str5.ToString() + " - " + str4.ToString());
        }

        private void clearMIDIsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void clearMIDIsListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void ConverterOGG_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayConversionStart();
            try
            {
                if (Globals.Soundfonts[0] == null)
                {
                    throw new Exception("Please select at least one soundfont.");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list.");
                }
                try
                {
                    Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", false);
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSInitSystem();
                            BASSStreamSystem(str);
                            BASSVSTInit();
                            BASSEffectSettings();
                            BASSEncoderInit(1, str);
                            DateTime starttime = DateTime.Now;
                            while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    BASSEncodingEngine(starttime);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                    Bass.BASS_StreamFree(Globals._recHandle);
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
                                Globals.RenderingMode = false;
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
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Conversion aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.RenderingMode = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                PlayConversionStop();
                            }
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.RenderingMode = false;
                            if (Globals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            if (Globals.AutoClearMIDIListEnabled == true)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MIDIList.Items.Clear();
                                });
                            }
                            else
                            {
                                if (Environment.OSVersion.Version.Major == 5)
                                {
                                    MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    PlayConversionStop();
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                    Bass.BASS_StreamFree(Globals._recHandle);
                    Bass.BASS_Free();
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    Globals.RenderingMode = false;
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 1);
                    errordialog.ShowDialog();
                }
            }
            catch (Exception exception2)
            {
                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                Bass.BASS_StreamFree(Globals._recHandle);
                Bass.BASS_Free();
                Globals.NewWindowName = "Keppy's MIDI Converter";
                Globals.RenderingMode = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception2.ToString(), 0, 1);
                errordialog.ShowDialog();
            }
        }

        private void ConverterWAV_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayConversionStart();
            try
            {
                if (Globals.Soundfonts[0] == null)
                {
                    throw new Exception("Please select at least one soundfont.");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list.");
                }
                try
                {
                    Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", false);
                    bool KeepLooping = true;
                    while (KeepLooping) 
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSInitSystem();
                            BASSStreamSystem(str);
                            BASSEncoderInit(0, str);
                            BASSVSTInit();
                            BASSEffectSettings();
                            DateTime starttime = DateTime.Now;
                            while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    BASSEncodingEngine(starttime);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                    Bass.BASS_StreamFree(Globals._recHandle);
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
                                Globals.RenderingMode = false;
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
                            Bass.BASS_Free();
  
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Conversion aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.RenderingMode = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                PlayConversionStop();
                            } 
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.RenderingMode = false;
                            if (Globals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            if (Globals.AutoClearMIDIListEnabled == true)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MIDIList.Items.Clear();
                                });
                            }
                            else
                            {
                                if (Environment.OSVersion.Version.Major == 5)
                                {
                                    MessageBox.Show("Conversion finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    PlayConversionStop();
                                }
                            }
                        }
                    }     
                }
                catch (Exception exception)
                {
                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                    Bass.BASS_StreamFree(Globals._recHandle);
                    Bass.BASS_Free();
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    Globals.RenderingMode = false;
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 1);
                    errordialog.ShowDialog();
                }
            }
            catch (Exception exception2)
            {
                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                Bass.BASS_StreamFree(Globals._recHandle);
                Bass.BASS_Free();
                Globals.NewWindowName = "Keppy's MIDI Converter";
                Globals.RenderingMode = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception2.ToString(), 0, 1);
                errordialog.ShowDialog();
            }
        }

        private void RealTimePlayBackBeta_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayConversionStart();
            try
            {
                if (Globals.Soundfonts[0] == null)
                {
                    throw new Exception("Please select at least one soundfont.");
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception("No MIDIs in the conversion list.");
                }
                try
                {
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            Bass.BASS_Init(-1, Globals.Frequency, BASSInit.BASS_DEVICE_LATENCY, IntPtr.Zero);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATEPERIOD, 0);
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, 32);
                            BASS_INFO info = Bass.BASS_GetInfo();
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_BUFFER, info.minbuf + 10);
                            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
                            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
                            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                            Un4seen.Bass.Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 85);
                            Globals.NewWindowName = "Keppy's MIDI Converter | Playing \"" + Path.GetFileNameWithoutExtension(str) + "\"...";
                            BASSVSTInit();
                            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
                            Globals._plm.CalcRMS = true;
                                BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[Globals.Soundfonts.Length];
                                int sfnum = 0;
                                foreach (string s in Globals.Soundfonts)
                                {
                                    fonts[sfnum].font = BassMidi.BASS_MIDI_FontInit(s);
                                    fonts[sfnum].preset = -1;
                                    fonts[sfnum].bank = 0;
                                    BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, sfnum + 1);
                                    sfnum += 1;
                                }
                                BassMidi.BASS_MIDI_StreamLoadSamples(Globals._recHandle);
                            if (Globals.FXDisabled == true)
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
                            }
                            else
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOFX);
                            }
                            if (Globals.NoteOff1Event == true)
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                            }
                            else
                            {
                                Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOTEOFF1);
                            }
                            Bass.BASS_ChannelPlay(Globals._recHandle, false);
                            int tempo = BassMidi.BASS_MIDI_StreamGetEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO);
                            Globals.OriginalTempo = 60000000 / tempo;
                            while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (Globals.CancellationPendingValue != 1)
                                { 
                                    if (MainWindow.Globals.TempoOverride == true)
                                    {
                                        BassMidi.BASS_MIDI_StreamEvent(Globals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO, 60000000 / Globals.FinalTempo);
                                    }
                                    else
                                    {
                                        // NULL
                                    }
                                    if (Globals.FXDisabled == true)
                                    {
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
                                    }
                                    else
                                    {
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOFX);
                                    }
                                    if (Globals.NoteOff1Event == true)
                                    {
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
                                    }
                                    else
                                    {
                                        Un4seen.Bass.Bass.BASS_ChannelFlags(Globals._recHandle, 0, BASSFlag.BASS_MIDI_NOTEOFF1);
                                    }
                                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, Convert.ToInt32(Globals.Volume));
                                    Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
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
                                    Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref num11);
                                    Globals.CurrentStatusTextString = num8.ToString("0.0") + "MBs of RAW datas played.\nCurrent position: " + str5.ToString() + " - " + str4.ToString();
                                    Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                                    Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                                    Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                                    Globals.CurrentPeak = String.Format("Root mean square: {0:#00.0} dB | Average: {1:#00.0} dB | Peak: {2:#00.0} dB", Globals._plm.RMS_dBV, Globals._plm.AVG_dBV, Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                                    Bass.BASS_ChannelUpdate(Globals._recHandle, 0);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                    Bass.BASS_StreamFree(Globals._recHandle);
                                    Bass.BASS_Free();
                                    Globals.CurrentStatusTextString = "Conversion aborted.";
                                    Globals.ActiveVoicesInt = 0;
                                    Globals.NewWindowName = "Keppy's MIDI Converter";
                                    MessageBox.Show("Playback aborted.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    Globals.CurrentStatusTextString = null;
                                    KeepLooping = false;
                                    break;
                                    Globals.PlaybackMode = false;
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
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = "Playback aborted.";
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.PlaybackMode = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Playback finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                PlayConversionStop();
                            }     
                        }
                        else
                        {
                            BassEnc.BASS_Encode_Stop(Globals._Encoder);
                            Bass.BASS_StreamFree(Globals._recHandle);
                            Bass.BASS_Free();
                            Globals.CancellationPendingValue = 0;
                            Globals.ActiveVoicesInt = 0;
                            Globals.CurrentStatusTextString = null;
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.PlaybackMode = false;
                            if (Environment.OSVersion.Version.Major == 5)
                            {
                                MessageBox.Show("Playback finished!\n\nBASS message:" + Bass.BASS_ErrorGetCode().ToString(), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                PlayConversionStop();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                    Bass.BASS_StreamFree(Globals._recHandle);
                    Bass.BASS_Free();
                    Globals.NewWindowName = "Keppy's MIDI Converter";
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 1);
                    errordialog.ShowDialog();
                    Globals.PlaybackMode = false;
                }
            }
            catch (Exception exception2)
            {
                BassEnc.BASS_Encode_Stop(Globals._Encoder);
                Bass.BASS_StreamFree(Globals._recHandle);
                Bass.BASS_Free();
                Globals.NewWindowName = "Keppy's MIDI Converter";
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception2.ToString(), 0, 1);
                errordialog.ShowDialog();
                Globals.PlaybackMode = false;
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

        public bool AeroEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
                return false;
            bool Enabled = false;
            DwmIsCompositionEnabled(out Enabled);
            return Enabled;
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                if (AeroEnabled() == true) {
                    Opacity += 0.015;
                }
                else
                {
                    Opacity += 0.05;
                }      
        }

        void fadeOut(object sender, EventArgs e)
        {
            if (Opacity == 0)     //check if opacity is 0
            {
                t2.Stop();    //if it is, we stop the timer
                Process.GetCurrentProcess().Kill();  
            }
            else
                Opacity -= 0.05;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) Process.GetCurrentProcess().Kill();

            // Confirm user wants to close
            if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show("The converter is still busy doing a job!\n\nAre you sure you want to exit?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                e.Cancel = true;    //cancel the event so the form won't be closed
                t2.Interval = 10;  //we'll increase the opacity every 10ms
                t2.Tick += new EventHandler(fadeOut);  //this calls the function that changes opacity 
                t2.Start();  
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show("The converter is still busy doing a job!\n\nAre you sure you want to exit?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                t2.Interval = 10;  //we'll increase the opacity every 10ms
                t2.Tick += new EventHandler(fadeOut);  //this calls the function that changes opacity 
                t2.Start();  
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

        private void MIDIList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                if (Globals.RenderingMode == true | Globals.PlaybackMode == true)
                {
                    MessageBox.Show("You cannot add nor remove MIDI files from the list, while the converter is converting/playing them!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Path.GetExtension(s[i]) == ".mid" | Path.GetExtension(s[i]) == ".midi" | Path.GetExtension(s[i]) == ".kar" | Path.GetExtension(s[i]) == ".rmi" | Path.GetExtension(s[i]) == ".MID" | Path.GetExtension(s[i]) == ".MIDI" | Path.GetExtension(s[i]) == ".KAR" | Path.GetExtension(s[i]) == ".RMI")
                    {
                        MIDIList.Items.Add(s[i]);
                    }
                    else
                    {
                        MessageBox.Show(Path.GetFileName(s[i]) + " is not a valid MIDI file!\n\nPlease drop a valid MIDI file inside the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
        }

        private void MIDIList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MIDIList_KeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (Globals.RenderingMode == true | Globals.PlaybackMode == true)
                {
                    MessageBox.Show("Can not edit the list while the converter is busy!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (e.KeyValue == (char)Keys.Delete)
                    {
                        for (int i = this.MIDIList.SelectedIndices.Count - 1; i >= 0; i--)
                        {
                            this.MIDIList.Items.RemoveAt(this.MIDIList.SelectedIndices[i]);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public bool SelectItem(ListBox listBox, string item)
        {
            bool contains = listBox.Items.Contains(item);
            if (!contains)
                return false;
            listBox.SelectedItem = item;
            return listBox.SelectedItems.Contains(item);
        }

        private void RenderingTimer_Tick(object sender, EventArgs e)
        {
            MIDIImport.InitialDirectory = Globals.MIDILastDirectory;
            ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            if (!Globals.AutoShutDownEnabled)
            {
                Globals.AutoShutDownEnabled = false;
                disabledToolStripMenuItem.Checked = true;
            }
            if (!Globals.AutoClearMIDIListEnabled)
            {
                Globals.AutoClearMIDIListEnabled = false;
                disabledToolStripMenuItem1.Checked = true;
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
                    if (Globals.PlaybackMode == true)
                    {
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        this.CurrentStatusText.Text = "The converter is allocating memory for the playback.\nPlease wait...";
                        this.UsedVoices.Text = "Voices: " + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        this.DefMenu.Enabled = false;
                        this.loadingpic.Visible = false;
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = Globals.CurrentPeak;
                        this.SettingsBox.Enabled = true;
                        this.label3.Enabled = true;
                        this.VolumeBar.Enabled = true;
                        this.VoiceLimit.Maximum = 2000;
                        this.CurrentStatusText.Size = new Size(488, 60);
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
                    }
                    else if (Globals.RenderingMode == true)
                    {
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        this.CurrentStatusText.Text = "The converter is allocating memory for the conversion process.\nPlease wait...";
                        this.UsedVoices.Text = "Voices: " + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        this.DefMenu.Enabled = false;
                        this.loadingpic.Visible = false;
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = Globals.CurrentPeak;
                        this.SettingsBox.Enabled = false;
                        this.label3.Enabled = false;
                        this.VolumeBar.Enabled = false;
                        this.VoiceLimit.Maximum = 100000;
                        this.CurrentStatusText.Size = new Size(488, 60);
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
                    }
                    else if (Globals.RenderingMode == false & Globals.PlaybackMode == false)
                    {
                        this.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        this.CurrentStatus.Maximum = 999;
                        this.CurrentStatus.Value = 0;
                        this.CurrentStatusText.Text = "Idle.\nSelect a MIDI, and load your soundfonts to start the conversion/playback!";
                        this.UsedVoices.Text = @"Voices: 0/" + Globals.LimitVoicesInt.ToString();
                        this.MIDIList.Enabled = true;
                        this.DefMenu.Enabled = true;
                        this.loadingpic.Visible = false;
                        this.importMIDIsToolStripMenuItem.Enabled = true;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = true;
                        this.clearMIDIsListToolStripMenuItem.Enabled = true;
                        this.startRenderingWAVToolStripMenuItem.Enabled = true;
                        this.startRenderingOGGToolStripMenuItem.Enabled = true;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = true;
                        this.abortRenderingToolStripMenuItem.Enabled = false;
                        this.labelRMS.Text = Globals.CurrentPeak;
                        this.SettingsBox.Enabled = true;
                        this.label3.Enabled = false;
                        this.VolumeBar.Enabled = false;
                        this.VoiceLimit.Maximum = 100000;
                        this.CurrentStatusText.Size = new Size(488, 60);
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.Idle;
                    }

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
                            this.SettingsBox.Enabled = true;
                            this.label3.Enabled = true;
                            this.VolumeBar.Enabled = true;
                            this.VoiceLimit.Maximum = 2000;
                        }
                        else
                        {
                            this.SettingsBox.Enabled = false;
                            this.label3.Enabled = false;
                            this.VolumeBar.Enabled = false;
                            this.VoiceLimit.Maximum = 100000;
                        }
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        if (Globals.VSTMode == true)
                        {
                            this.CurrentStatusText.Text = "The BASS engine is being prepared for the process.\nSet the VST DSP up when its dialog appears.\nPlease wait...";
                        }
                        else
                        {
                            this.CurrentStatusText.Text = "The BASS engine is being prepared for the process.\nPlease wait...";
                        }
                        this.UsedVoices.Text = "Voices: " + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        this.DefMenu.Enabled = false;
                        this.loadingpic.Visible = true;
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = Globals.CurrentPeak;
                        this.CurrentStatusText.Size = new Size(425, 60);
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
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
                            this.SettingsBox.Enabled = true;
                            this.VolumeBar.Enabled = true;
                            this.VoiceLimit.Maximum = 2000;
                        }
                        else
                        {
                            this.SettingsBox.Enabled = false;
                            this.VolumeBar.Enabled = false;
                            this.VoiceLimit.Maximum = 100000;
                        }
                        this.MIDIList.Enabled = false;
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
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = Globals.CurrentPeak;
                        this.CurrentStatusText.Size = new Size(425, 60);
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
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

        private void playInRealtimeBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadingpic.Visible = true;
            Globals.PlaybackMode = true;
            this.RealTimePlayBack.RunWorkerAsync();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("volume", VolumeBar.Value.ToString(), Microsoft.Win32.RegistryValueKind.DWord);
                Globals.Volume = Convert.ToInt32(this.VolumeBar.Value);
                Settings.Close();
                VolumeTip.SetToolTip(VolumeBar, Convert.ToString(Convert.ToInt32(Globals.Volume / 100)) + "%");
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
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
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void AdvSettingsButton_Click(object sender, EventArgs e)
        {
            Globals.frm.ShowDialog();
        }

        private void openTheSoundfontsManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.frm2.ShowDialog();
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

        private void enabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem1.Checked = true;
            disabledToolStripMenuItem1.Checked = false;
            Globals.AutoClearMIDIListEnabled = true;
        }

        private void disabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem1.Checked = false;
            disabledToolStripMenuItem1.Checked = true;
            Globals.AutoClearMIDIListEnabled = false;
        }

        private void enabledToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("audioevents", "1", RegistryValueKind.DWord);
            enabledToolStripMenuItem4.Checked = true;
            disabledToolStripMenuItem4.Checked = false;
            Settings.Close();
        }

        private void disabledToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("audioevents", "0", RegistryValueKind.DWord);
            enabledToolStripMenuItem4.Checked = false;
            disabledToolStripMenuItem4.Checked = true;
            Settings.Close();
        }

        private void enabledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("autoupdatecheck", "1", RegistryValueKind.DWord);
            enabledToolStripMenuItem3.Checked = true;
            disabledToolStripMenuItem3.Checked = false;
            Settings.Close();
        }

        private void disabledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("autoupdatecheck", "0", RegistryValueKind.DWord);
            enabledToolStripMenuItem3.Checked = false;
            disabledToolStripMenuItem3.Checked = true;
            Settings.Close();
        }

        private void enabledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem2.Checked = true;
                disabledToolStripMenuItem2.Checked = false;
                Globals.OldTimeThingy = true;
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("oldtimethingy", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Globals.LimitVoicesInt = Convert.ToInt32(VoiceLimit.Value.ToString());
                Settings.Close();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void disabledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem2.Checked = false;
                disabledToolStripMenuItem2.Checked = true;
                Globals.OldTimeThingy = false;
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Settings.SetValue("oldtimethingy", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Globals.LimitVoicesInt = Convert.ToInt32(VoiceLimit.Value.ToString());
                Settings.Close();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void makeADonationToSupportTheDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "";

            string business = "prapapappo1999@gmail.com";
            string description = "Donation";
            string country = "US";
            string currency = "USD";

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            Process.Start(url);
        }

        private void officialBlackMIDICommunityGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://plus.google.com/communities/105907289212970966669");
        }

        private void forceCloseTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to crash the converter?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.Enabled = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Fatal error!", "Fatal error on the execution of the converter!\n\nPress OK to close the program.", 1, 0);
                errordialog.ShowDialog();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
             
            }
        }

        private void PlayConversionStart()
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            if (Convert.ToInt32(Settings.GetValue("audioevents", 1)) == 1)
            {
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convstart;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.Play();
            }
            Settings.Close();
        }

        private void PlayConversionStop()
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            if (Convert.ToInt32(Settings.GetValue("audioevents", 1)) == 1)
            {
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convfin;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.Play();
            }
            Settings.Close();
        }

        private void f_Closing(object sender, CancelEventArgs e)
        {
            // unembed the VST editor
            BassVst.BASS_VST_EmbedEditor(Globals._VSTHandle, IntPtr.Zero);
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) { return value; }

            return value.Substring(0, Math.Min(value.Length, maxLength));
        }
    }

    public static class InputExtensions
    {
        public static int LimitToRange(this int value, int inclusiveMinimum, int inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }
    }
}
