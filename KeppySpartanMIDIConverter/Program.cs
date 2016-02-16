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
        static void Main()
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
            Application.Run(new MainWindow());
            GC.KeepAlive(m);
        }
    }
}
