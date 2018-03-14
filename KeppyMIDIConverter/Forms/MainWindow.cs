using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BASS
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;
using Un4seen.Bass.AddOn.Vst;
using Un4seen.Bass.Misc;
using Un4seen.BassWasapi;

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
        public static string Title = "";
        public static MainWindow Delegate;
        public static Random FPSSimulator = new Random();

        public static class KMCDialogs
        {
            public static AdvancedSettings AdvSett = new AdvancedSettings();
            public static SoundfontDialog SFDialog = new SoundfontDialog();
            public static OpenFileDialog MIDIImport = new OpenFileDialog();
            public static CommonOpenFileDialog MIDIExport = new CommonOpenFileDialog();
            public static ToolTip VolumeTip = new ToolTip();
        }

        public static class KMCThreads
        {
            public static Timer RenderingTimer = new Timer();
            public static BackgroundWorker GarbageCollector = new BackgroundWorker();
            public static BackgroundWorker ConversionProcess = new BackgroundWorker();
            public static BackgroundWorker ConversionProcessRT = new BackgroundWorker();
            public static BackgroundWorker PlaybackProcess = new BackgroundWorker();
            public static BackgroundWorker GetInfoWorker = new BackgroundWorker();
        }

        public static class KMCGlobals
        {
            public static string[] MIDIs = null;

            public static BASS_MIDI_EVENT[] events;
            public static DSPPROC _myDSP;
            public static SYNCPROC _mySync;
            public static SYNCPROC _myVSTSync;
            public static SYNCPROC _myTempoSync;
            public static WASAPIPROC _myWasapi;
            public static UInt32 eventc;
            public static DSP_PeakLevelMeter _plm;
            public static bool AutoClearMIDIListEnabled = false;
            public static bool AutoShutDownEnabled = false;
            public static bool DoNotCountNotes = false;
            public static bool RealTime = false;
            public static bool VSTSkipSettings = false;
            public static int ActiveVoicesInt = 0;
            public static int AverageCPU;
            public static int CancellationPendingValue = 0;
            public static int CurrentEncoder;
            public static int CurrentMode;
            public static int DefaultSoundfont;
            public static int MIDITempo = 0;            // MIDI file tempo
            public static float TempoScale = 1.0f;      // Tempo adjustment
            public static int _LoudMaxHan;
            public static int OriginalTempo;
            public static int SoundFont;
            public static int Time = 0;
            public static int UpdateRate;
            public static int _Encoder;
            public static int _Mixer;
            public static int _recHandle;
            public static int _VolFX;
            public static BASS_FX_VOLUME_PARAM _VolFXParam = new BASS_FX_VOLUME_PARAM();
            public static string BenchmarkTime;
            public static string CurrentStatusTextString;
            public static string DisabledOr;
            public static string MIDIName;
            public static string NewWindowName = null;
            public static string PercentageProgress = "0";
            public static int RealTimeFreq = 44100;
            public static string WAVName;

            // Other
            public static string ExecutablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static class KMCStatus
        {
            public static Int32[] ChannelsVoices = new Int32[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            public static Int32[] ChannelsVolume = new Int32[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

            public static Boolean RenderingMode = false;
            public static Boolean VSTMode = false;
            public static Boolean IsKMCBusy = false;
            public static Boolean IsKMCNowExporting = false;

            public static UInt64 PlayedNotes = 0;
            public static UInt64 TotalNotes = 0;
            public static UInt64 TotalNotesOrg = 0;

            public static DateTime StartTime;
            public static TimeSpan PassedTime;
            public static TimeSpan EstimatedTime;
        }

        public static class VSTs
        {
            public static int[] _VSTHandles = new int[8];
            public static BASS_VST_INFO[] VSTInfo = new BASS_VST_INFO[8];
            public static string[] VSTDLLs = new string[8];
            public static string[] VSTDLLDescs = new string[8];
        }

        public static class SoundFontChain
        {
            public static string[] SoundFonts = new string[0];
        }

        public static void InitializeLanguage()
        {
            Delegate.Text = String.Format(Delegate.Text, Program.Who, Program.Title);

            // Dialogs
            KMCDialogs.MIDIImport.Title = Languages.Parse("ImportMIDIWindow");
            KMCDialogs.MIDIImport.Filter = String.Format("{0}|*.mid;*.midi;*.kar;*.rmi;*.riff", Languages.Parse("MIDIFiles"));
            KMCDialogs.MIDIImport.Multiselect = true;
            KMCDialogs.MIDIExport.Title = Languages.Parse("ExportMIDIWindow");
            KMCDialogs.MIDIExport.IsFolderPicker = true;

            // MIDIs list
            Delegate.MIDIList.Columns.Clear();
            Delegate.MIDIList.Columns.Add(Languages.Parse("MIDIFile"), 1, HorizontalAlignment.Left);
            Delegate.MIDIList.Columns.Add(Languages.Parse("MIDINotes"), 1, HorizontalAlignment.Left);
            Delegate.MIDIList.Columns.Add(Languages.Parse("MIDITracks"), 1, HorizontalAlignment.Left);
            Delegate.MIDIList.Columns.Add(Languages.Parse("MIDILength"), 1, HorizontalAlignment.Left);
            Delegate.MIDIList.Columns.Add(Languages.Parse("MIDISize"), 1, HorizontalAlignment.Left);
            Delegate.MIDIList.Columns[0].Tag = 5.9;
            Delegate.MIDIList.Columns[1].Tag = 1.0;
            Delegate.MIDIList.Columns[2].Tag = 0.80;
            Delegate.MIDIList.Columns[3].Tag = 1.0;
            Delegate.MIDIList.Columns[4].Tag = 1.0;
            Delegate.MIDIList_SizeChanged(Delegate.MIDIList, new EventArgs());

            // Strips
            Delegate.ActionsStrip.Text = Languages.Parse("ActionsStrip");
            Delegate.OptionsStrip.Text = Languages.Parse("OptionsStrip");
            Delegate.HelpStrip.Text = Languages.Parse("HelpStrip");

            // Actions Strip
            Delegate.ImportMIDIs.Text = Languages.Parse("ImportMIDIs");
            Delegate.RemoveMIDIs.Text = Languages.Parse("RemoveMIDIs");
            Delegate.ClearList.Text = Languages.Parse("ClearList");
            Delegate.OpenSFVSTManager.Text = Languages.Parse("OpenSFVSTManager");
            Delegate.RenderToWAV.Text = String.Format("{0} {1} ({2})", Languages.Parse("RenderTo"), ".WAV", "Wave");
            Delegate.RenderToOGG.Text = String.Format("{0} {1} ({2})", Languages.Parse("RenderTo"), ".OGG", "Vorbis");
            Delegate.RenderToLAME.Text = String.Format("{0} {1} ({2})", Languages.Parse("RenderTo"), ".MP3", "LAME");
            Delegate.PreviewFiles.Text = Languages.Parse("PreviewFiles");
            Delegate.AbortConversion.Text = Languages.Parse("AbortConversion");
            Delegate.Exit.Text = Languages.Parse("Exit");

            // Options strip
            Delegate.RenderMode.Text = Languages.Parse("RenderMode");
            Delegate.RenderStandard.Text = Languages.Parse("RenderStandard");
            Delegate.RenderRTS.Text = Languages.Parse("RealTimeSim");
            Delegate.NoAffectPreview.Text = Languages.Parse("NoAffectPreview");
            Delegate.ACFUWSTC.Text = Languages.Parse("ACFUWSTC");
            Delegate.ASAR.Text = Languages.Parse("ASAR");
            Delegate.CMLAR.Text = Languages.Parse("CMLAR");
            Delegate.SCPIOTL.Text = Languages.Parse("SCPIOTL");
            Delegate.CSFFS.Text = Languages.Parse("CSFFS");
            Delegate.SBIOMB.Text = Languages.Parse("SBIOMB");
            Delegate.MTT.Text = Languages.Parse("MTT");
            Delegate.SVDS.Text = Languages.Parse("SVDS");
            Delegate.ChangeLanguage.Text = Languages.Parse("ChangeLanguage");

            // Help strip
            Delegate.IATP.Text = Languages.Parse("IATP");
            Delegate.STDWD.Text = Languages.Parse("STDWD");
            Delegate.KK99GP.Text = Languages.Parse("KK99GP");
            Delegate.KK99YTC.Text = Languages.Parse("KK99YTC");
            Delegate.JKSUS.Text = Languages.Parse("JKSUS");

            // VSTi strip
            Delegate.VSTiSettings.Text = Languages.Parse("VSTiSettings");

            // MIDIs list context strip
            Delegate.AutoResizeColumns.Text = Languages.Parse("AutoResizeColumns");
            Delegate.ImportMIDIsC.Text = Languages.Parse("ImportMIDIs");
            Delegate.RemoveMIDIsC.Text = Languages.Parse("RemoveMIDIs");
            Delegate.ClearListC.Text = Languages.Parse("ClearList");
            Delegate.SortName.Text = Languages.Parse("SortName");
            Delegate.MoveUp.Text = Languages.Parse("MoveUp");
            Delegate.MoveDown.Text = Languages.Parse("MoveDown");

            // The rest of the controls
            Delegate.VolumeLabel.Text = String.Format("{0}:", Languages.Parse("Volume"));
            Delegate.OpenSettings.Text = Languages.Parse("OpenSettings");
        }

        // Window functions
        public MainWindow(String[] args)
        {
            InitializeComponent();
            Delegate = this;

            // Initialize UI language
            InitializeLanguage();

            // Initialize context menu for MIDIs list
            MIDIList.ContextMenu = ListMenu;

            //Parse through arguments
            foreach (String s in args)
            {
                //To store all the soundfonts that where opened with the application
                List<String> soundfonts = null;
                //Find out is the current argument is a file path/name
                if (File.Exists(s))
                {
                    //Find out it the current file is a MIDI
                    if (s.ToLower().EndsWith(".mid") | s.ToLower().EndsWith(".midi") | s.ToLower().EndsWith(".kar") | s.ToLower().EndsWith(".rmi"))
                    {
                        //Add MIDI to midi list
                        string[] saLvwItem = new string[4];
                        string[] midiinfo = DataCheck.GetMoreInfoMIDI(s);
                        saLvwItem[0] = s;
                        saLvwItem[1] = midiinfo[0];
                        saLvwItem[2] = midiinfo[1];
                        saLvwItem[3] = midiinfo[2];
                        saLvwItem[4] = midiinfo[3];
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
                //Check if there are soundfonts
                if (soundfonts != null)
                {
                    SoundFontChain.SoundFonts = new string[soundfonts.Count];
                    soundfonts.CopyTo(SoundFontChain.SoundFonts, 0);
                    foreach (String SF in soundfonts)
                    {
                        KMCDialogs.SFDialog.SFList.Items.Add(s);
                    }
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Initialize the menu
            Menu = ConverterMenu;

            Title = Text;
            timeBeginPeriod(timerAccuracy);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            // Initialize threads
            KMCThreads.ConversionProcess.DoWork += ConverterFunctions.CPWork;
            KMCThreads.ConversionProcessRT.DoWork += ConverterFunctions.CPRWork;
            KMCThreads.PlaybackProcess.DoWork += ConverterFunctions.PBWork;

            // Notification icon in the system tray
            NotifyArea.ShowIconTray();

            // Initialize values
            for (int i = 0; i < 8; i++) VSTs.VSTInfo[i] = new BASS_VST_INFO();

            try
            {
                try
                {
                    // Generic settings
                    if (Properties.Settings.Default.Volume > 1.0f)
                    {
                        Properties.Settings.Default.Volume = 1.0f;
                        Properties.Settings.Default.Save();
                    }
                    VolumeBar.Value = Convert.ToInt32(Properties.Settings.Default.Volume * 10000.0f).LimitToRange(0, 10000);

                    // Load settings
                    CSFFS.Checked = Properties.Settings.Default.AudioEvents;
                    ACFUWSTC.Checked = Properties.Settings.Default.AutoUpdateCheck;
                    SCPIOTL.Checked = Properties.Settings.Default.ShowOldTimeInfo;
                    RenderStandard.Checked = !Properties.Settings.Default.RealTimeSimulator;
                    RenderRTS.Checked = Properties.Settings.Default.RealTimeSimulator;
                    SBIOMB.Checked = Properties.Settings.Default.ShowBalloon;
                    MTT.Checked = Properties.Settings.Default.MinimizeToTray;
                    ChangeLanguage.Enabled = !Program.DebugLang;
                }
                catch (Exception exception)
                {
                    ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                    errordialog.ShowDialog();
                }

                KMCThreads.GarbageCollector.DoWork += BasicFunctions.GCWork;
                KMCThreads.GarbageCollector.RunWorkerAsync();

                KMCThreads.GetInfoWorker.DoWork += ConverterFunctions.GIWWork;
                KMCThreads.GetInfoWorker.RunWorkerAsync();

                KMCThreads.RenderingTimer.Tick += ConverterFunctions.RTTick;
                KMCThreads.RenderingTimer.Interval = 10;
                KMCThreads.RenderingTimer.Enabled = true;
                KMCThreads.RenderingTimer.Start();
            }
            catch (Exception exception2)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("FatalError"), exception2.ToString(), 1, 0);
                errordialog.ShowDialog();
            }
        }

        private void ImportMIDIs_Click(object sender, EventArgs e)
        {
            KMCDialogs.MIDIImport.InitialDirectory = Properties.Settings.Default.LastMIDIFolder;

            if (KMCDialogs.MIDIImport.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LastMIDIFolder = Path.GetDirectoryName(KMCDialogs.MIDIImport.FileName);
                Properties.Settings.Default.Save();
                new AddingMIDIs(KMCDialogs.MIDIImport.FileNames, true).ShowDialog();
            }
        }

        private void RemoveMIDIs_Click(object sender, EventArgs e)
        {
            for (int i = this.MIDIList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                this.MIDIList.Items.RemoveAt(this.MIDIList.SelectedIndices[i]);
            }
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            this.MIDIList.Items.Clear();
        }

        private void OpenSFVSTManager_Click(object sender, EventArgs e)
        {
            KMCDialogs.SFDialog.ShowDialog();
        }

        private void RenderToWAV_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 0;
            KMCStatus.StartTime = DateTime.Now;
            ConverterFunctions.StartRenderingThread(false);
        }

        private void RenderToOGG_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 1;
            KMCStatus.StartTime = DateTime.Now;
            ConverterFunctions.StartRenderingThread(false);
        }

        private void RenderToLAME_Click(object sender, EventArgs e)
        {
            KMCGlobals.CurrentEncoder = 2;
            KMCStatus.StartTime = DateTime.Now;
            ConverterFunctions.StartRenderingThread(false);
        }

        private void PreviewFiles_Click(object sender, EventArgs e)
        {
            KMCStatus.StartTime = DateTime.Now;
            ConverterFunctions.StartRenderingThread(true);
        }

        private void AbortConversion_Click(object sender, EventArgs e)
        {
            KMCGlobals.CancellationPendingValue = 1;
            KMCGlobals.AutoShutDownEnabled = false;
        }

        private void SortName_Click(object sender, EventArgs e)
        {
            MIDIList.Sorting = SortOrder.Ascending;
            MIDIList.Sorting = SortOrder.None;
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            BasicFunctions.MoveListViewItems(MIDIList, BasicFunctions.MoveDirection.Up);
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            BasicFunctions.MoveListViewItems(MIDIList, BasicFunctions.MoveDirection.Down);
        }

        public static bool ConfirmExit()
        {
            // Confirm user wants to close
            if (Bass.BASS_ChannelIsActive(KMCGlobals._recHandle) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                DialogResult dialogResult = MessageBox.Show(Languages.Parse("AppBusy"), Languages.Parse("HeyYou"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.Yes)
                    return true;
                else if (dialogResult == DialogResult.No)
                    return false;
                else
                    return false;
            }
            else
                return true;
        }

        public static void CloseApp()
        {
            timeEndPeriod(timerAccuracy);
            Bass.BASS_StreamFree(KMCGlobals._recHandle);
            Bass.BASS_Free();
            if (Program.DeleteEncoder == true)
            {
                File.Delete(Program.OGGEnc);
                File.Delete(Program.MP3Enc);
            }
            NotifyArea.HideIconTray();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) CloseApp();

            if (ConfirmExit()) CloseApp();
            else e.Cancel = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.WindowState.Equals(FormWindowState.Minimized))
            {
                this.Hide();
                if (Properties.Settings.Default.FirstTimeTray != false)
                {
                    NotifyArea.ShowStatusTray(Languages.Parse("Information"), Languages.Parse("MinimizedToTray"), ToolTipIcon.Info);
                    Properties.Settings.Default.FirstTimeTray = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (ConfirmExit()) CloseApp();
        }

        private bool Resizing = false;
        private void MIDIList_SizeChanged(object sender, EventArgs e)
        {
            if (!Resizing)
            {
                Resizing = true;
                if (sender is ListView listView)
                {
                    float totalColumnWidth = 0;

                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += (float)Convert.ToDouble(listView.Columns[i].Tag);

                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = ((float)Convert.ToDouble(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }
            Resizing = false;
        }

        private void MIDIList_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            new AddingMIDIs((string[])e.Data.GetData(DataFormats.FileDrop, false), false).ShowDialog();
        }

        private void MIDIList_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MIDIList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (KMCStatus.IsKMCBusy == false)
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
            } catch { }
        }

        private void AutoResizeColumns_Click(object sender, EventArgs e)
        {
            MIDIList_SizeChanged(MIDIList, e);
        }

        private void OpenSettings_Click(object sender, EventArgs e)
        {
            KMCDialogs.AdvSett.Show();
        }

        private void IATP_Click(object sender, EventArgs e)
        {
            new InfoDialog(0).ShowDialog();
        }

        private void AVSLabel_Click(object sender, EventArgs e)
        {
            try
            {
                AdvancedVoices vfrm = new AdvancedVoices();
                vfrm.Show();
            }
            catch { }
        }

        public static Boolean Seeking = false;
        public static long CurrentSeek = 0;
        private void PreviewTrackBar_Scroll(object sender, EventArgs e)
        {
            KMCStatus.TotalNotes = KMCStatus.TotalNotesOrg + KMCStatus.PlayedNotes;
            Seeking = true;
            CurrentSeek = PreviewTrackBar.Value * 120;
        }

        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Volume = (float)Convert.ToDouble((float)this.VolumeBar.Value / 10000.0f);
                Properties.Settings.Default.Save();
                KMCDialogs.VolumeTip.SetToolTip(VolumeBar, String.Format("{0} {1}", Languages.Parse("Volume"), ((float)this.VolumeBar.Value / 100).ToString("000.00") + "%"));
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }

        private void ACFUWSTC_Click(object sender, EventArgs e)
        {
            ACFUWSTC.Checked = !ACFUWSTC.Checked;
            Properties.Settings.Default.AutoUpdateCheck = ACFUWSTC.Checked;
            Properties.Settings.Default.Save();
        }

        private void ASAR_Click(object sender, EventArgs e)
        {
            ASAR.Checked = !ASAR.Checked;
            KMCGlobals.AutoShutDownEnabled = ASAR.Checked;
            ASAR.Checked = ASAR.Checked;
        }

        private void CMLAR_Click(object sender, EventArgs e)
        {
            CMLAR.Checked = !CMLAR.Checked;
            KMCGlobals.AutoClearMIDIListEnabled = CMLAR.Checked;
            CMLAR.Checked = CMLAR.Checked;
        }

        private void SCPIOTL_Click(object sender, EventArgs e)
        {
            SCPIOTL.Checked = !SCPIOTL.Checked;
            Properties.Settings.Default.ShowOldTimeInfo = SCPIOTL.Checked;
            Properties.Settings.Default.Save();
        }

        private void CSFFS_Click(object sender, EventArgs e)
        {
            CSFFS.Checked = !CSFFS.Checked;
            Properties.Settings.Default.AudioEvents = CSFFS.Checked;
            Properties.Settings.Default.Save();
        }

        private void SVS_Click(object sender, EventArgs e)
        {
            SVDS.Checked = !SVDS.Checked;
            KMCGlobals.VSTSkipSettings = SVDS.Checked;
        }

        private void RenderStandard_Click(object sender, EventArgs e)
        {
            RenderStandard.Checked = true;
            RenderRTS.Checked = false;
            Properties.Settings.Default.RealTimeSimulator = false;
            Properties.Settings.Default.Save();
        }

        private void RenderRTS_Click(object sender, EventArgs e)
        {
            RenderStandard.Checked = false;
            RenderRTS.Checked = true;
            Properties.Settings.Default.RealTimeSimulator = true;
            Properties.Settings.Default.Save();
        }

        private void STDWD_Click(object sender, EventArgs e)
        {
            BasicFunctions.Donate();
        }

        private void KK99GP_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/KaleidonKep99");
        }

        private void KK99YTC_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCJeqODojIv4TdeHcBfHJRnA");
        }

        private void JKSUS_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/jUaHPrP");
        }

        private void ChangeLanguage_Click(object sender, EventArgs e)
        {
            new OverrideLanguage().ShowDialog();
        }

        private void VSTiSettings_Click(object sender, EventArgs e)
        {
            BASSControl.BASSVSTShowDialog(false, MainWindow.KMCGlobals._recHandle, MainWindow.VSTs._VSTHandles[0], MainWindow.VSTs.VSTInfo[0]);
        }
    }
}