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
using System.Globalization;
using System.Resources;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KeppyMIDIConverter
{
    public partial class MainWindow : Form
    {
        public static class Globals
        {
            public static AdvancedSettings frm = new AdvancedSettings();
            public static DSPPROC _myDSP;
            public static SYNCPROC _mySync;
            public static KeppyMIDIConverter.SoundfontDialog frm2 = new KeppyMIDIConverter.SoundfontDialog();
            public static Un4seen.Bass.Misc.DSP_PeakLevelMeter _plm;
            public static bool AutoClearMIDIListEnabled = false;
            public static bool AutoShutDownEnabled = false;
            public static bool DeleteEncoder = false;
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
            public static int pictureset = 1;
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
            public static string CurrentPeak = "0.0 dB";
            public static string CurrentRMS = "0.0 dB";
            public static string CurrentAverage = "0.0 dB";
            public static string CurrentStatusTextString;
            public static string DisabledOr;
            public static string EncoderPath;
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

        public MainWindow(String[] args, string encoder, bool deletencoder)
        {          
            InitializeComponent();
            InitializeLanguage();
            Globals.EncoderPath = encoder;
            Globals.DeleteEncoder = deletencoder;
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

        public static ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        public static CultureInfo cul;            // declare culture info

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool enabled);

        private void InitializeLanguage()
        {
            res_man = new ResourceManager("KeppyMIDIConverter.Languages.res", typeof(MainWindow).Assembly);
            cul = Program.ReturnCulture();
            // Translate system
            FL12Discount.Text = res_man.GetString("FLStudioDiscount", cul);
            ActionsStrip.Text = res_man.GetString("ActionsStrip", cul);
            AdvSettingsButton.Text = res_man.GetString("AdvSettingsButton", cul);
            AudioEventsStrip.Text = res_man.GetString("AudioEventsStrip", cul);
            AutoUpdatesCheckStrip.Text = res_man.GetString("AutoUpdatesCheckStrip", cul);
            AutomaticShutdownStrip.Text = res_man.GetString("AutomaticShutdownStrip", cul);
            ClearListAutomaticallyStrip.Text = res_man.GetString("ClearListAutomaticallyStrip", cul);
            ConvPosOrTimeLeft.Text = res_man.GetString("ConvPosOrTimeLeft", cul);
            HelpStrip.Text = res_man.GetString("HelpStrip", cul);
            KaleidonKep99sGitHubPageToolStripMenuItem.Text = res_man.GetString("KaleidonKep99sGitHubPage", cul);
            KaleidonKep99sYouTubeChannelToolStripMenuItem.Text = res_man.GetString("KaleidonKep99sYouTubeChannel", cul);
            MoveDownMIDIRightClick.Text = res_man.GetString("MoveDOWN", cul);
            MoveUpMIDIRightClick.Text = res_man.GetString("MoveUP", cul);
            OptionsStrip.Text = res_man.GetString("OptionsStrip", cul);
            SettingsBox.Text = res_man.GetString("SettingsBox", cul);
            VoiceLabel.Text = res_man.GetString("VoiceLabel", cul);
            abortRenderingToolStripMenuItem.Text = res_man.GetString("AbortConvPlayback", cul);
            clearMIDIsListToolStripMenuItem.Text = ClearMIDIsListRightClick.Text = res_man.GetString("ClearMIDIsList", cul);
            disabledToolStripMenuItem.Text = disabledToolStripMenuItem1.Text = disabledToolStripMenuItem2.Text = disabledToolStripMenuItem3.Text = disabledToolStripMenuItem4.Text = disabledToolStripMenuItem5.Text = res_man.GetString("DisabledText", cul);
            enabledToolStripMenuItem.Text = enabledToolStripMenuItem1.Text = enabledToolStripMenuItem2.Text = enabledToolStripMenuItem3.Text = enabledToolStripMenuItem4.Text = enabledToolStripMenuItem5.Text = res_man.GetString("EnabledText", cul);
            OverrideStrip.Text = res_man.GetString("OverrideLanguage", cul);
            exitToolStripMenuItem.Text = res_man.GetString("ExitStrip", cul);
            forceCloseTheApplicationToolStripMenuItem.Text = res_man.GetString("forceCloseTheApplicationStrip", cul);
            importMIDIsToolStripMenuItem.Text = ImportMIDIsRightClick.Text = res_man.GetString("ImportMIDI", cul);
            informationAboutTheProgramToolStripMenuItem.Text = res_man.GetString("informationAboutTheProgramStrip", cul);
            label3.Text = res_man.GetString("Volume", cul);
            openTheSoundfontsManagerToolStripMenuItem.Text = res_man.GetString("SFVSTManager", cul);
            playInRealtimeBetaToolStripMenuItem.Text = res_man.GetString("RenderToSpeakers", cul);
            removeSelectedMIDIsToolStripMenuItem.Text = RemoveMIDIsRightClick.Text = res_man.GetString("RemoveMIDI", cul);
            startRenderingOGGToolStripMenuItem.Text = res_man.GetString("RenderToOGG", cul);
            startRenderingWAVToolStripMenuItem.Text = res_man.GetString("RenderToWAV", cul);
            supportTheDeveloperWithADonationToolStripMenuItem.Text = res_man.GetString("supportTheDeveloperWithADonation", cul);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            BassNet.Registration("kaleidonkep99@outlook.com", "2X203132524822");
            this.Menu = DefaultMenu;
            MIDIList.ContextMenu = DefMenu;
            // Fade in
            t1.Interval = 10; // Increases opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  // This calls the function that changes opacity 
            t1.Start();
            // Fade in
            if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor == 1)
            {
                if (Environment.OSVersion.Version.Build == 2600)
                {
                    // Continues
                }
                else
                {
                    // If you're using Windows XP SP1 or older, the converter will close itself.
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("WinXPSP1NotSupportedTitle", cul), res_man.GetString("WinXPSP1NotSupportedMessage", cul), 1, 0);
                    errordialog.ShowDialog();
                    this.Hide();
                    Application.ExitThread();
                }
            }
            else
            {
                try
                {
                    RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter");
                    if (Key != null)
                    {
                        RegistryKey Language = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", true);
                        try
                        {
                            if (Convert.ToInt32(Language.GetValue("langoverride", 0)) == 1)
                            {
                                enabledToolStripMenuItem5.PerformClick();
                            }
                            else
                            {
                                disabledToolStripMenuItem5.PerformClick();
                            }
                        }
                        catch
                        {
                            enabledToolStripMenuItem5.Checked = false;
                            disabledToolStripMenuItem5.Checked = true;
                            Language.SetValue("langoverride", "0", RegistryValueKind.DWord);
                        }
                        RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                        try
                        {
                            // Generic settings
                            VoiceLimit.Value = Convert.ToInt32(Settings.GetValue("voices", 1000));
                            VolumeBar.Value = Convert.ToInt32(Settings.GetValue("volume", 10000));
                            Globals.Volume = Convert.ToInt32(Settings.GetValue("volume", 10000));
                            Globals.Frequency = Convert.ToInt32(Settings.GetValue("audiofreq", 44100));
                            Globals.Bitrate = Convert.ToInt32(Settings.GetValue("oggbitrate", 256));
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
                            Globals.MIDILastDirectory = Settings.GetValue("lastmidifolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
                            Globals.ExportLastDirectory = Settings.GetValue("lastexportfolder", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).ToString();
                            Settings.Close();
                        }
                        catch (Exception exception)
                        {
                            KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("FatalError", cul), exception.Message.ToString(), 1, 0);
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
                }
                catch (Exception exception2)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("Error", cul), exception2.ToString(), 0, 0);
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
            this.ExportWhere.FileName = res_man.GetString("SaveHere", cul);
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            this.ExportWhere.Title = res_man.GetString("ExportWhere", cul);
            Globals.CurrentStatusTextString = null;
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.CurrentStatusTextString = null;
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                Settings.Close();
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                Globals.CurrentEncoder = 0;
                this.ConverterProcess.RunWorkerAsync();
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
            this.ExportWhere.FileName = res_man.GetString("SaveHere", cul);
            this.ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
            this.ExportWhere.Title = res_man.GetString("ExportWhere", cul);
            if (this.ExportWhere.ShowDialog() == DialogResult.OK)
            {
                Globals.CurrentStatusTextString = null;
                Globals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                Globals.ExportLastDirectory = Path.GetDirectoryName(ExportWhere.FileName);
                Settings.SetValue("lastexportfolder", Globals.ExportLastDirectory);
                Settings.Close();
                ExportWhere.InitialDirectory = Globals.ExportLastDirectory;
                Globals.CurrentEncoder = 1;
                this.ConverterProcess.RunWorkerAsync();
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

        private void BASSInitSystem()
        {
            Bass.BASS_StreamFree(Globals._recHandle);
            Bass.BASS_Free();
            Un4seen.Bass.Bass.BASS_Init(0, Globals.Frequency, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
            Un4seen.Bass.Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
        }

        private void BASSVSTShowDialog(int towhichstream, int whichvst, BASS_VST_INFO vstInfo)
        {
            Form f = new Form();
            f.Width = vstInfo.editorWidth + 4;
            f.Height = vstInfo.editorHeight + 34;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.Text = res_man.GetString("DSPSettings", cul) + vstInfo.effectName;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
            BassVst.BASS_VST_EmbedEditor(whichvst, f.Handle);
            try
            {
                f.ShowDialog();
                BassVst.BASS_VST_EmbedEditor(whichvst, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("==== Start of Keppy's MIDI Converter Error ====");
                sb.AppendLine(ex.ToString());
                sb.AppendLine("====  End of Keppy's MIDI Converter Error  ====");
                System.Threading.Thread thread = new System.Threading.Thread(() => Clipboard.SetText(sb.ToString()));
                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();
                thread.Join();
                MessageBox.Show(String.Format(res_man.GetString("VSTInvalidCallError", cul), vstInfo.effectName, ex.Message.ToString()), "Keppy's MIDI Converter - " + res_man.GetString("VSTInvalidCallTitle", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BassVst.BASS_VST_EmbedEditor(whichvst, IntPtr.Zero);
                BassVst.BASS_VST_ChannelRemoveDSP(towhichstream, whichvst);
            }
        }

        private void BASSVSTInit(int towhichstream)
        {
            if (Globals.VSTMode == true)
            {
                Globals._VSTHandle = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                Globals._VSTHandle2 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL2, BASSVSTDsp.BASS_VST_DEFAULT, 2);
                Globals._VSTHandle3 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL3, BASSVSTDsp.BASS_VST_DEFAULT, 3);
                Globals._VSTHandle4 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL4, BASSVSTDsp.BASS_VST_DEFAULT, 4);
                Globals._VSTHandle5 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL5, BASSVSTDsp.BASS_VST_DEFAULT, 5);
                Globals._VSTHandle6 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL6, BASSVSTDsp.BASS_VST_DEFAULT, 6);
                Globals._VSTHandle7 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL7, BASSVSTDsp.BASS_VST_DEFAULT, 7);
                Globals._VSTHandle8 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, Globals.VSTDLL8, BASSVSTDsp.BASS_VST_DEFAULT, 8);
                BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle2, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle2, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle3, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle3, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle4, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle4, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle5, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle5, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle6, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle6, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle7, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle7, vstInfo);
                }
                if (BassVst.BASS_VST_GetInfo(Globals._VSTHandle8, vstInfo) && vstInfo.hasEditor)
                {
                    BASSVSTShowDialog(towhichstream, Globals._VSTHandle8, vstInfo);
                }
            }
        }

        private void BASSStreamSystem(String str)
        {
            Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", false);
            Globals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIDI_DECAYEND, Globals.Frequency);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, Globals.Volume);
            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Globals.LimitVoicesInt);
            Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 0);
            if (Path.GetFileNameWithoutExtension(str).Length >= 49)
                Globals.NewWindowName = String.Format(res_man.GetString("ConversionText", cul), Path.GetFileNameWithoutExtension(str).Truncate(45));
            else
                Globals.NewWindowName = String.Format(res_man.GetString("ConversionText", cul), Path.GetFileNameWithoutExtension(str));
            BASS_MIDI_FONT[] fonts = new BASS_MIDI_FONT[Globals.Soundfonts.Length];
            int sfnum = 0;
            foreach (string s in Globals.Soundfonts)
            {
                fonts[sfnum].font = BassMidi.BASS_MIDI_FontInit(s);
                fonts[sfnum].preset = -1;
                fonts[sfnum].bank = 0;
                BassMidi.BASS_MIDI_FontSetVolume(fonts[sfnum].font, ((float)Globals.Volume / 10000));
                BassMidi.BASS_MIDI_StreamSetFonts(Globals._recHandle, fonts, sfnum + 1);
                sfnum += 1;
            }
            Globals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(Globals._recHandle, 1);
            Globals._plm.CalcRMS = true;
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

        private void BASSEncoderInit(Int32 stream, Int32 format, String str)
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
                    Globals._Encoder = BassEnc.BASS_Encode_Start(stream, path, BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
                }
                else
                {
                    BassEnc.BASS_Encode_Stop(Globals._recHandle);
                    Globals._Encoder = BassEnc.BASS_Encode_Start(stream, Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".wav", BASSEncode.BASS_ENCODE_AUTOFREE | BASSEncode.BASS_ENCODE_PCM, null, IntPtr.Zero);
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
                            path = String.Format("{0} -m {1} -M {2} - -o \"{3}\"", Globals.EncoderPath, Globals.Bitrate.ToString(), Globals.Bitrate.ToString(), Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg");
                            audiopath = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg";
                        }
                        else
                        {
                            path = String.Format("{0} - -o \"{1}\"", Globals.EncoderPath, Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg");
                            audiopath = Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + " (Copy " + num3.ToString() + ").ogg";
                        }
                        ++num3;
                    } while (File.Exists(audiopath));
                    foreach (Process proc in Process.GetProcessesByName(Globals.EncoderPath))
                    {
                        proc.Kill();
                    }
                    BassEnc.BASS_Encode_Stop(Globals._recHandle);
                    Globals._Encoder = BassEnc.BASS_Encode_Start(stream, path, BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                }
                else
                {
                    if (Globals.QualityOverride == true)
                    {
                        foreach (Process proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Globals.EncoderPath)))
                        {
                            proc.Kill();
                        }
                        BassEnc.BASS_Encode_Stop(Globals._recHandle);
                        Globals._Encoder = BassEnc.BASS_Encode_Start(stream, String.Format("{0} -m {1} -M {2} - -o \"{3}\"", Globals.EncoderPath, Globals.Bitrate.ToString(), Globals.Bitrate.ToString(), Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg"), BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
                    }
                    else
                    {
                        foreach (Process proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Globals.EncoderPath)))
                        {
                            proc.Kill();
                        }
                        BassEnc.BASS_Encode_Stop(Globals._recHandle);
                        Globals._Encoder = BassEnc.BASS_Encode_Start(stream, String.Format("{0} - -o \"{1}\"", Globals.EncoderPath, Globals.ExportWhereYay + @"\" + Path.GetFileNameWithoutExtension(str) + ".ogg"), BASSEncode.BASS_ENCODE_AUTOFREE, null, IntPtr.Zero);
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
            string str4 = span.Minutes.ToString() + ":" + span.Seconds.ToString().PadLeft(2, '0');
            string str5 = span2.Minutes.ToString() + ":" + span2.Seconds.ToString().PadLeft(2, '0');
            float num11 = 0f;
            float num12 = 0f;
            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref num11);
            Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_CPU, ref num12);
            Globals.ActiveVoicesInt = Convert.ToInt32(num11);
            Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
            Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
            int secondsremaining = (int)(timespent.TotalSeconds / (int)num6 * ((int)pos - (int)num6));
            TimeSpan span3 = TimeSpan.FromSeconds(secondsremaining);
            string str6 = span3.Minutes.ToString() + ":" + span3.Seconds.ToString().PadLeft(2, '0');
            string str7 = timespent.Minutes.ToString() + ":" + timespent.Seconds.ToString().PadLeft(2, '0');
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

            Un4seen.Bass.Bass.BASS_ChannelGetData(Globals._recHandle, buffer, length);

            if (num12 < 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusFasterNew", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str6, str7, Convert.ToInt32(num12).ToString(), ((float)(100f / num12)).ToString("0.0"));
                else
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusFasterOld", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str5, str4, Convert.ToInt32(num12).ToString(), ((float)(100f / num12)).ToString("0.0"));
            }
            else if (num12 == 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusNormalNew", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str6, str7, Convert.ToInt32(num12).ToString());
                else
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusNormalOld", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str5, str4, Convert.ToInt32(num12).ToString());
            }
            else if (num12 > 100f)
            {
                if (Globals.OldTimeThingy == false)
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusSlowerNew", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str6, str7, Convert.ToInt32(num12).ToString(), ((float)(num12 / 100f)).ToString("0.0"));
                else
                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("ConvStatusSlowerOld", cul), num8.ToString("0.00"), percentagefinal.ToString("0.0%"), str5, str4, Convert.ToInt32(num12).ToString(), ((float)(num12 / 100f)).ToString("0.0"));
            }
        }

        private void BASSCloseStream(string message, string title, int type) {
            BassEnc.BASS_Encode_Stop(Globals._Encoder);
            Bass.BASS_StreamFree(Globals._recHandle);
            Bass.BASS_Free();
            Globals.CurrentStatusTextString = message;
            Globals.ActiveVoicesInt = 0;
            Globals.NewWindowName = "Keppy's MIDI Converter";
            if (type == 0)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PlayConversionStop();
            }
            Globals.CancellationPendingValue = 0;
            Globals.CurrentStatusTextString = null;
        }

        private void BASSCloseStreamCrash(Exception ex)
        {
            BassEnc.BASS_Encode_Stop(Globals._Encoder);
            Bass.BASS_StreamFree(Globals._recHandle);
            Bass.BASS_Free();
            Globals.NewWindowName = "Keppy's MIDI Converter";
            Globals.RenderingMode = false;
            KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("NewValueTempo", cul), ex.ToString(), 0, 1);
            errordialog.ShowDialog();
        }

        private void clearMIDIsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void ConverterProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayConversionStart();
            try
            {
                if (Globals.Soundfonts[0] == null)
                {
                    throw new Exception(res_man.GetString("SelectOneSF", cul));
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception(res_man.GetString("AddOneMIDI", cul));
                }
                try
                {
                    Microsoft.Win32.RegistryKey Settings = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", false);
                    bool KeepLooping = true;
                    BASSInitSystem();
                    while (KeepLooping)
                    {
                        foreach (string str in this.MIDIList.Items)
                        {
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSStreamSystem(str);
                            BASSVSTInit(Globals._recHandle);
                            BASSEffectSettings();
                            BASSEncoderInit(Globals._recHandle, Globals.CurrentEncoder, str);
                            DateTime starttime = DateTime.Now;
                            while (Un4seen.Bass.Bass.BASS_ChannelIsActive(Globals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (Globals.CancellationPendingValue != 1)
                                {
                                    BASSEncodingEngine(starttime);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BASSCloseStream(res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
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
                            BASSCloseStream(res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
                            KeepLooping = false;
                            Globals.RenderingMode = false;
                            PlayConversionStop();
                        }
                        else
                        {
                            BASSCloseStream(res_man.GetString("ConversionCompleted", cul), res_man.GetString("ConversionCompleted", cul), 1);
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
                                PlayConversionStop();
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
                    BASSCloseStreamCrash(exception);
                }
            }
            catch (Exception exception2)
            {
                BASSCloseStreamCrash(exception2);
            }
        }

        private void RealTimePlayBackBeta_DoWork(object sender, DoWorkEventArgs e)
        {
            PlayConversionStart();
            try
            {
                if (Globals.Soundfonts[0] == null)
                {
                    throw new Exception(res_man.GetString("SelectOneSF", cul));
                }
                if (this.MIDIList.Items.Count == 0)
                {
                    throw new Exception(res_man.GetString("AddOneMIDI", cul));
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
                            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, Globals.Volume);
                            Un4seen.Bass.Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 85);
                            if (Path.GetFileNameWithoutExtension(str).Length >= 49)
                                Globals.NewWindowName = String.Format(res_man.GetString("PlaybackText", cul), Path.GetFileNameWithoutExtension(str).Truncate(45));
                            else
                                Globals.NewWindowName = String.Format(res_man.GetString("PlaybackText", cul), Path.GetFileNameWithoutExtension(str));
                            BASSVSTInit(Globals._recHandle);
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
                                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, Globals.Volume);
                                    Bass.BASS_ChannelSetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, Convert.ToInt32(Globals.LimitVoicesInt));
                                    long pos = Un4seen.Bass.Bass.BASS_ChannelGetLength(Globals._recHandle);
                                    long num6 = Un4seen.Bass.Bass.BASS_ChannelGetPosition(Globals._recHandle);
                                    float num7 = ((float)pos) / 1048576f;
                                    float num8 = ((float)num6) / 1048576f;
                                    double num9 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, pos);
                                    double num10 = Un4seen.Bass.Bass.BASS_ChannelBytes2Seconds(Globals._recHandle, num6);
                                    TimeSpan span = TimeSpan.FromSeconds(num9);
                                    TimeSpan span2 = TimeSpan.FromSeconds(num10);
                                    string str4 = span.Minutes.ToString() + ":" + span.Seconds.ToString().PadLeft(2, '0');
                                    string str5 = span2.Minutes.ToString() + ":" + span2.Seconds.ToString().PadLeft(2, '0');
                                    float percentage = num8 / num7;
                                    float percentagefinal;
                                    if (percentage * 100 < 0)
                                        percentagefinal = 0.0f;
                                    else if (percentage * 100 > 100)
                                        percentagefinal = 1.0f;
                                    else
                                        percentagefinal = percentage;
                                    float num11 = 0f;
                                    Un4seen.Bass.Bass.BASS_ChannelGetAttribute(Globals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref num11);
                                    Globals.CurrentStatusTextString = String.Format(res_man.GetString("PlaybackStatus", cul), percentage.ToString("0%"), str5, str4);
                                    Globals.ActiveVoicesInt = Convert.ToInt32(num11);
                                    Globals.CurrentStatusMaximumInt = Convert.ToInt32((long)(pos / 0x100000L));
                                    Globals.CurrentStatusValueInt = Convert.ToInt32((long)(num6 / 0x100000L));
                                    Bass.BASS_ChannelUpdate(Globals._recHandle, 0);
                                }
                                else if (Globals.CancellationPendingValue == 1)
                                {
                                    BassEnc.BASS_Encode_Stop(Globals._Encoder);
                                    Bass.BASS_StreamFree(Globals._recHandle);
                                    Bass.BASS_Free();
                                    Globals.CurrentStatusTextString = res_man.GetString("PlaybackAborted", cul);
                                    Globals.ActiveVoicesInt = 0;
                                    Globals.NewWindowName = "Keppy's MIDI Converter";
                                    MessageBox.Show(res_man.GetString("PlaybackAborted", cul), res_man.GetString("PlaybackXPTitle", cul), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            Globals.CurrentStatusTextString = res_man.GetString("PlaybackAborted", cul);
                            Globals.NewWindowName = "Keppy's MIDI Converter";
                            KeepLooping = false;
                            Globals.PlaybackMode = false;
                            PlayConversionStop();
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
                            PlayConversionStop();
                        }
                    }
                }
                catch (Exception exception)
                {
                    BASSCloseStreamCrash(exception);
                    Globals.PlaybackMode = false;
                }
            }
            catch (Exception exception2)
            {
                BASSCloseStreamCrash(exception2);
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
                DialogResult dialogResult = MessageBox.Show(res_man.GetString("AppBusy", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
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
                DialogResult dialogResult = MessageBox.Show(res_man.GetString("AppBusy", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    if (Globals.DeleteEncoder == true)
                    {
                        File.Delete(Globals.EncoderPath);
                    }
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
            MIDIImport.Title = res_man.GetString("ImportMIDIWindow", cul);
            MIDIImport.InitialDirectory = Globals.MIDILastDirectory;
            if (this.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in this.MIDIImport.FileNames)
                {
                    if (Path.GetExtension(str) == ".mid" | Path.GetExtension(str) == ".midi" | Path.GetExtension(str) == ".kar" | Path.GetExtension(str) == ".rmi" | Path.GetExtension(str) == ".MID" | Path.GetExtension(str) == ".MIDI" | Path.GetExtension(str) == ".KAR" | Path.GetExtension(str) == ".RMI")
                    {
                        MIDIList.Items.Add(str);
                    }
                    else
                    {
                        MessageBox.Show(String.Format(res_man.GetString("InvalidMIDIFile", cul), Path.GetFileName(str)), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
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

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIList.SelectedItems.Count >= 2)
            {
                MessageBox.Show(res_man.GetString("OnlyOneItemMsg", cul), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.MoveItem(-1);
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MIDIList.SelectedItems.Count >= 2)
            {
                MessageBox.Show(res_man.GetString("OnlyOneItemMsg", cul), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        // Links

        private void kaleidonKep99sYouTubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCJeqODojIv4TdeHcBfHJRnA");
        }

        private void KaleidonKep99sGitHubPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/KaleidonKep99/");
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
            {
                if (Path.GetExtension(s[i]) == ".mid" | Path.GetExtension(s[i]) == ".midi" | Path.GetExtension(s[i]) == ".kar" | Path.GetExtension(s[i]) == ".rmi" | Path.GetExtension(s[i]) == ".MID" | Path.GetExtension(s[i]) == ".MIDI" | Path.GetExtension(s[i]) == ".KAR" | Path.GetExtension(s[i]) == ".RMI")
                {
                    MIDIList.Items.Add(s[i]);
                }
                else
                {
                    MessageBox.Show(String.Format(res_man.GetString("InvalidMIDIFile", cul), Path.GetFileName(s[i])), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        if (Globals.VSTMode == true)
                        {
                            this.CurrentStatusText.Text = res_man.GetString("MemoryAllocationPlayback", cul);
                        }
                        else
                        {
                            this.CurrentStatusText.Text = res_man.GetString("MemoryAllocationPlaybackVST", cul);
                        }
                        this.UsedVoices.Text = res_man.GetString("ActiveVoices", cul) + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        if (Globals.pictureset != 0)
                        {
                            this.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convbusy;
                            Globals.pictureset = 0;
                        }
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = String.Format("{0}: {1:#00.0} dB | {2}: {3:#00.0} dB | {4}: {5:#00.0} dB", res_man.GetString("RMS", cul), Globals._plm.RMS_dBV, res_man.GetString("AverageLevel", cul), Globals._plm.AVG_dBV, res_man.GetString("PeakLevel", cul), Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                        this.SettingsBox.Enabled = true;
                        this.label3.Enabled = true;
                        this.VolumeBar.Enabled = true;
                        this.VoiceLimit.Maximum = 2000;
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
                    }
                    else if (Globals.RenderingMode == true)
                    {
                        this.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        this.CurrentStatusText.Text = res_man.GetString("MemoryAllocationConversion", cul);
                        this.UsedVoices.Text = res_man.GetString("ActiveVoices", cul) + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        if (Globals.pictureset != 0)
                        {
                            this.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convbusy;
                            Globals.pictureset = 0;
                        }
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = String.Format("{0}: {1:#00.0} dB | {2}: {3:#00.0} dB | {4}: {5:#00.0} dB", res_man.GetString("RMS", cul), Globals._plm.RMS_dBV, res_man.GetString("AverageLevel", cul), Globals._plm.AVG_dBV, res_man.GetString("PeakLevel", cul), Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
                        this.SettingsBox.Enabled = false;
                        this.label3.Enabled = false;
                        this.VolumeBar.Enabled = false;
                        this.VoiceLimit.Maximum = 100000;
                        Process thisProc = Process.GetCurrentProcess();
                        thisProc.PriorityClass = ProcessPriorityClass.RealTime;
                    }
                    else if (Globals.RenderingMode == false & Globals.PlaybackMode == false)
                    {
                        this.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        this.CurrentStatus.Maximum = 999;
                        this.CurrentStatus.Value = 0;
                        this.CurrentStatusText.Text = res_man.GetString("IdleMessage", cul);
                        this.UsedVoices.Text = res_man.GetString("ActiveVoices", cul) + @"0/" + Globals.LimitVoicesInt.ToString();
                        this.MIDIList.Enabled = true;
                        if (Globals.pictureset != 1)
                        {
                            this.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convpause;
                            Globals.pictureset = 1;
                        }
                        this.importMIDIsToolStripMenuItem.Enabled = true;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = true;
                        this.clearMIDIsListToolStripMenuItem.Enabled = true;
                        this.startRenderingWAVToolStripMenuItem.Enabled = true;
                        this.startRenderingOGGToolStripMenuItem.Enabled = true;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = true;
                        this.abortRenderingToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = String.Format("{0}: 0.0 dB | {1}: 0.0 dB | {2}: 0.0 dB", res_man.GetString("RMS", cul), res_man.GetString("AverageLevel", cul), res_man.GetString("PeakLevel", cul));
                        this.SettingsBox.Enabled = true;
                        this.label3.Enabled = true;
                        this.VolumeBar.Enabled = true;
                        this.VoiceLimit.Maximum = 100000;
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
                            this.CurrentStatusText.Text = res_man.GetString("BASSEngineConfigurationVST", cul);
                        }
                        else
                        {
                            this.CurrentStatusText.Text = res_man.GetString("BASSEngineConfiguration", cul);
                        }
                        this.UsedVoices.Text = res_man.GetString("ActiveVoices", cul) + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.MarqueeAnimationSpeed = 100;
                        this.MIDIList.Enabled = false;
                        if (Globals.pictureset != 0)
                        {
                            this.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convbusy;
                            Globals.pictureset = 0;
                        }
                        this.importMIDIsToolStripMenuItem.Enabled = false;
                        this.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                        this.clearMIDIsListToolStripMenuItem.Enabled = false;
                        this.startRenderingWAVToolStripMenuItem.Enabled = false;
                        this.startRenderingOGGToolStripMenuItem.Enabled = false;
                        this.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
                        this.playInRealtimeBetaToolStripMenuItem.Enabled = false;
                        this.abortRenderingToolStripMenuItem.Enabled = true;
                        this.labelRMS.Text = String.Format("{0}: {1:#00.0} dB | {2}: {3:#00.0} dB | {4}: {5:#00.0} dB", res_man.GetString("RMS", cul), Globals._plm.RMS_dBV, res_man.GetString("AverageLevel", cul), Globals._plm.AVG_dBV, res_man.GetString("PeakLevel", cul), Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
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
                        this.UsedVoices.Text = res_man.GetString("ActiveVoices", cul) + Globals.ActiveVoicesInt.ToString() + @"/" + Globals.LimitVoicesInt.ToString();
                        this.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        if (Globals.pictureset != 0)
                        {
                            this.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convbusy;
                            Globals.pictureset = 0;
                        }
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
                        this.labelRMS.Text = String.Format("{0}: {1:#00.0} dB | {2}: {3:#00.0} dB | {4}: {5:#00.0} dB", res_man.GetString("RMS", cul), Globals._plm.RMS_dBV, res_man.GetString("AverageLevel", cul), Globals._plm.AVG_dBV, res_man.GetString("PeakLevel", cul), Math.Max(Globals._plm.PeakHoldLevelL_dBV, Globals._plm.PeakHoldLevelR_dBV));
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

        private void VolumeBar_Scroll(object sender, EventArgs e)
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
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("Error", cul), exception.Message.ToString(), 0, 0);
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
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("Error", cul), exception.Message.ToString(), 0, 0);
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
            disabledToolStripMenuItem2.Checked = false;
            Settings.Close();
        }

        private void disabledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            Settings.SetValue("autoupdatecheck", "0", RegistryValueKind.DWord);
            enabledToolStripMenuItem3.Checked = false;
            disabledToolStripMenuItem2.Checked = true;
            Settings.Close();
        }


        private void enabledToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem5.Checked = true;
                disabledToolStripMenuItem5.Checked = false;
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Language = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", true);
                Language.SetValue("langoverride", "1", Microsoft.Win32.RegistryValueKind.DWord);
                Language.Close();
                InitializeLanguage();
                // List
                ChineseCNOverride.Enabled = true;
                ChineseHKOverride.Enabled = true;
                ChineseTWOverride.Enabled = true;
                DutchOverride.Enabled = false;
                EnglishOverride.Enabled = true;
                EstonianOverride.Enabled = true;
                FrenchOverride.Enabled = false;
                GermanOverride.Enabled = true;
                IndonesianOverride.Enabled = false;
                ItalianOverride.Enabled = true;
                JapaneseOverride.Enabled = true;
                KoreanOverride.Enabled = true;
                SpanishOverride.Enabled = true;
                TurkishOverride.Enabled = false;
                BengaliOverride.Enabled = true;
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void disabledToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem5.Checked = false;
                disabledToolStripMenuItem5.Checked = true;
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Language = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", true);
                Language.SetValue("langoverride", "0", Microsoft.Win32.RegistryValueKind.DWord);
                Language.Close();
                InitializeLanguage();
                // List
                ChineseCNOverride.Enabled = false;
                ChineseHKOverride.Enabled = false;
                ChineseTWOverride.Enabled = false;
                DutchOverride.Enabled = false;
                EnglishOverride.Enabled = false;
                EstonianOverride.Enabled = false;
                FrenchOverride.Enabled = false;
                GermanOverride.Enabled = false;
                IndonesianOverride.Enabled = false;
                ItalianOverride.Enabled = false;
                JapaneseOverride.Enabled = false;
                KoreanOverride.Enabled = false;
                SpanishOverride.Enabled = false;
                TurkishOverride.Enabled = false;
                BengaliOverride.Enabled = false;
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
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

        private void forceCloseTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(res_man.GetString("CrashQuestion", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                this.Enabled = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(res_man.GetString("FatalError", cul), res_man.GetString("CrashTriggeredByUser", cul), 1, 0);
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

        // Language overrides

        private void ChangeLanguage(string selectedlanguage)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", true);
                Settings.SetValue("selectedlanguage", selectedlanguage, Microsoft.Win32.RegistryValueKind.String);
                Settings.Close();
                AdvancedSettings example = new AdvancedSettings();
                InitializeLanguage();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.Message.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void ItalianOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("it");
        }

        private void TurkishOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("tr");
        }

        private void EnglishOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void SpanishOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("es");
        }

        private void GermanOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("de");
        }

        private void EstonianOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("et");
        }

        private void DutchOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("nl");
        }

        private void IndonesianOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("id");
        }

        private void FrenchOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("fr");
        }

        private void ChineseCN_Click(object sender, EventArgs e)
        {
            ChangeLanguage("zh-CN");
        }

        private void ChineseTW_Click(object sender, EventArgs e)
        {
            ChangeLanguage("zh-TW");
        }

        private void ChineseHK_Click(object sender, EventArgs e)
        {
            ChangeLanguage("zh-HK");
        }

        private void JapaneseOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ja");
        }

        private void KoreanOverride_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ko");
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            ChangeLanguage("bn");
        }

        private void FL12Discount_Click(object sender, EventArgs e)
        {
            Process.Start("http://affiliate.image-line.com/BFHHCGAE552");
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
