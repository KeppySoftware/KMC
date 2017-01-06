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
            try
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture();
                // Translate system
                copyErrorMessageToolStripMenuItem.Text = res_man.GetString("CopyErrorMessage", cul);
                label1.Text = res_man.GetString("RightClickCopyNotice", cul);
            }
            catch
            {
                MessageBox.Show("Keppy's MIDI Converter tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                // Translate system
                copyErrorMessageToolStripMenuItem.Text = res_man.GetString("CopyErrorMessage", cul);
                label1.Text = res_man.GetString("RightClickCopyNotice", cul);
            }

        }

        private void ErrorHandler_Load(object sender, EventArgs e)
        {
            this.ContextMenu = RBTMenu;
            ErrorBox.ContextMenu = RBTMenu;
            if (TOE == 0)
            {
                pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.warningicon;
            }
            else
            {
                pictureBox1.Image = KeppyMIDIConverter.Properties.Resources.erroricon;
            }   
            PlayConversionFail();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (TOE == 0)
                Application.ExitThread();
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                {
                    throw new AntiDamageCrash("The converter has been manually crashed to avoid damages to the computer.");
                }));
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (TOE == 0)
                Close();
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                {
                    throw new AntiDamageCrash("The converter has been manually crashed to avoid damages to the computer.");
                }));
            }
        }

        private void PlayConversionFail()
        {
            MainWindow.PlayConverterError();
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