using System;
using System.Windows.Forms;
using Un4seen.Bass.AddOn.Midi;

namespace KeppyMIDIConverter
{
    public partial class TracksToIgnore : Form
    {
        public TracksToIgnore(Int32 TracksCount)
        {
            InitializeComponent();
            Text = Languages.Parse("TracksToIgnoreTitle");

            for (int i = 0; i < TracksCount; i++)
            {
                BASS_MIDI_MARK[] TracksText = BassMidi.BASS_MIDI_StreamGetMarks(MainWindow.KMCGlobals._recHandle, i, BASSMIDIMarker.BASS_MIDI_MARK_TRACK);
                UInt64 NoteCountTrack = (UInt64)BassMidi.BASS_MIDI_StreamGetEvents(MainWindow.KMCGlobals._recHandle, i, BASSMIDIEvent.MIDI_EVENT_NOTES, null);

                if (TracksText != null)
                    TracksCheckboxes.Items.Add(String.Format("Track {0} - {1} (Notes count: {2})", i + 1, TracksText[0].ToString(), NoteCountTrack), false);
                else
                    TracksCheckboxes.Items.Add(String.Format("Track {0} - No text (Notes count: {1})", i + 1, NoteCountTrack), false);
            }
        }

        private void TracksToIgnore_Load(object sender, EventArgs e)
        {

        }

        private void OK_Click(object sender, EventArgs e)
        {
            BASSControl.TracksList = new Boolean[TracksCheckboxes.Items.Count];

            int ItemsChecked;
            for (ItemsChecked = 0; ItemsChecked < TracksCheckboxes.Items.Count; ItemsChecked++)
                BASSControl.TracksList[ItemsChecked] = TracksCheckboxes.GetItemChecked(ItemsChecked);

            if (ItemsChecked > 0) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
