using System;
using System.Windows.Forms;
using System.Threading;
using System.Text;
using System.Reflection;
using System.Net;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.Win32;

namespace KeppyMIDIConverter
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        //Take in arguments
        static void Main(String[] args)
        {
            RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
            bool ok;
            Mutex m = new Mutex(true, "KepMIDIConv", out ok);
            if (!ok)
            {
                MessageBox.Show("One instance is enough.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if (Convert.ToInt32(Settings.GetValue("autoupdatecheck", 1)) == 1)
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppySpartanMIDIConverter/kmcupdate.txt");
                    StreamReader reader = new StreamReader(stream);
                    String newestversion = reader.ReadToEnd();
                    FileVersionInfo Driver = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
                    Version x = null;
                    Version.TryParse(newestversion.ToString(), out x);
                    Version y = null;
                    Version.TryParse(Driver.FileVersion.ToString(), out y);
                    Thread.Sleep(50);
                    if (x > y)
                    {
                        DialogResult dialogResult = MessageBox.Show("A new update for Keppy's MIDI Converter has been found.\n\nVersion installed: " + Driver.FileVersion.ToString() + "\nVersion available online: " + newestversion.ToString() + "\n\nWould you like to update now?\nIf you choose \"Yes\", the converter will be automatically closed.\n\n(You can disable the automatic update check through \"Options > Automatically check for updates when starting the converter\".)", "New version of Keppy's MIDI Converter found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start("https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases");
                            TriggerDate();
                            Application.ExitThread();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Settings.Close();
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            TriggerDate();
                            Application.Run(new MainWindow(args));
                            GC.KeepAlive(m);
                        }
                    }
                    else
                    {
                        Settings.Close();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        TriggerDate();
                        Application.Run(new MainWindow(args));
                        GC.KeepAlive(m);
                    }
                }
                else
                {
                    Settings.Close();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow(args));
                    TriggerDate();
                    GC.KeepAlive(m);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the languages!\n\nError:" + ex.ToString(), "Keppy's MIDI Converter - Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static CultureInfo ReturnCulture()
        {
            try
            {
                Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey Language = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", false);
                if (Language != null)
                {
                    if (Convert.ToInt32(Language.GetValue("langoverride", 0)) == 1)
                    {
                        if (Language.GetValue("selectedlanguage", "en").ToString() != null)
                        {
                            return CultureInfo.CreateSpecificCulture(Language.GetValue("selectedlanguage").ToString());
                        }
                        else
                        {
                            return CultureInfo.CreateSpecificCulture("en");
                        }
                    }
                    else
                    {
                        CultureInfo ci = CultureInfo.InstalledUICulture;
                        if (ci.Name == "it-IT" | ci.Name == "it-CH") // Kep's native language first ;)
                            return CultureInfo.CreateSpecificCulture("it");
                        else if (ci.Name == "et-EE")
                            return CultureInfo.CreateSpecificCulture("et");
                        else if (ci.Name == "zh-CN")
                            return CultureInfo.CreateSpecificCulture("zh-CN");
                        else if (ci.Name == "zh-HK")
                            return CultureInfo.CreateSpecificCulture("zh-HK");
                        else if (ci.Name == "zh-TW")
                            return CultureInfo.CreateSpecificCulture("zh-TW");
                        else if (ci.Name == "tr-TR")
                            return CultureInfo.CreateSpecificCulture("tr");
                        else if (ci.Name == "de-DE" | ci.Name == "de-AT" | ci.Name == "de-CH")
                            return CultureInfo.CreateSpecificCulture("de");
                        else if (ci.Name == "es-AR" | ci.Name == "es-VE" | ci.Name == "es-BO" | ci.Name == "es-CL" | ci.Name == "es-DO" | ci.Name == "es-EC" | ci.Name == "es-SV" | ci.Name == "es-CO" | ci.Name == "es-CR" | ci.Name == "es-ES" | ci.Name == "es-GT" | ci.Name == "es-HN" | ci.Name == "es-MX" | ci.Name == "es-NI" | ci.Name == "es-PA" | ci.Name == "es-PY" | ci.Name == "es-PE" | ci.Name == "es-PR" | ci.Name == "es-US" | ci.Name == "es-UY")
                            return CultureInfo.CreateSpecificCulture("es");
                        // else if (ci.Name == "nl-NL" | ci.Name == "nl-BE")
                        //     return CultureInfo.CreateSpecificCulture("nl");
                        else if (ci.Name == "ja-JP")
                            return CultureInfo.CreateSpecificCulture("ja");
                        else // The current language of the UI is not available, fallback to English.
                            return CultureInfo.CreateSpecificCulture("en");
                    }
                    Language.Close();
                }
                else
                {
                    CultureInfo ci = CultureInfo.InstalledUICulture;
                    if (ci.Name == "it-IT" | ci.Name == "it-CH") // Kep's native language first ;)
                        return CultureInfo.CreateSpecificCulture("it");
                    else if (ci.Name == "et-EE")
                        return CultureInfo.CreateSpecificCulture("ee");
                    else if (ci.Name == "zh-CN")
                        return CultureInfo.CreateSpecificCulture("zh-CN");
                    else if (ci.Name == "zh-HK")
                        return CultureInfo.CreateSpecificCulture("zh-HK");
                    else if (ci.Name == "zh-TW")
                        return CultureInfo.CreateSpecificCulture("zh-TW");
                    else if (ci.Name == "tr-TR")
                        return CultureInfo.CreateSpecificCulture("tr");
                    else if (ci.Name == "de-DE" | ci.Name == "de-AT" | ci.Name == "de-CH")
                        return CultureInfo.CreateSpecificCulture("de");
                    // else if (ci.Name == "nl-NL" | ci.Name == "nl-BE")
                    //     return CultureInfo.CreateSpecificCulture("nl");
                    else if (ci.Name == "ja-JP")
                        return CultureInfo.CreateSpecificCulture("ja");
                    else // The current language of the UI is not available, fallback to English.
                        return CultureInfo.CreateSpecificCulture("en");
                }
            }
            catch
            {
                return CultureInfo.CreateSpecificCulture("en");
            }
        }

        static void TriggerDate()
        {
            DateTime BirthDate = DateTime.Now;
            int kepbirthday = 1999;
            int kmcbirthday = 2015;
            int currentyear = Convert.ToInt32(BirthDate.ToString("yyyy"));
            if (BirthDate.ToString("dd/MM") == "23/04")
            {
                MessageBox.Show("Today is Frozen's birthday! He turned " + (currentyear - kepbirthday).ToString() + " years old!\n\nHappy birthday, you potato!", "Happy birthday to Frozen Snow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "17/09")
            {
                MessageBox.Show("Today, KMC turned " + (currentyear - kmcbirthday).ToString() + " year(s) old!\n\nHappy birthday, awesome converter!", "Happy birthday to me, Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "31/10")
            {
                MessageBox.Show("Spooky conversions today, huh?", "Happy Halloween!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "05/12")
            {
                MessageBox.Show("Today is Keppy's birthday! He turned " + (currentyear - kepbirthday).ToString() + " years old!\n\nHappy birthday, you potato!", "Happy birthday to Kepperino", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "25/12")
            {
                MessageBox.Show("Oh oh oh, Merry Christmas!", "Happy holidays, and Merry Christmas!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "01/01")
            {
                MessageBox.Show("HAPPY NEW YEAR!", "Finally, " + BirthDate.ToString("yyyy") + " has begun!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
