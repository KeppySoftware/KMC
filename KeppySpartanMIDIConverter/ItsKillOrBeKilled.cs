using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace KeppySpartanMIDIConverter
{
    public partial class ItsKillOrBeKilled : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        public ItsKillOrBeKilled()
        {
            InitializeComponent();
        }

        private void CargoPrivateFontCollection()
        {
            byte[] fontArray = KeppyMIDIConverter.Properties.Resources.Undertale;
            int dataLength = KeppyMIDIConverter.Properties.Resources.Undertale.Length;
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);
            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);
            ff = pfc.Families[0];
            font = new Font(ff, 48f, FontStyle.Bold);
        }

        private void CargoEtiqueta(Font font)
        {
            float size = 11f;
            FontStyle fontStyle = FontStyle.Regular;
            this.label1.Font = new Font(ff, 36, fontStyle);
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public Object crashMe()
        {
            return null;
        }

        private void ItsKillOrBeKilled_Load(object sender, EventArgs e)
        {
            CargoPrivateFontCollection();
            CargoEtiqueta(font);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            label1.Text = "Nah, joking!\nYou can go now.";
            pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.Nojk;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            label1.Text = "...";
            pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.itskillorbekilled;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Text = "DIE.";
                int counterofdeath = 0;
                while (counterofdeath < 1)
                {
                    counterofdeath = +1;
                }
                crashMe().ToString();
            }
            catch (Exception exception)
            {
                Environment.FailFast("", exception);
            }        
        }
    }
}
