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
using HundredMilesSoftware.UltraID3Lib;
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
        public static float RAWTotal;
        public static float RAWConverted;
        public static double LenRAWToDouble;
        public static double CurRAWToDouble;
        public static TimeSpan LenDoubleToSpan;
        public static TimeSpan CurDoubleToSpan;

        private static Process thisProc = Process.GetCurrentProcess();

        private static void DisableEncoderButtons()
        {
            MainWindow.Delegate.startRenderingWAVToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.startRenderingOGGToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.startRenderingMp3ToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.playInRealtimeBetaToolStripMenuItem.Enabled = false;
            if (!MainWindow.KMCGlobals.IsKMCBusy)
                MainWindow.Delegate.abortRenderingToolStripMenuItem.Enabled = false;
            else
                MainWindow.Delegate.abortRenderingToolStripMenuItem.Enabled = true;
        }

        private static void EnableEncoderButtons()
        {
            MainWindow.Delegate.startRenderingWAVToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.startRenderingOGGToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.startRenderingMp3ToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.playInRealtimeBetaToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.abortRenderingToolStripMenuItem.Enabled = false;
        }

        private static void DisableImportButtons()
        {
            MainWindow.Delegate.importMIDIsToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.removeSelectedMIDIsToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.clearMIDIsListToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.openTheSoundfontsManagerToolStripMenuItem.Enabled = false;
        }

        private static void EnableImportButtons()
        {
            MainWindow.Delegate.importMIDIsToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.removeSelectedMIDIsToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.clearMIDIsListToolStripMenuItem.Enabled = true;
            MainWindow.Delegate.openTheSoundfontsManagerToolStripMenuItem.Enabled = true;
        }

        private static void DefaultSelectionMenu(Int32 Which)
        {
            if (Which == 0)
            {
                MainWindow.Delegate.importMIDIsToolStripMenuItem.DefaultItem = true;
                MainWindow.Delegate.openTheSoundfontsManagerToolStripMenuItem.DefaultItem = false;
            }
            else if (Which == 1)
            {
                MainWindow.Delegate.importMIDIsToolStripMenuItem.DefaultItem = false;
                MainWindow.Delegate.openTheSoundfontsManagerToolStripMenuItem.DefaultItem = true;
            }
        }

        private static String ReturnOutputText(TimeSpan TimeToCheck)
        {
            if (LenDoubleToSpan.Hours >= 10) return @"hh\:mm\:ss\.f";
            else
            {
                if (LenDoubleToSpan.Hours >= 1) return @"h\:mm\:ss\.f";
                else
                {
                    if (LenDoubleToSpan.Minutes >= 10) return @"mm\:ss\.f";
                    else return @"m\:ss\.f";
                }
            }
        }

        private static void UpdateText()
        {
            String Time = ReturnOutputText(LenDoubleToSpan);
            String TimeExpect = @"hh\:mm\:ss";

            string MIDILengthString = LenDoubleToSpan.ToString(Time);
            string MIDICurrentString = CurDoubleToSpan.ToString(Time);
            float percentage = RAWConverted / RAWTotal;
            float percentagefinal;
            if (percentage * 100 < 0)
                percentagefinal = 0.0f;
            else if (percentage * 100 > 100)
                percentagefinal = 1.0f;
            else
                percentagefinal = percentage;
            MainWindow.KMCGlobals.PercentageProgress = percentagefinal.ToString("0.0%");

            String PassedTime = String.Format("{0}:{1}",
                (Int32)MainWindow.KMCStatus.PassedTime.TotalMinutes,
                MainWindow.KMCStatus.PassedTime.Seconds.ToString("00"));

            String EstimatedTime = String.Format("{0}:{1}",
                (Int32)MainWindow.KMCStatus.EstimatedTime.TotalMinutes,
                MainWindow.KMCStatus.EstimatedTime.Seconds.ToString("00"));

            MainWindow.KMCStatus.PassedTime = DateTime.Now - MainWindow.KMCStatus.StartTime;
            if (!MainWindow.KMCGlobals.RealTime)
            {
                try
                {
                    Double secondsremaining = (Double)(MainWindow.KMCStatus.PassedTime.TotalSeconds / (Double)RTF.MIDICurrentPosRAW * ((Double)RTF.MIDILengthRAW - (Double)RTF.MIDICurrentPosRAW));
                    MainWindow.KMCStatus.EstimatedTime = TimeSpan.FromSeconds(secondsremaining);
                }
                catch { MainWindow.KMCStatus.EstimatedTime = TimeSpan.FromSeconds(0); }
            }
            else MainWindow.KMCStatus.EstimatedTime = TimeSpan.FromSeconds(0);

            if (!MainWindow.KMCGlobals.RenderingMode)
            {
                if (MainWindow.KMCGlobals.pictureset != 2)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convprwo;
                    MainWindow.KMCGlobals.pictureset = 2;
                }

                if (!MainWindow.KMCGlobals.DoNotCountNotes) MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("PlaybackStatus", MainWindow.cul),
                            RAWConverted.ToString("0.00MB"),
                            MIDICurrentString, MIDILengthString,
                            MainWindow.KMCStatus.PlayedNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")),
                            MainWindow.KMCStatus.TotalNotes.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de")));

                else MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("PlaybackStatus", MainWindow.cul),
                            RAWConverted.ToString("0.00MB"),
                            MIDICurrentString, MIDILengthString,
                            "N/A",
                            "N/A");
            }
            else
            {
                if (MainWindow.KMCGlobals.pictureset != 3)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convsave;
                    MainWindow.KMCGlobals.pictureset = 3;
                }
                if (CPUUsage < 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterNew", MainWindow.cul),
                            RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(100f / CPUUsage)).ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterNew", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                EstimatedTime, PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                                ((float)(100f / CPUUsage)).ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterOld", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                MIDICurrentString, MIDILengthString, Convert.ToInt32(CPUUsage).ToString(),
                                ((float)(100f / CPUUsage)).ToString("0.0"));
                    }
                }
                else if (CPUUsage == 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalNew", MainWindow.cul),
                            RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            CPUUsage.ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalNew", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                EstimatedTime, PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                                CPUUsage.ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalOld", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                MIDICurrentString, MIDILengthString, Convert.ToInt32(CPUUsage).ToString(),
                                CPUUsage.ToString("0.0"));
                    }
                }
                else if (CPUUsage > 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerNew", MainWindow.cul),
                            RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                            "?:??", PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                            ((float)(CPUUsage / 100f)).ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerNew", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                EstimatedTime, PassedTime, Convert.ToInt32(CPUUsage).ToString(),
                                ((float)(CPUUsage / 100f)).ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerOld", MainWindow.cul),
                                RAWConverted.ToString("0.00"), percentagefinal.ToString("0.0%"),
                                MIDICurrentString, MIDILengthString, Convert.ToInt32(CPUUsage).ToString(),
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
                    MainWindow.Delegate.labelRMS.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                         MainWindow.res_man.GetString("RMS", MainWindow.cul), 0,
                         MainWindow.res_man.GetString("AverageLevel", MainWindow.cul), 0,
                         MainWindow.res_man.GetString("PeakLevel", MainWindow.cul), 0);
                }
                else if (Mode == 1)
                {
                    MainWindow.Delegate.labelRMS.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                         MainWindow.res_man.GetString("RMS", MainWindow.cul), MainWindow.KMCGlobals._plm.RMS_dBV,
                         MainWindow.res_man.GetString("AverageLevel", MainWindow.cul), MainWindow.KMCGlobals._plm.AVG_dBV,
                         MainWindow.res_man.GetString("PeakLevel", MainWindow.cul), Math.Max(MainWindow.KMCGlobals._plm.PeakHoldLevelL_dBV, MainWindow.KMCGlobals._plm.PeakHoldLevelR_dBV));
                }
            }
            catch {
                MainWindow.Delegate.labelRMS.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                     MainWindow.res_man.GetString("RMS", MainWindow.cul), 0,
                     MainWindow.res_man.GetString("AverageLevel", MainWindow.cul), 0,
                     MainWindow.res_man.GetString("PeakLevel", MainWindow.cul), 0);
            }
        }

        private static void CurrentMode(Int32 Mode) 
        {
            if (Mode == 0) // Idle
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}: 0/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), 0, MainWindow.KMCGlobals.LimitVoicesInt);
                MainWindow.Delegate.SettingsBox.Enabled = true;
                MainWindow.Delegate.VolumeLabel.Enabled = true;
                MainWindow.Delegate.VolumeBar.Enabled = true;
                MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                thisProc.PriorityClass = ProcessPriorityClass.Idle;
            }
            else if (Mode == 1) // Memory allocation
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}: 0/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), 0, MainWindow.KMCGlobals.LimitVoicesInt);
                if (MainWindow.KMCGlobals.RenderingMode)
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.VolumeLabel.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.VolumeLabel.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.Delegate.VoiceLimit.Maximum = 2000;
                }
                thisProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (Mode == 2) // Rendering/Playback
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}: {1}/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), Convert.ToInt32(ActiveVoices), MainWindow.KMCGlobals.LimitVoicesInt);
                if (MainWindow.KMCGlobals.RenderingMode)
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.VolumeLabel.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.SettingsBox.Enabled = true;
                    MainWindow.Delegate.VolumeLabel.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.Delegate.VoiceLimit.Maximum = 2000;
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
                    MainWindow.Delegate.Text = "Keppy's MIDI Converter";
                }
                else
                {
                    if (MainWindow.KMCGlobals.IsKMCBusy == false)
                    {
                        MainWindow.Delegate.Text = "Keppy's MIDI Converter";
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.RenderingMode == false)
                            MainWindow.Delegate.Text = String.Format(MainWindow.res_man.GetString("PlaybackText", MainWindow.cul), MainWindow.KMCGlobals.NewWindowName);
                        else
                            MainWindow.Delegate.Text = String.Format(MainWindow.res_man.GetString("ConversionText", MainWindow.cul), MainWindow.KMCGlobals.NewWindowName);
                    }
                }
            }
            catch
            {
                MainWindow.Delegate.Text = "Keppy's MIDI Converter";
            }
        }

        private static void SetProgressBar(Int32 Mode)
        {
            try
            {
                if (Mode == 0) // Idle
                {
                    MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Blocks;
                    MainWindow.Delegate.CurrentStatus.Minimum = 0;
                    MainWindow.Delegate.CurrentStatus.Maximum = 1;
                    MainWindow.Delegate.CurrentStatus.Value = 0;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                if (Mode == 1) // Memory allocation
                {
                    MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Marquee;
                    MainWindow.Delegate.CurrentStatus.Maximum = 1;
                    MainWindow.Delegate.CurrentStatus.Value = 0;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                }
                if (Mode == 2) // Rendering/Playback
                {
                    if (!MainWindow.KMCGlobals.RealTime)
                    {
                        Int32 CurPercentage = (int)((RAWConverted / RAWTotal) * 10000);
                        if (CurPercentage > 10000) CurPercentage = 10000;
                        else if (CurPercentage < 0) CurPercentage = 0;
                        MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        MainWindow.Delegate.CurrentStatus.Minimum = 0;
                        MainWindow.Delegate.CurrentStatus.Maximum = 10000;
                        MainWindow.Delegate.CurrentStatus.Value = CurPercentage;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(CurPercentage, 10000);
                    }
                    else
                    {
                        MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Marquee;
                        MainWindow.Delegate.CurrentStatus.Maximum = 1;
                        MainWindow.Delegate.CurrentStatus.Value = 0;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                    }
                }
            }
            catch {
                if (Mode == 2) // Rendering/Playback 
                {
                    if (!MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Blocks;
                        MainWindow.Delegate.CurrentStatus.Minimum = 0;
                        MainWindow.Delegate.CurrentStatus.Maximum = 1;
                        MainWindow.Delegate.CurrentStatus.Value = 1;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(1, 1);
                    }
                }
            }
        }

        private static void SetStatus(Int32 Mode)
        {
            if (Mode == 0) // Idle
            {
                MainWindow.Delegate.MIDIList.Enabled = true;
                SetProgressBar(0);
                MainWindow.Delegate.CurrentStatusText.Text = MainWindow.res_man.GetString("IdleMessage", MainWindow.cul);
                if (MainWindow.KMCGlobals.pictureset != 1)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convpause;
                    MainWindow.KMCGlobals.pictureset = 1;
                }
                if (MainWindow.Delegate.MIDIList.Items.Count < 1)
                {
                    EnableImportButtons();
                    DisableEncoderButtons();
                }
                else
                {
                    if (MainWindow.KMCGlobals.Soundfonts.Length == 0)
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
                MainWindow.Delegate.MIDIList.Enabled = false;
                SetProgressBar(1);
                if (MainWindow.KMCGlobals.pictureset != 0)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convbusy;
                    MainWindow.KMCGlobals.pictureset = 0;
                }
                if (MainWindow.KMCGlobals.RenderingMode)
                {
                    MainWindow.Delegate.CurrentStatusText.Text = MainWindow.res_man.GetString("MemoryAllocationConversion", MainWindow.cul);
                }
                else
                {
                    if (MainWindow.KMCGlobals.VSTMode == true)
                        MainWindow.Delegate.CurrentStatusText.Text = MainWindow.res_man.GetString("MemoryAllocationPlayback", MainWindow.cul);
                    else
                        MainWindow.Delegate.CurrentStatusText.Text = MainWindow.res_man.GetString("MemoryAllocationPlaybackVST", MainWindow.cul);
                }
                DisableImportButtons();
                DisableEncoderButtons();
                thisProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (Mode == 2) // Rendering/Playback
            {
                MainWindow.Delegate.MIDIList.Enabled = false;
                SetProgressBar(2);
                DisableImportButtons();
                DisableEncoderButtons();
                UpdateText();
                thisProc.PriorityClass = ProcessPriorityClass.High;
            }
        }

        public static void GetVoices()
        {
            MainWindow.KMCChannelsVoices.ch1 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 0, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch2 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 1, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch3 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 2, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch4 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 3, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch5 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 4, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch6 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 5, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch7 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 6, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch8 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 7, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch9 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 8, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.chD = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 9, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch11 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 10, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch12 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 11, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch13 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 12, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch14 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 13, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch15 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 14, (BASSMIDIEvent)0x20001);
            MainWindow.KMCChannelsVoices.ch16 = BassMidi.BASS_MIDI_StreamGetEvent(MainWindow.KMCGlobals._recHandle, 15, (BASSMIDIEvent)0x20001);
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
}