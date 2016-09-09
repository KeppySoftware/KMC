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
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        public BankNPresetSel(String Target, int WindowMode, int typeofsf)
        {
            InitializeComponent();
            InitializeLanguage();
            SelectedSF = Target;
            SelectedSFLabel.Text = String.Format("{0}:\n{1}", res_man.GetString("BankNPresetSelectedSF", cul), Path.GetFileNameWithoutExtension(SelectedSF));
            BankVal.Value = 0;
            PresetVal.Value = 0;
            if (typeofsf == 1)
            {
                BankVal.Minimum = -1;
                PresetVal.Minimum = -1;
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
            try
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture();
                // Translate system
                Text = res_man.GetString("BankNPresetTitle", cul);
                label5.Text = res_man.GetString("BankNPresetSrcPrst", cul);
                label4.Text = res_man.GetString("BankNPresetSrcBank", cul);
                label2.Text = res_man.GetString("BankNPresetDesPrst", cul);
                label3.Text = res_man.GetString("BankNPresetDesBank", cul);
                label1.Text = res_man.GetString("BankNPresetSelectMsg", cul);
                label6.Text = res_man.GetString("BankNPresetDiscl", cul);
                WikipediaLink.Text = res_man.GetString("BankNPresetGuide", cul);
                IgnoreBtn.Text = res_man.GetString("BankNPresetIgnore", cul);
                ConfirmBut.Text = res_man.GetString("BankNPresetConfirm", cul);
            }
            catch
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = CultureInfo.CreateSpecificCulture("en");
                // Translate system
                Text = res_man.GetString("BankNPresetTitle", cul);
                label5.Text = res_man.GetString("BankNPresetSrcPrst", cul);
                label4.Text = res_man.GetString("BankNPresetSrcBank", cul);
                label2.Text = res_man.GetString("BankNPresetDesPrst", cul);
                label3.Text = res_man.GetString("BankNPresetDesBank", cul);
                label1.Text = res_man.GetString("BankNPresetSelectMsg", cul);
                label6.Text = res_man.GetString("BankNPresetDiscl", cul);
                WikipediaLink.Text = res_man.GetString("BankNPresetGuide", cul);
                IgnoreBtn.Text = res_man.GetString("BankNPresetIgnore", cul);
                ConfirmBut.Text = res_man.GetString("BankNPresetConfirm", cul);
                ToBeTranslated.Visible = true;
            }
        }

        private void ConfirmBut_Click(object sender, EventArgs e)
        {
            BankValueReturn = Convert.ToInt32(BankVal.Value);
            PresetValueReturn = Convert.ToInt32(PresetVal.Value);
            DesBankValueReturn = Convert.ToInt32(DesBankVal.Value);
            DesPresetValueReturn = Convert.ToInt32(DesPresetVal.Value);
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
            DialogResult dialogResult = MessageBox.Show(String.Format("This window is not available in your native language: {0}\n\nDo you want to help the translation?", Program.ReturnCulture().EnglishName.ToString()), "Keppy's MIDI Converter - Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://github.com/kaleidonKep99/Keppys-MIDI-Converter#main-languages-available");
            }
        }
    }
}
