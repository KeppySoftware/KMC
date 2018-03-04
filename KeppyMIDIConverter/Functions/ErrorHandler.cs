using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(this.Handle, "", "");
            base.OnHandleCreated(e);
        }

        public static int TOE = 0;

        private void InitializeLanguage(String errortitle)
        {
            Text = "Keppy's MIDI Converter - " + errortitle;

            if (TOE == 0) ErrorLab.Text = Languages.Parse("NonFatalErrorHandler");
            else if (TOE == 1) ErrorLab.Text = Languages.Parse("FatalErrorHandler");

            OKBtn.Text = Languages.Parse("OKBtn");
            copyErrorMessageToolStripMenuItem.Text = Languages.Parse("CopyErrorMessage");
            label1.Text = Languages.Parse("RightClickCopyNotice");
        }

        public ErrorHandler(String ErrorTitle, String ErrorMessage, Int16 TypeOfError, Int16 ConvOrNot)
        {
            TOE = TypeOfError;
            InitializeComponent();
            InitializeLanguage(ErrorTitle);

            if (ConvOrNot == 0) this.ShowInTaskbar = false;
            if (ConvOrNot == 1) this.ShowInTaskbar = true;

            ErrorBox.Text = ErrorMessage;
        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            this.ContextMenu = RBTMenu;
            ErrorBox.ContextMenu = RBTMenu;

            if (TOE == 0)
                pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.warningicon;
            else
                pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.erroricon; 

            PlayConversionFail();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (TOE == 1)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                {
                    //throw new AntiDamageCrash("The converter has been manually crashed to avoid damages to the computer.");
                }));
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlayConversionFail()
        {
            //MainWindow.PlayConverterError();
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
            MessageBox.Show(String.Format(Languages.Parse("CopiedToClipboardNotice"), sb.ToString()), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}