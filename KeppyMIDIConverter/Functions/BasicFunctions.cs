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

        private static bool CustomStart = false;
        public static void PlayConversionStart()
        {
            FileStream CustomStartStream = null;
            String CustomStartLnk = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "convstart.wav";
            if (Properties.Settings.Default.AudioEvents)
            {
                if (File.Exists(CustomStartLnk)) { CustomStart = true; CustomStartStream = new FileStream(CustomStartLnk, FileMode.Open); } else { CustomStart = false; }
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convstart;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(CustomStart ? CustomStartStream : str);
                player.Play();
                str.Dispose();
                if (File.Exists(CustomStartLnk)) CustomStartStream.Dispose();
            }
        }

        private static bool CustomStop = false;
        public static void PlayConversionStop()
        {
            FileStream CustomStopStream = null;
            String CustomStopLnk = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "convfin.wav";
            if (Properties.Settings.Default.AudioEvents)
            {
                if (File.Exists(CustomStopLnk)) { CustomStop = true; CustomStopStream = new FileStream(CustomStopLnk, FileMode.Open); } else { CustomStop = false; }
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convfin;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(CustomStop ? CustomStopStream : str);
                player.Play();
                str.Dispose();
                if (File.Exists(CustomStopLnk)) CustomStopStream.Dispose();
            }
        }

        private static bool CustomError = false;
        public static void PlayConverterError()
        {
            FileStream CustomErrorStream = null;
            String CustomErrorLnk = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "convfail.wav";
            if (Properties.Settings.Default.AudioEvents)
            {
                if (File.Exists(CustomErrorLnk)) { CustomError = true; CustomErrorStream = new FileStream(CustomErrorLnk, FileMode.Open); } else { CustomError = false; }
                System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.convfail;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(CustomError ? CustomErrorStream : str);
                player.Play();
                str.Dispose();
                if (File.Exists(CustomErrorLnk)) CustomErrorStream.Dispose();
            }
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
            string url = "";

            string business = "prapapappo1999@gmail.com";
            string description = Languages.Parse("STDWD");
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

        public static void GCWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void CheckForUpdates(Boolean Startup)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppyMIDIConverter/kmcupdate.txt");
            StreamReader reader = new StreamReader(stream);
            String newestversion = reader.ReadToEnd();
            FileVersionInfo Driver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            Version x = null;
            Version.TryParse(newestversion.ToString(), out x);
            Version y = null;
            Version.TryParse(Driver.FileVersion.ToString(), out y);
            Thread.Sleep(50);
            if (x > y)
            {
                DialogResult dialogResult = MessageBox.Show(String.Format(Languages.Parse("UpdateFound"), Program.Who, Program.Title), String.Format(Languages.Parse("UpdateFoundTitle"), Program.Who, Program.Title), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateDownloader frm = new UpdateDownloader(newestversion);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            else
            {
                if (!Startup)
                {
                    MessageBox.Show(String.Format(Languages.Parse("NoUpdatesFound"), Program.Who, Program.Title), String.Format(Languages.Parse("NoUpdatesFoundTitle"), Program.Who, Program.Title), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static bool CheckSizeOverride()
        {
            if (MainWindow.ModifierKeys == Keys.Control)
            {
                MessageBox.Show(Languages.Parse("IgnoreSize"), Languages.Parse("Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
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
            if (notes == "0" || GetMIDILength(str) == -1) MessageBox.Show(String.Format(Languages.Parse("InvalidMIDIFile"), Path.GetFileName(str)), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MainWindow.Delegate.MIDIList.Items.Add(lvi);
        }

        public static void AddFilesToList(String[] filenames, Boolean IsImportDialog, Boolean GetEntireSize)
        {
            foreach (string str in filenames)
            {
                try
                {
                    Stream SM = File.Open(str, FileMode.Open);
                    StreamReader SMs = new StreamReader(SM);
                    BinaryReader SMb = new BinaryReader(SMs.BaseStream);
                    String Header = new String(SMb.ReadChars(4));

                    SMb.Dispose();
                    SMs.Dispose();
                    SM.Dispose();

                    if (Header.Contains("MThd") || Header.Contains("RIFF"))
                    {
                        if (MainWindow.ModifierKeys == Keys.Shift)
                        {
                            Int32 UserAnswer = Int32.Parse(Microsoft.VisualBasic.Interaction.InputBox(
                                String.Format(Languages.Parse("HowManyTimesAdd"), str), MainWindow.Title, "1"));

                            if (UserAnswer == 0) UserAnswer = 1;

                            string[] midiinfo = DataCheck.GetMoreInfoMIDI(str, GetEntireSize);
                            ListViewItem lvi = new ListViewItem(new string[] { str, midiinfo[2], midiinfo[1], midiinfo[0], midiinfo[3] });

                            for (int i = 0; i < UserAnswer; i++) ToAddOrNotToAdd(lvi, midiinfo[1], str);
                        }
                        else
                        {
                            string[] midiinfo = DataCheck.GetMoreInfoMIDI(str, GetEntireSize);
                            ListViewItem lvi = new ListViewItem(new string[] { str, midiinfo[2], midiinfo[1], midiinfo[0], midiinfo[3] } );
                            ToAddOrNotToAdd(lvi, midiinfo[1], str);
                        }

                    }
                    else MessageBox.Show(String.Format(Languages.Parse("InvalidMIDIFile"), Path.GetFileName(str)), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exception)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                    errordialog.ShowDialog();
                }
            }
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
