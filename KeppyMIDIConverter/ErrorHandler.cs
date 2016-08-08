using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class ErrorHandler : Form
    {
        public static int TOE = 0;

        public ErrorHandler(String errortitle, String errormessage, Int16 typeoferror, Int16 ConvOrNot)
        {
            TOE = typeoferror;
            InitializeComponent();
            if (ConvOrNot == 0)
            {
                this.ShowInTaskbar = false;
            }
            if (ConvOrNot == 1)
            {
                this.ShowInTaskbar = true;
            }
            if (typeoferror == 0)
            {
                ErrorLab.Text = "There was an error during the execution of the converter.\n\nMore information down below:";
            }
            else if (typeoferror == 1)
            {
                ErrorLab.Text = "A problem has been detected and the converter\nhas been halted to prevent further problems.\nMore information down below:";
            }
            Text = "Keppy's MIDI Converter - " + errortitle;
            ErrorBox.Text = errormessage;
        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            this.ContextMenu = RBTMenu;
            ErrorBox.ContextMenu = RBTMenu;
            PlayConversionFail();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (TOE == 0)
            {
                Close();
            }
            else
            {
                Application.ExitThread();
            }   
        }

        private void PlayConversionFail()
        {
            System.IO.Stream str = Properties.Resources.convfail;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
            player.Play();
        }

        private void copyErrorMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("==== Start of Keppy's MIDI Converter Error ====");
            foreach (string line in ErrorBox.Lines) { sb.AppendLine(line); }
            sb.AppendLine("====  End of Keppy's MIDI Converter Error  ====");

            Thread thread = new Thread(() => Clipboard.SetText(sb.ToString()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            MessageBox.Show("Error message copied to clipboard!\n\nMessage:\n" + sb.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
