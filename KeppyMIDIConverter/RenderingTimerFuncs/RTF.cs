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

namespace KeppyMIDIConverter
{
    class RTF
    {
        private static Process thisProc = Process.GetCurrentProcess();

        private static void DisableEncoderButtons()
        {
            MainWindow.Delegate.startRenderingWAVToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.startRenderingOGGToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.startRenderingMp3ToolStripMenuItem.Enabled = false;
            MainWindow.Delegate.playInRealtimeBetaToolStripMenuItem.Enabled = false;
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

        private static void UpdateText()
        {
            if (!MainWindow.KMCGlobals.RenderingMode)
            {
                if (MainWindow.KMCGlobals.pictureset != 2)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convprwo;
                    MainWindow.KMCGlobals.pictureset = 2;
                }
                MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("PlaybackStatus", MainWindow.cul),
                            MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.CurrentTime,
                            MainWindow.KMCStatus.TotalTime, MainWindow.KMCStatus.PlayedNotes,
                            MainWindow.KMCStatus.TotalNotes);
            }
            else
            {
                if (MainWindow.KMCGlobals.pictureset != 3)
                {
                    MainWindow.Delegate.loadingpic.Image = KeppyMIDIConverter.Properties.Resources.convsave;
                    MainWindow.KMCGlobals.pictureset = 3;
                }
                if (MainWindow.KMCStatus.CPUUsage < 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterNew", MainWindow.cul),
                            MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                            MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                            ((float)(100f / MainWindow.KMCStatus.CPUUsage)).ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterNew", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                                MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                ((float)(100f / MainWindow.KMCStatus.CPUUsage)).ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusFasterOld", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.CurrentTime,
                                MainWindow.KMCStatus.TotalTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                ((float)(100f / MainWindow.KMCStatus.CPUUsage)).ToString("0.0"));
                    }
                }
                else if (MainWindow.KMCStatus.CPUUsage == 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalNew", MainWindow.cul),
                            MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                            MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                            (MainWindow.KMCStatus.CPUUsage).ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalNew", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                                MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                (MainWindow.KMCStatus.CPUUsage).ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusNormalOld", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.CurrentTime,
                                MainWindow.KMCStatus.TotalTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                (MainWindow.KMCStatus.CPUUsage).ToString("0.0"));
                    }
                }
                else if (MainWindow.KMCStatus.CPUUsage > 100f)
                {
                    if (MainWindow.KMCGlobals.RealTime)
                    {
                        MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerNew", MainWindow.cul),
                            MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                            MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                            ((float)(MainWindow.KMCStatus.CPUUsage / 100f)).ToString("0.0"));
                    }
                    else
                    {
                        if (MainWindow.KMCGlobals.OldTimeThingy == false)
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerNew", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.EstimatedTime,
                                MainWindow.KMCStatus.PassedTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                ((float)(MainWindow.KMCStatus.CPUUsage / 100f)).ToString("0.0"));
                        else
                            MainWindow.Delegate.CurrentStatusText.Text = String.Format(MainWindow.res_man.GetString("ConvStatusSlowerOld", MainWindow.cul),
                                MainWindow.KMCStatus.RAWConverted, MainWindow.KMCStatus.Percentage, MainWindow.KMCStatus.CurrentTime,
                                MainWindow.KMCStatus.TotalTime, Convert.ToInt32(MainWindow.KMCStatus.CPUUsage).ToString(),
                                ((float)(MainWindow.KMCStatus.CPUUsage / 100f)).ToString("0.0"));
                    }
                }
            }
        }

        private static void SetPeak()
        {
            if (!MainWindow.KMCGlobals.IsKMCBusy)
            {
                MainWindow.Delegate.labelRMS.Text = String.Format("{0}: {1:#0.0} dB | {2}: {3:#0.0} dB | {4}: {5:#0.0} dB",
                     MainWindow.res_man.GetString("RMS", MainWindow.cul), 0,
                     MainWindow.res_man.GetString("AverageLevel", MainWindow.cul), 0,
                     MainWindow.res_man.GetString("PeakLevel", MainWindow.cul), 0);
            }
            else {
                MainWindow.Delegate.labelRMS.Text = String.Format("{0}: {1:#0.0} | {2}: {3:#0.0} | {4}: {5:#0.0}",
                     MainWindow.res_man.GetString("RMS", MainWindow.cul), MainWindow.KMCGlobals._plm.RMS_dBV,
                     MainWindow.res_man.GetString("AverageLevel", MainWindow.cul), MainWindow.KMCGlobals._plm.AVG_dBV,
                     MainWindow.res_man.GetString("PeakLevel", MainWindow.cul), Math.Max(MainWindow.KMCGlobals._plm.PeakHoldLevelL_dBV, MainWindow.KMCGlobals._plm.PeakHoldLevelR_dBV));
            }
        }

        private static void CurrentMode(Int32 Mode) 
        {
            if (Mode == 0) // Idle
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}0/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), MainWindow.KMCGlobals.ActiveVoicesInt, MainWindow.KMCGlobals.LimitVoicesInt);
                MainWindow.Delegate.SettingsBox.Enabled = true;
                MainWindow.Delegate.label3.Enabled = true;
                MainWindow.Delegate.VolumeBar.Enabled = true;
                MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                thisProc.PriorityClass = ProcessPriorityClass.Idle;
            }
            else if (Mode == 1) // Memory allocation
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}0/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), MainWindow.KMCGlobals.ActiveVoicesInt, MainWindow.KMCGlobals.LimitVoicesInt);
                if (MainWindow.KMCGlobals.RenderingMode)
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.label3.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.label3.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.Delegate.VoiceLimit.Maximum = 2000;
                }
                thisProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
            else if (Mode == 2) // Rendering/Playback
            {
                MainWindow.Delegate.UsedVoices.Text = String.Format("{0}{1}/{2}", MainWindow.res_man.GetString("ActiveVoices", MainWindow.cul), MainWindow.KMCGlobals.ActiveVoicesInt, MainWindow.KMCGlobals.LimitVoicesInt);
                if (MainWindow.KMCGlobals.RenderingMode)
                {
                    MainWindow.Delegate.SettingsBox.Enabled = false;
                    MainWindow.Delegate.label3.Enabled = false;
                    MainWindow.Delegate.VolumeBar.Enabled = false;
                    MainWindow.Delegate.VoiceLimit.Maximum = 100000;
                }
                else
                {
                    MainWindow.Delegate.SettingsBox.Enabled = true;
                    MainWindow.Delegate.label3.Enabled = true;
                    MainWindow.Delegate.VolumeBar.Enabled = true;
                    MainWindow.Delegate.VoiceLimit.Maximum = 2000;
                }
                thisProc.PriorityClass = ProcessPriorityClass.High;
            }
        }

        private static void SetStatus(Int32 Mode)
        {
            if (Mode == 0) // Idle
            {
                MainWindow.Delegate.MIDIList.Enabled = true;
                MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Blocks;
                MainWindow.Delegate.CurrentStatus.Maximum = 999;
                MainWindow.Delegate.CurrentStatus.Value = 0;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
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
                MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Marquee;
                MainWindow.Delegate.CurrentStatus.Maximum = 1;
                MainWindow.Delegate.CurrentStatus.Value = 0;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
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

                if (!MainWindow.KMCGlobals.RealTime)
                {
                    MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Blocks;
                    MainWindow.Delegate.CurrentStatus.Maximum = MainWindow.KMCGlobals.CurrentStatusMaximumInt;
                    MainWindow.Delegate.CurrentStatus.Value = MainWindow.KMCGlobals.CurrentStatusValueInt;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    TaskbarManager.Instance.SetProgressValue(MainWindow.KMCGlobals.CurrentStatusValueInt, MainWindow.KMCGlobals.CurrentStatusMaximumInt);
                }
                else
                {
                    MainWindow.Delegate.CurrentStatus.Style = ProgressBarStyle.Marquee;
                    MainWindow.Delegate.CurrentStatus.Maximum = 1;
                    MainWindow.Delegate.CurrentStatus.Value = 0;
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                }
                DisableImportButtons();
                DisableEncoderButtons();
                UpdateText();
                thisProc.PriorityClass = ProcessPriorityClass.High;
            }
        }

        // Imports

        public static void KMCIdle()
        {
            SetStatus(0);
            CurrentMode(0);
            SetPeak();
        }

        public static void KMCMemoryAllocation()
        {
            SetStatus(1);
            CurrentMode(1);
            SetPeak();
        }

        public static void KMCBusy()
        {
            SetStatus(2);
            CurrentMode(2);
            SetPeak();
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
