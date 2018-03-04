using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class BecomeAPatron : Form
    {
        private void InitializeLanguage()
        {
            Text = Languages.Parse("BecomeAPatronTitle");
            PatreonDesc.Text = Languages.Parse("PatreonDesc");
            DontShowAnymore.Text = Languages.Parse("PatreonMaybeLater");
            BecomeAPatronNow.Text = Languages.Parse("PatreonBecomeOne");
        }

        public BecomeAPatron()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private void DontShowAnymore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BecomeAPatronNow_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.patreon.com/KaleidonKep99");
            Close();
        }

        private void BecomeAPatron_Load(object sender, EventArgs e)
        {

        }
    }
}
