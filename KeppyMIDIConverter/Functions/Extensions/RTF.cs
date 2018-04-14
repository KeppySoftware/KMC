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
using System.Threading;

namespace KeppyMIDIConverter
{
    class RTF
    {
        public static float CPUUsage = 0.0f;
        public static float ActiveVoices = 0.0f;
        public static long MIDILengthRAW;
        public static long MIDICurrentPosRAW;
        public static long CurrentTicks;
        public static long TotalTicks;
        public static float RAWTotal;
        public static float RAWConverted;
        public static double LenRAWToDouble;
        public static double CurRAWToDouble;
        public static TimeSpan LenDoubleToSpan;
        public static TimeSpan CurDoubleToSpan;

        private static Process thisProc = Process.GetCurrentProcess();

        private static void DisableEncoderButtons()
        {
            MainWindow.Delegate.RenderToWAV.Enabled = false;
            MainWindow.Delegate.RenderToOGG.Enabled = false;
            MainWindow.Delegate.RenderToLAME.Enabled = false;
            MainWindow.Delegate.PreviewFiles.Enabled = false;

            if (!MainWindow.KMCStatus.IsKMCBusy)
                MainWindow.Delegate.AbortConversion.Enabled = false;
            else
                MainWindow.Delegate.AbortConversion.Enabled = true;
        }

        private static void EnableEncoderButtons()
        {
            MainWindow.Delegate.RenderToWAV.Enabled = true;
            MainWindow.Delegate.RenderToOGG.Enabled = true;
            MainWindow.Delegate.RenderToLAME.Enabled = true;
            MainWindow.Delegate.PreviewFiles.Enabled = true;
            MainWindow.Delegate.AbortConversion.Enabled = false;
        }

        private static void DisableImportButtons()
        {
            MainWindow.Delegate.RenderMode.Enabled = false;
            MainWindow.Delegate.ImportMIDIs.Enabled = false;
            MainWindow.Delegate.RemoveMIDIs.Enabled = false;
            MainWindow.Delegate.ClearList.Enabled = false;
            MainWindow.Delegate.OpenSFVSTManager.Enabled = false;
            MainWindow.Delegate.SVDS.Enabled = false;

            // Right-click Context Menu
            MainWindow.Delegate.ImportMIDIsC.Enabled = false;
            MainWindow.Delegate.RemoveMIDIsC.Enabled = false;
            MainWindow.Delegate.ClearListC.Enabled = false;
            MainWindow.Delegate.SortName.Enabled = false;
            MainWindow.Delegate.MoveUp.Enabled = false;
            MainWindow.Delegate.MoveDown.Enabled = false;
        }

        private static void EnableImportButtons()
        {
            // Main Menu
            MainWindow.Delegate.RenderMode.Enabled = true;
            MainWindow.Delegate.ImportMIDIs.Enabled = true;
            MainWindow.Delegate.RemoveMIDIs.Enabled = true;
            MainWindow.Delegate.ClearList.Enabled = true;
            MainWindow.Delegate.OpenSFVSTManager.Enabled = true;
            MainWindow.Delegate.SVDS.Enabled = true;

            // Right-click Context Menu
            MainWindow.Delegate.ImportMIDIsC.Enabled = true;
            MainWindow.Delegate.RemoveMIDIsC.Enabled = true;
            MainWindow.Delegate.ClearListC.Enabled = true;
            MainWindow.Delegate.SortName.Enabled = true;
            MainWindow.Delegate.MoveUp.Enabled = true;
            MainWindow.Delegate.MoveDown.Enabled = true;
        }

        private static void DefaultSelectionMenu(Int32 Which)
        {
            if (Which == 0)
            {
                MainWindow.Delegate.ImportMIDIs.DefaultItem = true;
                MainWindow.Delegate.OpenSFVSTManager.DefaultItem = false;
            }
            else if (Which == 1)
            {
                MainWindow.Delegate.ImportMIDIs.DefaultItem = false;
                MainWindow.Delegate.OpenSFVSTManager.DefaultItem = true;
            }
        }

        private static String ReturnOutputText(TimeSpan TimeToCheck)
        {
            if (LenDoubleToSpan.Hours >= 10) return @"hh\:mm\:ss\.fff";
            else
            {
                if (LenDoubleToSpan.Hours >= 1) return @"h\:mm\:ss\.fff";
                else
                {
                    if (LenDoubleToSpan.Minutes >= 10) return @"mm\:ss\.fff";
                    else return @"m\:ss\.fff";
                }
            }
        }

        private static void UpdateText()
        {
            String Time = ReturnOutputText(LenDoubleToSpan);

            string MIDILengthString = (LenDoubleToSpan).ToString(Time);
            string MIDICurrentString = (CurDoubleToSpan).ToString(Time);

            float Percentage = (RAWConverted / RAWTotal).LimitFloatToRange(0.0f, 100.0f);

            MainWindow.KMCGlobals.PercentageProgress = Percentage.ToString("0.0%");

            String PassedTime = String.Format("{0}:{1}",
                (Int32)MainWindow.KMCStatus.PassedTime.TotalMinutes,
                MainWindow.KMCStatus.PassedTime.Seconds.ToString("00"));

            String EstimatedTime = String.Format("{0}:{1}",
                (Int32)MainWindow.KMCStatus.EstimatedTime.TotalMinutes,
                MainWindow.KMCStatus.EstimatedTime.Seconds.ToString("00"));

            MainWindow.KMCStatus.PassedTime = DateTime.Now - MainWindow.KMCStatus.StartTime;

            try
            {
                Double secondsremaining = (Double)(MainWindow.KMCStatus.PassedTime.TotalSeconds / (Double)RTF.MIDICurrentPosRAW * ((Double)RTF.MIDILengthRAW - (Double)RTF.MIDICurrentPosRAW));
                MainWindow.KMCStatus.EstimatedTime = TimeSpan.FromSeconds(MainWindow.KMCGlobals.RealTime ? 0 : secondsremaining);
            }
            catch { MainWindow.KMCStatus.EstimatedTime = TimeSpan.FromSeconds(0); }

            if (!MainWindow.KMCStatus.RenderingMode)
            {
                if (CPUUsage < 100f || CPUUsage == 100f)
                {
                    MainWindow.Delegate.StatusMsg.Text = String.Format(Languages.Parse("PlaybackStatusNormal"),
                        Percentage.ToString("0.0%"),
                        MIDICurrentString, MIDILengthString,
                        MainWindow.KMCGlobals.DoNotCountNotes ? "N/A" : MainWindow.KMCStatus.PlayedNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")),
                        MainWindow.KMCGlobals.DoNotCountNotes ? "N/A" : MainWindow.KMCStatus.TotalNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")),
                        CPUUsage.ToString("0.0"));
                }
                else if (CPUUsage > 100f)
                {
                    MainWindow.Delegate.StatusMsg.Text = String.Format(Languages.Parse("PlaybackStatusSlower"),
                        Percentage.ToString("0.0%"),
                        MIDICurrentString, MIDILengthString,
                        MainWindow.KMCGlobals.DoNotCountNotes ? "N/A" : MainWindow.KMCStatus.PlayedNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")),
                        MainWindow.KMCGlobals.DoNotCountNotes ? "N/A" : MainWindow.KMCStatus.TotalNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")),
                        ((float)(CPUUsage / 100f)).ToString("0.0"));
                }
            }
            else
            {
                if (CPUUsage < 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(Languages.Parse("ConvStatusFasterNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(100f / CPUUsage)).ToString("0.0"));
                    }
                    else
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(
                            Properties.Settings.Default.ShowOldTimeInfo ? Languages.Parse("ConvStatusFasterOld") : Languages.Parse("ConvStatusFasterNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDICurrentString : EstimatedTime,
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDILengthString : PassedTime,
                            Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(100f / CPUUsage)).ToString("0.0"));
                    }
                }
                else if (CPUUsage == 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(Languages.Parse("ConvStatusNormalNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            CPUUsage.ToString("0.0"));
                    }
                    else
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(
                            Properties.Settings.Default.ShowOldTimeInfo ? Languages.Parse("ConvStatusNormalOld") : Languages.Parse("ConvStatusNormalNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDICurrentString : EstimatedTime,
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDILengthString : PassedTime,
                            Convert.ToInt32(CPUUsage).ToString(),
                            CPUUsage.ToString("0.0"));
                    }
                }
                else if (CPUUsage > 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(Languages.Parse("ConvStatusSlowerNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(CPUUsage / 100f)).ToString("0.0"));
                    }
                    else
                    {
                        MainWindow.Delegate.StatusMsg.Text = String.Format(
                            Properties.Settings.Default.ShowOldTimeInfo ? Languages.Parse("ConvStatusSlowerOld") : Languages.Parse("ConvStatusSlowerNew"),
                            RAWConverted.ToString("0.00"), Percentage.ToString("0.0%"),
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDICurrentString : EstimatedTime,
                            Properties.Settings.Default.ShowOldTimeInfo ? MIDILengthString : PassedTime,
                            Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(CPUUsage / 100f)).ToString("0.0"));
                    }
                }
            }
        }

        private static void SetPeak(Int32 Mode)
        {
            try
            {
                if (Mode == 0)
                {
                    MainWindow.Delegate.RMSLabel.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                         Languages.Parse("RMS"), 0,
                         Languages.Parse("AverageLevel"), 0,
                         Languages.Parse("PeakLevel"), 0);
                }
                else if (Mode == 1)
                {
                    MainWindow.Delegate.RMSLabel.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                         Languages.Parse("RMS"), MainWindow.KMCGlobals._plm.RMS_dBV,
                         Languages.Parse("AverageLevel"), MainWindow.KMCGlobals._plm.AVG_dBV,
                         Languages.Parse("PeakLevel"), Math.Max(MainWindow.KMCGlobals._plm.PeakHoldLevelL_dBV, MainWindow.KMCGlobals._plm.PeakHoldLevelR_dBV));
                }
            }
            catch
            {
                MainWindow.Delegate.RMSLabel.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                     Languages.Parse("RMS"), 0,
                     Languages.Parse("AverageLevel"), 0,
                     Languages.Parse("PeakLevel"), 0);
            }
        }

        private static void CurrentMode(Int32 Mode)
        {
            if (Mode == 0) // Idle
            {
                MainWindow.Delegate.AVSLabel.Text = String.Format("{0}: 0/{2}", Languages.Parse("ActiveVoices"), 0, Properties.Settings.Default.Voices);
                MainWindow.Delegate.OpenSettings.Enabled = true;
                MainWindow.Delegate.VolumeLabel.Enabled = true;
                MainWindow.Delegate.PreviewTrackBar.Enabled = false;
                MainWindow.Delegate.VolumeBar.Enabled = true;
                MainWindow.Delegate.VSTiSeparator.Visible = false;
                MainWindow.Delegate.VSTiSettings.Visible = false;
                MainWindow.KMCDialogs.AdvSett.MaxVoices.Maximum = 100000;
                thisProc.PriorityClass = ProcessPriorityClass.Idle;
            }
            else if (Mode == 1) // Memory allocation
            {
                MainWindow.Delegate.AVSLabel.Text = String.Format("{0}: 0/{2}", Languages.Parse("ActiveVoices"), 0, Properties.Settings.Default.Voices);
                MainWindow.Delegate.OpenSettings.Enabled = false;
                MainWindow.Delegate.PreviewTrackBar.Enabled = false;
                MainWindow.Delegate.VSTiSeparator.Visible = false;
                MainWindow.Delegate.VSTiSettings.Visible = false;

                if (MainWindow.KMCStatus.RenderingMode)
                {
                    MainWindow.Delegate.VolumeLabel.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.KMCDialogs.AdvSett.MaxVoices.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.VolumeLabel.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.KMCDialogs.AdvSett.MaxVoices.Maximum = 2000;
                }

                thisProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (Mode == 2) // Rendering/Playback
            {
                if (MainWindow.VSTs.VSTInfo[0].isInstrument) MainWindow.Delegate.AVSLabel.Text = String.Format("{0}: {1}", Languages.Parse("ActiveVoices"), Languages.Parse("Unavailable"));
                else MainWindow.Delegate.AVSLabel.Text = String.Format("{0}: {1}/{2}", Languages.Parse("ActiveVoices"), Convert.ToInt32(ActiveVoices), Properties.Settings.Default.Voices);

                if (MainWindow.KMCStatus.RenderingMode)
                {
                    MainWindow.Delegate.OpenSettings.Enabled = false;
                    MainWindow.Delegate.VolumeLabel.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.Delegate.PreviewTrackBar.Enabled = false;
                    MainWindow.Delegate.VSTiSeparator.Visible = false;
                    MainWindow.Delegate.VSTiSettings.Visible = false;
                    MainWindow.KMCDialogs.AdvSett.MaxVoices.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.OpenSettings.Enabled = true;
                    MainWindow.Delegate.VolumeLabel.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.Delegate.PreviewTrackBar.Enabled = true;

                    if (MainWindow.VSTs.VSTInfo[0].isInstrument)
                    {
                        MainWindow.Delegate.VSTiSeparator.Visible = true;
                        MainWindow.Delegate.VSTiSettings.Visible = true;
                    }
                    else
                    {
                        MainWindow.Delegate.VSTiSeparator.Visible = false;
                        MainWindow.Delegate.VSTiSettings.Visible = false;
                    }

                    MainWindow.KMCDialogs.AdvSett.MaxVoices.Maximum = 2000;
                }

                thisProc.PriorityClass = ProcessPriorityClass.Normal;
            }
        }

        private static void CurrentTitle(Int32 Mode)
        {
            try
            {
                if (Mode == 0 || Mode == 1) // Idle
                {
                    MainWindow.Delegate.Text = MainWindow.Title;
                }
                else
                {
                    if (MainWindow.KMCStatus.IsKMCBusy == false)
                    {
                        MainWindow.Delegate.Text = MainWindow.Title;
                    }
                    else
                    {
                        if (MainWindow.KMCStatus.RenderingMode == false)
                            MainWindow.Delegate.Text = String.Format(Languages.Parse("PlaybackText"), MainWindow.Title, MainWindow.KMCGlobals.NewWindowName);
                        else
                            MainWindow.Delegate.Text = String.Format(Languages.Parse("ConversionText"), MainWindow.Title, MainWindow.KMCGlobals.NewWindowName);
                    }
                }
            }
            catch
            {
                MainWindow.Delegate.Text = MainWindow.Title;
            }
        }

        private static void SetProgressBar(Int32 Mode)
        {
            try
            {
                if (Mode == 0) // Idle
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    MainWindow.Delegate.PreviewTrackBar.Value = 0;
                    MainWindow.Delegate.PreviewTrackBar.Maximum = 0;
                }
                if (Mode == 1) // Memory allocation
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                    if (MainWindow.KMCGlobals.RealTime == false) MainWindow.Delegate.PreviewTrackBar.Maximum = Convert.ToInt32(TotalTicks / 120);
                    else MainWindow.Delegate.PreviewTrackBar.Maximum = 0;
                }
                if (Mode == 2) // Rendering/Playback
                {
                    if (MainWindow.KMCGlobals.RealTime == false)
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(Convert.ToInt32(CurrentTicks / 120), Convert.ToInt32(TotalTicks / 120));
                        MainWindow.Delegate.PreviewTrackBar.Maximum = Convert.ToInt32(TotalTicks / 120);
                        MainWindow.Delegate.PreviewTrackBar.Value = Convert.ToInt32(CurrentTicks / 120);
                    }
                    else
                    {
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                        TaskbarManager.Instance.SetProgressValue(0, 0);
                        MainWindow.Delegate.PreviewTrackBar.Value = 0;
                    }
                }
            }
            catch { }
        }

        static bool Busy = true;
        static int PictureSet = 0;
        private static void SetStatus(Int32 Mode)
        {
            if (Mode == 0) // Idle
            {
                SetProgressBar(0);
                MainWindow.Delegate.StatusMsg.Text = Languages.Parse("IdleMessage");

                if (Busy)
                {
                    MainWindow.Delegate.StatusPicture.Image = Properties.Resources.convpause;
                    Busy = false;
                }
                if (PictureSet != 1)
                {
                    MainWindow.Delegate.StatusPicture.BackgroundImage = null;
                    PictureSet = 1;
                }

                if (MainWindow.Delegate.MIDIList.Items.Count < 1)
                {
                    EnableImportButtons();
                    DisableEncoderButtons();
                }
                else
                {
                    if (MainWindow.SoundFontChain.SoundFonts.Length == 0)
                    {
                        DirectoryInfo PathToGenericSF = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        String FullPath = String.Format("{0}\\GMGeneric.sf2", PathToGenericSF.Parent.FullName);
                        if (File.Exists(FullPath))
                        {
                            EnableImportButtons();
                            EnableEncoderButtons();
                            DefaultSelectionMenu(0);
                        }
                        else
                        {
                            EnableImportButtons();
                            DisableEncoderButtons();
                            DefaultSelectionMenu(1);
                        }
                    }
                    else
                    {
                        EnableImportButtons();
                        EnableEncoderButtons();
                        DefaultSelectionMenu(0);
                    }
                }
                thisProc.PriorityClass = ProcessPriorityClass.Idle;
            }
            else if (Mode == 1) // Memory allocation
            {
                SetProgressBar(1);

                if (!Busy)
                {
                    MainWindow.Delegate.StatusPicture.Image = Properties.Resources.convbusy;
                    Busy = true;
                }
                if (PictureSet != 0)
                {
                    MainWindow.Delegate.StatusPicture.BackgroundImage = Properties.Resources.convfiles;
                    PictureSet = 0;
                }

                if (MainWindow.KMCStatus.RenderingMode)
                {
                    if (MainWindow.KMCStatus.VSTMode == false)
                        MainWindow.Delegate.StatusMsg.Text = Languages.Parse("MemoryAllocationConversion");
                    else
                        MainWindow.Delegate.StatusMsg.Text = Languages.Parse("MemoryAllocationConversionVST");
                }
                else
                {
                    if (MainWindow.KMCStatus.VSTMode == false)
                        MainWindow.Delegate.StatusMsg.Text = Languages.Parse("MemoryAllocationPlayback");
                    else
                        MainWindow.Delegate.StatusMsg.Text = Languages.Parse("MemoryAllocationPlaybackVST");
                }
                DisableImportButtons();
                DisableEncoderButtons();
                thisProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (Mode == 2) // Rendering/Playback
            {
                SetProgressBar(2);

                if (!Busy)
                {
                    MainWindow.Delegate.StatusPicture.Image = Properties.Resources.convbusy;
                    Busy = true;
                }
                if (!MainWindow.KMCStatus.RenderingMode)
                {
                    if (PictureSet != 2)
                    {
                        MainWindow.Delegate.StatusPicture.BackgroundImage = Properties.Resources.convprvw;
                        PictureSet = 2;
                    }
                }
                else
                {
                    if (PictureSet != 3)
                    {
                        MainWindow.Delegate.StatusPicture.BackgroundImage = Properties.Resources.convsave;
                        PictureSet = 3;
                    }
                }

                DisableImportButtons();
                DisableEncoderButtons();
                UpdateText();
                thisProc.PriorityClass = ProcessPriorityClass.High;
            }
        }

        public static void GetVoices()
        {
            try { for (int i = 0; i <= 15; i++) MainWindow.KMCStatus.ChannelsVoices[i] = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, i, (BASSMIDIEvent)0x20001); }
            catch { for (int i = 0; i <= 15; i++) MainWindow.KMCStatus.ChannelsVoices[i] = 0; }
        }

        // Imports

        public static void KMCIdle()
        {
            CurrentTitle(0);
            SetStatus(0);
            CurrentMode(0);
            SetPeak(0);
        }

        public static void KMCMemoryAllocation()
        {
            CurrentTitle(1);
            SetStatus(1);
            CurrentMode(1);
            SetPeak(0);
        }

        public static void KMCBusy()
        {
            CurrentTitle(2);
            SetStatus(2);
            CurrentMode(2);
            SetPeak(1);
        }

        public static bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
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

    public static float LimitFloatToRange(this float value, float inclusiveMinimum, float inclusiveMaximum)
    {
        if (value < inclusiveMinimum) { return inclusiveMinimum; }
        if (value > inclusiveMaximum) { return inclusiveMaximum; }
        return value;
    }
}