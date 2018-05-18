using System;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyMIDIConverter
{
    public partial class TracksToIgnore : Form
    {
        public TracksToIgnore()
        {
            InitializeComponent();
            Text = Languages.Parse("TracksToIgnoreTitle");

            int TracksCount = BassMidi.BASS_MIDI_StreamGetTrackCount(MainWindow.KMCGlobals._recHandle);
 
            for (int i = 0; i < TracksCount; i++)
            {
                BASS_MIDI_MARK[] TracksText = BassMidi.BASS_MIDI_StreamGetMarks(MainWindow.KMCGlobals._recHandle, i, BASSMIDIMarker.BASS_MIDI_MARK_TRACK);

                if (TracksText != null)
                    TracksCheckboxes.Items.Add(String.Format("Track {0} - {1}", i + 1, TracksText[0].ToString()), false);
                else
                    TracksCheckboxes.Items.Add(String.Format("Track {0}", i + 1), false);
            }
        }

        private void TracksToIgnore_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            BASSControl.TracksList = new Boolean[TracksCheckboxes.Items.Count];

            for (int i = 0; i < TracksCheckboxes.Items.Count; i++)
                BASSControl.TracksList[i] = TracksCheckboxes.GetItemChecked(i);

            Close();
        }
    }
}
