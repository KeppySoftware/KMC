using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class BankNPresetSel : Form
    {
        public string DesBankValueReturn { get; set; }
        public string DesPresetValueReturn { get; set; }
        public string SrcBankValueReturn { get; set; }
        public string SrcPresetValueReturn { get; set; }
        public string SelectedSF { get; set; }
        public int WindowView { get; set; }

        private void InitializeLanguage()
        {
            Text = Languages.Parse("BankNPresetSelTitle");

            BNPSelDesc.Text = Languages.Parse("BNPSelDesc");
            BNPSelHelp.Text = Languages.Parse("BNPSelHelp");
            BNPSelWiki.Text = Languages.Parse("BNPSelWiki");
            ConfirmBtn.Text = Languages.Parse("ConfirmBtn");
            CancelBtn.Text = Languages.Parse("CancelBtn");

            SrcBankLabel.Text = Languages.Parse("SrcBank");
            SrcPresetLabel.Text = Languages.Parse("SrcPreset");
            DesBankLabel.Text = Languages.Parse("DesBank");
            DesPresetLabel.Text = Languages.Parse("DesPreset");
        }

        public BankNPresetSel(String Target, Boolean ParsePreset)
        {
            InitializeComponent();
            InitializeLanguage();
            SelectedSF = Target;
            SelectedSFLabel.Text = String.Format(Languages.Parse("SelectedSF"), SelectedSF);
            SrcBankVal.Value = 0;
            SrcPresetVal.Value = 0;
            if (!ParsePreset)
            {
                SrcBankVal.Minimum = -1;
                SrcPresetVal.Minimum = 0;
            }
            else
            {
                SrcBankVal.Enabled = false;
                SrcPresetVal.Enabled = false;
                SrcBankVal.Value = 0;
                SrcPresetVal.Value = 0;
            }
        }

        private void ConfirmBut_Click(object sender, EventArgs e)
        {
            SrcBankValueReturn = SrcBankVal.Value.ToString();
            SrcPresetValueReturn = SrcPresetVal.Value.ToString();
            DesBankValueReturn = DesBankVal.Value.ToString();
            DesPresetValueReturn = DesPresetVal.Value.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WikipediaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var helpFile = Path.Combine(Path.GetTempPath(), "help.txt");
            File.WriteAllText(helpFile, Properties.Resources.gmlist);
            Process.Start(helpFile);
        }

        private void BankNPresetSel_Load(object sender, EventArgs e)
        {

        }
    }
}
