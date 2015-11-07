using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeppySpartanMIDIConverter
{
    public partial class Informations : Form
    {
        public Informations()
        {
            InitializeComponent();
        }

        private void Informations_Load(object sender, EventArgs e)
        {
            if (IntPtr.Size == 8)
            {
                Versionlabel.Text = "Compiled for 64-bit systems, optimized for SSE2 ready CPUs.";
            }
            else if (IntPtr.Size == 4)
            {
                Versionlabel.Text = "Compiled for 32-bit systems, optimized for MMX ready CPUs.";
            }
            KeppyVer.Text = "Keppy's MIDI Converter " + Application.ProductVersion + ", by Keppy Studios";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.un4seen.com");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad.exe", "license.rtf");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://keppystudios.com/");
        }
    }
}
