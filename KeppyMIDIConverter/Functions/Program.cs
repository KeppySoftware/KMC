using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    static class Program
    {
        private const int timerAccuracy = 10;

        public static bool DebugLang = false;
        public static bool DebugMode = false;
        public static string Who = "Keppy's";
        public static string Title = "MIDI Converter";

        public static string OGGEnc = String.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kmcogg.exe");
        public static string MP3Enc = String.Format("{0}\\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "kmcmp3.exe");
        public static bool DeleteEncoder = false;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        /// 
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                if (Properties.Settings.Default.UpgradeRequired)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpgradeRequired = false;
                    Properties.Settings.Default.Save();
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BootUp.CheckUp(args);

                Application.Run(new MainWindow(args));
            }
            catch (Exception exception)
            {
                ErrorHandler errordialog = new KeppyMIDIConverter.ErrorHandler(Languages.Parse("FatalError"), exception.ToString(), 1, 0);
                errordialog.ShowDialog();
            }
        }
    }
}