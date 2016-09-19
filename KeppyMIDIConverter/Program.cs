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
using System.Speech.Synthesis;

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
            bool deletencoder = false;
            string encoder = "kmcogg.exe";
            bool ok;
            DeteOldLanguages();
            Mutex m = new Mutex(true, "KepMIDIConv", out ok);
            if (!ok)
            {
                var bytes = new byte[16];
                var rnd = new Random();
                rnd.NextBytes(bytes);
                string originalkmcpath = String.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kmcogg.exe");
                string newkmcoggpath = String.Format("{0}kmcogg{1}.exe", Path.GetTempPath(), Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "").ToString());
                File.Copy(originalkmcpath, newkmcoggpath);
                deletencoder = true;
                encoder = newkmcoggpath;
            }
            try
            {
                int shouldupdate = 1;
                foreach (String s in args)
                {
                    switch (s.Substring(0, 4).ToUpper())
                    {
                        case "/NAU":
                            shouldupdate = 0;
                            break;
                        case "/RLN":
                            Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                            RegistryKey Language = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Languages", true);
                            Language.SetValue("langoverride", "0", Microsoft.Win32.RegistryValueKind.DWord);
                            Language.SetValue("selectedlanguage", "en", Microsoft.Win32.RegistryValueKind.String);
                            Language.Close();
                            MessageBox.Show("Language succesfully restored.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        case "/NOP":
                            System.IO.Stream str = KeppyMIDIConverter.Properties.Resources.no;
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(str);
                            player.PlaySync();
                            return;
                        case "/NTM":
                            MessageBox.Show("Visual styles have been disabled.\n\nKeppy's MIDI Converter is going to use Windows 2000's style.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
                            break;
                        case "/SOI":
                        SOI:
                            System.IO.Stream soi = KeppyMIDIConverter.Properties.Resources.soi;
                            System.Media.SoundPlayer soiplay = new System.Media.SoundPlayer(soi);
                            soiplay.PlaySync();
                            soiplay.Dispose();
                            soi.Dispose();
                            goto SOI;
                            return;
                        case "/KEK":
                        KEK:
                            System.IO.Stream kek = KeppyMIDIConverter.Properties.Resources.kek;
                            System.Media.SoundPlayer kekplay = new System.Media.SoundPlayer(kek);
                            kekplay.PlaySync();
                            kekplay.Dispose();
                            kek.Dispose();
                            goto KEK;
                            return;
                        case "/ZEB":
                            System.IO.Stream merdinskimerdonski = KeppyMIDIConverter.Properties.Resources.merdinskimerdonski;
                            System.Media.SoundPlayer mermerplay = new System.Media.SoundPlayer(merdinskimerdonski);
                            mermerplay.PlaySync();
                            mermerplay.Dispose();
                            merdinskimerdonski.Dispose();
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                            {
                                throw new MerdinskiMerdonski("MAAMMMENONMMENEFFREGAUNCCCAZO");
                            }));
                            break;
                        case "/TTS":
                            SpeechSynthesizer speak = new SpeechSynthesizer();
                            speak.Volume = 100;
                            speak.Rate = 0;
                            speak.SpeakAsync("Hello. Seems like you triggered the Speech Synthesizer secret in Keppy's MIDI Converter. Well, good for you, I guess. Here, take this cookie, you deserve it. And remember, Keppy is awesome. AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                            break;
                        case "/RRJ":
                            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                            return;
                        case "/KSP":
                        case "/KEP":
                            Process.Start("https://plus.google.com/u/0/+RichardForhenson");
                            return;
                        case "/FRZ":
                        case "/FSP":
                            Process.Start("http://frozensnowproductions.com/");
                            return;
                        case "/BMT":
                        case "/BMC":
                            Process.Start("https://plus.google.com/communities/105907289212970966669");
                            return;
                        case "/THX":
                        LOL:
                            MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            goto LOL;
                            return;
                        case "/BGM":
                            MessageBox.Show("Itily", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Process.Start("https://www.youtube.com/channel/UCMLqR6uhl_uANtw-aMO77Mw");
                            return;
                        case "/W98":
                            MessageBox.Show("There are no easter eggs here, go away.");
                            System.Threading.Thread.Sleep(3000);
                            MessageBox.Show("Who knows tho...");
                            return;
                        case "/JAP" :
                            string Emojipasta = @"👌👀👌👀👌👀👌👀👌👀 良いくそ　良( |クそ👌 それ ✔ は 良い👌👌くそだ　 ｽｸﾞ👌👌 ｿ👌 ｺ👌👌👌 すぐ✔そこ ✔✔わたL/\　と 💯 言え｜よ” 💯 コレツイテ　はなすぅ　しゅごぅすぉこぉ 素具祖子 (ｶﾞｯｼｮ: スク”ンコ) んんんんんｎ💯 👌👌 👌ほ王おおおぉぉぉおォォオォオｫｵｵｵｫゥ👌 👌👌 👌 💯 👌 👀👀 👀 👌👌ョイ糞";
                            string Sasukechan = "Omg hai ___^ I’m anon-san and I absolutely luuuv @__@ anime <3 and my fav is naurto!!! Okies so anyways, im going to tell you about the BEST day of my life when I met my hot husband sasuke!! <333333333 OMFGZ HE WAS SOOOOO FREAKIN KAWAII IN PERSON!!! Supa kawaii desu!!!!!!!! ^___________________________________^\nWhen I walked onto Tokyo street =____=I looked up and saw…SASUKE!!!!!!!!!!!!!!! <33333333333333333333333333333333333333333333333333333333333333!!!! “ KONNICHIWA OMGZZZZZZZZZZZZZZZZ SUPA SUPA SUPA KAWAII SASUKE-SAMA!!!!!” I yelled n____n then he turned chibi then un-chibi!! he looked at me [O.O;;;;;;;;;;;] and then he saw how hot I am *___* he grabbed my hand and winked ~_^ then pulled me behind a pocky shop o_o and started to kiss me!!!!!! [OMG!!! HIS TOUNGE TASTED LIKE RAMEN!!! RLY!! >.> <.< >.< (O) (O) (O)] then I saw some baka fat bitch watching us and I could tell she was undressing him with her eyes!!!!!!! [ -___________-;;;;; OMG I COULDN’T BELIEVE IT EITHER!!! (ò_ó) (ò_ó) (ò_ó)] so I yelled “UH UH BAKA NEKO THAT’S MY MAN WHY DON’T YOU GO HOOK UP WITH NARUTO CAUSE SASUKE-SAMA LOVES ME!!! (ò_ó)” then sasuke held me close =^= and said he would only ever love me and kissed me again!!!!!!! ** (O)/ then we went to his apartment and banged all night long and made 42 babies and they all became ninjas!!!!!!!!!!!!!!! Nyaaaaa!!! (^___<) ^______________;;;;;;;;;;;;;;;;";
                            MessageBox.Show(Emojipasta, "お兄ちゃん", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MessageBox.Show(Sasukechan, "サスケちゃん", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            ThreadPool.QueueUserWorkItem(new WaitCallback(ignored =>
                            {
                                throw new IHateWeeabos("NOTICE ME SENPAI~");
                            }));
                            break;
                        default:
                            break;
                    }
                }
                if (shouldupdate == 1)
                    PerformUpdate();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow(args, encoder, deletencoder));
                TriggerDate();
                GC.KeepAlive(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while trying to load the languages!\n\nError:" + ex.ToString(), "Keppy's MIDI Converter - Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void DeteOldLanguages()
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
                RegistryKey Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                if (Settings == null)
                {
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryOptions.None);
                    Settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Keppy's MIDI Converter\\Settings", true);
                }
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
                            Application.ExitThread();
                        }
                    }
                }
                Settings.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not check for updates.\n\nError:\n" + ex.ToString(), "Keppy's MIDI Converter- Can not check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static CultureInfo CultureFunc(CultureInfo ci)
        {
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
            else if (ci.Name == "bn-BD" | ci.Name == "bn-IN")
                return CultureInfo.CreateSpecificCulture("bn");
            else if (ci.Name == "ru-RU")
                return CultureInfo.CreateSpecificCulture("ru");
            // else if (ci.Name == "fr-BE" | ci.Name == "fr-CA" | ci.Name == "fr-FR" | ci.Name == "fr-LU" | ci.Name == "fr-MC" | ci.Name == "fr-CH")
            //    return CultureInfo.CreateSpecificCulture("fr");
            else if (ci.Name == "ko-KR")
                return CultureInfo.CreateSpecificCulture("ko");
            else if (ci.Name == "de-DE" | ci.Name == "de-AT" | ci.Name == "de-CH")
                return CultureInfo.CreateSpecificCulture("de");
            else if (ci.Name == "es-AR" | ci.Name == "es-VE" | ci.Name == "es-BO" | ci.Name == "es-CL" | ci.Name == "es-DO" | ci.Name == "es-EC" | ci.Name == "es-SV" | ci.Name == "es-CO" | ci.Name == "es-CR" | ci.Name == "es-ES" | ci.Name == "es-GT" | ci.Name == "es-HN" | ci.Name == "es-MX" | ci.Name == "es-NI" | ci.Name == "es-PA" | ci.Name == "es-PY" | ci.Name == "es-PE" | ci.Name == "es-PR" | ci.Name == "es-US" | ci.Name == "es-UY")
                return CultureInfo.CreateSpecificCulture("es");
            else if (ci.Name == "ja-JP")
                return CultureInfo.CreateSpecificCulture("ja");
            else // The current language of the UI is not available, fallback to English.
                return CultureInfo.CreateSpecificCulture("en");
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
                            return CultureInfo.CreateSpecificCulture(Language.GetValue("selectedlanguage").ToString());
                        else
                            return CultureInfo.CreateSpecificCulture("en");
                    }
                    else
                    {
                        CultureInfo ci = CultureInfo.CurrentUICulture;
                        return CultureFunc(ci);
                    }
                    Language.Close();
                }
                else
                {
                    CultureInfo ci = CultureInfo.InstalledUICulture;
                    return CultureFunc(ci);
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
            int currentyear = Convert.ToInt32(BirthDate.ToString("yyyy"));
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
}

// Custom exceptions
public class IHateWeeabos : Exception
{
    public IHateWeeabos()
    {
    }

    public IHateWeeabos(string message)
        : base(message)
    {
    }

    public IHateWeeabos(string message, Exception inner)
        : base(message, inner)
    {
    }
}

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

public class MerdinskiMerdonski : Exception
{
    public MerdinskiMerdonski()
    {
    }

    public MerdinskiMerdonski(string message)
        : base(message)
    {
    }

    public MerdinskiMerdonski(string message, Exception inner)
        : base(message, inner)
    {
    }
}