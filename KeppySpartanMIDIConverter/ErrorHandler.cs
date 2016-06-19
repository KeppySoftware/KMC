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
                ErrorLab.Text = "Error during the execution of the converter!\n\nMore information down below:";
            }
            else if (typeoferror == 1)
            {
                ErrorLab.Text = "Fatal error during the execution of the converter!!!\nIt's recommended to restart it, to prevent data loss!\nMore information down below:";
            }
            Text = "Keppy's MIDI Converter - " + errortitle;
            ErrorBox.Text = errormessage;
        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer convfail = new System.Media.SoundPlayer(Application.StartupPath + @"\convfail.wav");
            convfail.Play();
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
    }
}
