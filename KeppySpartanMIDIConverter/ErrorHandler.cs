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
        public ErrorHandler(String errortitle, String errormessage, Int16 typeoferror)
        {
            InitializeComponent();
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
            System.Media.SystemSounds.Hand.Play();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
