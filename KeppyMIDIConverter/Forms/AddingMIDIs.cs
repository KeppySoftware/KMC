using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class AddingMIDIs : Form
    {
        private static AddingMIDIs Delegate;
        private UInt64 ValidFiles = 0;
        private UInt64 InvalidFiles = 0;
        private Int64 TotalFiles = 0;
        private String[] MIDIsToLoad;

        private void InitializeLanguage()
        {
            Text = Languages.Parse("ParsingMIDIInfo");
            CancelBtn.Text = Languages.Parse("CancelBtn");
            ParsingMIDIInfoStatus.Text = String.Format("ParsingMIDIInfoStatus", ValidFiles + InvalidFiles, TotalFiles);
        }

        public AddingMIDIs(String[] MIDIs, Boolean IsImportDialog)
        {
            InitializeComponent();
            Delegate = this;

            MIDIsToLoad = MIDIs;
            foreach (string str in MIDIsToLoad)
                CheckCount(str);

            InitializeLanguage();
        }

        // CheckDirectory, but it counts files instead
        private void CheckCount(String Target)
        {
            try
            {
                foreach (String folder in GetFiles(Target)) TotalFiles++;
            }
            catch (Exception exception)
            {
                ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                errordialog.ShowDialog();
                Close();
            }
        }

        // Check if each file is valid
        private void CheckDirectory(ref List<ListViewItem> ArrayIT, String Target)
        {
            try
            {
                foreach (String file in GetFiles(Target))
                {
                    if (AnalyzeMIDIs.CancellationPending) return;
                    CheckFile(ref ArrayIT, file);
                }
            }
            catch (Exception exception)
            {
                ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                errordialog.ShowDialog();
                Close();
            }
        }

        private void CheckFile(ref List<ListViewItem> ArrayIT, String str)
        {
            if (Path.GetExtension(str).ToLower() == ".mid" || Path.GetExtension(str).ToLower() == ".midi" || Path.GetExtension(str).ToLower() == ".kar" || Path.GetExtension(str).ToLower() == ".rmi")
            {
                string[] MIDIInfo = DataCheck.GetMoreInfoMIDI(str);

                if (MIDIInfo != null)
                {
                    ArrayIT.Add(new ListViewItem(new string[] { str, MIDIInfo[2], MIDIInfo[1], MIDIInfo[0], MIDIInfo[3] }));
                    ValidFiles++;
                    return;
                }
            }
            InvalidFiles++;
        }

        private void AddingMIDIs_Load(object sender, EventArgs e)
        {
            AnalyzeMIDIs.RunWorkerAsync();
        }

        private void AnalyzerProgress_Tick(object sender, EventArgs e)
        {
            try
            {
                ParsingMIDIInfoStatus.Text = String.Format(Languages.Parse("ParsingMIDIInfoStatus"),
                    (ValidFiles + InvalidFiles).ToString("N0", new CultureInfo("is-IS")),
                    TotalFiles.ToString("N0", new CultureInfo("is-IS")));
            }
            catch { }
        }

        private void AnalyzeMIDIs_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ListViewItem> ArrayIT = new List<ListViewItem>();
            foreach (string str in MIDIsToLoad)
            {
                try
                {
                    if (AnalyzeMIDIs.CancellationPending) break;
                    CheckDirectory(ref ArrayIT, str);
                }
                catch (Exception exception)
                {
                    ErrorHandler errordialog = new ErrorHandler(Languages.Parse("Error"), exception.ToString(), 0, 0);
                    errordialog.ShowDialog();
                }
            }

            MainWindow.Delegate.Invoke((MethodInvoker)delegate { MainWindow.Delegate.MIDIList.Items.AddRange(ArrayIT.ToArray()); });
        }

        private void AnalyzeMIDIs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (InvalidFiles > 0)
            {
                AnalyzerProgress.Enabled = false;
                AnalyzerProgressBar.Value = 100;
                CancelBtn.Text = Languages.Parse("ConfirmBtn");
                ParsingMIDIInfoStatus.Text = String.Format(Languages.Parse("ParsingMIDIInfoInvalidOutcome"),
                    (ValidFiles + InvalidFiles).ToString("N0", new CultureInfo("is-IS")),
                    ValidFiles.ToString("N0", new CultureInfo("is-IS")),
                    InvalidFiles.ToString("N0", new CultureInfo("is-IS")));
            }
            else Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (AnalyzeMIDIs.IsBusy)
                try { AnalyzeMIDIs.CancelAsync(); } catch { }
            else Close();
        }

        // Code by Mac Gravell, edited by Keppy
        // https://stackoverflow.com/a/929418
        static IEnumerable<String> GetFiles(String Target)
        {
            Queue<string> AnalyzeQueue = new Queue<string>();

            // Add target of queue to the queue
            AnalyzeQueue.Enqueue(Target);

            // Do this while the queue list still contains items
            while (AnalyzeQueue.Count > 0)
            {
                // Dequeue the item that is going to be analyzed
                Target = AnalyzeQueue.Dequeue();

                try
                {
                    // Add each subdir to the queue
                    foreach (string subDir in Directory.GetDirectories(Target)) AnalyzeQueue.Enqueue(subDir);
                }
                catch (Exception ex) { BasicFunctions.WriteToConsole(ex); }
           
                string[] Files = null;
                try
                {
                    // Add files from the directory of the queued item
                    Files = Directory.GetFiles(Target);
                }
                catch (Exception ex) { BasicFunctions.WriteToConsole(ex); }

                // If the function detected items, return them to the calling foreach loop
                if (Files != null)
                {
                    for (int i = 0; i < Files.Length; i++) yield return Files[i];
                }

                // If the queued item is actually a direct path to the file, return it to the foreach loop
                if (File.Exists(Target)) yield return Target;
            }
        }
    }
}
