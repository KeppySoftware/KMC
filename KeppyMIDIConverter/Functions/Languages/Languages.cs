using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    class Languages
    {
        public static ResourceManager RM  = new ResourceManager("KeppyMIDIConverter.Languages.Lang", typeof(MainWindow).Assembly);
        public static CultureInfo DC = CultureInfo.CreateSpecificCulture("en-US");
        public static CultureInfo DCF = CultureInfo.CreateSpecificCulture("en-US");

        public static String Parse(String ToTranslate)
        {
            try { return RM.GetString(ToTranslate, DC); }
            catch {
                try {
                    return RM.GetString(ToTranslate, DCF);
                }
                catch { return String.Format("{0}", ToTranslate); }
            }
        }

        // Language overrides

        public static CultureInfo ReturnCulture(Boolean Default, string Custom)
        {
            try
            {
                if (Default)
                {
                    return CultureInfo.CreateSpecificCulture("en-US");
                }
                else
                {
                    if (Properties.Settings.Default.LangOverride)
                    {
                        if (Custom != null) return CultureInfo.CreateSpecificCulture(Custom);
                        else return CultureInfo.CreateSpecificCulture(Properties.Settings.Default.SelectedLang);
                    }
                    else
                    {
                        CultureInfo ci = CultureInfo.CurrentUICulture;
                        return CultureFunc(ci);
                    }
                }
            }
            catch
            {
                try { return CultureInfo.CreateSpecificCulture("en-US"); }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    Application.ExitThread();
                    return null;
                }
            }
        }

        public static CultureInfo CultureFunc(CultureInfo ci)
        {
            if (ci.Name == "it-IT" | ci.Name == "it-CH") // Kep's native language first ;)
                return CultureInfo.CreateSpecificCulture("it-IT");
            else if (ci.Name == "et-EE")
                return CultureInfo.CreateSpecificCulture("et-EE");
            else if (ci.Name == "zh-CN")
                return CultureInfo.CreateSpecificCulture("zh-CN");
            else if (ci.Name == "zh-HK")
                return CultureInfo.CreateSpecificCulture("zh-HK");
            else if (ci.Name == "zh-TW")
                return CultureInfo.CreateSpecificCulture("zh-TW");
            else if (ci.Name == "cy-GB")
                return CultureInfo.CreateSpecificCulture("en-US"); // Not done yet, should be cy-GB
            else if (ci.Name == "bn-BD" | ci.Name == "bn-IN")
                return CultureInfo.CreateSpecificCulture("bn-BD");
            else if (ci.Name == "en-US" | ci.Name == "en-BZ" | ci.Name == "en-CA" | ci.Name == "en-029" | ci.Name == "en-IN" | ci.Name == "en-IE" | ci.Name == "en-JM" | ci.Name == "en-MY" | ci.Name == "en-NZ" | ci.Name == "en-PH" | ci.Name == "en-SG" | ci.Name == "en-ZA" | ci.Name == "en-TT" | ci.Name == "en-GB" | ci.Name == "en-ZW")
                return CultureInfo.CreateSpecificCulture("en-US");
            else if (ci.Name == "ru-RU")
                return CultureInfo.CreateSpecificCulture("ru-RU");
            else if (ci.Name == "th-TH")
                return CultureInfo.CreateSpecificCulture("th-TH");
           else if (ci.Name == "fr-BE" | ci.Name == "fr-CA" | ci.Name == "fr-FR" | ci.Name == "fr-LU" | ci.Name == "fr-MC" | ci.Name == "fr-CH")
                return CultureInfo.CreateSpecificCulture("en-US"); // Not done yet, should be fr-FR
            else if (ci.Name == "ko-KR")
                return CultureInfo.CreateSpecificCulture("ko-KR");
            else if (ci.Name == "de-DE" | ci.Name == "de-AT" | ci.Name == "de-CH")
                return CultureInfo.CreateSpecificCulture("de-DE");
            else if (ci.Name == "es-AR" | ci.Name == "es-VE" | ci.Name == "es-BO" | ci.Name == "es-CL" | ci.Name == "es-DO" | ci.Name == "es-EC" | ci.Name == "es-SV" | ci.Name == "es-CO" | ci.Name == "es-CR" | ci.Name == "es-ES" | ci.Name == "es-GT" | ci.Name == "es-HN" | ci.Name == "es-MX" | ci.Name == "es-NI" | ci.Name == "es-PA" | ci.Name == "es-PY" | ci.Name == "es-PE" | ci.Name == "es-PR" | ci.Name == "es-US" | ci.Name == "es-UY")
                return CultureInfo.CreateSpecificCulture("es-ES");
            else if (ci.Name == "ja-JP")
                return CultureInfo.CreateSpecificCulture("ja-JP");
            else // The current language of the UI is not available, fallback to English.
                return CultureInfo.CreateSpecificCulture("en-US");
        }

        public static void ChangeLanguage(string selectedlanguage)
        {
            try
            {
                Properties.Settings.Default.SelectedLang = selectedlanguage;
                DC = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.SelectedLang);
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        const int LangNum = 4;

        public static String[] LanguagesAvailable = new String[LangNum] {
            // "বাঙালি (Bengali)",
            "English (English)",
            // "Eesti (Estonian)",
            // "Deutsch (German)",
            "Italiano (Italian)",
            "日本語 (Japanese)",
            // "한국어 (Korean)",
            // "Pу́сский (Russian)",
            "简体中文 (Simplified Chinese, PRC)",
            // "Español (Spanish)",
            // "ภาษาไทย (Thai)",
            // "廣東話 (Traditional Chinese, Hong Kong)",
            // "台灣 (Traditional Chinese, Taiwan)",
        };

        public static Bitmap[] LanguagesFlags = new Bitmap[LangNum] {
            // Properties.Resources.Bangladesh,
            Properties.Resources.United_Kingdom_Great_Britain_,
            // Properties.Resources.Estonia,
            // Properties.Resources.Germany,
            Properties.Resources.Italy,
            Properties.Resources.Japan,
            // Properties.Resources.South_Korea,
            // Properties.Resources.Russian_Federation,
            Properties.Resources.China,
            // Properties.Resources.Spain,
            // Properties.Resources.Thailand,
            // Properties.Resources.China,
            // Properties.Resources.China,
        };

        public static String[] LanguagesCodes = new String[LangNum] {
            // "bn-BD",
            "en-US",
            // "et-EE",
            // "de-DE",
            "it-IT",
            "ja-JP",
            // "ko-KR",
            // "ru-RU",
            "zh-CN",
            // "es-ES",
            // "th-TH",
            // "zh-HK",
            // "zh-TW",
        };
    }
}
