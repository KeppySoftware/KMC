using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace KeppyMIDIConverter
{
    public partial class ErrorHandler : Form
    {
        public static int TOE = 0;
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        public ErrorHandler(String errortitle, String errormessage, Int16 typeoferror, Int16 ConvOrNot)
        {
            TOE = typeoferror;
            InitializeComponent();
            InitializeLanguage();
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
                ErrorLab.Text = res_man.GetString("NonFatalErrorHandler", cul);
            }
            else if (typeoferror == 1)
            {
                ErrorLab.Text = res_man.GetString("FatalErrorHandler", cul);
            }
            Text = "Keppy's MIDI Converter - " + errortitle;
            ErrorBox.Text = errormessage;
        }

        private void InitializeLanguage()
        {
            res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
            cul = Program.ReturnCulture();
            // Translate system
            copyErrorMessageToolStripMenuItem.Text = res_man.GetString("CopyErrorMessage", cul);
            label1.Text = res_man.GetString("RightClickCopyNotice", cul);
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
            MessageBox.Show(String.Format(res_man.GetString("CopiedToClipboardNotice", cul), sb.ToString()), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
