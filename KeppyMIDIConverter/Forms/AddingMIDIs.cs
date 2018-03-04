using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class AddingMIDIs : Form
    {
        private Int32 MIDIsCounted = 0;
        private String[] MIDIsToLoad;

        private void InitializeLanguage()
        {
            Text = Languages.Parse("ParsingMIDIInfo");
            ParsingMIDIInfoStatus.Text = String.Format("ParsingMIDIInfoStatus", MIDIsCounted, MIDIsToLoad.Length);
        }

        public AddingMIDIs(String[] MIDIs, Boolean IsImportDialog)
        {
            InitializeComponent();
            MIDIsToLoad = MIDIs;
            InitializeLanguage();
        }

        private void AddingMIDIs_Load(object sender, EventArgs e)
        {
            AnalyzeMIDIs.RunWorkerAsync();
        }

        private void AnalyzerProgress_Tick(object sender, EventArgs e)
        {
            AnalyzerProgressBar.Value = Convert.ToInt32(Math.Round(MIDIsCounted * 100.0 / MIDIsToLoad.Length));
            ParsingMIDIInfoStatus.Text = String.Format(Languages.Parse("ParsingMIDIInfoStatus"), MIDIsCounted, MIDIsToLoad.Length);
        }

        private void AnalyzeMIDIs_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string str in MIDIsToLoad)
            {
                try
                {
                    if (Path.GetExtension(str).ToLower() == ".mid" || Path.GetExtension(str).ToLower() == ".midi" || Path.GetExtension(str).ToLower() == ".kar" || Path.GetExtension(str).ToLower() == ".rmi")
                    {
                        string[] midiinfo = DataCheck.GetMoreInfoMIDI(str);
                        ListViewItem lvi = new ListViewItem(new string[] { str, midiinfo[2], midiinfo[1], midiinfo[0], midiinfo[3] });
                        BasicFunctions.ToAddOrNotToAdd(lvi, midiinfo[1], str);
                    }
                    else MessageBox.Show(String.Format(Languages.Parse("InvalidMIDIFile"), Path.GetFileName(str)), Languages.Parse("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exception)
                {
                    KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                    errordialog.ShowDialog();
                }
                MIDIsCounted++;
            }
        }

        private void AnalyzeMIDIs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
