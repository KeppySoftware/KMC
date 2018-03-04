using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;
using Un4seen.BassWasapi;

namespace KeppyMIDIConverter
{
    class ConverterFunctions
    {
        public static void RTTick(object sender, EventArgs e)
        {
            try
            {
                MainWindow.KMCDialogs.MIDIImport.InitialDirectory = Properties.Settings.Default.LastMIDIFolder;

                if (!MainWindow.KMCStatus.IsKMCBusy)
                {
                    RTF.KMCIdle();
                }
                else
                {
                    if (!MainWindow.KMCStatus.IsKMCNowExporting)
                        RTF.KMCMemoryAllocation();
                    else
                        RTF.KMCBusy();
                }

                System.Threading.Thread.Sleep(1);
            }
            catch (Exception ex)
            {
                BasicFunctions.WriteToConsole(ex);
            }
        }

        public static void GIWWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (MainWindow.KMCStatus.IsKMCBusy || MainWindow.KMCStatus.IsKMCNowExporting)
                    {
                        RTF.TotalTicks = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle, BASSMode.BASS_POS_MIDI_TICK);
                        RTF.CurrentTicks = Bass.BASS_ChannelGetPosition(MainWindow.KMCGlobals._recHandle, BASSMode.BASS_POS_MIDI_TICK);
                        RTF.MIDILengthRAW = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle);
                        RTF.MIDICurrentPosRAW = Bass.BASS_ChannelGetPosition(MainWindow.KMCGlobals._recHandle);
                        RTF.RAWTotal = ((float)RTF.MIDILengthRAW) / 1048576f;
                        RTF.RAWConverted = ((float)RTF.MIDICurrentPosRAW) / 1048576f;
                        RTF.LenRAWToDouble = Bass.BASS_ChannelBytes2Seconds(MainWindow.KMCGlobals._recHandle, RTF.MIDILengthRAW);
                        RTF.CurRAWToDouble = Bass.BASS_ChannelBytes2Seconds(MainWindow.KMCGlobals._recHandle, RTF.MIDICurrentPosRAW);
                        RTF.LenDoubleToSpan = TimeSpan.FromSeconds(RTF.LenRAWToDouble * MainWindow.KMCGlobals.TempoScale);
                        RTF.CurDoubleToSpan = TimeSpan.FromSeconds(RTF.CurRAWToDouble * MainWindow.KMCGlobals.TempoScale);
                        Bass.BASS_ChannelGetAttribute(MainWindow.KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_CPU, ref RTF.CPUUsage);
                        Bass.BASS_ChannelGetAttribute(MainWindow.KMCGlobals._recHandle, BASSAttribute.BASS_ATTRIB_MIDI_VOICES_ACTIVE, ref RTF.ActiveVoices);
                        RTF.GetVoices();
                    }
                    System.Threading.Thread.Sleep(1);
                }
                catch { }
            }
        }

        public static void StartRenderingThread(Boolean PreviewMode)
        {
            try
            {
                MainWindow.KMCStatus.IsKMCBusy = true;
                MainWindow.KMCStatus.RenderingMode = true;

                if (MainWindow.ModifierKeys == Keys.Control)
                {
                    MainWindow.KMCGlobals.VSTSkipSettings = true;
                    MessageBox.Show(Languages.Parse("SkipVSTSettings"), MainWindow.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (PreviewMode)
                {
                    MainWindow.KMCStatus.RenderingMode = false;

                    MainWindow.KMCGlobals.MIDIs = new string[MainWindow.Delegate.MIDIList.Items.Count];
                    for (int i = 0; i < MainWindow.Delegate.MIDIList.Items.Count; i++)
                        MainWindow.KMCGlobals.MIDIs[i] += MainWindow.Delegate.MIDIList.Items[i].Text;

                    MainWindow.KMCGlobals.RealTime = false;
                    MainWindow.KMCThreads.PlaybackProcess.RunWorkerAsync();
                }
                else
                {
                    MainWindow.KMCDialogs.MIDIExport.InitialDirectory = Properties.Settings.Default.LastExportFolder;
                    if (MainWindow.KMCDialogs.MIDIExport.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        MainWindow.KMCGlobals.CurrentStatusTextString = null;
                        Properties.Settings.Default.LastExportFolder = MainWindow.KMCDialogs.MIDIExport.FileName;
                        Properties.Settings.Default.Save();

                        MainWindow.KMCGlobals.MIDIs = new string[MainWindow.Delegate.MIDIList.Items.Count];
                        for (int i = 0; i < MainWindow.Delegate.MIDIList.Items.Count; i++)
                            MainWindow.KMCGlobals.MIDIs[i] += MainWindow.Delegate.MIDIList.Items[i].Text;

                        if (Properties.Settings.Default.RealTimeSimulator)
                        {
                            MainWindow.KMCGlobals.RealTime = true;
                            MainWindow.KMCThreads.ConversionProcessRT.RunWorkerAsync();
                        }
                        else
                        {
                            MainWindow.KMCGlobals.RealTime = false;
                            MainWindow.KMCThreads.ConversionProcess.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        MainWindow.KMCStatus.IsKMCBusy = false;
                        MainWindow.KMCStatus.RenderingMode = false;
                    }
                }
            }
            catch
            {
                MainWindow.KMCStatus.IsKMCBusy = false;
                MainWindow.KMCStatus.RenderingMode = false;
                ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), Languages.Parse("ConverterIsBusyAlready"), 0, 0);
                errordialog.ShowDialog();
            }
        }

        public static void CPWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    BasicFunctions.PlayConversionStart();
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (String str in MainWindow.KMCGlobals.MIDIs)
                        {
                            BASSControl.BASSInitSystem(false);
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            BASSControl.BASSStreamSystem(str, false);
                            BASSControl.BASSLoadSoundFonts();
                            BASSControl.BASSInitVSTiIfNeeded(false);
                            BASSControl.BASSVSTInit((MainWindow.KMCGlobals.vstIInfo.isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                            BASSControl.BASSEffectSettings();
                            BASSControl.BASSEncoderInit(MainWindow.KMCGlobals.CurrentEncoder, str);
                            long pos = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle);
                            int length = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes(MainWindow.KMCGlobals._recHandle, 0.03));
                            MainWindow.KMCStatus.IsKMCNowExporting = true;
                            bool DoINeedToContinue;
                            while (true)
                            {
                                if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                                {
                                    DoINeedToContinue = BASSControl.BASSEncodingEngine(pos, length);
                                    if (DoINeedToContinue == false) break;
                                }
                                else if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                                {
                                    BASSControl.BASSCloseStream(Languages.Parse("ConversionAborted"), Languages.Parse("ConversionAborted"), 0);
                                    KeepLooping = false;
                                    break;
                                }
                            }
                            if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                            {
                                BASSControl.ReleaseResources(false);
                                KeepLooping = false;
                                break;
                            }
                            else
                            {
                                BASSControl.ReleaseResources(true);
                                KeepLooping = false;
                                continue;
                            }
                        }
                        if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSControl.BASSCloseStream(Languages.Parse("ConversionAborted"), Languages.Parse("ConversionAborted"), 0);
                            KeepLooping = false;
                            MainWindow.KMCStatus.RenderingMode = false;
                            MainWindow.KMCStatus.IsKMCBusy = false;
                            MainWindow.KMCStatus.IsKMCNowExporting = false;
                            MainWindow.KMCGlobals.VSTSkipSettings = false;
                            BasicFunctions.PlayConversionStop();
                        }
                        else
                        {
                            BASSControl.BASSCloseStream(Languages.Parse("ConversionCompleted"), Languages.Parse("ConversionCompleted"), 1);
                            MainWindow.KMCStatus.RenderingMode = false;
                            MainWindow.KMCStatus.IsKMCBusy = false;
                            MainWindow.KMCStatus.IsKMCNowExporting = false;
                            MainWindow.KMCGlobals.VSTSkipSettings = false;

                            if (MainWindow.KMCGlobals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }

                            if (MainWindow.KMCGlobals.AutoClearMIDIListEnabled == true)
                            {
                                MainWindow.Delegate.Invoke((MethodInvoker)delegate { MainWindow.Delegate.MIDIList.Items.Clear(); });
                                BasicFunctions.PlayConversionStop();
                            }
                            else
                            {
                                BasicFunctions.PlayConversionStop();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    BasicFunctions.WriteToConsole(exception);
                    BASSControl.ReleaseResources(false);
                }
            }
            catch (Exception exception2)
            {
                BASSControl.BASSCloseStreamCrash(exception2);
            }
        }

        public static void CPRWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    BasicFunctions.PlayConversionStart();
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (String str in MainWindow.KMCGlobals.MIDIs)
                        {
                            BASSControl.BASSInitSystem(false);
                            double[] CustomFramerates;
                            BasicFunctions.ReturnCustomFramerate(out CustomFramerates);
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            BASSControl.BASSStreamSystemRT(str, false);
                            BASSControl.BASSLoadSoundFonts();
                            BASSControl.BASSInitVSTiIfNeeded(false);
                            BASSControl.BASSVSTInit((MainWindow.KMCGlobals.vstIInfo.isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                            BASSControl.BASSEffectSettings();
                            BASSControl.BASSEncoderInit(MainWindow.KMCGlobals.CurrentEncoder, str);
                            int pos = 0;
                            uint es = 0;
                            MainWindow.FPSSimulator.NextDouble();
                            MainWindow.KMCStatus.IsKMCNowExporting = true;
                            bool DoINeedToContinue;
                            for (pos = 0, es = 0; ;)
                            {
                                if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                                {
                                    DoINeedToContinue = BASSControl.BASSEncodingEngineRT(CustomFramerates, ref pos, ref es);
                                    if (DoINeedToContinue == false) break;
                                }
                                else if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                                {
                                    BASSControl.BASSCloseStream(Languages.Parse("ConversionAborted"), Languages.Parse("ConversionAborted"), 0);
                                    BASSControl.ReleaseResources(false);
                                    KeepLooping = false;
                                    break;
                                }
                                else if (MainWindow.KMCGlobals.CancellationPendingValue == 2)
                                {
                                    BASSControl.ReleaseResources(true);
                                    KeepLooping = false;
                                    continue;
                                }
                            }
                            if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                            {
                                MainWindow.KMCGlobals.events = null;
                                MainWindow.KMCStatus.RenderingMode = false;
                                MainWindow.KMCStatus.IsKMCBusy = false;
                                MainWindow.KMCStatus.IsKMCNowExporting = false;
                                MainWindow.KMCGlobals.VSTSkipSettings = false;
                                break;
                            }
                            else
                            {
                                MainWindow.KMCGlobals.events = null;
                                continue;
                            }
                        }
                        if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSControl.BASSCloseStream(Languages.Parse("ConversionAborted"), Languages.Parse("ConversionAborted"), 0);
                            KeepLooping = false;
                            MainWindow.KMCStatus.IsKMCBusy = false;
                            MainWindow.KMCStatus.IsKMCNowExporting = false;
                            MainWindow.KMCStatus.RenderingMode = false;
                            MainWindow.KMCGlobals.VSTSkipSettings = false;
                            MainWindow.KMCGlobals.eventc = 0;
                            MainWindow.KMCGlobals.events = null;
                            BasicFunctions.PlayConversionStop();
                        }
                        else
                        {
                            BASSControl.BASSCloseStream(Languages.Parse("ConversionCompleted"), Languages.Parse("ConversionCompleted"), 1);
                            MainWindow.KMCStatus.IsKMCBusy = false;
                            MainWindow.KMCStatus.IsKMCNowExporting = false;
                            MainWindow.KMCStatus.RenderingMode = false;
                            MainWindow.KMCGlobals.VSTSkipSettings = false;
                            KeepLooping = false;
                            MainWindow.KMCGlobals.eventc = 0;
                            MainWindow.KMCGlobals.events = null;
                            if (MainWindow.KMCGlobals.AutoShutDownEnabled == true)
                            {
                                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                                psi.CreateNoWindow = true;
                                psi.UseShellExecute = false;
                                Process.Start(psi);
                            }
                            if (MainWindow.KMCGlobals.AutoClearMIDIListEnabled == true)
                            {
                                MainWindow.Delegate.Invoke((MethodInvoker)delegate
                                {
                                    MainWindow.Delegate.MIDIList.Items.Clear();
                                });
                                BasicFunctions.PlayConversionStop();
                            }
                            else
                            {
                                BasicFunctions.PlayConversionStop();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    BasicFunctions.WriteToConsole(exception);
                    BASSControl.ReleaseResources(false);
                }
            }
            catch (Exception exception2)
            {
                BASSControl.BASSCloseStreamCrash(exception2);
            }
        }

        public static void PBWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    BasicFunctions.PlayConversionStart();
                    bool KeepLooping = true;
                    while (KeepLooping)
                    {
                        foreach (String str in MainWindow.KMCGlobals.MIDIs)
                        {
                            MainWindow.KMCStatus.PlayedNotes = 0;
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str);
                            BASSControl.BASSInitSystem(true);
                            BASSControl.BASSStreamSystem(str, true);
                            BASSControl.BASSInitVSTiIfNeeded(true);
                            BASSControl.BASSLoadSoundFonts();
                            BASSControl.BASSVSTInit((MainWindow.KMCGlobals.vstIInfo.isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                            BASSControl.BASSEffectSettings();
                            long pos = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle);
                            // cac
                            int notes = 0;
                            if (!MainWindow.KMCGlobals.DoNotCountNotes)
                            {
                                try
                                {
                                    MainWindow.KMCGlobals._mySync = new SYNCPROC(BASSControl.NoteSyncProc);
                                    int sync = Bass.BASS_ChannelSetSync(MainWindow.KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT, (long)BASSMIDIEvent.MIDI_EVENT_NOTE, MainWindow.KMCGlobals._mySync, IntPtr.Zero);
                                    MainWindow.KMCStatus.TotalNotesOrg = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(MainWindow.KMCGlobals._recHandle, -1, (BASSMIDIEvent)0x20000, null);
                                    MainWindow.KMCStatus.TotalNotes = MainWindow.KMCStatus.TotalNotesOrg;
                                }
                                catch (Exception ex)
                                {
                                    BasicFunctions.WriteToConsole(ex);
                                    MainWindow.KMCGlobals.DoNotCountNotes = true;
                                }
                            }
                            MainWindow.KMCStatus.IsKMCNowExporting = true;
                            int length = Convert.ToInt32(Bass.BASS_ChannelSeconds2Bytes(MainWindow.KMCGlobals._recHandle, 1.0));
                            BassWasapi.BASS_WASAPI_Start();
                            while (Bass.BASS_ChannelIsActive((MainWindow.KMCGlobals.vstIInfo.isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle)) == BASSActive.BASS_ACTIVE_PLAYING)
                            {
                                if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                                {
                                    notes = BASSControl.BASSPlayBackEngine(notes, length, pos);
                                }
                                else if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                                {
                                    break;
                                }
                            }
                            if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                            {
                                BASSControl.BASSCloseStream(Languages.Parse("PlaybackAborted"), Languages.Parse("PlaybackAborted"), 0);
                                BASSControl.ReleaseResources(false);
                                KeepLooping = false;
                                break;
                            }
                            else
                            {
                                BASSControl.ReleaseResources(true);
                                KeepLooping = false;
                                continue;
                            }
                        }
                        if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                        {
                            BASSControl.BASSCloseStream(Languages.Parse("PlaybackAborted"), Languages.Parse("PlaybackAborted"), 1);
                            KeepLooping = false;
                        }
                        else
                        {
                            BASSControl.BASSCloseStream("null", "null", 1);
                            break;
                        }
                    }
                }
                catch (Exception exception)
                {
                    BasicFunctions.WriteToConsole(exception);
                    BASSControl.ReleaseResources(false);
                }
            }
            catch (Exception exception2)
            {
                BASSControl.BASSCloseStreamCrash(exception2);
            }
        }
    }
}
