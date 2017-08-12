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
            CPUUsageChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            CPUUsageChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisX.MinorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            CPUUsageChart.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;
            CheckCPU.RunWorkerAsync();
        }

        private void CheckVoices_Tick(object sender, EventArgs e)
        {
            Text = String.Format("Active voices - Advanced (CPU usage: {0}%)", RTF.CPUUsage.ToString("0.0"));
            try
            {
                CHV1.Text = MainWindow.KMCChannelsVoices.ch1.ToString();
                CHV2.Text = MainWindow.KMCChannelsVoices.ch2.ToString();
                CHV3.Text = MainWindow.KMCChannelsVoices.ch3.ToString();
                CHV4.Text = MainWindow.KMCChannelsVoices.ch4.ToString();
                CHV5.Text = MainWindow.KMCChannelsVoices.ch5.ToString();
                CHV6.Text = MainWindow.KMCChannelsVoices.ch6.ToString();
                CHV7.Text = MainWindow.KMCChannelsVoices.ch7.ToString();
                CHV8.Text = MainWindow.KMCChannelsVoices.ch8.ToString();
                CHV9.Text = MainWindow.KMCChannelsVoices.ch9.ToString();
                CHV10.Text = MainWindow.KMCChannelsVoices.chD.ToString();
                CHV11.Text = MainWindow.KMCChannelsVoices.ch11.ToString();
                CHV12.Text = MainWindow.KMCChannelsVoices.ch12.ToString();
                CHV13.Text = MainWindow.KMCChannelsVoices.ch13.ToString();
                CHV14.Text = MainWindow.KMCChannelsVoices.ch14.ToString();
                CHV15.Text = MainWindow.KMCChannelsVoices.ch15.ToString();
                CHV16.Text = MainWindow.KMCChannelsVoices.ch16.ToString();
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
                                if (CPUUsageChart.Series[0].Points[0].YValues[0] > 100.0) CPUUsageChart.ChartAreas[0].AxisY.Maximum = CPUUsageChart.Series[0].Points[0].YValues[0];
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
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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
