using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            try
            {
                Text = MainWindow.res_man.GetString("ChangeLanguage", MainWindow.cul);
                OverrideLanguageCheck.Text = MainWindow.res_man.GetString("OverrideLanguage", MainWindow.cul);
            }
            catch (Exception ex)
            {
                MainWindow.res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                MainWindow.cul = Program.ReturnCulture(true);
                MessageBox.Show("Keppy's MIDI Converter tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Text = MainWindow.res_man.GetString("ChangeLanguage", MainWindow.cul);
                OverrideLanguageCheck.Text = MainWindow.res_man.GetString("OverrideLanguage", MainWindow.cul);
            }
        }

        public OverrideLanguage()
        {
            InitializeComponent();
            InitializeLanguage();
        }

        private void OverrideLanguage_Load(object sender, EventArgs e)
        {    
            // First of all, add all the languages to the combobox
            foreach (string x in Languages.LanguagesAvailable)
            {
                LangSel.Items.Add(x);
            }

            // Then check if the override is enabled
            OverrideLanguageCheck.Checked = Properties.Settings.Default.LangOverride;
            LangSel.Enabled = Properties.Settings.Default.LangOverride;

            // Then scan
            int num = 0;
            foreach (string x in Languages.LanguagesCodes)
            {
                if (String.Equals(x, Properties.Settings.Default.SelectedLang))
                {
                    LangSel.SelectedIndex = num;
                    break;
                }
                num++;
            }
        }

        private void OverrideLanguageCheck_CheckedChanged(object sender, EventArgs e)
        {
            LangSel.Enabled = OverrideLanguageCheck.Checked;
            Properties.Settings.Default.LangOverride = OverrideLanguageCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void LangSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SelectedLang = Languages.LanguagesCodes[LangSel.SelectedIndex];
            Languages.ChangeLanguage(Languages.LanguagesCodes[LangSel.SelectedIndex]);
            Properties.Settings.Default.Save();
            InitializeLanguage();
        }
    }
}
