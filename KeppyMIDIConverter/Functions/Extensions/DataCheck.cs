using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// BASS
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyMIDIConverter
{
    class DataCheck
    {
        public static long GetMIDILength(string str)
        {
            Bass.BASS_Init(0, 22050, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
            Int32 time = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE, 0);
            Bass.BASS_StreamFree(time);
            Bass.BASS_Free();
            return Bass.BASS_ChannelGetLength(time);
        }

        public static string[] GetMoreInfoMIDI(string str, bool overridedefault)
        {
            try
            {
                // Get size of MIDI
                long length = new System.IO.FileInfo(str).Length;
                string size;
                try
                {
                    if (length / 1024f >= 1000000000)
                        size = ((((length / 1024f) / 1024f) / 1024f) / 1024f).ToString("0.0 TiB");
                    else if (length / 1024f >= 1000000)
                        size = (((length / 1024f) / 1024f) / 1024f).ToString("0.0 GiB");
                    else if (length / 1024f >= 1000)
                        size = ((length / 1024f) / 1024f).ToString("0.0 MiB");
                    else if (length / 1024f >= 1)
                        size = (length / 1024f).ToString("0.0 KiB");
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
                        return new string[] { Languages.Parse("NA"), Languages.Parse("NA"), Languages.Parse("NA"), size, };
                    }
                }

                Bass.BASS_Init(0, 22050, BASSInit.BASS_DEVICE_NOSPEAKER, IntPtr.Zero);
                Int32 time = BassMidi.BASS_MIDI_StreamCreateFile(str, 0L, 0L, BASSFlag.BASS_STREAM_DECODE, 0);
                Int64 pos = Bass.BASS_ChannelGetLength(time);
                Double num9 = Bass.BASS_ChannelBytes2Seconds(time, pos);
                TimeSpan span = TimeSpan.FromSeconds(num9);

                // Get length of MIDI
                string Length = span.Minutes.ToString() + ":" + span.Seconds.ToString().PadLeft(2, '0') + "." + span.Milliseconds.ToString().PadLeft(3, '0');

                UInt64 count = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(time, -1, BASSMIDIEvent.MIDI_EVENT_NOTES, null);
                Int32 Tracks = BassMidi.BASS_MIDI_StreamGetTrackCount(time);

                Bass.BASS_Free();
                return new string[] { Length, Tracks.ToString("N0"), count.ToString("N0"), size, };
            }
            catch
            {
                MessageBox.Show(String.Format(Languages.Parse("NoEnoughMemoryParseInfo"), str), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return new string[] { Languages.Parse("NA"), Languages.Parse("NA"), Languages.Parse("NA"), Languages.Parse("NA") };
            }
        }

        public static void ToAddOrNotToAdd(ListViewItem lvi, string notes, string str)
        {
            if (notes == "0" || GetMIDILength(str) == -1)
                MessageBox.Show(String.Format(Languages.Parse("InvalidMIDIFile"), Path.GetFileName(str)), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MainWindow.Delegate.MIDIList.Items.Add(lvi);
        }
    }
}
