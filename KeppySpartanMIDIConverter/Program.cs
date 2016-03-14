using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace KeppySpartanMIDIConverter
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
            bool ok;
            Mutex m = new Mutex(true, "KepMIDIConv", out ok);
            if (!ok)
            {
                MessageBox.Show("One instance is enough.", "Keppy's MIDI Converter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Pass arguments to Main Windows
            Application.Run(new MainWindow(args));
            GC.KeepAlive(m);
        }
    }
}
