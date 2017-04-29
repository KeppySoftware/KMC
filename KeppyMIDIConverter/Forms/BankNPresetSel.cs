using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;

namespace KeppyMIDIConverter.Forms
{
    public partial class BankNPresetSel : Form
    {
        public int BankValueReturn { get; set; }
        public int PresetValueReturn { get; set; }
        public int DesBankValueReturn { get; set; }
        public int DesPresetValueReturn { get; set; }
        public string SelectedSF { get; set; }
        public int typeofsfhehe { get; set; }
        public int WindowView { get; set; }

        public BankNPresetSel(String Target, int WindowMode, int typeofsf)
        {
            InitializeComponent();
            InitializeLanguage();
            SelectedSF = Target;
            SelectedSFLabel.Text = String.Format("{0}:\n{1}", MainWindow.res_man.GetString("BankNPresetSelectedSF", MainWindow.cul), Path.GetFileNameWithoutExtension(SelectedSF));
            DesBankVal.Value = 0;
            DesPresetVal.Value = 0;
            if (Path.GetExtension(Target).ToLower() == ".sfz")
            {
                SrcBankLab.Enabled = false;
                SrcPresetLab.Enabled = false;
                SrcBankVal.Enabled = false;
                SrcPresetVal.Enabled = false;
            }
            if (WindowMode == 1)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }

        private void InitializeLanguage()
        {
            Text = MainWindow.res_man.GetString("BankNPresetTitle", MainWindow.cul);
            SrcBankLab.Text = MainWindow.res_man.GetString("BankNPresetSrcBank", MainWindow.cul);
            SrcPresetLab.Text = MainWindow.res_man.GetString("BankNPresetSrcPrst", MainWindow.cul);
            DesBankLab.Text = MainWindow.res_man.GetString("BankNPresetDesBank", MainWindow.cul);
            DesPresetLab.Text = MainWindow.res_man.GetString("BankNPresetDesPrst", MainWindow.cul);
            label1.Text = MainWindow.res_man.GetString("BankNPresetSelectMsg", MainWindow.cul);
            label6.Text = MainWindow.res_man.GetString("BankNPresetDiscl", MainWindow.cul);
            WikipediaLink.Text = MainWindow.res_man.GetString("BankNPresetGuide", MainWindow.cul);
            IgnoreBtn.Text = MainWindow.res_man.GetString("BankNPresetIgnore", MainWindow.cul);
            ConfirmBut.Text = MainWindow.res_man.GetString("BankNPresetConfirm", MainWindow.cul);
            if (MainWindow.res_man.GetString("BankNPresetTBT", MainWindow.cul) == "yes")
            {
                ToBeTranslated.Visible = true;
            }
        }

        private void ConfirmBut_Click(object sender, EventArgs e)
        {
            BankValueReturn = Convert.ToInt32(DesBankVal.Value);
            PresetValueReturn = Convert.ToInt32(DesPresetVal.Value);
            DesBankValueReturn = Convert.ToInt32(SrcBankVal.Value);
            DesPresetValueReturn = Convert.ToInt32(SrcPresetVal.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void IgnoreBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WikipediaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var helpFile = Path.Combine(Path.GetTempPath(), "help.txt");
            File.WriteAllText(helpFile, KeppyMIDIConverter.Properties.Resources.gmlist);
            Process.Start(helpFile);
        }

        private void ToBeTranslated_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(String.Format("This window is not available in your native language: {0}\n\nDo you want to help the translation?", Program.ReturnCulture(false).EnglishName.ToString()), "Keppy's MIDI Converter - Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://github.com/kaleidonKep99/Keppys-MIDI-Converter#main-languages-available");
            }
        }

        private void BankNPresetSel_Load(object sender, EventArgs e)
        {

        }
    }
}
