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
        static ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        static CultureInfo cul;            // declare culture info
        
        private void InitializeLanguage()
        {
            try
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture(false);
                Text = MainWindow.res_man.GetString("ChangeLanguage", cul);
                OverrideLanguageCheck.Text = MainWindow.res_man.GetString("OverrideLanguage", cul);
            }
            catch (Exception ex)
            {
                res_man = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
                cul = Program.ReturnCulture(false);
                MessageBox.Show("Keppy's MIDI Converter tried to load an invalid language, so English has been loaded automatically.", "Error with the languages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Text = MainWindow.res_man.GetString("ChangeLanguage", cul);
                OverrideLanguageCheck.Text = MainWindow.res_man.GetString("OverrideLanguage", cul);
            }
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
            catch (Exception ex)
            {
                ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", MainWindow.cul), ex.ToString(), 0, 1);
                errordialog.ShowDialog();
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
            Languages.ChangeLanguage(Languages.LanguagesCodes[LangSel.SelectedIndex]);
            Flag.BackgroundImage = Languages.LanguagesFlags[LangSel.SelectedIndex];
            cul = Program.ReturnCulture(false);
            InitializeLanguage();
        }
    }
}
