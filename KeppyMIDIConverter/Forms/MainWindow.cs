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
using Un4seen.BassWasapi;
using Un4seen.Bass.AddOn.Enc;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass.AddOn.Midi;
using HundredMilesSoftware.UltraID3Lib;
using System.Globalization;
using System.Resources;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace KeppyMIDIConverter
{
    public partial class MainWindow : Form
    {
        private const int timerAccuracy = 1;
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int timeBeginPeriod(int msec);
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        public static extern int timeEndPeriod(int msec);


        // Delegate for RTF
        public static MainWindow Delegate;
        public static String Title = "";

        public static class KMCGlobals
        {
            public static BASS_MIDI_EVENT[] events;
            public static BASS_VST_INFO vstIInfo = new BASS_VST_INFO();
            public static DSPPROC _myDSP;
            public static KeppyMIDIConverter.SoundfontDialog frm2 = new KeppyMIDIConverter.SoundfontDialog();
            public static List<string> EncodersPath = new List<string>();
            public static SYNCPROC _mySync;
            public static SYNCPROC _myVSTSync;
            public static SYNCPROC _myTempoSync;
            public static WASAPIPROC _myWasapi;
            public static UInt32 eventc;
            public static Un4seen.Bass.Misc.DSP_PeakLevelMeter _plm;
            public static bool AutoClearMIDIListEnabled = false;
            public static bool AutoShutDownEnabled = false;
            public static bool DeleteEncoder = false;
            public static bool DoNotCountNotes = false;
            public static bool FXDisabled = true;
            public static bool IsKMCBusy = false;
            public static bool IsKMCNowExporting = false;
            public static bool IsLoudMaxEnabled = false;
            public static bool NoteOff1Event = false;
            public static bool OldTimeThingy = false;
            public static bool QualityOverride = false;
            public static bool RealTime = false;
            public static bool RenderingMode = false;
            public static bool VSTMode = false;
            public static bool VSTSkipSettings = false;
            public static double RTFPS = 60.0;
            public static int ActiveVoicesInt = 0;
            public static int AverageCPU;
            public static int Bitrate = 128;
            public static int CancellationPendingValue = 0;
            public static int CurrentEncoder;
            public static int CurrentMode;
            public static int DefaultSoundfont;
            public static int MIDITempo = 0;              // MIDI file tempo
            public static float TempoScale = 1.0f;    // Tempo adjustment
            public static int Frequency = 0xbb80;
            public static int _LoudMaxHan;
            public static int LimitVoicesInt = 0x186a0;
            public static int OriginalTempo;
            public static int SoundFont;
            public static int Time = 0;
            public static int UpdateRate;
            public static int Volume;
            public static int _Encoder;
            public static int _Mixer;
            public static int _VSTHandle2;
            public static int _VSTHandle3;
            public static int _VSTHandle4;
            public static int _VSTHandle5;
            public static int _VSTHandle6;
            public static int _VSTHandle7;
            public static int _VSTHandle8;
            public static int _VSTHandle;
            public static int _recHandle;
            public static int pictureset = 1;
            public static long StreamSizeFLAC;
            public static string BenchmarkTime;
            public static string CurrentStatusTextString;
            public static string DisabledOr;
            public static string ExportLastDirectory;
            public static string ExportWhereYay;
            public static string MIDILastDirectory;
            public static string MIDIName;
            public static string NewWindowName = null;
            public static string PercentageProgress = "0";
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
            public static int RealTimeFreq = 44100;
            public static string WAVName;
            public static string[] Soundfonts = new string[0];
            public static AdvancedSettings frm = new AdvancedSettings();

            // Other
            public static string ExecutablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static class KMCStatus
        {
            public static UInt64 PlayedNotes = 0;
            public static UInt64 TotalNotes = 0;
            public static UInt64 TotalNotesOrg = 0;
            public static DateTime StartTime;
            public static TimeSpan PassedTime;
            public static TimeSpan EstimatedTime;
        }

        public static class KMCChannelsVoices
        {
            public static int ch1 = 0;
            public static int ch2 = 0;
            public static int ch3 = 0;
            public static int ch4 = 0;
            public static int ch5 = 0;
            public static int ch6 = 0;
            public static int ch7 = 0;
            public static int ch8 = 0;
            public static int ch9 = 0;
            public static int chD = 0;
            public static int ch11 = 0;
            public static int ch12 = 0;
            public static int ch13 = 0;
            public static int ch14 = 0;
            public static int ch15 = 0;
            public static int ch16 = 0;

        }

        public static class ID3Meta
        {
            public static string FileToEdit;
            public static short CurrentYear = (Int16)DateTime.Today.Year;
        }

        private Random FPSSimulator = new Random();

        private enum MoveDirection { Up = -1, Down = 1 };

        public MainWindow(String[] args, String[] encoders, bool deletencoder)
        {          
            InitializeComponent();
            InitializeLanguage();
            // Help me
            KMCGlobals.EncodersPath.Add(encoders[0]);
            KMCGlobals.EncodersPath.Add(encoders[1]);
            KMCGlobals.DeleteEncoder = deletencoder;
            //To store all the soundfonts that where opened with the application
            List<String> soundfonts = null;
            //Parse through arguments
            foreach (String s in args)
            {
                //Find out is the current argument is a file path/name
                if (File.Exists(s))
                {
                    //Find out it the current file is a MIDI
                    if (s.ToLower().EndsWith(".mid") | s.ToLower().EndsWith(".midi") | s.ToLower().EndsWith(".kar") | s.ToLower().EndsWith(".rmi"))
                    {
                        //Add MIDI to midi list
                        string[] saLvwItem = new string[4];
                        string[] midiinfo = GetMoreInfoMIDI(s, false);
                        saLvwItem[0] = s;
                        saLvwItem[1] = midiinfo[1];
                        saLvwItem[2] = midiinfo[0];
                        saLvwItem[3] = midiinfo[2];
                        ListViewItem lvi = new ListViewItem(saLvwItem);
                        this.MIDIList.Items.Add(lvi);
                    }
                    //If the file isnt a MIDI, check if its a soundfont
                    if (s.ToLower().EndsWith(".sf2") | s.ToLower().EndsWith(".sf3") | s.ToLower().EndsWith(".sfpack") | s.ToLower().EndsWith(".sfz"))
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
                KMCGlobals.Soundfonts = new string[soundfonts.Count];
                soundfonts.CopyTo(KMCGlobals.Soundfonts, 0);
                foreach(String s in soundfonts)
                {
                    KMCGlobals.frm2.SFList.Items.Add(s);
                }
            }
            //
        }

        System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();

        public static ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        public static CultureInfo cul;            // declare culture info

        [DllImport("dwmapi.dll")]
        private static extern int DwmIsCompositionEnabled(out bool enabled);

        private void InitializeLanguage()
        {
            try {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture(false);
                MIDIList.Columns.Clear();
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDIFile", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDINotes", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDILength", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDISize", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns[0].Tag = 7;
                MIDIList.Columns[1].Tag = 1;
                MIDIList.Columns[2].Tag = 1;
                MIDIList.Columns[3].Tag = 1;
                MIDIList_SizeChanged(MIDIList, new EventArgs());
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
                MoveDownItem.Text = res_man.GetString("MoveDOWN", cul);
                MoveUpItem.Text = res_man.GetString("MoveUP", cul);
                OptionsStrip.Text = res_man.GetString("OptionsStrip", cul);
                OverrideStrip.Text = res_man.GetString("ChangeLanguage", cul);
                SettingsBox.Text = res_man.GetString("SettingsBox", cul);
                SortByName.Text = res_man.GetString("SortByName", cul);
                VoiceLabel.Text = res_man.GetString("VoiceLabel", cul);
                abortRenderingToolStripMenuItem.Text = res_man.GetString("AbortConvPlayback", cul);
                clearMIDIsListToolStripMenuItem.Text = ClearMIDIsListRightClick.Text = res_man.GetString("ClearMIDIsList", cul);
                disabledToolStripMenuItem.Text = disabledToolStripMenuItem1.Text = disabledToolStripMenuItem2.Text = disabledToolStripMenuItem3.Text = disabledToolStripMenuItem4.Text = res_man.GetString("DisabledText", cul);
                enabledToolStripMenuItem.Text = enabledToolStripMenuItem1.Text = enabledToolStripMenuItem2.Text = enabledToolStripMenuItem3.Text = enabledToolStripMenuItem4.Text = res_man.GetString("EnabledText", cul);
                exitToolStripMenuItem.Text = res_man.GetString("ExitStrip", cul);
                forceCloseTheApplicationToolStripMenuItem.Text = res_man.GetString("forceCloseTheApplicationStrip", cul);
                importMIDIsToolStripMenuItem.Text = ImportMIDIsRightClick.Text = res_man.GetString("ImportMIDI", cul);
                informationAboutTheProgramToolStripMenuItem.Text = res_man.GetString("informationAboutTheProgramStrip", cul);
                if (Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor < 2) { VolumeLabel.Text = res_man.GetString("Volume", cul); }
                else { VolumeLabel.Text = String.Format("{0} {1}", "🔊", res_man.GetString("Volume", cul)); }
                openTheSoundfontsManagerToolStripMenuItem.Text = res_man.GetString("SFVSTManager", cul);
                playInRealtimeBetaToolStripMenuItem.Text = res_man.GetString("RenderToSpeakers", cul);
                removeSelectedMIDIsToolStripMenuItem.Text = RemoveMIDIsRightClick.Text = res_man.GetString("RemoveMIDI", cul);
                startRenderingOGGToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "Vorbis", "OGG");
                startRenderingWAVToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "Wave", "WAV");
                startRenderingMp3ToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "LAME", "MP3");
                supportTheDeveloperWithADonationToolStripMenuItem.Text = res_man.GetString("supportTheDeveloperWithADonation", cul);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Title + " tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture(true);
                MIDIList.Columns.Clear();
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDIFile", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDINotes", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDILength", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns.Add(MainWindow.res_man.GetString("MIDISize", cul), 1, HorizontalAlignment.Left);
                MIDIList.Columns[0].Tag = 7;
                MIDIList.Columns[1].Tag = 1;
                MIDIList.Columns[2].Tag = 1;
                MIDIList.Columns[3].Tag = 1;
                MIDIList_SizeChanged(MIDIList, new EventArgs());
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
                MoveDownItem.Text = res_man.GetString("MoveDOWN", cul);
                MoveUpItem.Text = res_man.GetString("MoveUP", cul);
                OptionsStrip.Text = res_man.GetString("OptionsStrip", cul);
                OverrideStrip.Text = res_man.GetString("ChangeLanguage", cul);
                SettingsBox.Text = res_man.GetString("SettingsBox", cul);
                SortByName.Text = res_man.GetString("SortByName", cul);
                VoiceLabel.Text = res_man.GetString("VoiceLabel", cul);
                abortRenderingToolStripMenuItem.Text = res_man.GetString("AbortConvPlayback", cul);
                clearMIDIsListToolStripMenuItem.Text = ClearMIDIsListRightClick.Text = res_man.GetString("ClearMIDIsList", cul);
                disabledToolStripMenuItem.Text = disabledToolStripMenuItem1.Text = disabledToolStripMenuItem2.Text = disabledToolStripMenuItem3.Text = disabledToolStripMenuItem4.Text = res_man.GetString("DisabledText", cul);
                enabledToolStripMenuItem.Text = enabledToolStripMenuItem1.Text = enabledToolStripMenuItem2.Text = enabledToolStripMenuItem3.Text = enabledToolStripMenuItem4.Text = res_man.GetString("EnabledText", cul);
                exitToolStripMenuItem.Text = res_man.GetString("ExitStrip", cul);
                forceCloseTheApplicationToolStripMenuItem.Text = res_man.GetString("forceCloseTheApplicationStrip", cul);
                importMIDIsToolStripMenuItem.Text = ImportMIDIsRightClick.Text = res_man.GetString("ImportMIDI", cul);
                informationAboutTheProgramToolStripMenuItem.Text = res_man.GetString("informationAboutTheProgramStrip", cul);
                if (Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor < 2) { VolumeLabel.Text = res_man.GetString("Volume", cul); }
                else { VolumeLabel.Text = String.Format("{0} {1}", "🔊", res_man.GetString("Volume", cul)); }
                openTheSoundfontsManagerToolStripMenuItem.Text = res_man.GetString("SFVSTManager", cul);
                playInRealtimeBetaToolStripMenuItem.Text = res_man.GetString("RenderToSpeakers", cul);
                removeSelectedMIDIsToolStripMenuItem.Text = RemoveMIDIsRightClick.Text = res_man.GetString("RemoveMIDI", cul);
                startRenderingOGGToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "Vorbis", "OGG");
                startRenderingWAVToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "Wave", "WAV");
                startRenderingMp3ToolStripMenuItem.Text = String.Format(MainWindow.res_man.GetString("RenderTo", cul), "LAME", "MP3");
                supportTheDeveloperWithADonationToolStripMenuItem.Text = res_man.GetString("supportTheDeveloperWithADonation", cul);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Here we go
            Title = String.Format(Program.Title, Program.Who);
            timeBeginPeriod(timerAccuracy);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.Menu = DefaultMenu;
            MIDIList.ContextMenu = DefMenu;
            try
            {
                try
                {
                    Properties.Settings.Default.Reload();

                    // Generic settings
                    VoiceLimit.Value = Properties.Settings.Default.Voices;
                    VolumeBar.Value = Properties.Settings.Default.Volume;
                    KMCGlobals.Volume = Properties.Settings.Default.Volume;
                    KMCGlobals.Frequency = Properties.Settings.Default.AudioFreq;
                    KMCGlobals.Bitrate = Properties.Settings.Default.OGGBitrate;
                    KMCGlobals.RTFPS = Properties.Settings.Default.RTFPS;

                    // Audio events
                    if (Properties.Settings.Default.AudioEvents)
                    {
                        enabledToolStripMenuItem4.Checked = true;
                        disabledToolStripMenuItem4.Checked = false;
                    }
                    else
                    {
                        enabledToolStripMenuItem4.Checked = false;
                        disabledToolStripMenuItem4.Checked = true;
                    }

                    // Autoupdate lel
                    if (Properties.Settings.Default.AutoUpdateCheck)
                    {
                        enabledToolStripMenuItem3.Checked = true;
                        disabledToolStripMenuItem3.Checked = false;
                    }
                    else
                    {
                        enabledToolStripMenuItem3.Checked = false;
                        disabledToolStripMenuItem3.Checked = true;
                    }

                    // Old time thingy
                    if (Properties.Settings.Default.ShowOldTimeInfo)
                    {
                        enabledToolStripMenuItem2.Checked = true;
                        disabledToolStripMenuItem2.Checked = false;
                        KMCGlobals.OldTimeThingy = true;
                    }
                    else
                    {
                        enabledToolStripMenuItem2.Checked = false;
                        disabledToolStripMenuItem2.Checked = true;
                        KMCGlobals.OldTimeThingy = false;
                    }

                    // LoudMax
                    KMCGlobals.IsLoudMaxEnabled = Properties.Settings.Default.LoudMaxEnabled;
                    KMCGlobals.VSTMode = Properties.Settings.Default.LoudMaxEnabled;

                    // Note off setting
                    KMCGlobals.NoteOff1Event = Properties.Settings.Default.NoteOff1;

                    // BASS default sound effects (Reverb and chorus)
                    KMCGlobals.FXDisabled = Properties.Settings.Default.DisableFX;

                    // OGG bitrate override
                    KMCGlobals.QualityOverride = Properties.Settings.Default.OverrideOGG;

                    // Folders
                    KMCGlobals.MIDILastDirectory = Properties.Settings.Default.LastMIDIFolder;
                    KMCGlobals.ExportLastDirectory = Properties.Settings.Default.LastExportFolder;
                }
                catch (Exception exception)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("FatalError", cul), exception.ToString(), 1, 0);
                    errordialog.ShowDialog();
                }
                Delegate = this;
                GarbageCollector.RunWorkerAsync();
                ThemeCheck.RunWorkerAsync();
                GetInfoWorker.RunWorkerAsync();
            }
            catch (Exception exception2)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), exception2.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
            KMCGlobals.AutoShutDownEnabled = false;
            KMCGlobals.AutoClearMIDIListEnabled = false;
            RenderingTimer.Enabled = true;
        }

        private void StartRenderingThread()
        {
            try
            {
                EEPlayer.Close();
                int convmode = 0;
                KMCGlobals.IsKMCBusy = true;
                KMCGlobals.RenderingMode = true;
                StatusPicture.Visible = true;
                ExportWhere.FileName = res_man.GetString("SaveHere", cul);
                ExportWhere.Title = res_man.GetString("ExportWhere", cul);
                ExportWhere.InitialDirectory = Properties.Settings.Default.LastExportFolder;

                if (ModifierKeys == Keys.Shift)
                {
                    convmode = 1;
                    MessageBox.Show("Real-time simulation mode activated.", Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ModifierKeys == Keys.Control)
                {
                    KMCGlobals.VSTSkipSettings = true;
                    MessageBox.Show("Skipping VST settings.", Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ModifierKeys == (Keys.Shift | Keys.Control))
                {
                    KMCGlobals.VSTSkipSettings = true;
                    convmode = 1;
                    MessageBox.Show("Real-time simulation mode activated.\n\nSkipping VST settings.", Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (ExportWhere.ShowDialog() == DialogResult.OK)
                {
                    KMCGlobals.CurrentStatusTextString = null;
                    KMCGlobals.ExportWhereYay = Path.GetDirectoryName(this.ExportWhere.FileName);
                    Properties.Settings.Default.LastExportFolder = KMCGlobals.ExportWhereYay;
                    Properties.Settings.Default.Save();

                    while (RealTimePlayBack.IsBusy || ConverterProcess.IsBusy || ConverterProcessRT.IsBusy)
                    {
                        if (!RealTimePlayBack.IsBusy && !ConverterProcess.IsBusy && !ConverterProcessRT.IsBusy)
                        {
                            break;
                        }
                    }

                    if (convmode == 1)
                    {
                        KMCGlobals.RealTime = true;
                        this.ConverterProcessRT.RunWorkerAsync();
                    }
                    else
                    {
                        KMCGlobals.RealTime = false;
                        this.ConverterProcess.RunWorkerAsync();
                    }
                }
                else
                {
                    KMCGlobals.IsKMCBusy = false;
                    KMCGlobals.RenderingMode = false;
                    this.StatusPicture.Visible = false;
                }
            }
            catch (Exception ex)
            {
                KMCGlobals.IsKMCBusy = false;
                KMCGlobals.RenderingMode = false;
                this.StatusPicture.Visible = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), ex.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void startRenderingWAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 0;
            KMCStatus.StartTime = DateTime.Now;
            StartRenderingThread();
        }

        private void startRenderingOGGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 1;
            KMCStatus.StartTime = DateTime.Now;
            StartRenderingThread();
        }

        private void startRenderingMp3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 2;
            KMCStatus.StartTime = DateTime.Now;
            StartRenderingThread();
        }

        private void playInRealtimeBetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EEPlayer.Close();
                if (ModifierKeys == Keys.Shift)
                {
                    KMCGlobals.DoNotCountNotes = true;
                }
                this.StatusPicture.Visible = true;
                KMCGlobals.RenderingMode = false;
                KMCGlobals.IsKMCBusy = true;
                while (RealTimePlayBack.IsBusy || ConverterProcess.IsBusy || ConverterProcessRT.IsBusy)
                {
                    if (!RealTimePlayBack.IsBusy && !ConverterProcess.IsBusy && !ConverterProcessRT.IsBusy)
                    {
                        break;
                    }
                }
                this.RealTimePlayBack.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                KMCGlobals.IsKMCBusy = false;
                KMCGlobals.RenderingMode = false;
                this.StatusPicture.Visible = false;
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), ex.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void abortRenderingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMCGlobals.CancellationPendingValue = 1;
            KMCGlobals.AutoShutDownEnabled = false;
            this.startRenderingWAVToolStripMenuItem.Enabled = true;
            this.startRenderingOGGToolStripMenuItem.Enabled = true;
            this.playInRealtimeBetaToolStripMenuItem.Enabled = true;
            this.abortRenderingToolStripMenuItem.Enabled = false;
        }

        private void BASSInitSystem(int type)
        {
            try
            {
                Bass.BASS_StreamFree(KMCGlobals._recHandle);
                Bass.BASS_Free();
                KMCGlobals.vstIInfo = new BASS_VST_INFO();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                if (type == 0)
                {
                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 100000);
                }
                else
                {
                    BassWasapi.BASS_WASAPI_Init(-1, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER | BASSWASAPIInit.BASS_WASAPI_SHARED, 0, 0, null, IntPtr.Zero);
                    BASS_WASAPI_DEVICEINFO info = new BASS_WASAPI_DEVICEINFO();
                    BassWasapi.BASS_WASAPI_GetDeviceInfo(BassWasapi.BASS_WASAPI_GetDevice(), info);
                    KMCGlobals.RealTimeFreq = info.mixfreq;
                    BassWasapi.BASS_WASAPI_Free();
                    Bass.BASS_Free();
                    Bass.BASS_Init(0, KMCGlobals.RealTimeFreq, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                    Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_MIDI_VOICES, 2000);
                }
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private void BASSVSTShowDialog(int towhichstream, int whichvst, BASS_VST_INFO vstInfo)
        {
            Form f = new Form();
            f.Width = vstInfo.editorWidth + 4;
            f.Height = vstInfo.editorHeight + 34;
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.Text = String.Format("{0} {1}", res_man.GetString("DSPSettings", cul), vstInfo.effectName);
            try
            {
                BassVst.BASS_VST_EmbedEditor(whichvst, f.Handle);
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
                MessageBox.Show(String.Format(MainWindow.res_man.GetString("VSTInvalidCallError", cul), vstInfo.effectName, ex.ToString()), Title + " - " + res_man.GetString("VSTInvalidCallTitle", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                BassVst.BASS_VST_EmbedEditor(whichvst, IntPtr.Zero);
                BassVst.BASS_VST_ChannelRemoveDSP(towhichstream, whichvst);
            }
        }

        private void BASSVSTInit(int towhichstream)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    if (KMCGlobals.VSTMode == true)
                    {
                        int temphandle = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL, BASSVSTDsp.BASS_VST_DEFAULT, 1);
                        KMCGlobals._VSTHandle2 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL2, BASSVSTDsp.BASS_VST_DEFAULT, 2);
                        KMCGlobals._VSTHandle3 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL3, BASSVSTDsp.BASS_VST_DEFAULT, 3);
                        KMCGlobals._VSTHandle4 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL4, BASSVSTDsp.BASS_VST_DEFAULT, 4);
                        KMCGlobals._VSTHandle5 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL5, BASSVSTDsp.BASS_VST_DEFAULT, 5);
                        KMCGlobals._VSTHandle6 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL6, BASSVSTDsp.BASS_VST_DEFAULT, 6);
                        KMCGlobals._VSTHandle7 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL7, BASSVSTDsp.BASS_VST_DEFAULT, 7);
                        KMCGlobals._VSTHandle8 = BassVst.BASS_VST_ChannelSetDSP(towhichstream, KMCGlobals.VSTDLL8, BASSVSTDsp.BASS_VST_DEFAULT, 8);
                        if (KMCGlobals.IsLoudMaxEnabled == true) KMCGlobals._LoudMaxHan = BassVst.BASS_VST_ChannelSetDSP(towhichstream, String.Format("{0}\\LoudMax.dll", Application.StartupPath), BASSVSTDsp.BASS_VST_DEFAULT, 9);
                        if (KMCGlobals.VSTSkipSettings != true)
                        {
                            BASS_VST_INFO vstInfo = new BASS_VST_INFO();
                            if (BassVst.BASS_VST_GetInfo(temphandle, vstInfo) && vstInfo.hasEditor)
                            {
                                if (KMCGlobals._VSTHandle == null) // VSTi check
                                {
                                    if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle, vstInfo) && vstInfo.hasEditor)
                                    {
                                        BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle, vstInfo);
                                    }
                                }
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle2, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle2, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle3, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle3, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle4, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle4, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle5, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle5, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle6, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle6, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle7, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle7, vstInfo);
                            }
                            if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle8, vstInfo) && vstInfo.hasEditor)
                            {
                                BASSVSTShowDialog(towhichstream, KMCGlobals._VSTHandle8, vstInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private void BASSInitVSTiIfNeeded()
        {
            try
            {
                KMCGlobals._VSTHandle = BassVst.BASS_VST_ChannelCreate((KMCGlobals.RenderingMode ? KMCGlobals.Frequency : KMCGlobals.RealTimeFreq), 2, KMCGlobals.VSTDLL, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT);
                if (BassVst.BASS_VST_GetInfo(KMCGlobals._VSTHandle, KMCGlobals.vstIInfo) && KMCGlobals.vstIInfo.hasEditor)
                {
                    KMCGlobals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(KMCGlobals._VSTHandle, 1);
                    KMCGlobals._plm.CalcRMS = true;
                    BASSVSTShowDialog(KMCGlobals._recHandle, KMCGlobals._VSTHandle, KMCGlobals.vstIInfo);
                }
                KMCGlobals._myVSTSync = new SYNCPROC(VSTProc);
                int sync = Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT, 0, KMCGlobals._myVSTSync, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private void BASSLoadSoundFonts(int type)
        {
            if (KMCGlobals.vstIInfo.isInstrument == false)
            {
                if (KMCGlobals.Soundfonts.Length == 0)
                {
                    DirectoryInfo PathToGenericSF = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    String FullPath = String.Format("{0}\\GMGeneric.sf2", PathToGenericSF.Parent.FullName);
                    if (File.Exists(FullPath))
                    {
                        BASS_MIDI_FONTEX[] fonts = new BASS_MIDI_FONTEX[1];
                        fonts[0].font = BassMidi.BASS_MIDI_FontInit(FullPath);
                        fonts[0].spreset = -1;
                        fonts[0].sbank = -1;
                        fonts[0].dpreset = -1;
                        fonts[0].dbank = 0;
                        fonts[0].dbanklsb = 0;
                        if (type == 0) { BassMidi.BASS_MIDI_FontSetVolume(fonts[0].font, ((float)KMCGlobals.Volume / 10000)); }
                        BassMidi.BASS_MIDI_StreamSetFonts(KMCGlobals._recHandle, fonts, 1);
                    }
                    else
                    {
                        throw new Exception("No soundfont available.");
                    }
                }
                else
                {
                    BASS_MIDI_FONTEX[] fonts = new BASS_MIDI_FONTEX[KMCGlobals.Soundfonts.Length];
                    int sfnum = 0;
                    foreach (string s in KMCGlobals.Soundfonts)
                    {
                        if (s.ToLower().IndexOf('=') != -1)
                        {
                            var matches = System.Text.RegularExpressions.Regex.Matches(s, "[0-9]+");
                            string sf = s.Substring(s.LastIndexOf('|') + 1);
                            fonts[sfnum].font = BassMidi.BASS_MIDI_FontInit(sf);
                            fonts[sfnum].spreset = Convert.ToInt32(matches[0].ToString());
                            fonts[sfnum].sbank = Convert.ToInt32(matches[1].ToString());
                            fonts[sfnum].dpreset = Convert.ToInt32(matches[2].ToString());
                            fonts[sfnum].dbank = Convert.ToInt32(matches[3].ToString());
                            fonts[sfnum].dbanklsb = 0;
                            if (type == 0) { BassMidi.BASS_MIDI_FontSetVolume(fonts[sfnum].font, ((float)KMCGlobals.Volume / 10000)); }
                            sfnum++;
                        }
                        else
                        {
                            fonts[sfnum].font = BassMidi.BASS_MIDI_FontInit(s);
                            fonts[sfnum].spreset = -1;
                            fonts[sfnum].sbank = -1;
                            fonts[sfnum].dpreset = -1;
                            fonts[sfnum].dbank = 0;
                            fonts[sfnum].dbanklsb = 0;
                            if (type == 0) { BassMidi.BASS_MIDI_FontSetVolume(fonts[sfnum].font, ((float)KMCGlobals.Volume / 10000)); }
                            sfnum++;
                        }
                    }
                    BassMidi.BASS_MIDI_StreamSetFonts(KMCGlobals._recHandle, fonts, fonts.Length);
                }
                BassMidi.BASS_MIDI_StreamLoadSamples(KMCGlobals._recHandle);
            }
        }

        private void BASSStreamSystem(String str, int type)
        {
            try
            {
                KMCGlobals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_MIDI_DECAYEND, 0);

                if (type == 1)
                {
                    KMCGlobals._myWasapi = new WASAPIPROC(MyWasapiProc);
                    BassWasapi.BASS_WASAPI_Init(-1, 0, 0, BASSWASAPIInit.BASS_WASAPI_EVENT | BASSWASAPIInit.BASS_WASAPI_SHARED, 0, 0, KMCGlobals._myWasapi, IntPtr.Zero);
                }

                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, KMCGlobals.Volume);
                Bass.BASS_ChannelSetAttribute(KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, KMCGlobals.LimitVoicesInt);
                Bass.BASS_ChannelSetAttribute(KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 0);
                if (Path.GetFileNameWithoutExtension(str).Length >= 49)
                    KMCGlobals.NewWindowName = Path.GetFileNameWithoutExtension(str).Truncate(45);
                else
                    KMCGlobals.NewWindowName = Path.GetFileNameWithoutExtension(str);

                BASSTempoSetSync();

                KMCGlobals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(KMCGlobals._recHandle, 1);
                KMCGlobals._plm.CalcRMS = true;
                BassMidi.BASS_MIDI_StreamLoadSamples(KMCGlobals._recHandle);
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private void BASSStreamSystemRT(String str, int type)
        {
            try
            {
                KMCGlobals._recHandle = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT, KMCGlobals.Frequency);

                KMCGlobals.StreamSizeFLAC = Bass.BASS_ChannelGetLength(KMCGlobals._recHandle);
                BASS_MIDI_EVENT[] eventChunk;
                try
                {
                    // Thank you so much Falcosoft for helping me there!!!
                    // Visit his website: http://falcosoft.hu/index.html#start
                    KMCGlobals.eventc = (UInt32)BassMidi.BASS_MIDI_StreamGetEvents(KMCGlobals._recHandle, -1, 0, null); // Counts all the events in the MIDI
                    KMCGlobals.events = new BASS_MIDI_EVENT[KMCGlobals.eventc]; // Creates an array with the events count as size
                    for (int i = 0; i <= (KMCGlobals.eventc / 50000000); i++)
                    {
                        int subCount = Math.Min(50000000, (int)KMCGlobals.eventc - (i * 50000000));
                        eventChunk = new BASS_MIDI_EVENT[subCount];
                        BassMidi.BASS_MIDI_StreamGetEvents(KMCGlobals._recHandle, -1, 0, eventChunk, i * 50000000, subCount); //Falcosoft: to avoid marshalling errors pass the smaller local buffer to the function   
                        eventChunk.CopyTo(KMCGlobals.events, i * 50000000); //Falcosoft: copy local buffer to global one at each iteration
                    }
                    eventChunk = null;
                }
                catch (Exception ex)
                {
                    throw new MIDILoadError("Can not load this MIDI.\n\n" +
                        "Are you sure you're not trying to open it in the 32-bit version of Keppy's MIDI Converter?\n" +
                        "Also, try increasing the size of your paging file, you might not have enough RAM.\n\n" +
                        "Additional info:\n" + ex.ToString());
                }
                Bass.BASS_StreamFree(KMCGlobals._recHandle);
                KMCGlobals._recHandle = BassMidi.BASS_MIDI_StreamCreate(16, BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_SAMPLE_SOFTWARE, KMCGlobals.Frequency);
                BassWasapi.BASS_WASAPI_SetVolume(BASSWASAPIVolume.BASS_WASAPI_VOL_SESSION, ((float)KMCGlobals.Volume / 10000.0f));
                Bass.BASS_ChannelSetAttribute(KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, KMCGlobals.LimitVoicesInt);
                Bass.BASS_ChannelSetAttribute(KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_CPU, 0);

                SetTempo(true, true);
                KMCGlobals._myTempoSync = new SYNCPROC(TempoSync);
                Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT | BASSSync.BASS_SYNC_MIXTIME, (long)BASSMIDIEvent.MIDI_EVENT_TEMPO, KMCGlobals._myTempoSync, IntPtr.Zero);
                Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_SETPOS | BASSSync.BASS_SYNC_MIXTIME, 0, KMCGlobals._myTempoSync, IntPtr.Zero);

                if (Path.GetFileNameWithoutExtension(str).Length >= 49)
                    KMCGlobals.NewWindowName = Path.GetFileNameWithoutExtension(str).Truncate(45);
                else
                    KMCGlobals.NewWindowName = Path.GetFileNameWithoutExtension(str);
                KMCGlobals._plm = new Un4seen.Bass.Misc.DSP_PeakLevelMeter(KMCGlobals._recHandle, 1);
                KMCGlobals._plm.CalcRMS = true;
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private void BASSTempoSetSync()
        {
            SetTempo(true, true);
            KMCGlobals._myTempoSync = new SYNCPROC(TempoSync);
            Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT | BASSSync.BASS_SYNC_MIXTIME, (long)BASSMIDIEvent.MIDI_EVENT_TEMPO, KMCGlobals._myTempoSync, IntPtr.Zero);
            Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_SETPOS | BASSSync.BASS_SYNC_MIXTIME, 0, KMCGlobals._myTempoSync, IntPtr.Zero);
        }

        private void BASSEffectSettings()
        {
            if (KMCGlobals.FXDisabled == true)
            {
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
            }
            else
            {
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), 0, BASSFlag.BASS_MIDI_NOFX);
            }
            if (KMCGlobals.NoteOff1Event == true)
            {
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
            }
            else
            {
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), 0, BASSFlag.BASS_MIDI_NOTEOFF1);
            }
        }

        private string EncoderString(String encpath, String str, String ext, String argstoadd)
        {
            if (ext == "wav")
            {
                return String.Format("{0}.{1}", str, ext);
            }
            else
            {
                return String.Format("{0} {1} \"{2}.{3}\"", encpath, argstoadd, str, ext);
            }
        }

        private BASSEncode IsOgg(int format)
        {
            string str = "";
            switch (format)
            {
                case 0:
                    return BASSEncode.BASS_ENCODE_PCM;
                default:
                    return (BASSEncode)0;
            }
            return BASSEncode.BASS_ENCODE_PCM;
        }

        private void BASSEncoderInit(Int32 format, String str)
        {
            try
            {
                var encoders = KMCGlobals.EncodersPath.ToArray();
                string pathwithoutext = String.Format("{0}\\{1}", KMCGlobals.ExportWhereYay, Path.GetFileNameWithoutExtension(str));
                string ext;
                string enc;
                string args;
                int copynum = 1;
                if (format == 1)
                {
                    foreach (Process proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(encoders[0])))
                    {
                        proc.Kill();
                    }
                    ext = "ogg";
                    enc = encoders[0];
                    if (KMCGlobals.QualityOverride == true)
                    {
                        args = String.Format("--managed -b {0} -m {0} -M {0} - -o", KMCGlobals.Bitrate.ToString());
                    }
                    else
                    {
                        args = "- -o";
                    }
                }
                else if (format == 2)
                {
                    foreach (Process proc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(encoders[1])))
                    {
                        proc.Kill();
                    }
                    ext = "mp3";
                    enc = encoders[1];
                    if (KMCGlobals.QualityOverride == true)
                    {
                        args = String.Format("-m j -b {0} - ", KMCGlobals.Bitrate.ToString());
                    }
                    else
                    {
                        args = "-m j -b 192 - ";
                    }
                }
                else
                {
                    ext = "wav";
                    enc = null;
                    args = "";
                }
                if (File.Exists(String.Format("{0}.{1}", pathwithoutext, ext)))
                {
                    string temp;
                    string finalpath;
                    do
                    {
                        temp = String.Format("{0} ({1} {2})", pathwithoutext, res_man.GetString("CopyText", cul), copynum);
                        ++copynum;
                    } while (File.Exists(String.Format("{0}.{1}", temp, ext)));
                    BassEnc.BASS_Encode_Stop(KMCGlobals._VSTHandle);
                    BassEnc.BASS_Encode_Stop(KMCGlobals._recHandle);
                    KMCGlobals._Encoder = BassEnc.BASS_Encode_Start((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), EncoderString(enc, temp, ext, args), BASSEncode.BASS_ENCODE_AUTOFREE | IsOgg(format), null, IntPtr.Zero);
                    ID3Meta.FileToEdit = EncoderString(enc, temp, ext, args);
                    // MessageBox.Show(EncoderString(enc, temp, ext, args));
                }
                else
                {
                    BassEnc.BASS_Encode_Stop(KMCGlobals._VSTHandle);
                    BassEnc.BASS_Encode_Stop(KMCGlobals._recHandle);
                    KMCGlobals._Encoder = BassEnc.BASS_Encode_Start((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), EncoderString(enc, pathwithoutext, ext, args), BASSEncode.BASS_ENCODE_AUTOFREE | IsOgg(format), null, IntPtr.Zero);
                    ID3Meta.FileToEdit = EncoderString(enc, pathwithoutext, ext, args);
                    // MessageBox.Show(EncoderString(enc, pathwithoutext, ext, args));
                }
            }
            catch (Exception ex)
            {
                BASSCloseStreamCrash(ex);
            }
        }

        private byte[] ReturnMetadata(String ToConvert)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(ToConvert);
            return bytes;
        }

        private int BASSPlayBackEngine(int notes, int length, long pos)
        {
            int pnotes = notes;
            int tempo = BassMidi.BASS_MIDI_StreamGetEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO);
            KMCGlobals.OriginalTempo = 60000000 / tempo;

            if (KMCGlobals.FXDisabled == true)
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), BASSFlag.BASS_MIDI_NOFX, BASSFlag.BASS_MIDI_NOFX);
            else
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), 0, BASSFlag.BASS_MIDI_NOFX);
            if (KMCGlobals.NoteOff1Event == true)
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), BASSFlag.BASS_MIDI_NOTEOFF1, BASSFlag.BASS_MIDI_NOTEOFF1);
            else
                Bass.BASS_ChannelFlags((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), 0, BASSFlag.BASS_MIDI_NOTEOFF1);

            BassWasapi.BASS_WASAPI_SetVolume(BASSWASAPIVolume.BASS_WASAPI_VOL_SESSION, ((float)KMCGlobals.Volume / 10000.0f));
            Bass.BASS_ChannelSetAttribute(KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES, KMCGlobals.LimitVoicesInt);

            System.Threading.Thread.Sleep(1);

            if (!KMCGlobals.DoNotCountNotes)
                return pnotes;
            else
                return 0;
        }

        private bool BASSEncodingEngine(long pos, int length)
        {
            int tempo = BassMidi.BASS_MIDI_StreamGetEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO);
            KMCGlobals.OriginalTempo = 60000000 / tempo;
            byte[] buffer = new byte[length];

            int gotm;
            int got;
            if (KMCGlobals.vstIInfo.isInstrument)
            {
                gotm = Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
                got = Bass.BASS_ChannelGetData(KMCGlobals._VSTHandle, buffer, length);
            }
            else
            {
                gotm = Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
            }
            if (gotm < 0)
            {
                KMCGlobals.CancellationPendingValue = 2;
                return false;
            }

            return true;
        }

        private bool BASSEncodingEngineRT(double[] CustomFramerates, ref int pos, ref uint es)
        {
            double fpssim = FPSSimulator.NextDouble() * (CustomFramerates[0] - CustomFramerates[1]) + CustomFramerates[1];
            int length = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), fpssim));
            byte[] buffer = new byte[length];

            while (es < KMCGlobals.eventc && KMCGlobals.events[es].pos < pos + length)
            {
                BassMidi.BASS_MIDI_StreamEvent(KMCGlobals._recHandle, KMCGlobals.events[es].chan, KMCGlobals.events[es].eventtype, KMCGlobals.events[es].param);
                es++;
            }

            int gotm;
            int got;
            if (KMCGlobals.vstIInfo.isInstrument)
            {
                gotm = Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
                got = Bass.BASS_ChannelGetData(KMCGlobals._VSTHandle, buffer, length);
            }
            else
            {
                gotm = Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
            }

            if (gotm < 0)
            {
                KMCGlobals.CancellationPendingValue = 2;
                return false;
            }
            pos += gotm;
            if (es == KMCGlobals.eventc)
            {
                BassMidi.BASS_MIDI_StreamEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_END, 0);
            }

            float fpsstring = 1 / (float)fpssim;

            return true;
        }

        private delegate ListView.ListViewItemCollection GetItems(ListView lstview);
        private ListView.ListViewItemCollection getListViewItems(ListView lstview)
        {
            ListView.ListViewItemCollection temp = new ListView.ListViewItemCollection(new ListView());
            if (!lstview.InvokeRequired)
            {
                foreach (ListViewItem item in lstview.Items)
                    temp.Add((ListViewItem)item.Clone());
                return temp;
            }
            else
                return (ListView.ListViewItemCollection)this.Invoke(new GetItems(getListViewItems), new object[] { lstview });
        }

        private void BASSSetID3(bool terminate)
        {           
            //if (terminate)
            //    Bass.BASS_StreamFree(KMCGlobals._recHandle);
            //UltraID3 u = new UltraID3();
            //u.Read(ID3Meta.FileToEdit);
            //u.Artist = "Converted through Keppy's MIDI Converter";
            //u.Write();
        }

        private void BASSCloseStream(string message, string title, int type) {
            KMCGlobals.DoNotCountNotes = false;
            BassWasapi.BASS_WASAPI_Stop(true);
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_StreamFree(KMCGlobals._recHandle);
            Bass.BASS_Free();
            KMCGlobals.CurrentStatusTextString = message;
            KMCGlobals.ActiveVoicesInt = 0;
            KMCGlobals.NewWindowName = null;
            KMCGlobals.IsKMCBusy = false;
            KMCGlobals.RenderingMode = false;
            KMCGlobals.DoNotCountNotes = false;
            KMCGlobals.eventc = 0;
            KMCGlobals.events = null;
            RTF.CPUUsage = 0.0f;
            RTF.ActiveVoices = 0.0f;
            if (type == 0)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            KMCGlobals.CancellationPendingValue = 0;
            KMCGlobals.CurrentStatusTextString = null;
            PlayConversionStop();
        }

        private void BASSCloseStreamCrash(Exception ex)
        {
            BassWasapi.BASS_WASAPI_Stop(true);
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_StreamFree(KMCGlobals._recHandle);
            Bass.BASS_Free();
            KMCGlobals.NewWindowName = null;
            KMCGlobals.IsKMCBusy = false;
            KMCGlobals.RenderingMode = false;
            KMCGlobals.DoNotCountNotes = false;
            KMCGlobals.eventc = 0;
            KMCGlobals.events = null;
            KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), ex.ToString(), 0, 1);
            errordialog.ShowDialog();
        }

        private void ReleaseResources(bool stillrendering)
        {
            KMCGlobals.DoNotCountNotes = false;
            BassWasapi.BASS_WASAPI_Stop(true);
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_StreamFree(KMCGlobals._recHandle);
            Bass.BASS_Free();
            KMCGlobals.IsKMCBusy = stillrendering;
            KMCGlobals.IsKMCNowExporting = false;
            KMCGlobals.RenderingMode = stillrendering;
            KMCGlobals.eventc = 0;
            KMCGlobals.events = null;
        }

        private void clearMIDIsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void ConverterProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    PlayConversionStart();         
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (ListViewItem itemerino in getListViewItems(MIDIList))
                        {
                            BASSInitSystem(0);
                            string str = itemerino.Text;
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSStreamSystem(str, 0);
                            BASSLoadSoundFonts(0);
                            BASSInitVSTiIfNeeded();
                            BASSVSTInit((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle));
                            BASSEffectSettings();
                            BASSEncoderInit(KMCGlobals.CurrentEncoder, str);
                            long pos = Bass.BASS_ChannelGetLength(KMCGlobals._recHandle);
                            int length = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes(KMCGlobals._recHandle, 0.03));
                            KMCGlobals.IsKMCNowExporting = true;
                            bool DoINeedToContinue;
                            while (true)
                            {
                                if (KMCGlobals.CancellationPendingValue != 1)
                                {
                                    DoINeedToContinue = BASSEncodingEngine(pos, length);
                                    if (!DoINeedToContinue) break;
                                }
                                else if (KMCGlobals.CancellationPendingValue == 1)
                                {
                                    BASSSetID3(true);
                                    BASSCloseStream(MainWindow.res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
                                    KeepLooping = false;
                                    break;
                                }
                            }
                            if (KMCGlobals.CancellationPendingValue == 1)
                            {
                                ReleaseResources(false);
                                KeepLooping = false;
                                BASSSetID3(false);
                                break;
                            }
                            else
                            {
                                ReleaseResources(true);
                                KeepLooping = false;
                                BASSSetID3(true);
                                continue;
                            }
                        }
                        if (KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSCloseStream(MainWindow.res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
                            BASSSetID3(false);
                            KeepLooping = false;
                            KMCGlobals.RenderingMode = false;
                            KMCGlobals.IsKMCBusy = false;
                            KMCGlobals.IsKMCNowExporting = false;
                            KMCGlobals.VSTSkipSettings = false;
                            PlayConversionStop();
                        }
                        else
                        {
                            BASSCloseStream(MainWindow.res_man.GetString("ConversionCompleted", cul), res_man.GetString("ConversionCompleted", cul), 1);
                            BASSSetID3(false);
                            KeepLooping = false;
                            KMCGlobals.RenderingMode = false;
                            KMCGlobals.IsKMCBusy = false;
                            KMCGlobals.IsKMCNowExporting = false;
                            KMCGlobals.VSTSkipSettings = false;
                            if (KMCGlobals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            if (KMCGlobals.AutoClearMIDIListEnabled == true)
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
                    WriteToConsole(exception);
                }
            }
            catch (Exception exception2)
            {
                BASSCloseStreamCrash(exception2);
            }
        }

        private void ReturnCustomFramerate(out double[] fpsarr)
        {
            fpsarr = new double[2] { (1.0 / KMCGlobals.RTFPS) - 0.00005556, (1.0 / KMCGlobals.RTFPS) + 0.00005556 };
        }

        private void ConverterProcessRT_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    PlayConversionStart();
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (ListViewItem itemerino in getListViewItems(MIDIList))
                        {
                            BASSInitSystem(0);
                            double[] CustomFramerates;
                            ReturnCustomFramerate(out CustomFramerates);
                            string str = itemerino.Text;
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSStreamSystemRT(str, 0);
                            BASSLoadSoundFonts(0);
                            BASSInitVSTiIfNeeded();
                            BASSVSTInit((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle));
                            BASSEffectSettings();
                            BASSEncoderInit(KMCGlobals.CurrentEncoder, str);
                            int pos = 0;
                            uint es = 0;
                            FPSSimulator.NextDouble();
                            KMCGlobals.IsKMCNowExporting = true;
                            bool DoINeedToContinue;
                            for (pos = 0, es = 0; ; )
                            {
                                if (KMCGlobals.CancellationPendingValue != 1)
                                {
                                    DoINeedToContinue = BASSEncodingEngineRT(CustomFramerates, ref pos, ref es);
                                    if (!DoINeedToContinue) break;
                                }
                                else if (KMCGlobals.CancellationPendingValue == 1)
                                {
                                    BASSCloseStream(MainWindow.res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
                                    ReleaseResources(false);
                                    KeepLooping = false;
                                    BASSSetID3(false);
                                    break;
                                }
                                else if (KMCGlobals.CancellationPendingValue == 2)
                                {
                                    ReleaseResources(true);
                                    KeepLooping = false;
                                    BASSSetID3(true);
                                    continue;
                                }
                            }
                            if (KMCGlobals.CancellationPendingValue == 1)
                            {
                                KMCGlobals.events = null;
                                KMCGlobals.RenderingMode = false;
                                KMCGlobals.IsKMCBusy = false;
                                KMCGlobals.IsKMCNowExporting = false;
                                KMCGlobals.VSTSkipSettings = false;
                                break;
                            }
                            else
                            {
                                BASSSetID3(true);
                                KMCGlobals.events = null;
                                continue;
                            }
                        }
                        if (KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSCloseStream(MainWindow.res_man.GetString("ConversionAborted", cul), res_man.GetString("ConversionAborted", cul), 0);
                            BASSSetID3(false);
                            KeepLooping = false;
                            KMCGlobals.IsKMCBusy = false;
                            KMCGlobals.IsKMCNowExporting = false;
                            KMCGlobals.RenderingMode = false;
                            KMCGlobals.VSTSkipSettings = false;
                            KMCGlobals.eventc = 0;
                            KMCGlobals.events = null;
                            PlayConversionStop();
                        }
                        else
                        {
                            BASSCloseStream(MainWindow.res_man.GetString("ConversionCompleted", cul), res_man.GetString("ConversionCompleted", cul), 1);
                            BASSSetID3(false);
                            KMCGlobals.IsKMCBusy = false;
                            KMCGlobals.IsKMCNowExporting = false; 
                            KMCGlobals.RenderingMode = false;
                            KMCGlobals.VSTSkipSettings = false;
                            KeepLooping = false;
                            KMCGlobals.eventc = 0;
                            KMCGlobals.events = null;
                            if (KMCGlobals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            if (KMCGlobals.AutoClearMIDIListEnabled == true)
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
                    WriteToConsole(exception);
                }
            }
            catch (Exception exception2)
            {
                BASSCloseStreamCrash(exception2);
            }
        }

        private void RealTimePlayBack_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    PlayConversionStart();
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (ListViewItem itemerino in getListViewItems(MIDIList))
                        {
                            KMCStatus.PlayedNotes = 0;
                            BASSInitSystem(1);
                            string str = itemerino.Text;
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            string encpath = null;
                            BASSStreamSystem(str, 1);
                            BASSLoadSoundFonts(1);
                            BASSInitVSTiIfNeeded();
                            BASSVSTInit((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle));
                            BASSEffectSettings();
                            long pos = Bass.BASS_ChannelGetLength((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle));
                            // cac
                            int notes = 0;
                            if (!KMCGlobals.DoNotCountNotes)
                            {
                                try
                                {
                                    KMCGlobals._mySync = new SYNCPROC(NoteSyncProc);
                                    int sync = Bass.BASS_ChannelSetSync(KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT, (long)BASSMIDIEvent.MIDI_EVENT_NOTE, KMCGlobals._mySync, IntPtr.Zero);
                                    KMCStatus.TotalNotesOrg = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(KMCGlobals._recHandle, -1, (BASSMIDIEvent)0x20000, null);
                                    KMCStatus.TotalNotes = KMCStatus.TotalNotesOrg;
                                }
                                catch (Exception ex)
                                {
                                    WriteToConsole(ex);
                                    KMCGlobals.DoNotCountNotes = true;
                                }
                            }
                            KMCGlobals.IsKMCNowExporting = true;
                            int length = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle), 1.0));
                            BassWasapi.BASS_WASAPI_Start();
                            while (Bass.BASS_ChannelIsActive((KMCGlobals.vstIInfo.isInstrument ? KMCGlobals._VSTHandle : KMCGlobals._recHandle)) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (KMCGlobals.CancellationPendingValue != 1)
                                {
                                    notes = BASSPlayBackEngine(notes, length, pos);
                                }
                                else if (KMCGlobals.CancellationPendingValue == 1)
                                {
                                    BassWasapi.BASS_WASAPI_Stop(true);
                                    break;
                                }
                            }
                            if (KMCGlobals.CancellationPendingValue == 1)
                            {
                                BASSCloseStream(MainWindow.res_man.GetString("PlaybackAborted", cul), res_man.GetString("PlaybackAborted", cul), 0);
                                ReleaseResources(false);
                                KeepLooping = false;
                                BASSSetID3(false);
                                break;
                            }
                            else
                            {
                                ReleaseResources(true);
                                KeepLooping = false;
                                BASSSetID3(true);
                                continue;
                            }
                        }
                        if (KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSCloseStream(MainWindow.res_man.GetString("PlaybackAborted", cul), res_man.GetString("PlaybackAborted", cul), 1);
                        }
                        else
                        {
                            BASSCloseStream("null", "null", 1);
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    WriteToConsole(exception);
                    ReleaseResources(false);
                    BASSSetID3(false);
                }
            }
            catch (Exception exception2)
            {
                BASSCloseStreamCrash(exception2);
            }
        }

        private void WriteToConsole(Exception exception)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Time of the exception: " + DateTime.Now.ToString());
            Console.WriteLine();
            Console.Write("An error has been encountered during the playback/conversion process.");
            Console.WriteLine();
            Console.Write(exception.ToString());
            Console.WriteLine();
            Console.Write("The converter will now try to continue...");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void SetTempo(bool reset, bool isitworker)
        {
            if (isitworker)
            {
                if (reset) KMCGlobals.MIDITempo = BassMidi.BASS_MIDI_StreamGetEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO); // get the file's tempo
                BassMidi.BASS_MIDI_StreamEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO, Convert.ToInt32(KMCGlobals.MIDITempo * KMCGlobals.TempoScale));   // set tempo
            }
            else
            {
                new Thread(() =>
                {
                    if (reset) KMCGlobals.MIDITempo = BassMidi.BASS_MIDI_StreamGetEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO); // get the file's tempo
                    BassMidi.BASS_MIDI_StreamEvent(KMCGlobals._recHandle, 0, BASSMIDIEvent.MIDI_EVENT_TEMPO, Convert.ToInt32(KMCGlobals.MIDITempo * KMCGlobals.TempoScale));   // set tempo
                }).Start();
            }
        }

        private void TempoSync(int handle, int channel, int data, IntPtr user)
        {
            SetTempo(true, true);
        }

        private void NoteSyncProc(int handle, int channel, int data, IntPtr user)
        {
            if ((data & 0xff00) != 0)
            {
                ++KMCStatus.PlayedNotes;
            }
        }

        private void VSTProc(int handle, int channel, int data, IntPtr user)
        {
            int evento = (data >> 24);
            int midichan = (data >> 16) & 0xff;
            int param = (data & 0xffff);
            BassVst.BASS_VST_ProcessEvent(KMCGlobals._VSTHandle, midichan, (BASSMIDIEvent)evento, param);
        }

        private int MyWasapiProc(IntPtr buffer, Int32 length, IntPtr user)
        {
            if (KMCGlobals.vstIInfo.isInstrument)
            {
                int d1 = Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
                int d2 = Bass.BASS_ChannelGetData(KMCGlobals._VSTHandle, buffer, length);
                return (KMCGlobals.vstIInfo.isInstrument ? d2 : d1);
            }
            else
            {
                return Bass.BASS_ChannelGetData(KMCGlobals._recHandle, buffer, length);
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
            if (Bass.BASS_ChannelIsActive(KMCGlobals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show(MainWindow.res_man.GetString("AppBusy", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    CloseApp();
                }
            }
            else
            {
                CloseApp();
            }
        }

        private void CloseApp()
        {
            timeEndPeriod(timerAccuracy);
            Bass.BASS_StreamFree(KMCGlobals._recHandle);
            Bass.BASS_Free();
            if (KMCGlobals.DeleteEncoder == true)
            {
                foreach (string i in KMCGlobals.EncodersPath)
                {
                    File.Delete(i);
                }
            }
            Process.GetCurrentProcess().Kill();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) Process.GetCurrentProcess().Kill();

            // Confirm user wants to close
            if (Bass.BASS_ChannelIsActive(KMCGlobals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show(MainWindow.res_man.GetString("AppBusy", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    CloseApp();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                CloseApp();
            }
        }

        private long GetMIDILength(string str)
        {
            Bass.BASS_Init(0, 22050, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
            Int32 time = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE, 0);
            return Bass.BASS_ChannelGetLength(time);
            Bass.BASS_StreamFree(time);
            Bass.BASS_Free();
        }

        private string[] GetMoreInfoMIDI(string str, bool overridedefault)
        {
            try
            {
                // Get size of MIDI
                long length = new System.IO.FileInfo(str).Length;
                string size;
                try
                {
                    if (length / 1024f >= 1000000000)
                        size = ((((length / 1024f) / 1024f) / 1024f) / 1024f).ToString("0.0 TB");
                    else if (length / 1024f >= 1000000)
                        size = (((length / 1024f) / 1024f) / 1024f).ToString("0.0 GB");
                    else if (length / 1024f >= 1000)
                        size = ((length / 1024f) / 1024f).ToString("0.0 MB");
                    else if (length / 1024f >= 1)
                        size = (length / 1024f).ToString("0.0 KB");
                    else
                        size = (length).ToString("0 B");
                }
                catch { size = "-"; }

                // If the MIDI is too big, skip data parsing
                if (length / 1024f >= 9860)
                {
                    // If the user is not holding CTRL, skip the data parsing
                    if (!overridedefault)
                    {
                        return new string[] { "N/A", "N/A", size, };
                    }
                }

                Bass.BASS_Init(0, 22050, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                Int32 time = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE, 0);
                Int64 pos = Bass.BASS_ChannelGetLength(time);
                Double num9 = Bass.BASS_ChannelBytes2Seconds(time, pos);
                TimeSpan span = TimeSpan.FromSeconds(num9);

                // Get length of MIDI
                string str4 = span.Minutes.ToString() + ":" + span.Seconds.ToString().PadLeft(2, '0') + "." + span.Milliseconds.ToString().PadLeft(3, '0');

                UInt64 count = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(time, -1, (BASSMIDIEvent)0x20000, null);

                Bass.BASS_Free();
                return new string[] { str4, count.ToString("N0"), size, };
            }
            catch (Exception ex) {
                MessageBox.Show(String.Format("There's no enough memory to get the info for this MIDI:\n{0}", str), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new string[] { "N/A", "N/A", "N/A", };
            }     
        }

        private void ToAddOrNotToAdd(ListViewItem lvi, string notes, string str)
        {
            if (notes == "0" || GetMIDILength(str) == -1) MessageBox.Show(String.Format(MainWindow.res_man.GetString("InvalidMIDIFile", cul), Path.GetFileName(str)), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MIDIList.Items.Add(lvi);
        }

        private void importMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean overridedefault = false;
            MIDIImport.Title = res_man.GetString("ImportMIDIWindow", cul);
            MIDIImport.InitialDirectory = Properties.Settings.Default.LastMIDIFolder;
            if (ModifierKeys == Keys.Control)
            {
                overridedefault = true;
                MessageBox.Show("The converter will ignore the size of the MIDIs, and get their full info anyway.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                AddFilesToList(MIDIImport.FileNames, true, overridedefault);
            }
        }

        private void MIDIList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Boolean overridedefault = false;
            if (ModifierKeys == Keys.Control)
            {
                overridedefault = true;
                MessageBox.Show("The converter will ignore the size of the MIDIs, and get their full info anyway.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            AddFilesToList(s, false, overridedefault);
        }

        private void MIDIList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void AddFilesToList(String[] filenames, Boolean IsImportDialog, Boolean GetEntireSize)
        {
            if (ModifierKeys == Keys.Shift)
            {
                foreach (string str in filenames)
                {
                    if (Path.GetExtension(str).ToLower() == ".mid" || Path.GetExtension(str).ToLower() == ".midi" || Path.GetExtension(str).ToLower() == ".kar" || Path.GetExtension(str).ToLower() == ".rmi")
                    {
                        Int32 UserAnswer = Int32.Parse(Microsoft.VisualBasic.Interaction.InputBox(
                            String.Format("How many times do you want to add this MIDI?\n{0}", str), Title, "1"));

                        if (UserAnswer == 0 || UserAnswer == null) UserAnswer = 1;

                        for (int i = 0; i < UserAnswer; i++)
                        {
                            string[] saLvwItem = new string[4];
                            string[] midiinfo = GetMoreInfoMIDI(str, GetEntireSize);
                            saLvwItem[0] = str;
                            saLvwItem[1] = midiinfo[1];
                            saLvwItem[2] = midiinfo[0];
                            saLvwItem[3] = midiinfo[2];
                            ListViewItem lvi = new ListViewItem(saLvwItem);
                            ToAddOrNotToAdd(lvi, midiinfo[1], filenames[0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Format(MainWindow.res_man.GetString("InvalidMIDIFile", cul), Path.GetFileName(str)), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                foreach (string str in filenames)
                {
                    if (Path.GetExtension(str).ToLower() == ".mid" || Path.GetExtension(str).ToLower() == ".midi" || Path.GetExtension(str).ToLower() == ".kar" || Path.GetExtension(str).ToLower() == ".rmi")
                    {
                        string[] saLvwItem = new string[4];
                        string[] midiinfo = GetMoreInfoMIDI(str, GetEntireSize);
                        saLvwItem[0] = str;
                        saLvwItem[1] = midiinfo[1];
                        saLvwItem[2] = midiinfo[0];
                        saLvwItem[3] = midiinfo[2];
                        ListViewItem lvi = new ListViewItem(saLvwItem);
                        ToAddOrNotToAdd(lvi, midiinfo[1], str);
                    }
                    else
                    {
                        MessageBox.Show(String.Format(MainWindow.res_man.GetString("InvalidMIDIFile", cul), Path.GetFileName(str)), res_man.GetString("Error", cul), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                KMCGlobals.MIDILastDirectory = Path.GetDirectoryName(filenames[0]);
                Properties.Settings.Default.LastMIDIFolder = KMCGlobals.MIDILastDirectory;
                Properties.Settings.Default.Save();
            }
        }

        private void informationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Informations().ShowDialog();
        }

        private void OverrideStrip_Click(object sender, EventArgs e)
        {
            new OverrideLanguage().ShowDialog();
            RenderingTimer.Enabled = false;
            InitializeLanguage();
            RenderingTimer.Enabled = true;
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

        private void MoveUpItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(MIDIList, MoveDirection.Up);
        }

        private void MoveDownItem_Click(object sender, EventArgs e)
        {
            MoveListViewItems(MIDIList, MoveDirection.Down);
        }

        private void SortByName_Click(object sender, EventArgs e)
        {
            MIDIList.Sorting = SortOrder.Ascending;
            MIDIList.Sorting = SortOrder.None;
        }

        private static void MoveListViewItems(ListView sender, MoveDirection direction)
        {
            int dir = (int)direction;
            int opp = dir * -1;

            bool valid = sender.SelectedItems.Count > 0 &&
                            ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                        || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

            if (valid)
            {
                foreach (ListViewItem item in sender.SelectedItems)
                {
                    string str = item.Text;
                    int index = item.Index + dir;

                    sender.Items.RemoveAt(item.Index);
                    sender.Items.Insert(index, item);
                }
            }
        }

        private void MIDIList_KeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (KMCGlobals.IsKMCBusy == true)
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
                    else if (e.KeyCode == Keys.A && e.Control)
                    {
                        foreach (ListViewItem item in MIDIList.Items)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private bool Resizing = false;
        private void MIDIList_SizeChanged(object sender, EventArgs e)
        {
            if (!Resizing)
            {
                Resizing = true;
                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }
            Resizing = false;
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
            try
            {
                MIDIImport.InitialDirectory = KMCGlobals.MIDILastDirectory;
                ExportWhere.InitialDirectory = KMCGlobals.ExportLastDirectory;
                if (!KMCGlobals.AutoShutDownEnabled)
                {
                    KMCGlobals.AutoShutDownEnabled = false;
                    disabledToolStripMenuItem.Checked = true;
                }
                if (!KMCGlobals.AutoClearMIDIListEnabled)
                {
                    KMCGlobals.AutoClearMIDIListEnabled = false;
                    disabledToolStripMenuItem1.Checked = true;
                }
                if (!KMCGlobals.IsKMCBusy)
                {
                    RTF.KMCIdle();
                }
                else
                {
                    if (!KMCGlobals.IsKMCNowExporting)
                    {
                        RTF.KMCMemoryAllocation();
                    }
                    else
                    {
                        RTF.KMCBusy();
                    }
                }
                System.Threading.Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                WriteToConsole(ex);
            }
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Volume = VolumeBar.Value;
                Properties.Settings.Default.Save();
                KMCGlobals.Volume = Convert.ToInt32(this.VolumeBar.Value);
                VolumeTip.SetToolTip(VolumeBar, String.Format("{0} {1}", res_man.GetString("Volume", cul), ((float)KMCGlobals.Volume / 100).ToString("000.00") + "%"));
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void VoiceLimit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Voices = (int)VoiceLimit.Value;
                Properties.Settings.Default.Save();
                KMCGlobals.LimitVoicesInt = Convert.ToInt32(VoiceLimit.Value.ToString());
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void AdvSettingsButton_Click(object sender, EventArgs e)
        {
            if (KMCGlobals.IsKMCBusy == true && KMCGlobals.RenderingMode == false)
            {
                if (!KMCGlobals.frm.Visible)
                {
                    KMCGlobals.frm.Show();
                }
                else
                {
                    KMCGlobals.frm.Focus();
                }
            }
            else
            {
                KMCGlobals.frm.ShowDialog();
            }          
        }

        private void UsedVoices_Click(object sender, EventArgs e)
        {
            try
            {
                AdvancedVoices vfrm = new AdvancedVoices();
                vfrm.Show();
            }
            catch { }
        }

        private void openTheSoundfontsManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMCGlobals.frm2.ShowDialog();
        }

        private void DefMenu_Popup(object sender, EventArgs e)
        {
            if (MIDIList.Items.Count < 1)
            {
                RemoveMIDIsRightClick.Enabled = false;
                ClearMIDIsListRightClick.Enabled = false;
                SortByName.Enabled = false;
                MoveUpItem.Enabled = false;
                MoveDownItem.Enabled = false;
            }
            else if (MIDIList.Items.Count < 2)
            {
                RemoveMIDIsRightClick.Enabled = true;
                ClearMIDIsListRightClick.Enabled = true;
                SortByName.Enabled = false;
                MoveUpItem.Enabled = false;
                MoveDownItem.Enabled = false;
            }
            else
            {
                RemoveMIDIsRightClick.Enabled = true;
                ClearMIDIsListRightClick.Enabled = true;
                SortByName.Enabled = true;
                MoveUpItem.Enabled = true;
                MoveDownItem.Enabled = true;
            }
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = true;
            disabledToolStripMenuItem.Checked = false;
            KMCGlobals.AutoShutDownEnabled = true;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = true;
            KMCGlobals.AutoShutDownEnabled = false;
        }

        private void enabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem1.Checked = true;
            disabledToolStripMenuItem1.Checked = false;
            KMCGlobals.AutoClearMIDIListEnabled = true;
        }

        private void disabledToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            enabledToolStripMenuItem1.Checked = false;
            disabledToolStripMenuItem1.Checked = true;
            KMCGlobals.AutoClearMIDIListEnabled = false;
        }

        private void enabledToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioEvents = true;
            Properties.Settings.Default.Save();
            enabledToolStripMenuItem4.Checked = true;
            disabledToolStripMenuItem4.Checked = false;
        }

        private void disabledToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioEvents = false;
            Properties.Settings.Default.Save();
            enabledToolStripMenuItem4.Checked = false;
            disabledToolStripMenuItem4.Checked = true;
        }

        private void enabledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpdateCheck = true;
            Properties.Settings.Default.Save();
            enabledToolStripMenuItem3.Checked = true;
            disabledToolStripMenuItem2.Checked = false;
        }

        private void disabledToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AudioEvents = false;
            Properties.Settings.Default.Save();
            enabledToolStripMenuItem3.Checked = false;
            disabledToolStripMenuItem2.Checked = true;
        }

        private void enabledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem2.Checked = true;
                disabledToolStripMenuItem2.Checked = false;
                KMCGlobals.OldTimeThingy = true;
                Properties.Settings.Default.ShowOldTimeInfo = true;
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void disabledToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                enabledToolStripMenuItem2.Checked = false;
                disabledToolStripMenuItem2.Checked = true;
                KMCGlobals.OldTimeThingy = false;
                Properties.Settings.Default.ShowOldTimeInfo = false;
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void makeADonationToSupportTheDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Donate();
        }

        private void forceCloseTheApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(MainWindow.res_man.GetString("CrashQuestion", cul), "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                if (ModifierKeys == Keys.Shift)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", cul), res_man.GetString("CrashTriggeredByUser", cul), 0, 1);
                    errordialog.ShowDialog();
                }
                else
                {
                    this.Enabled = false;
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("FatalError", cul), res_man.GetString("CrashTriggeredByUser", cul), 1, 0);
                    RenderingTimer.Stop();
                    errordialog.ShowDialog();
                    Application.Exit();
                }
            }
        }

        public static void PlayConversionStart()
        {
            if (Properties.Settings.Default.AudioEvents)
            {
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convstart;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.PlaySync();
            }
        }

        public static void PlayConversionStop()
        {
            if (Properties.Settings.Default.AudioEvents)
            {
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convfin;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.Play();
            }
        }

        public static void PlayConverterError()
        {
            if (Properties.Settings.Default.AudioEvents)
            {
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convfail;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                player.Play();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; 
                return parms;
            }
        }

        // Snap feature

        private const int SnapDist = 25;

        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
            if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
            if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
            if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
            Refresh();
        }

        private void GarbageCollector_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Threading.Thread.Sleep(100);
            }
        }

        private void GetInfoWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (KMCGlobals.IsKMCBusy || KMCGlobals.IsKMCNowExporting)
                    {
                        RTF.TotalTicks = Bass.BASS_ChannelGetLength(KMCGlobals._recHandle, BASSMode.BASS_POS_MIDI_TICK);
                        RTF.CurrentTicks = Bass.BASS_ChannelGetPosition(KMCGlobals._recHandle, BASSMode.BASS_POS_MIDI_TICK);
                        RTF.MIDILengthRAW = Bass.BASS_ChannelGetLength(KMCGlobals._recHandle);
                        RTF.MIDICurrentPosRAW = Bass.BASS_ChannelGetPosition(KMCGlobals._recHandle);
                        RTF.RAWTotal = ((float)RTF.MIDILengthRAW) / 1048576f;
                        RTF.RAWConverted = ((float)RTF.MIDICurrentPosRAW) / 1048576f;
                        RTF.LenRAWToDouble = Bass.BASS_ChannelBytes2Seconds(KMCGlobals._recHandle, RTF.MIDILengthRAW);
                        RTF.CurRAWToDouble = Bass.BASS_ChannelBytes2Seconds(KMCGlobals._recHandle, RTF.MIDICurrentPosRAW);
                        RTF.LenDoubleToSpan = TimeSpan.FromSeconds(RTF.LenRAWToDouble * MainWindow.KMCGlobals.TempoScale);
                        RTF.CurDoubleToSpan = TimeSpan.FromSeconds(RTF.CurRAWToDouble * MainWindow.KMCGlobals.TempoScale);
                        Bass.BASS_ChannelGetAttribute(MainWindow.KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_CPU, ref RTF.CPUUsage);
                        Bass.BASS_ChannelGetAttribute(MainWindow.KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref RTF.ActiveVoices);
                        RTF.GetVoices();
                    }
                    System.Threading.Thread.Sleep(10);
                }
                catch { }
            }
        }

        private void DiscordHypeSquadRef_Click(object sender, EventArgs e)
        {
            new KeppyMIDIConverter.Forms.DiscordHypeSquad().ShowDialog();
        }

        private void ThemeCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true) Program.ThemeCheckFunction(this);
        }

        private void RealTimePreviewTrackBar_Scroll(object sender, EventArgs e)
        {
            KMCStatus.TotalNotes = KMCStatus.TotalNotesOrg + KMCStatus.PlayedNotes;
            Bass.BASS_ChannelSetPosition(KMCGlobals._recHandle, RealTimePreviewTrackBar.Value * 120, BASSMode.BASS_POS_MIDI_TICK);
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

// Custom exceptions
public class MIDILoadError : Exception
{
    public MIDILoadError()
    {
    }

    public MIDILoadError(string message)
        : base(message)
    {
    }

    public MIDILoadError(string message, Exception inner)
        : base(message, inner)
    {
    }
}

public class InvalidSoundFont : Exception
{
    public InvalidSoundFont()
    {
    }

    public InvalidSoundFont(string message)
        : base(message)
    {
    }

    public InvalidSoundFont(string message, Exception inner)
        : base(message, inner)
    {
    }
}