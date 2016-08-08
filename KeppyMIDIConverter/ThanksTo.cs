using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class ThanksTo : Form
    {
        public ThanksTo()
        {
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
