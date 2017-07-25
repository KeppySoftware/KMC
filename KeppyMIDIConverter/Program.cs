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
using System.Resources;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Win32;
using System.Configuration;
using System.Speech.Synthesis;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace KeppyMIDIConverter
{
    static class Program
    {
        private const int timerAccuracy = 10;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        //Take in arguments
        static void Main(String[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException; 

            if (Properties.Settings.Default.MigrateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.MigrateSettings = false;
                Properties.Settings.Default.Save();
            }

            bool deletencoder = false;
            string oggencoder = "kmcogg.exe";
            string mp3encoder = "kmcmp3.exe";
            bool ok;
            DeleteOldLanguages();
            Mutex m = new Mutex(true, "KepMIDIConv", out ok);
            if (!ok)
            {
                var bytes = new byte[16];
                var rnd = new Random();

                rnd.NextBytes(bytes);
                string originalkmcpath = String.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kmcogg.exe");
                string newkmcoggpath = String.Format("{0}kmcogg{1}.exe", Path.GetTempPath(), Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "").ToString());
                File.Copy(originalkmcpath, newkmcoggpath);

                rnd.NextBytes(bytes);
                originalkmcpath = String.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kmcmp3.exe");
                string newkmcmp3path = String.Format("{0}kmcmp3{1}.exe", Path.GetTempPath(), Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "").ToString());
                File.Copy(originalkmcpath, newkmcmp3path);

                deletencoder = true;
                oggencoder = newkmcoggpath;
                mp3encoder = newkmcmp3path;
            }
            try
            {
                int shouldupdate = 1;
                int skiptrigger = 1;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].ToLowerInvariant() == "/skipupdate")
                    {
                        shouldupdate = 0;
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/avoidtrigger")
                    {
                        skiptrigger = 0;
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/resetsettings")
                    {
                        Properties.Settings.Default.Reset();
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Settings have been reset to their default values.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/debug") // DO NOT USE IF NOT NEEDED <.<
                    {
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                        string version = fvi.FileVersion;
                        AllocConsole();
                        Console.Title = "Keppy's MIDI Converter Debug Window";
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Keppy's MIDI Converter Debug Window - Version " + version);
                        Console.WriteLine("Copyright KaleidonKep99 2013 - " + DateTime.Now.Year.ToString());
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("This should only be used when Kep himself asks you to do so. It's not really that useful, if not for debug.");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Debug started, waiting for errors...");
                        Console.ResetColor();
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/nothemespartial")
                    {
                        Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NonClientAreaEnabled;
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/nothemesfull")
                    {
                        Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/alternativetextrendering")
                    {
                        Application.SetCompatibleTextRenderingDefault(true);
                        break;
                    }
                    else if (args[i].ToLowerInvariant() == "/restorelanguage")
                    {
                        Properties.Settings.Default.LangOverride = false;
                        Properties.Settings.Default.SelectedLang = "en-US";
                        Properties.Settings.Default.Save();
                        MessageBox.Show("Language succesfully restored.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (args[i].ToLowerInvariant() == "/rickroll")
                    {
                        Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                        return;
                    }
                    else if (args[i].ToLowerInvariant() == "/triggerdonation")
                    {
                        Properties.Settings.Default.NoMoreDonation = false;
                        Properties.Settings.Default.Save();
                        Form frm = new DonateMonthlyDialog();
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                    }
                    else if (args[i].ToLowerInvariant() == "/ksp" | args[i].ToLowerInvariant() == "/keppysteinwaypiano")
                    {
                        Process.Start("https://github.com/KaleidonKep99/Keppy-Steinway-Piano");
                        return;
                    }
                    else if (args[i].ToLowerInvariant() == "/kep" | args[i].ToLowerInvariant() == "/keppy" | args[i].ToLowerInvariant() == "/kaleidonkep99")
                    {
                        Process.Start("https://plus.google.com/u/0/+RiccardoLoi");
                        return;
                    }
                    else if (args[i].ToLowerInvariant() == "/blackmidi" | args[i].ToLowerInvariant() == "/blackmiditeam" | args[i].ToLowerInvariant() == "/blackmidicommunity")
                    {
                        Process.Start("https://plus.google.com/communities/105907289212970966669");
                        return;
                    }
                    else if (args[i].ToLowerInvariant() == "/blackmididiscord" | args[i].ToLowerInvariant() == "/bmcdiscord" | args[i].ToLowerInvariant() == "/bmtdiscord")
                    {
                        Process.Start("https://discord.gg/9afWatV");
                        return;
                    }
                    else if (args[i].ToLowerInvariant().Contains("/"))
                    {
                        MessageBox.Show(String.Format("\"{0}\" is not a valid command line argument!\n\nPress OK to continue.", args[i]), "Keppy's MIDI Converter - Argument error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                if (shouldupdate == 1)
                    PerformUpdate();
                if (skiptrigger == 1)
                    TriggerDate();
                var encoders = new List<string>();
                encoders.Add(oggencoder);
                encoders.Add(mp3encoder);
                String[] array = encoders.ToArray();
                Application.Run(new MainWindow(args, array, deletencoder));
                GC.KeepAlive(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the languages!\n\nError:" + ex.ToString(), "Keppy's MIDI Converter - Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Thread.CurrentThread.IsBackground = true;
            Thread.CurrentThread.Name = "Dead thread";

            KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(MainWindow.res_man.GetString("Error", ReturnCulture(true)), e.ToString(), 0, 0);
            errordialog.ShowDialog();

            Process.GetCurrentProcess().Kill();
        }

        public static void DeleteOldLanguages()
        {
            string[] todelete = { "de", "ee", "en", "it", "ja", "nl" };

            foreach (string value in todelete)
            {
                try
                {
                    Directory.Delete(value, true);
                }
                catch
                {
                    // Nothing
                }
            }
        }

        public static void PerformUpdate()
        {
            try
            {
                if (Properties.Settings.Default.AutoUpdateCheck)
                {
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("https://raw.githubusercontent.com/KaleidonKep99/Keppys-MIDI-Converter/master/KeppyMIDIConverter/kmcupdate.txt");
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
                            UpdateDownloader frm = new UpdateDownloader(newestversion);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("The converter can not connect to the GitHub servers.\n\nCheck your network connection, or contact your system administrator or network service provider.\n\nPress OK to continue and open the converter's window.", "Keppy's MIDI Converter - Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public static CultureInfo ReturnCulture(Boolean Default)
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
                        return CultureInfo.CreateSpecificCulture(Properties.Settings.Default.SelectedLang);
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
                return CultureInfo.CreateSpecificCulture("en-US");
            }
        }

        public static void Donate()
        {
            string url = "";

            string business = "prapapappo1999@gmail.com";
            string description = MainWindow.res_man.GetString("supportTheDeveloperWithADonation", MainWindow.cul);
            string country = "US";
            string currency = "USD";

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            Process.Start(url);
        }

        public static void TriggerDate()
        {
            DateTime BirthDate = DateTime.Now;
            int currentyear = Convert.ToInt32(BirthDate.ToString("yyyy"));
            if (BirthDate.ToString("dd") == "01")
            {
                double days = (DateTime.Now.Date - Properties.Settings.Default.DonationShownWhen).TotalDays;
                if (days > 30 && Properties.Settings.Default.NoMoreDonation == false)
                {
                    Form frm = new DonateMonthlyDialog();
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            if (BirthDate.ToString("dd/MM") == "23/04")
                MessageBox.Show("Today is Frozen's birthday! He turned " + (currentyear - 1996).ToString() + " years old!\n\nHappy birthday, you potato!", "Happy birthday to Frozen Snow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (BirthDate.ToString("dd/MM") == "17/09")
                MessageBox.Show("Today, KMC turned " + (currentyear - 2015).ToString() + " year(s) old!\n\nHappy birthday, awesome converter!", "Happy birthday to me, Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (BirthDate.ToString("dd/MM") == "31/10")
                MessageBox.Show("Spooky conversions today, huh?", "Happy Halloween!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (BirthDate.ToString("dd/MM") == "05/12")
                MessageBox.Show("Today is Keppy's birthday! He turned " + (currentyear - 1999).ToString() + " years old!\n\nHappy birthday, you potato!", "Happy birthday to Kepperino", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (BirthDate.ToString("dd/MM") == "25/12")
                MessageBox.Show("Oh oh oh, Merry Christmas!", "Happy holidays, and Merry Christmas!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (BirthDate.ToString("dd/MM") == "01/01")
                MessageBox.Show("HAPPY NEW YEAR!", "Finally, " + BirthDate.ToString("yyyy") + " has begun!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Languages
    {
        public static String[] LanguagesAvailable = new String[13] {
            "বাঙালি (Bengali)",
            "English (English)",
            "Eesti (Estonian)",
            "Deutsch (German)",
            "Italiano (Italian)",
            "日本語 (Japanese)",
            "한국어 (Korean)",
            "Pу́сский (Russian)",
            "简化字 (Simplified Chinese, PRC)",
            "Español (Spanish)",
            "ภาษาไทย (Thai)",
            "廣東話 (Traditional Chinese, Hong Kong)",
            "台灣 (Traditional Chinese, Taiwan)",
        };

        public static Bitmap[] LanguagesFlags = new Bitmap[13] {
            Properties.Resources.Bangladesh,
            Properties.Resources.United_Kingdom_Great_Britain_,
            Properties.Resources.Estonia,
            Properties.Resources.Germany,
            Properties.Resources.Italy,
            Properties.Resources.Japan,
            Properties.Resources.South_Korea,
            Properties.Resources.Russian_Federation,
            Properties.Resources.China,
            Properties.Resources.Spain,
            Properties.Resources.Thailand,
            Properties.Resources.China,
            Properties.Resources.China,
        };

        public static String[] LanguagesCodes = new String[13] {
            "bn-BD",
            "en-US",
            "et-EE",
            "de-DE",
            "it-IT",
            "ja-JP",
            "ko-KR",
            "ru-RU",
            "zh-CN",
            "es-ES",
            "th-TH",
            "zh-HK",
            "zh-TW",
        };


        // Language overrides

        public static void ChangeLanguage(string selectedlanguage)
        {
            try
            {
                Properties.Settings.Default.SelectedLang = selectedlanguage;
                Properties.Settings.Default.Save();
            }
            catch (Exception exception)
            {
                KeppyMIDIConverter.ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler("Error", exception.ToString(), 0, 0);
                errordialog.ShowDialog();
            }
        }
    }
}

// Custom exceptions
public class AntiDamageCrash : Exception
{
    public AntiDamageCrash()
    {
    }

    public AntiDamageCrash(string message)
        : base(message)
    {
    }

    public AntiDamageCrash(string message, Exception inner)
        : base(message, inner)
    {
    }
}