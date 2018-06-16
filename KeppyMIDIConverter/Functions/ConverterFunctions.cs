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
                        Bass.BASS_ChannelGetAttribute((MainWindow.VSTs.VSTInfo[0].isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle), BASSAttribute.BASS_ATTRIB_CPU, ref RTF.CPUUsage);
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
                MainWindow.Delegate.Invoke((MethodInvoker)delegate {
                    ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), Languages.Parse("ConverterIsBusyAlready"), 0, 0);
                    errordialog.ShowDialog();
                });
            }
        }

        private static BASSActive CheckStreamStatus()
        {
            return Bass.BASS_ChannelIsActive(MainWindow.KMCGlobals._recHandle);
        }

        public static void CPWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    BasicFunctions.PlayConversionStart();

                    // First of all, initialize BASS itself
                    BASSControl.BASSInitSystem(false);
                    BASSControl.InitializeDummyVSTs();
                    foreach (String str in MainWindow.KMCGlobals.MIDIs)
                    {
                        // Initialize BASS stream
                        BASSControl.BASSStreamSystem(str, false);
                        BASSControl.BASSLoadSoundFonts(str);
                        BASSControl.BASSInitVSTiIfNeeded(false);
                        BASSControl.InitializeVSTsForStream((MainWindow.VSTs.VSTInfo[0].isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                        BASSControl.BASSEffectSettings();
                        BASSControl.BASSVolumeSlideInit();
                        BASSControl.BASSEncoderInit(MainWindow.KMCGlobals.CurrentEncoder, str);

                        // Get length of the stream
                        Int64 pos = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle);
                        Int64 length = Convert.ToInt64(Bass.BASS_ChannelSeconds2Bytes(MainWindow.KMCGlobals._recHandle, 0.0275));

                        // KMC is now busy
                        MainWindow.KMCStatus.IsKMCNowExporting = true;
                        while (BASSControl.BASSEncodingEngine(pos, length))
                        {
                            if (MainWindow.KMCGlobals.CancellationPendingValue == 1)
                                break;
                        }
                        BASSControl.ReleaseResources((MainWindow.KMCGlobals.CancellationPendingValue != 1));
                    }

                    MainWindow.KMCStatus.RenderingMode = false;
                    MainWindow.KMCStatus.IsKMCBusy = false;
                    MainWindow.KMCStatus.IsKMCNowExporting = false;
                    MainWindow.KMCGlobals.VSTSkipSettings = false;

                    String Msg = (MainWindow.KMCGlobals.CancellationPendingValue == 1) ? "ConversionAborted" : "ConversionCompleted";
                    BASSControl.BASSCloseStream(Languages.Parse(Msg), Languages.Parse(Msg), 0);

                    if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                    {
                        if (MainWindow.KMCGlobals.AutoShutDownEnabled == true)
                            Process.Start(new ProcessStartInfo("shutdown", "/s /t 0") { CreateNoWindow = true, UseShellExecute = false });

                        if (MainWindow.KMCGlobals.AutoClearMIDIListEnabled)
                            MainWindow.Delegate.Invoke((MethodInvoker)delegate { MainWindow.Delegate.MIDIList.Items.Clear(); });
                    }

                    BasicFunctions.PlayConversionStop();
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

                    // First of all, initialize BASS itself
                    BASSControl.BASSInitSystem(false);
                    BASSControl.InitializeDummyVSTs();
                    foreach (String str in MainWindow.KMCGlobals.MIDIs)
                    {
                        // Initialize RT stuff
                        Double[] CustomFramerates;
                        BasicFunctions.ReturnCustomFramerate(out CustomFramerates);
                        MainWindow.FPSSimulator.NextDouble();

                        // Initialize BASS stream
                        BASSControl.BASSStreamSystemRT(str, false);
                        BASSControl.BASSLoadSoundFonts(str);
                        BASSControl.BASSInitVSTiIfNeeded(false);
                        BASSControl.InitializeVSTsForStream((MainWindow.VSTs.VSTInfo[0].isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                        BASSControl.BASSEffectSettings();
                        BASSControl.BASSVolumeSlideInit();
                        BASSControl.BASSEncoderInit(MainWindow.KMCGlobals.CurrentEncoder, str);

                        // Get length of the stream
                        Int64 pos = 0, es = 0;

                        // KMC is now busy
                        MainWindow.KMCStatus.IsKMCNowExporting = true;
                        for (pos = 0, es = 0; ;)
                        {
                            if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                            {
                                if (!BASSControl.BASSEncodingEngineRT(CustomFramerates, ref pos, ref es)) break;
                            }
                            else break;
                        }
                        BASSControl.ReleaseResources((MainWindow.KMCGlobals.CancellationPendingValue != 1));
                    }

                    MainWindow.KMCStatus.RenderingMode = false;
                    MainWindow.KMCStatus.IsKMCBusy = false;
                    MainWindow.KMCStatus.IsKMCNowExporting = false;
                    MainWindow.KMCGlobals.VSTSkipSettings = false;

                    String Msg = (MainWindow.KMCGlobals.CancellationPendingValue == 1) ? "ConversionAborted" : "ConversionCompleted";
                    BASSControl.BASSCloseStream(Languages.Parse(Msg), Languages.Parse(Msg), 0);

                    if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                    {
                        if (MainWindow.KMCGlobals.AutoShutDownEnabled == true)
                            Process.Start(new ProcessStartInfo("shutdown", "/s /t 0") { CreateNoWindow = true, UseShellExecute = false });

                        if (MainWindow.KMCGlobals.AutoClearMIDIListEnabled)
                            MainWindow.Delegate.Invoke((MethodInvoker)delegate { MainWindow.Delegate.MIDIList.Items.Clear(); });
                    }

                    BasicFunctions.PlayConversionStop();
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

                    // First of all, initialize BASS itself
                    BASSControl.BASSInitSystem(true);
                    BASSControl.InitializeDummyVSTs();
                    foreach (String str in MainWindow.KMCGlobals.MIDIs)
                    {
                        // Initialize BASS stream
                        BASSControl.BASSStreamSystem(str, true);
                        BASSControl.BASSLoadSoundFonts(str);
                        BASSControl.BASSInitVSTiIfNeeded(true);
                        BASSControl.InitializeVSTsForStream((MainWindow.VSTs.VSTInfo[0].isInstrument ? MainWindow.VSTs._VSTHandles[0] : MainWindow.KMCGlobals._recHandle));
                        BASSControl.BASSEffectSettings();
                        BASSControl.BASSVolumeSlideInit();
                        BASSControl.BASSEncoderInit(MainWindow.KMCGlobals.CurrentEncoder, str);

                        // Get length of the stream
                        Int64 Position = Bass.BASS_ChannelGetLength(MainWindow.KMCGlobals._recHandle);
                        Int64 Length = Convert.ToInt64(Bass.BASS_ChannelSeconds2Bytes(MainWindow.KMCGlobals._recHandle, 0.0275));

                        // Notes stuff
                        if (!MainWindow.KMCGlobals.DoNotCountNotes)
                        {
                            try
                            {
                                MainWindow.KMCGlobals._mySync = new SYNCPROC(BASSControl.NoteSyncProc);
                                Bass.BASS_ChannelSetSync(MainWindow.KMCGlobals._recHandle, BASSSync.BASS_SYNC_MIDI_EVENT, (Int64)BASSMIDIEvent.MIDI_EVENT_NOTE, MainWindow.KMCGlobals._mySync, IntPtr.Zero);
                                MainWindow.KMCStatus.TotalNotesOrg = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(MainWindow.KMCGlobals._recHandle, -1, (BASSMIDIEvent)0x20000, null);
                                MainWindow.KMCStatus.TotalNotes = MainWindow.KMCStatus.TotalNotesOrg;
                            }
                            catch (Exception ex)
                            {
                                BasicFunctions.WriteToConsole(ex);
                                MainWindow.KMCGlobals.DoNotCountNotes = true;
                            }
                        }

                        // KMC is now busy
                        MainWindow.KMCStatus.IsKMCNowExporting = true;
                        BassWasapi.BASS_WASAPI_Start();
                        while (CheckStreamStatus() != BASSActive.BASS_ACTIVE_STOPPED)
                        {
                            if (MainWindow.KMCGlobals.CancellationPendingValue != 1)
                                BASSControl.BASSPlayBackEngine(Length, Position);
                            else break;

                            TimerFuncs.MicroSleep(-1);
                        }
                        BASSControl.ReleaseResources((MainWindow.KMCGlobals.CancellationPendingValue != 1));
                    }

                    MainWindow.KMCStatus.RenderingMode = false;
                    MainWindow.KMCStatus.IsKMCBusy = false;
                    MainWindow.KMCStatus.IsKMCNowExporting = false;
                    MainWindow.KMCGlobals.VSTSkipSettings = false;

                    String Msg = (MainWindow.KMCGlobals.CancellationPendingValue == 1) ? "PlaybackAborted" : "PlaybackCompleted";
                    BASSControl.BASSCloseStream(Languages.Parse(Msg), Languages.Parse(Msg), 0);

                    BasicFunctions.PlayConversionStop();
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
