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
        public DonateMonthlyDialog()
        {
            InitializeComponent();
        }

        
        private void DonateMonthlyDialog_Load(object sender, EventArgs e)
        {
            // Lel
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.Donate();
        }

        private void ShowMeNext_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DontShowAnymore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.NoMoreDonation = false;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
