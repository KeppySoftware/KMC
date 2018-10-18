using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class ErrorHandler : Form
    {
        private static String CopyException;
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

            CopyException = ErrorMessage;

            ErrorBox.Text = ErrorMessage;
        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            this.ContextMenu = RBTMenu;
            ErrorBox.ContextMenu = RBTMenu;

            if (TOE == 0)
                pictureBox1.Image = Properties.Resources.warningicon;
            else
                pictureBox1.Image = Properties.Resources.erroricon; 

            PlayConversionFail();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            /*
            if (TOE == 1)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                {
                    throw new ConverterUnhandledException(CopyException);
                }));
            }
            */
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlayConversionFail()
        {
            BasicFunctions.PlayConverterError();
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

public class ConverterUnhandledException : Exception
{
    public ConverterUnhandledException()
    {
    }

    public ConverterUnhandledException(string message)
        : base(message)
    {
    }

    public ConverterUnhandledException(string message, Exception inner)
        : base(message, inner)
    {
    }
}