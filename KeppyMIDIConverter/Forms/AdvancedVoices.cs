using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeppyMIDIConverter
{
    public partial class AdvancedVoices : Form
    {
        public static uint BringToFrontMessage;
        public static Mutex m;

        public AdvancedVoices()
        {
            bool ok;
            m = new Mutex(true, "KepMIDIConvAV", out ok);

            if (!ok)
            {
                WinAPI.PostMessage((IntPtr)WinAPI.HWND_BROADCAST, BringToFrontMessage, IntPtr.Zero, IntPtr.Zero);
                System.Media.SystemSounds.Asterisk.Play();
                Close();
            }

            InitializeComponent();
            GC.KeepAlive(m);
        }

        private void AdvancedVoices_Load(object sender, EventArgs e)
        {
            CVList.Columns.Add("Channels", 1, HorizontalAlignment.Left);
            CVList.Columns.Add("Voices", 1, HorizontalAlignment.Left);
            CVList.Columns[0].Tag = 1;
            CVList.Columns[1].Tag = 1;
            CVList_SizeChanged(CVList, new EventArgs());
        }

        private bool Resizing = false;
        private void CVList_SizeChanged(object sender, EventArgs e)
        {
            if (!Resizing)
            {
                Resizing = true;
                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }
            Resizing = false;
        }

        private void CheckVoices_Tick(object sender, EventArgs e)
        {
            CVList.Items[0].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch1.ToString();
            CVList.Items[1].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch2.ToString();
            CVList.Items[2].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch3.ToString();
            CVList.Items[3].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch4.ToString();
            CVList.Items[4].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch5.ToString();
            CVList.Items[5].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch6.ToString();
            CVList.Items[6].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch7.ToString();
            CVList.Items[7].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch8.ToString();
            CVList.Items[8].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch9.ToString();
            CVList.Items[9].SubItems[1].Text = MainWindow.KMCChannelsVoices.chD.ToString();
            CVList.Items[10].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch11.ToString();
            CVList.Items[11].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch12.ToString();
            CVList.Items[12].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch13.ToString();
            CVList.Items[13].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch14.ToString();
            CVList.Items[14].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch15.ToString();
            CVList.Items[15].SubItems[1].Text = MainWindow.KMCChannelsVoices.ch16.ToString();
            System.Threading.Thread.Sleep(1);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        // Snap feature

        private const int SnapDist = 25;

        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta > 0 && delta <= SnapDist;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Left, scn.WorkingArea.Left)) this.Left = scn.WorkingArea.Left;
            if (DoSnap(this.Top, scn.WorkingArea.Top)) this.Top = scn.WorkingArea.Top;
            if (DoSnap(scn.WorkingArea.Right, this.Right)) this.Left = scn.WorkingArea.Right - this.Width;
            if (DoSnap(scn.WorkingArea.Bottom, this.Bottom)) this.Top = scn.WorkingArea.Bottom - this.Height;
        }
    }

    static class WinAPI
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        public const uint HWND_BROADCAST = 0xFFFF;
        public const short SW_RESTORE = 9;
    }
}
