using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KeppyMIDIConverter
{
    public partial class DonateMonthlyDialog : Form
    {
        private void InitializeLanguage()
        {
            Text = Languages.Parse("KeepAliveProject");

            // Donation text
            DonateText.Text = Languages.Parse("DonateText");
            ShowMeNext.Text = Languages.Parse("ShowMeNext");
            DontShowAnymore.Text = Languages.Parse("DontShowAnymore");
        }

        public DonateMonthlyDialog()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private void DonateMonthlyDialog_Load(object sender, EventArgs e)
        {
            // Lel
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BasicFunctions.Donate();
        }

        private void ShowMeNext_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DonationShownWhen = DateTime.Now;
            Properties.Settings.Default.DonationAlreadyShown = true;
            Properties.Settings.Default.Save();
            Close();
        }

        private void DontShowAnymore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DonationShownWhen = DateTime.Now;
            Properties.Settings.Default.DonationAlreadyShown = true;
            Properties.Settings.Default.NoMoreDonation = true;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
