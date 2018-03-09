using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class OverrideLanguage : Form
    {
        private void InitializeLanguage()
        {
            Text = Languages.Parse("ChangeLanguage");
            OverrideLanguageCheck.Text = Languages.Parse("OverrideLanguage");
            MissingTranslations.Text = Languages.Parse("MissingTranslations");
        }

        public OverrideLanguage()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private void OverrideLanguage_Load(object sender, EventArgs e)
        {
            try
            {
                // First of all, add all the languages to the combobox
                foreach (string x in Languages.LanguagesAvailable) LangSel.Items.Add(x);

                // Then scan
                for (int i = 0; i <= Languages.LanguagesCodes.Length; i++)
                {
                    if (String.Equals(Languages.LanguagesCodes[i], Properties.Settings.Default.SelectedLang))
                    {
                        LangSel.SelectedIndex = i;
                        break;
                    }
                }

                // Then check if the override is enabled
                OverrideLanguageCheck.Checked = Properties.Settings.Default.LangOverride;
                LangSel.Enabled = Properties.Settings.Default.LangOverride;
            }
            catch (Exception ex)
            {
                ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("Error"), ex.ToString(), 0, 1);
                errordialog.ShowDialog();
            }
        }

        private void OverrideLanguageCheck_CheckedChanged(object sender, EventArgs e)
        {
            LangSel.Enabled = OverrideLanguageCheck.Checked;
            Properties.Settings.Default.LangOverride = OverrideLanguageCheck.Checked;
            Properties.Settings.Default.Save();
            Languages.ChangeLanguage(OverrideLanguageCheck.Checked ? Languages.LanguagesCodes[LangSel.SelectedIndex] : Languages.ReturnCulture(false).Name);
            InitializeLanguage();
            MainWindow.InitializeLanguage();
            AdvancedSettings.InitializeLanguage();
            SoundfontDialog.InitializeLanguage();
        }

        private void LangSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flag.BackgroundImage = Languages.LanguagesFlags[LangSel.SelectedIndex];
            if (LangSel.Enabled)
            {
                Languages.ChangeLanguage(Languages.LanguagesCodes[LangSel.SelectedIndex]);
                InitializeLanguage();
                MainWindow.InitializeLanguage();
                AdvancedSettings.InitializeLanguage();
                SoundfontDialog.InitializeLanguage();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
