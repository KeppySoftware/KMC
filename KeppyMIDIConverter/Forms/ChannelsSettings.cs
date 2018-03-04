using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class ChannelsSettings : Form
    {
        private void InitializeLanguage()
        {
            Text = Languages.Parse("ChannelsSettings");

            AllCh.Text = Languages.Parse("ChannelsSettingsAll");
        }

        public ChannelsSettings()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private void ChannelsSettings_Load(object sender, EventArgs e)
        {
            CH1VOL.Value = MainWindow.KMCStatus.ChannelsVolume[0];
            CH2VOL.Value = MainWindow.KMCStatus.ChannelsVolume[1];
            CH3VOL.Value = MainWindow.KMCStatus.ChannelsVolume[2];
            CH4VOL.Value = MainWindow.KMCStatus.ChannelsVolume[3];
            CH5VOL.Value = MainWindow.KMCStatus.ChannelsVolume[4];
            CH6VOL.Value = MainWindow.KMCStatus.ChannelsVolume[5];
            CH7VOL.Value = MainWindow.KMCStatus.ChannelsVolume[6];
            CH8VOL.Value = MainWindow.KMCStatus.ChannelsVolume[7];
            CH9VOL.Value = MainWindow.KMCStatus.ChannelsVolume[8];
            CH10VOL.Value = MainWindow.KMCStatus.ChannelsVolume[9];
            CH11VOL.Value = MainWindow.KMCStatus.ChannelsVolume[10];
            CH12VOL.Value = MainWindow.KMCStatus.ChannelsVolume[11];
            CH13VOL.Value = MainWindow.KMCStatus.ChannelsVolume[12];
            CH14VOL.Value = MainWindow.KMCStatus.ChannelsVolume[13];
            CH15VOL.Value = MainWindow.KMCStatus.ChannelsVolume[14];
            CH16VOL.Value = MainWindow.KMCStatus.ChannelsVolume[15];
        }

        private void VolumeToolTip(int channel, TrackBar trackbar)
        {
            VolumeTip.SetToolTip(trackbar, String.Format("{0}: {1}%", String.Format(Languages.Parse("ChannelsSettingsChan"), channel), trackbar.Value));
            MainWindow.KMCStatus.ChannelsVolume[channel - 1] = trackbar.Value;
        }

        private void CH1VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(1, sender as TrackBar);
        }

        private void CH2VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(2, sender as TrackBar);
        }

        private void CH3VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(3, sender as TrackBar);
        }

        private void CH4VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(4, sender as TrackBar);
        }

        private void CH5VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(5, sender as TrackBar);
        }

        private void CH6VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(6, sender as TrackBar);
        }

        private void CH7VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(7, sender as TrackBar);
        }

        private void CH8VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(8, sender as TrackBar);
        }

        private void CH9VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(9, sender as TrackBar);
        }

        private void CH10VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(10, sender as TrackBar);
        }

        private void CH11VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(11, sender as TrackBar);
        }

        private void CH12VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(12, sender as TrackBar);
        }

        private void CH13VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(13, sender as TrackBar);
        }

        private void CH14VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(14, sender as TrackBar);
        }

        private void CH15VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(15, sender as TrackBar);
        }

        private void CH16VOL_Scroll(object sender, EventArgs e)
        {
            VolumeToolTip(16, sender as TrackBar);
        }

        private void MainVol_Scroll(object sender, EventArgs e)
        {
            CH1VOL.Value = CH2VOL.Value = CH3VOL.Value = CH4VOL.Value = CH5VOL.Value = CH6VOL.Value = CH7VOL.Value = CH8VOL.Value = CH9VOL.Value = CH10VOL.Value = CH11VOL.Value = CH12VOL.Value = CH13VOL.Value = CH14VOL.Value = CH15VOL.Value = CH16VOL.Value = MainVol.Value;
            VolumeTip.SetToolTip(MainVol, String.Format("{0}: {1}%", Languages.Parse("ChannelsSettingsAll"), MainVol.Value));

            for (int i = 0; i <= 15; i++)
                MainWindow.KMCStatus.ChannelsVolume[i] = MainVol.Value;
        }
    }
}
