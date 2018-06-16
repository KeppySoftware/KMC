using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyMIDIConverter
{
    class BasicFunctions
    {
        public static void WriteCurrentActionToConsole(Boolean IsError, String CurrentAction)
        {
            if (Program.DebugMode)
            {
                Console.BackgroundColor = IsError ? ConsoleColor.Red : ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write(String.Format("{0} - {1}", DateTime.Now.ToString(), CurrentAction));
                Console.ResetColor();
            }
        }

        public static void WriteToConsole(Exception exception)
        {
            if (Program.DebugMode)
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
        }

        public static void ReturnCustomFramerate(out double[] fpsarr)
        {
            fpsarr = new double[2] { (1.0 / Properties.Settings.Default.RealTimeFPS) - 0.00005556, (1.0 / Properties.Settings.Default.RealTimeFPS) + 0.00005556 };
        }

        static void PlayKMCSound(String CustomSound, ref Boolean CustomSoundBool, Stream DefaultSound)
        {
            FileStream CustomStream = null;
            String CustomLnk = String.Format("{0}\\CustomSounds\\{1}.wav", Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.FullName, CustomSound);
            if (Properties.Settings.Default.AudioEvents)
            {
                if (File.Exists(CustomLnk)) { CustomSoundBool = true; CustomStream = new FileStream(CustomLnk, FileMode.Open); } else { CustomSoundBool = false; }
                Stream str = DefaultSound;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(CustomSoundBool ? CustomStream : str);
                player.Play();
                str.Dispose();
                if (File.Exists(CustomLnk)) CustomStream.Dispose();
            }
        }

        private static bool CustomStart = false;
        public static void PlayConversionStart()
        {
            PlayKMCSound("convstart", ref CustomStart, Properties.Resources.convstart);
        }

        private static bool CustomStop = false;
        public static void PlayConversionStop()
        {
            PlayKMCSound("convfin", ref CustomStop, Properties.Resources.convfin);
        }

        private static bool CustomError = false;
        public static void PlayConverterError()
        {
            PlayKMCSound("convfail", ref CustomError, Properties.Resources.convfail);
        }

        public enum MoveDirection { Up = -1, Down = 1 };
        public static void MoveListViewItems(ListView sender, MoveDirection direction)
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

        public static DateTime GetLinkerTime(Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }

        public static void Donate()
        {
            Process.Start("https://paypal.me/KaleidonKep99");
        }

        public static void GCWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Threading.Thread.Sleep(100);
            }
        }

        static Boolean AlreadyChecking = false;
        public static void CheckForUpdates(Boolean Startup)
        {
            if (!AlreadyChecking)
            {
                new Thread(() =>
                {
                    AlreadyChecking = true;
                    Thread.CurrentThread.IsBackground = true;

                    WebClient client;
                    Stream stream;
                    try
                    {
                        client = new WebClient();
                        stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppyMIDIConverter/kmcupdate.txt");
                        StreamReader reader = new StreamReader(stream);
                        String newestversion = reader.ReadToEnd();
                        FileVersionInfo Converter = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                        Version.TryParse(newestversion, out Version x);
                        Version.TryParse(Converter.FileVersion.ToString(), out Version y);
                        if (x > y)
                        {
                            while (Application.OpenForms.OfType<MainWindow>().Count() != 1)
                                Thread.Sleep(1);

                            MainWindow.Delegate.Invoke((MethodInvoker)delegate {
                                DialogResult dialogResult = MessageBox.Show(String.Format(Languages.Parse("UpdateFound"), Program.Who, Program.Title, Converter.FileVersion, newestversion), String.Format(Languages.Parse("UpdateFoundTitle"), Program.Who, Program.Title), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    UpdateDownloader frm = new UpdateDownloader(newestversion)
                                    {
                                        StartPosition = FormStartPosition.CenterScreen
                                    };
                                    frm.ShowDialog();
                                }
                            });
                        }
                        else
                        {
                            if (!Startup)
                            {
                                MainWindow.Delegate.Invoke((MethodInvoker)delegate {
                                    MessageBox.Show(String.Format(Languages.Parse("NoUpdatesFound"), Program.Who, Program.Title), String.Format(Languages.Parse("NoUpdatesFoundTitle"), Program.Who, Program.Title), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                });      
                            }
                        }
                    }
                    catch
                    {
                        if (!Startup)
                        {
                            MainWindow.Delegate.Invoke((MethodInvoker)delegate {
                                MessageBox.Show(String.Format(Languages.Parse("NoUpdatesFound"), Program.Who, Program.Title), String.Format(Languages.Parse("NoUpdatesFoundTitle"), Program.Who, Program.Title), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            });
                        }
                    }
                    AlreadyChecking = false;
                }).Start();
            }
        }

        public static long GetMIDILength(string str)
        {
            Bass.BASS_Init(0, 22050, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
            Int32 Stream = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE, 0);
            Int64 Time = Bass.BASS_ChannelGetLength(Stream);
            Bass.BASS_StreamFree(Stream);
            Bass.BASS_Free();
            return Time;

        }

        public static void ToAddOrNotToAdd(ListViewItem lvi, string notes, string str)
        {
            if (notes == "0" || GetMIDILength(str) == -1)
                MainWindow.Delegate.Invoke((MethodInvoker)delegate { MessageBox.Show(String.Format(Languages.Parse("InvalidMIDIFile"), Path.GetFileName(str)), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error); });
            else
                MainWindow.Delegate.Invoke((MethodInvoker)delegate { MainWindow.Delegate.MIDIList.Items.Add(lvi); });
        }

        public static void AddMIDIToListWithInfo(string MIDI)
        {
            string[] midiinfo = DataCheck.GetMoreInfoMIDI(MIDI);
            ListViewItem lvi = new ListViewItem(new string[] { MIDI, midiinfo[2], midiinfo[1], midiinfo[0], midiinfo[3] });
            ToAddOrNotToAdd(lvi, midiinfo[1], MIDI);
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
}
