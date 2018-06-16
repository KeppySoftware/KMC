using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    class BootUp
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static EventWaitHandle m;

        public static string OGGEnc = "kmcogg.exe";
        public static string MP3Enc = "kmcmp3.exe";

        public static bool SkipUpdate = false;
        public static bool SkipTrigger = false;
        public static bool CloseApp = false;
        public static string Session = "000000000000000000000";

        private static Random rnd = new Random();

        public static void CheckUp(String[] args)
        {
            bool FailedOnce = false;
            bool Okay;
            ReTest:
            m = new EventWaitHandle(false, EventResetMode.ManualReset, String.Format("KepMIDIConv{0}", Session), out Okay);
            if (!Okay)
            {
                if (!FailedOnce) FailedOnce = true;

                var bytes = new byte[16];
                rnd.NextBytes(bytes);
                Session = Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "").ToString();

                goto ReTest;
            }

            if (FailedOnce)
            {
                try
                {
                    string OriginalPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    Program.OGGEnc = String.Format("{0}kmcogg{1}.exe", Path.GetTempPath(), Session);
                    Program.MP3Enc = String.Format("{0}kmcmp3{1}.exe", Path.GetTempPath(), Session);
                    File.Copy(String.Format("{0}\\{1}", OriginalPath, "kmcogg.exe"), Program.OGGEnc);
                    File.Copy(String.Format("{0}\\{1}", OriginalPath, "kmcmp3.exe"), Program.MP3Enc);

                    Program.DeleteEncoder = true;
                }
                catch { Program.DeleteEncoder = false; }
            }

            Languages.DC = Languages.ReturnCulture(false, null);
            Languages.ChangeLanguage(Languages.ReturnCulture(false, null).Name);
            CheckStartUpArguments(args);

            if (!SkipUpdate) PerformUpdate();
            if (!SkipTrigger) TriggerDate();
        }

        public static void CheckStartUpArguments(String[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLowerInvariant() == "/skipupdate")
                {
                    SkipUpdate = true;
                }
                else if (args[i].ToLowerInvariant() == "/avoidtrigger")
                {
                    SkipTrigger = true;
                }
                else if (args[i].ToLowerInvariant() == "/resetsettings")
                {
                    Properties.Settings.Default.Reset();
                    Properties.Settings.Default.Save();
                    MessageBox.Show(Languages.Parse("SettingsReset"), "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (args[i].ToLowerInvariant() == "/debug") // DO NOT USE IF NOT NEEDED <.<
                {
                    Program.DebugMode = true;
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                    string version = fvi.FileVersion;
                    AllocConsole();
                    Console.Title = "Keppy's MIDI Converter Debug Window";
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Properties.Resources.KMCTitle);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Keppy's MIDI Converter Debug Window - Version " + version);
                    Console.WriteLine("Copyright(C) KaleidonKep99 2013 - " + DateTime.Now.Year.ToString());
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
                }
                else if (args[i].ToLowerInvariant() == "/restorelanguage")
                {
                    Properties.Settings.Default.LangOverride = false;
                    Properties.Settings.Default.SelectedLang = "en-US";
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Language succesfully restored.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (args[i].ToLowerInvariant() == "/triggerdonation")
                {
                    Properties.Settings.Default.NoMoreDonation = false;
                    Properties.Settings.Default.Save();
                    Form frm = new DonateMonthlyDialog
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frm.ShowDialog();
                }
                else if (args[i].ToLowerInvariant().Contains("/"))
                {
                    MessageBox.Show(String.Format(Languages.Parse("InvalidArg"), args[i]), Languages.Parse("ArgumentError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseApp = true;
                }
                else break;
            }
        }

        public static void TriggerDate()
        {
            Random Chance = new Random();
            DateTime BirthDate = DateTime.Now;
            int currentyear = Convert.ToInt32(BirthDate.ToString("yyyy"));

            if (BirthDate.ToString("dd") == "01")
            {
                double days = (DateTime.Now.Date - Properties.Settings.Default.DonationShownWhen).TotalDays;
                if (days > 30 && Properties.Settings.Default.NoMoreDonation == false)
                {
                    Form frm = new DonateMonthlyDialog
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frm.ShowDialog();
                }
            }

            if (BirthDate.ToString("dd/MM") == "17/09")
            {
                MessageBox.Show("Today, KMC turned " + (currentyear - 2015).ToString() + " year(s) old!\n\nHappy birthday, awesome converter!", "Happy birthday to me, Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (BirthDate.ToString("dd/MM") == "05/12")
            {
                MessageBox.Show("Today is Keppy's birthday! He turned " + (currentyear - 1999).ToString() + " years old!\n\nHappy birthday, you potato!", "Happy birthday to Kepperino", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void PerformUpdate()
        {
            if (Properties.Settings.Default.AutoUpdateCheck) BasicFunctions.CheckForUpdates(true);
        }
    }
}
