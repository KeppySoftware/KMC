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
        const int WM_SETREDRAW = 0x0b;

        private void InitializeLanguage()
        {
            CHV1L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 1);
            CHV2L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 2);
            CHV3L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 3);
            CHV4L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 4);
            CHV5L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 5);
            CHV6L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 6);
            CHV7L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 7);
            CHV8L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 8);
            CHV9L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 9);
            CHV10L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 10);
            CHV11L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 11);
            CHV12L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 12);
            CHV13L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 13);
            CHV14L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 14);
            CHV15L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 15);
            CHV16L.Text = String.Format(Languages.Parse("AdvancedVoicesChannel"), 16);
        }

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
            InitializeLanguage();
            GC.KeepAlive(m);
        }

        private void AdvancedVoices_Load(object sender, EventArgs e)
        {
            CPUUsageChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            CPUUsageChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisX.MinorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            CheckCPU.RunWorkerAsync();
        }

        private void CheckVoices_Tick(object sender, EventArgs e)
        {
            Text = String.Format(Languages.Parse("AdvancedVoicesTitle"), RTF.CPUUsage.ToString("0.0"));
            try
            {
                CHV1.Text = MainWindow.KMCStatus.ChannelsVoices[0].ToString();
                CHV2.Text = MainWindow.KMCStatus.ChannelsVoices[1].ToString();
                CHV3.Text = MainWindow.KMCStatus.ChannelsVoices[2].ToString();
                CHV4.Text = MainWindow.KMCStatus.ChannelsVoices[3].ToString();
                CHV5.Text = MainWindow.KMCStatus.ChannelsVoices[4].ToString();
                CHV6.Text = MainWindow.KMCStatus.ChannelsVoices[5].ToString();
                CHV7.Text = MainWindow.KMCStatus.ChannelsVoices[6].ToString();
                CHV8.Text = MainWindow.KMCStatus.ChannelsVoices[7].ToString();
                CHV9.Text = MainWindow.KMCStatus.ChannelsVoices[8].ToString();
                CHV10.Text = MainWindow.KMCStatus.ChannelsVoices[9].ToString();
                CHV11.Text = MainWindow.KMCStatus.ChannelsVoices[10].ToString();
                CHV12.Text = MainWindow.KMCStatus.ChannelsVoices[11].ToString();
                CHV13.Text = MainWindow.KMCStatus.ChannelsVoices[12].ToString();
                CHV14.Text = MainWindow.KMCStatus.ChannelsVoices[13].ToString();
                CHV15.Text = MainWindow.KMCStatus.ChannelsVoices[14].ToString();
                CHV16.Text = MainWindow.KMCStatus.ChannelsVoices[15].ToString();
            }
            catch { }
            System.Threading.Thread.Sleep(1);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m.Close();
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

        private void CheckCPU_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    this.Invoke(new Action(() =>
                    {
                        CPUUsageChart.Series[0].Points.SuspendUpdates();
                        if (RTF.CPUUsage > 100.0f)
                        {
                            CPUUsageChart.ChartAreas[0].AxisY.Maximum = Double.NaN;
                            CPUUsageChart.ChartAreas[0].RecalculateAxesScale();
                        }
                        else
                        {
                            try
                            {
                                if (CPUUsageChart.Series[0].Points.FindMaxByValue().YValues[0] > 100.0) CPUUsageChart.ChartAreas[0].AxisY.Maximum = CPUUsageChart.Series[0].Points.FindMaxByValue().YValues[0];
                                else CPUUsageChart.ChartAreas[0].AxisY.Maximum = 100.0;
                            }
                            catch { CPUUsageChart.ChartAreas[0].AxisY.Maximum = 100.0; }
                        }

                        CPUUsageChart.Series[0].Points.Add(RTF.CPUUsage);

                        while (CPUUsageChart.Series[0].Points.Count > 20) { CPUUsageChart.Series[0].Points.RemoveAt(0); }
                        CPUUsageChart.Series[0].Points.ResumeUpdates();
                    }));
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch { }
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
